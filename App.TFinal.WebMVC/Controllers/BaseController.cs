using App.TFinal.WebMVC.ActionFilters;
using App.TFinal.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.TFinal.WebMVC.Controllers
{
    [ErrorActionFilter]
    [Authorize]
    public class BaseController : Controller
    {
        protected IUnitOfWork _unit;
        protected ILog _log;
        public BaseController(ILog log, IUnitOfWork unit)
        {
            _unit = unit;
            _log = log;
        }
    }
}