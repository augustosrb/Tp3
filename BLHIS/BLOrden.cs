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
    public class BLOrden
    {
        DLOrden dlOrden = new DLOrden();

        private ResponseModel rm = new ResponseModel();

        public List<ELOrdenIntervencion> BL_ConsultarOI()
        {
            List<ELOrdenIntervencion> ordenIntervencion = new List<ELOrdenIntervencion>();
            try
            {
                ordenIntervencion = dlOrden.DL_ConsultarOI();
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return ordenIntervencion;
        }

        public List<ELOrdenMedica> BL_ConsultarOM(string dni)
        {
            List<ELOrdenMedica> ordenIntervencion = new List<ELOrdenMedica>();
            try
            {
                ordenIntervencion = dlOrden.DL_BuscarOrdenMedica(dni);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return ordenIntervencion;
        }

        public ELPaciente BL_BuscarPaciente(string dni)
        {
            ELPaciente paciente = new ELPaciente();
            try
            {
                paciente = dlOrden.DL_BuscarPaciente(dni);
                paciente.lstOrdenMedica = dlOrden.DL_BuscarOrdenMedica(dni);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return paciente;
        }

        public ELPaciente BL_BuscarRequisitos(int tipointervencion)
        {
            ELPaciente paciente = new ELPaciente();
            try
            {
                paciente.lstRequisitos = dlOrden.DL_BuscarRequisitos(tipointervencion);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return paciente;
        }
    }
}
