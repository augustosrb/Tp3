using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helper;
using System.Web.Mvc;

using ERP_HIS.CustomAttributes;

namespace ERP_HIS.Controllers
{
    [IfNotLoggedActionAttribute]
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~");
        }
    }
}