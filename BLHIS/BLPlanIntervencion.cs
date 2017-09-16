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
    public class BLPlanIntervencion
    {
        DLPlanIntervencion dlPlanInt = new DLPlanIntervencion();

        private ResponseModel rm = new ResponseModel();

        public List<ELPlanIntervencion> BL_ConsultarPlan(DateTime dtFecha, int nTipoInt)
        {
            List<ELPlanIntervencion> lstPlanIntervencion = new List<ELPlanIntervencion>();
            try
            {
                lstPlanIntervencion = dlPlanInt.DL_ConsultarPlan(dtFecha, nTipoInt);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return lstPlanIntervencion;
        }

        public string BL_Insertar_RequisitoPlan(int nOrdenIntervencionId, string cRequisitoDesc, int nCantidad)
        {

            return dlPlanInt.DL_Insertar_RequisitoPlan(nOrdenIntervencionId, cRequisitoDesc, nCantidad);
        }
    }
}
