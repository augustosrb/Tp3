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
    public class BLPriorizarAtencion
    {
        DLPriorizarAtencion dlPriori = new DLPriorizarAtencion();

        private ResponseModel rm = new ResponseModel();

        public List<ELPriorizarAtencion> BL_ConsultarPriorizados()
        {
            List<ELPriorizarAtencion> lstPriorizados = new List<ELPriorizarAtencion>();
            try
            {
                lstPriorizados = dlPriori.DL_ConsultarPriorizados();
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return lstPriorizados;
        }

        public List<ELPriorizarAtencion> BL_ConsultarActividades(int nOrdenId)
        {
            List<ELPriorizarAtencion> lstPriorizados = new List<ELPriorizarAtencion>();
            try
            {
                lstPriorizados = dlPriori.DL_ConsultarActividades(nOrdenId);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return lstPriorizados;
        }

        
    }
}
