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
    public class MaestroController : Controller
    {
        // GET: Maestro
        public JsonResult ListadoEstadoClinica()
        {
            BLMaestro bl = new BLMaestro();
            int nTablaId = 5;
            List<ELMaestro> lstMaestro = bl.BL_ConsultarMaestro(nTablaId);
            return Json(lstMaestro, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoTipoDoc()
        {
            BLMaestro bl = new BLMaestro();
            int nTablaId = 3;
            List<ELMaestro> lstMaestro = bl.BL_ConsultarMaestro(nTablaId);
            return Json(lstMaestro, JsonRequestBehavior.AllowGet);
        }
    }
}