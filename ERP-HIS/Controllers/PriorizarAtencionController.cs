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

    //JBC : Lista los pacientes a priorizar por -- ListadoPriorizados -- 09-09-2017
    //ARB : El parametro de fecha se eliminó  -- ListadoPriorizados -- 11-09-2017
    public class PriorizarAtencionController : Controller
    {
        // GET: PriorizarAtencion
        public ActionResult Index()
        {
            ViewBag.nombrePage = "Priorizar Atención";
            ViewBag.fecha = DateTime.Now.ToShortDateString();
            return View();
        }

       
        public JsonResult ListadoPriorizados()
        {
            BLPriorizarAtencion bl = new BLPriorizarAtencion();
            List<ELPriorizarAtencion> lstPriorizados = bl.BL_ConsultarPriorizados();
            return Json(lstPriorizados, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoActividades(int nOrdenId)
        {
            BLPriorizarAtencion bl = new BLPriorizarAtencion();
            List<ELPriorizarAtencion> lstPriorizados = bl.BL_ConsultarActividades(nOrdenId);
            return Json(lstPriorizados, JsonRequestBehavior.AllowGet);
        }
    }
}
