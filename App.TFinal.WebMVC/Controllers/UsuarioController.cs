using App.TFinal.WebMVC.Models;
using App.TFinal.Models;
using App.TFinal.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.TFinal.WebMVC.Controllers
{
    public class UsuarioController :  BaseController
    {
        public UsuarioController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }


        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var lista = await _unit.Usuarios.Listar();
            return View(lista);
        }

        // GET: Usuario/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unit.Usuarios.Obtener(id));
        }

        // GET: Usuario/Create
        public async Task<ActionResult> Create()
        {

            ViewBag.ListaTipoDoc = await _unit.Documentos.Listar();

            return View("Create", new Usuario { Estado = true, IdRol = 1, Sexo = "V" });
           
        }

        // POST: Usuario/Create
        [HttpPost]
        public async Task<ActionResult> Create(Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //await _unit.Usuarios.Agregar(usuario);
                    var mensajeRetorno = await _unit.Usuarios.CrearUsuario(usuario);
                    if (mensajeRetorno.Objeto != null) return RedirectToAction("Index", "Home");
                    else
                    {
                        ViewBag.ErrorMessage = mensajeRetorno.Mensaje;
                        return View(usuario);
                    }
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.Usuarios.Obtener(id));
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unit.Usuarios.Modificar(usuario);
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                if ((await _unit.Usuarios.Eliminar(id)) != 0) return RedirectToAction("Index");

                return View(await _unit.Usuarios.Obtener(id));
            }
            catch
            {
                return View(await _unit.Usuarios.Obtener(id));
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View("Login2",new UserViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            Usuario usuarioValido = await _unit.Usuarios.ValidarUsuario(user.Email, user.Password);

            if (usuarioValido == null)
            {
                ModelState.AddModelError("Error", "Email o Password inválido");
                return View(user);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, usuarioValido.Email),
                new Claim(ClaimTypes.Role, "ADM"),
                new Claim(ClaimTypes.Name, $"{usuarioValido.Nombres} {usuarioValido.Apellidos}"),
                new Claim(ClaimTypes.NameIdentifier, usuarioValido.Id.ToString())
            }, "ApplicationCookie");

            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignIn(identity);

            return RedirectToLocal(user.ReturnUrl);
        }
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("Login", "Usuario");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
