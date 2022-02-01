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
    [RoutePrefix("EstadoPelicula")]
    public class EstadoPeliculaController : BaseController
    {
        public EstadoPeliculaController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }
        // GET: Usuario
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var lista = await _unit.EstadoPeliculas.Listar();
            return View(lista);
        }

        // GET: Rol/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            //return View(await _unit.Documentos.Obtener(id));
            return PartialView("_Details", await _unit.EstadoPeliculas.Obtener(id));
        }

        // GET: Rol/Create
        [HttpGet]
        public ActionResult Create()
        {
            //return View();
            return PartialView("_Create");
        }

        // POST: Rol/Create
        [HttpPost]
        public async Task<ActionResult> Create(EstadoPelicula estadopelicula)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    await _unit.EstadoPeliculas.Agregar(estadopelicula);
                    return RedirectToAction("Index");
                }
                return View(estadopelicula);
            }
            catch
            {
                return View(estadopelicula);
            }
        }

        // GET: Rol/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            //return View(await _unit.Documentos.Obtener(id));
            return PartialView("_Edit", await _unit.EstadoPeliculas.Obtener(id));
        }

        // POST: Rol/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(EstadoPelicula estadopelicula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unit.EstadoPeliculas.Modificar(estadopelicula);
                    return RedirectToAction("Index");
                }
                return View(estadopelicula);
            }
            catch
            {
                return View();
            }
        }

        // GET: Rol/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            //return View();
            return PartialView("_Delete", await _unit.EstadoPeliculas.Obtener(id));
        }

        // POST: Rol/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                if ((await _unit.EstadoPeliculas.Eliminar(id)) != 0) return RedirectToAction("Index");

                return View(await _unit.EstadoPeliculas.Obtener(id));
            }
            catch
            {
                return View(await _unit.EstadoPeliculas.Obtener(id));
            }
        }

    }
}
