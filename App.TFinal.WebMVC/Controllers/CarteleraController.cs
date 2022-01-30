using App.TFinal.Models;
using App.TFinal.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.TFinal.WebMVC.Controllers
{

    //public class PeliculaController : BaseController
    public class CarteleraController : BaseController
    {
        // GET: Cartelera

        public CarteleraController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }


        public async Task<ActionResult> Index()
        {
            var lista = await _unit.Carteleras.Listar();
            return View(lista);
        }

        // GET: Pelicula/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unit.Carteleras.Obtener(id));
        }

        // GET: Cartelera/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cartelera/Create
        [HttpPost]
        public async Task<ActionResult> Create(Cartelera cartelera)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //await _unit.Usuarios.Agregar(usuario);
                    var mensajeRetorno = await _unit.Carteleras.CrearCartelera(cartelera);
                    //     if (mensajeRetorno.Objeto != null) return RedirectToAction("Index" ,  "Home");
                    if (mensajeRetorno.Objeto != null) return RedirectToAction("Index");
                    else
                    {
                        ViewBag.ErrorMessage = mensajeRetorno.Mensaje;
                        return View(cartelera);
                    }
                }
                return View(cartelera);
            }
            catch
            {
                return View(cartelera);
            }
        }


        // GET: Cartelera/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.Carteleras.Obtener(id));
        }

        // POST: Pelicula/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Cartelera cartelera)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unit.Carteleras.Modificar(cartelera);
                    return RedirectToAction("Index");
                }
                return View(cartelera);
            }
            catch
            {
                return View();
            }
        }


        // GET: Cartelera/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cartelera/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                if ((await _unit.Carteleras.Eliminar(id)) != 0) return RedirectToAction("Index");

                return View(await _unit.Carteleras.Obtener(id));
            }
            catch
            {
                return View(await _unit.Carteleras.Obtener(id));
            }
        }
    }
}
