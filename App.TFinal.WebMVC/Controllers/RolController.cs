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
    public class RolController : BaseController
    {
        public RolController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var lista = await _unit.Rols.Listar();
            return View(lista);
        }

        // GET: Rol/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unit.Rols.Obtener(id));
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
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
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.Rols.Obtener(id));
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

        // GET: Rol/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
