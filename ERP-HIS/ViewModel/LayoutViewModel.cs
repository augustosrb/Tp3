using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELHIS;
using Helper;
using BLHIS;

namespace ERP_HIS.ViewModel
{
    public class LayoutViewModel
    {
        public static ELUsuario ObtenerUsuarioLogeado() 
        {
            return new BLUsuario().Obtener(SessionHelper.GetUser());
        }
    }
}