using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELHIS;
using DLHIS;
using Helper;

namespace BLHIS
{
    public class BLTipoIntervencion
    {
        DLTipoIntervencion dlTipoIntervencion = new DLTipoIntervencion();

        private ResponseModel rm = new ResponseModel();

        public List<ELTipoIntervencion> BL_ConsultarTipoIntervencion()
        {
            List<ELTipoIntervencion> lstTipoIntervencion = new List<ELTipoIntervencion>();
            try
            {
                lstTipoIntervencion = dlTipoIntervencion.DL_ConsultarTipoInternvencion();
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return lstTipoIntervencion;
        }
    }
}
