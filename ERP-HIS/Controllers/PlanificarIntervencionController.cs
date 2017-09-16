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
    public class PlanificarIntervencionController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.nombrePage = "Planificar Intervención";
            return View();
        }

        public JsonResult ListadoPlan(DateTime dtFecha, int nTipoInt)
        {
            BLPlanIntervencion bl = new BLPlanIntervencion();
            List<ELPlanIntervencion> lstPlanInt = bl.BL_ConsultarPlan(dtFecha, nTipoInt);
            return Json(lstPlanInt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoTipoInt()
        {
            BLTipoIntervencion bl = new BLTipoIntervencion();
            List<ELTipoIntervencion> lstTiposInt = bl.BL_ConsultarTipoIntervencion();
            return Json(lstTiposInt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertarReqPlan(int nOrdenIntervencionId, string cRequisitoDesc, int nCantidad)
        {
            BLPlanIntervencion bl = new BLPlanIntervencion();
            string res = bl.BL_Insertar_RequisitoPlan(nOrdenIntervencionId, cRequisitoDesc, nCantidad);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}