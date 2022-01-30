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
    //[ErrorActionFilter]
    [RoutePrefix("Rol")]
    public class RolController : BaseController
    {
        public RolController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }
        // GET: Usuario
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var lista = await _unit.Rols.Listar();
            return View(lista);
        }

        // GET: Rol/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            //return View(await _unit.Rols.Obtener(id));
            return PartialView("_Details", await _unit.Rols.Obtener(id));
        }

        // GET: Rol/Create
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Rol/Create
        [HttpPost]
        public async Task<ActionResult> Create(Rol rol)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    await _unit.Rols.Agregar(rol);
                    return RedirectToAction("Index");
                }
                return View(rol);
            }
            catch
            {
                return View(rol);
            }
        }

        // GET: Rol/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            //return View(await _unit.Rols.Obtener(id));
            return PartialView("_Edit", await _unit.Rols.Obtener(id));
        }

        // POST: Rol/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Rol rol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unit.Rols.Modificar(rol);
                    return RedirectToAction("Index");
                }
                return View(rol);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: Rol/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            //return View(await _unit.Rols.Obtener(id));
            return PartialView("_Delete", await _unit.Rols.Obtener(id));
        }

        // POST: Rol/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                if ((await _unit.Rols.Eliminar(id)) != 0) return RedirectToAction("Index");

                return View(await _unit.Rols.Obtener(id));
            }
            catch
            {
                return View(await _unit.Rols.Obtener(id));
            }
        }
        
    }
}
