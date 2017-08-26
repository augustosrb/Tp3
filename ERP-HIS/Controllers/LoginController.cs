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
    [IfLoggedActionAttribute]
    public class LoginController : Controller
    {

        private BLUsuario um = new BLUsuario();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult Acceder(string Login, string Password)
        {
            if (ModelState.IsValid)
            {
                return Json(um.Acceder(new ELUsuario { Login = Login, Password = Password }));
            }
            else
            {
                return Json(new { response = false, message = "Ocurrio un error con la validación del Formulario." });
            }
        }


    }
}