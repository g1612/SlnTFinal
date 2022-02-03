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
    public class PeliculaController : BaseController
    {

        public PeliculaController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }

        // GET: Pelicula
        public async Task<ActionResult> Index()
        {
            var lista = await _unit.Peliculas.ListarPeliculas();
            return View(lista);



        }

        // GET: Pelicula/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //return View(await _unit.Peliculas.Obtener(id));
            return PartialView("_Details", await _unit.Peliculas.Obtener(id));

        }

        // GET: Pelicula/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }


        // POST: Pelicula/Create
        [HttpPost]
        public async Task<ActionResult> Create(Pelicula pelicula)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //await _unit.Usuarios.Agregar(usuario);
                    var mensajeRetorno = await _unit.Peliculas.CrearPelicula(pelicula);
                    //     if (mensajeRetorno.Objeto != null) return RedirectToAction("Index" ,  "Home");
                    if (mensajeRetorno.Objeto != null) return RedirectToAction("Index");
                    else
                    {
                        ViewBag.ErrorMessage = mensajeRetorno.Mensaje;
                        return View(pelicula);
                    }
                }
                return View(pelicula);
            }
            catch
            {
                return View(pelicula);
            }
        }

        // GET: Pelicula/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //    return View(await _unit.Peliculas.Obtener(id));
            return PartialView("_Edit", await _unit.Peliculas.Obtener(id));
        }

        // POST: Pelicula/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Pelicula pelicula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unit.Peliculas.Modificar(pelicula);
                    return RedirectToAction("Index");
                }
                return View(pelicula);
            }
            catch
            {
                return View();
            }
        }

        // GET: Pelicula/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return PartialView("_Delete", await _unit.Peliculas.Obtener(id));
        }

        // POST: Pelicula/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                if ((await _unit.Peliculas.Eliminar(id)) != 0) return RedirectToAction("Index");

                return View(await _unit.Peliculas.Obtener(id));
            }
            catch
            {
                return View(await _unit.Peliculas.Obtener(id));
            }
        }
    }
}
