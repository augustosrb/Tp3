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
    public class AmbienteController : Controller
    {
        public JsonResult ListadoSede()
        {
            BLAmbiente bl = new BLAmbiente();
            int nTipoAmbienteId = 1;
            int nAmbienteId = 0;
            List<ELAmbiente> lstMaestro = bl.BL_ConsultarAmbiente(nTipoAmbienteId,nAmbienteId);
            return Json(lstMaestro, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoZona(int nAmbienteId)
        {
            BLAmbiente bl = new BLAmbiente();
            int nTipoAmbienteId = 2;
            List<ELAmbiente> lstMaestro = bl.BL_ConsultarAmbiente(nTipoAmbienteId,nAmbienteId);
            return Json(lstMaestro, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoSala(int nAmbienteId)
        {
            BLAmbiente bl = new BLAmbiente();
            int nTipoAmbienteId = 3;
            List<ELAmbiente> lstMaestro = bl.BL_ConsultarAmbiente(nTipoAmbienteId,nAmbienteId);
            return Json(lstMaestro, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListadoHabitacionRep(int nAmbienteId)
        {
            BLAmbiente bl = new BLAmbiente();
            int nTipoAmbienteId = 4;
            List<ELAmbiente> lstMaestro = bl.BL_ConsultarAmbiente(nTipoAmbienteId,nAmbienteId);
            return Json(lstMaestro, JsonRequestBehavior.AllowGet);
        }
    }
}