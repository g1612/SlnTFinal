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
    public class BDGXXXXENTI1Controller : BaseController
    {
        // GET: Cartelera

        public BDGXXXXENTI1Controller(ILog log, IUnitOfWork unit) : base(log, unit)
        {
            //_unit = unit;
        }


        public async Task<ActionResult> Index(string id)
        {
            //var lstTipoCategoria = await _unit.BDGXXXXENTI1S.ListaTE();
            //ViewBag.BDGXXXXENTI1S = lstTipoCategoria;

            //ViewData["BDGXXXXENTI1S"] = lstTipoCategoria;
            ////ViewData.Add("TipoCategorias", lstTipoCategoria);

            ////var lstCategorias = await _unit.ListaPeliculas.ListarPeliculas();
            ////return View(lstCategorias.AsEnumerable());

            string id1 = "0002";
            var lista = await _unit.BDGXXXXENTI1S.ListarBDGXXXXENTI1(id1,"");
            return View(lista);
        }

        // GET: Pelicula/Details/5
        public async Task<ActionResult> Details(BDGXXXXENTI1 bdgxxxxenti1, string id)
        {
            string val = " where e1_codent='" + id + "'";

            return PartialView("_Details", await _unit.BDGXXXXENTI1S.BuscarPorId(bdgxxxxenti1, val));

        }


        // GET: Cartelera/Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        // POST: Cartelera/Create
        [HttpPost]
        public async Task<ActionResult> Create(BDGXXXXENTI1 bdgxxxxenti1)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //await _unit.Usuarios.Agregar(usuario);
                    var mensajeRetorno = await _unit.BDGXXXXENTI1S.CrearBDGXXXXENTI1(bdgxxxxenti1);
                    //     if (mensajeRetorno.Objeto != null) return RedirectToAction("Index" ,  "Home");
                    if (mensajeRetorno.Objeto != null) return RedirectToAction("Index");
                    else
                    {
                        ViewBag.ErrorMessage = mensajeRetorno.Mensaje;
                        return View(bdgxxxxenti1);
                    }
                }
                return View(bdgxxxxenti1);
            }
            catch
            {
                return View(bdgxxxxenti1);
            }
        }


        // GET: Cartelera/Edit/5
        public async Task<ActionResult> Edit(BDGXXXXENTI1 bdgxxxxenti1,string id)
        {
            //    return View(await _unit.Peliculas.Obtener(id));
            string val =" where e1_codent='"+ id +"'";

            return PartialView("_Edit", await _unit.BDGXXXXENTI1S.BuscarPorId(bdgxxxxenti1,val));
        }

        // POST: Pelicula/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(BDGXXXXENTI1 bdgxxxxenti1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unit.BDGXXXXENTI1S.ModificarBDGXXXXENTI1(bdgxxxxenti1);
                    return RedirectToAction("Index");
                }
                return View(bdgxxxxenti1);
            }
            catch
            {
                return View();
            }
        }


        // GET: Cartelera/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            return PartialView("_Delete", await _unit.BDGXXXXENTI1S.Obtener(id));
            // return PartialView("_Delete", await _unit.BDGXXXXENTI1S.Eliminar(id));

            //if ((await _unit.BDGXXXXENTI1S.Eliminar(id)) != 0) return RedirectToAction("Index");

        }

        // POST: Cartelera/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletePost(string id)
        {
            try
            {
                if ((await _unit.BDGXXXXENTI1S.Eliminar(id)) != 0) return RedirectToAction("Index");

                return View(await _unit.BDGXXXXENTI1S.Obtener(id));
            }
            catch
            {
                return View(await _unit.BDGXXXXENTI1S.Obtener(id));
            }
        }

        public ActionResult CorporationRegistrationPg1(string id)
        {
            return View( _unit.BDGXXXXENTI1S.Obtener(id));
        }

        public ActionResult CorporationRegistrationPg2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CorporationRegistrationPg2(int selectedTab)
        {
            ViewBag.SelectedTab = selectedTab;
            return View();
        }
    }
}
