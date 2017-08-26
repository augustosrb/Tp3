using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLHIS;
using ELHIS;
using Helper;
using ERP_HIS.CustomAttributes;

namespace ERP_HIS.Controllers
{
    public class OIntervencionController : Controller
    {
        private BLOrden um = new BLOrden();

        // GET: OIntervencion
        public ActionResult Index()
        {
            ViewBag.nombrePage = "Gestionar Orden de Intervención";
            return View();
        }

        public ActionResult RegistrarOI()
        {
            ViewBag.nombrePage = "Registrar Orden de Intervención";
            return View();
        }

        public JsonResult ListadoOrden()
        {
            BLOrden bl = new BLOrden();
            List<ELOrdenIntervencion> lstOrdenIntervencion = bl.BL_ConsultarOI();
            return Json(lstOrdenIntervencion, JsonRequestBehavior.AllowGet);
        }



        [OnlyAjaxRequestAttribute]
        public PartialViewResult ConsultarOI()
        {
             return PartialView("~/views/ointervencion/consultaroi.cshtml", um.BL_ConsultarOI());
        }

        [OnlyAjaxRequestAttribute]
        public PartialViewResult BuscarPaciente(string dni)
        {
            return PartialView("~/views/ointervencion/buscarpaciente.cshtml", um.BL_BuscarPaciente(dni));
        }

        [OnlyAjaxRequestAttribute]
        public PartialViewResult BuscarRequisitos(int inter)
        {
            return PartialView("~/views/ointervencion/buscarrequisitos.cshtml", um.BL_BuscarRequisitos(inter));
        }

        [OnlyAjaxRequestAttribute]
        public PartialViewResult GuardarOI()
        {
            return PartialView("~/views/ointervencion/buscarrequisitos.cshtml");
        }
    }
}