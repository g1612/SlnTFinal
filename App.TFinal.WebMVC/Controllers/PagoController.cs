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

    //   public class PeliculaController : BaseController
    public class PagoController : BaseController
    {
        // GET: Pago
        public PagoController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }

        // GET: Pelicula
        public async Task<ActionResult> Index()
        {
            var lista = await _unit.Pagos.ListaPagos();
            return View(lista);
        }

        // GET: Pago/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pago/Create
        public async Task<ActionResult> Create(int id)
        {
            var lstCartelera = await _unit.Pagos.ListaCartelera(id);
            ViewBag.ListaCartelera = lstCartelera;
            ViewData["ListaCartelera"] = lstCartelera;

            //var lstTipoCategoria = await _unit.ListaPeliculas.BuscarPorId(id);
            //ViewBag.ListaPeliculas = lstTipoCategoria;

            //ViewData["DatPelicula"] = lstTipoCategoria;

           return PartialView("_Create");
            //return View("Create");

            //await _unit.Pagos.insert(id);

            //return PartialView("_Create");
        }

        // POST: Pago/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
               

                // TODO: Add insert logic here
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pago/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pago/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pago/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pago/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ListaCartelera(int id)
        {
            var lstCartelera = await _unit.Pagos.ListaCartelera(id);
            ViewBag.ListaCartelera = lstCartelera;
            ViewData["ListaCartelera"] = lstCartelera;

            //var lstTipoCategoria = await _unit.ListaPeliculas.BuscarPorId(id);
            //ViewBag.ListaPeliculas = lstTipoCategoria;

            //ViewData["DatPelicula"] = lstTipoCategoria;

            return PartialView("_Create", await _unit.Pagos.ListaCartelera(id));
        }
    }
}
