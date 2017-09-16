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
    public class BLMaestro
    {
        DLMaestro dlOrden = new DLMaestro();

        private ResponseModel rm = new ResponseModel();

        public List<ELMaestro> BL_ConsultarMaestro(int nTablaId)
        {
            List<ELMaestro> maestro = new List<ELMaestro>();
            try
            {
                maestro = dlOrden.DL_ConsultarMaestro(nTablaId);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return maestro;
        }
    }
}
