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
    public class DocumentoController : BaseController
    {
        public DocumentoController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var lista = await _unit.Documentos.Listar();
            return View(lista);
        }

        // GET: Rol/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _unit.Documentos.Obtener(id));
        }

        // GET: Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rol/Create
        [HttpPost]
        public async Task<ActionResult> Create(Documento documento)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    await _unit.Documentos.Agregar(documento);
                    return RedirectToAction("Index");
                }
                return View(documento);
            }
            catch
            {
                return View(documento);
            }
        }

        // GET: Rol/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _unit.Documentos.Obtener(id));
        }

        // POST: Rol/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Documento documento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unit.Documentos.Modificar(documento);
                    return RedirectToAction("Index");
                }
                return View(documento);
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
                if ((await _unit.Documentos.Eliminar(id)) != 0) return RedirectToAction("Index");

                return View(await _unit.Documentos.Obtener(id));
            }
            catch
            {
                return View(await _unit.Documentos.Obtener(id));
            }
        }

    }
}
