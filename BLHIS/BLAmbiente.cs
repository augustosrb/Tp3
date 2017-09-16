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
    public class BLAmbiente
    {
        DLAmbiente dlAmbiente = new DLAmbiente();

        private ResponseModel rm = new ResponseModel();

        public List<ELAmbiente> BL_ConsultarAmbiente(int nTipoAmbienteId, int nAmbienteId)
        {
            List<ELAmbiente> lstAmbiente = new List<ELAmbiente>();
            try
            {
                lstAmbiente = dlAmbiente.DL_ConsultarAmbiente(nTipoAmbienteId,nAmbienteId);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return lstAmbiente;
        }
    }
}
