using App.TFinal.Repositories;
using App.TFinal.Repositories.Dapper;
using App.TFinal.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace App.TFinal.WebMVC.Controllers
{
    //[AllowAnonymous]
    public class HomeController : Controller
    {
        private IUnitOfWork _unit = new VentasUnitOfWork("");

        public ActionResult Index()
        {

            //var objUsuarios = _unit.Usuarios.BuscarPorId(1);
            return View();
        }

        public ActionResult ObtenerRol()
        {
            //VERIFICACION
            var obj = _unit.Rols.BuscarPorId(1);
            var objUsuarios = _unit.Usuarios.BuscarPorId(1);
                      return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}