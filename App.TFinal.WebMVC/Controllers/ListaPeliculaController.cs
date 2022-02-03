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
    public class ListaPeliculaController : BaseController
    {

        public ListaPeliculaController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }
        public async Task<ActionResult> Index()
        {
            var lstTipoCategoria = await _unit.ListaPeliculas.ListarPeliculas();
            ViewBag.ListaPeliculas = lstTipoCategoria;

            ViewData["ListaPeliculas"] = lstTipoCategoria;
            //ViewData.Add("TipoCategorias", lstTipoCategoria);

            var lstCategorias = await _unit.ListaPeliculas.ListarPeliculas();
            return View(lstCategorias.AsEnumerable());
           // return View();
        }

        private ActionResult View(Func<List<ListaPelicula>> toList)
        {
            throw new NotImplementedException();
        }


        // GET: ListaPelicula/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ListaPelicula/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaPelicula/Create
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

        // GET: ListaPelicula/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ListaPelicula/Edit/5
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

        // GET: ListaPelicula/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ListaPelicula/Delete/5
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
    }
}
