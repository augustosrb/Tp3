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
    public class ActualizarPostOpeController : Controller
    {
        // GET: ActualizarPostOpe
        public ActionResult Index()
        {
            ViewBag.nombrePage = "Actualizar Estado Post Operatorio";
            return View();
        }


        public JsonResult buscarPacienteHistoria(string hc)
        {
            BLOrden bl = new BLOrden();
            ELPaciente objBuscarPaciente = bl.BL_BuscarPaciente("", hc);
            return Json(objBuscarPaciente, JsonRequestBehavior.AllowGet);
        }


        public JsonResult registrarPostOpe(int nHistoriaClinica, string cSubjetivo, string cApreciacion)
        {
            BLOrden bl = new BLOrden();
            string res = bl.BL_Insertar_SOAP(nHistoriaClinica, cSubjetivo, cApreciacion);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}