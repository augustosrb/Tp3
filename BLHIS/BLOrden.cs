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

        public List<ELOrdenIntervencion> BL_ConsultarOI(string documento, int estado)
        {
            List<ELOrdenIntervencion> ordenIntervencion = new List<ELOrdenIntervencion>();
            try
            {
                ordenIntervencion = dlOrden.DL_ConsultarOI(documento, estado);
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
                ordenIntervencion = dlOrden.DL_ConsultarOM(dni);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return ordenIntervencion;
        }

        public ELPaciente BL_BuscarPaciente(string dni, string hc)
        {
            ELPaciente paciente = new ELPaciente();
            try
            {
                paciente = dlOrden.DL_BuscarPaciente(dni,hc);
                paciente.lstOrdenMedica = dlOrden.DL_ConsultarOM(dni);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return paciente;
        }

        public string BL_Insertar_SOAP(int nHistoriaClinica, string cSubjetivo, string cApreciacion)
        {
            //ELPaciente paciente = new ELPaciente();
            try
            {
                dlOrden.DL_Insertar_SOAP(nHistoriaClinica, cSubjetivo, cApreciacion);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return "Registro Exitoso";
        }

        public string BL_registrarOrden(int habreposo, int nOrdenMedId)
        {
            //ELPaciente paciente = new ELPaciente();
            try
            {
                dlOrden.DL_registrarOrden(habreposo, nOrdenMedId);
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return "Registro Exitoso";
        }


    }
}
