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

        public JsonResult buscarPaciente(string dni)
        {
            BLOrden bl = new BLOrden();
            ELPaciente objBuscarPaciente = bl.BL_BuscarPaciente(dni);
            return Json(objBuscarPaciente, JsonRequestBehavior.AllowGet);
        }



        public JsonResult buscarOrdenesMedicas(string dni)
        {
            BLOrden bl = new BLOrden();
            List<ELOrdenMedica> lstOrdenMedica = bl.BL_ConsultarOM(dni);
            return Json(lstOrdenMedica, JsonRequestBehavior.AllowGet);
        }

        public JsonResult buscarOrdenesMedicas1(string dni)
        {
            BLOrden bl = new BLOrden();
            List<ELOrdenMedica> lstOrdenMedica = bl.BL_ConsultarOM(dni);
            return Json(lstOrdenMedica, JsonRequestBehavior.AllowGet);
        }



    }
}