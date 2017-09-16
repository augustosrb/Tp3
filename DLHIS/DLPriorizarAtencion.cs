using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ELHIS;
using Helper;

namespace DLHIS
{
    public class DLPriorizarAtencion : DLDBOBase
    {
        String strCon = ConfigurationManager.AppSettings["ERPHISConexion"].ToString();
        SqlCommand cmd = new SqlCommand();

        public List<ELPriorizarAtencion> DL_ConsultarPriorizados()
        {
            List<ELPriorizarAtencion> lstPriorizados = new List<ELPriorizarAtencion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_Consultar_Pacientes_Priorizados";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        lstPriorizados = (List<ELPriorizarAtencion>)ConvertirDataReaderALista<ELPriorizarAtencion>(drSQL);
                    }
                }
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }

            return lstPriorizados;
        }

        public List<ELPriorizarAtencion> DL_ConsultarActividades(int nOrdenId)
        {
            List<ELPriorizarAtencion> lstPriorizados = new List<ELPriorizarAtencion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_MostrarInfoPaciente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    pAddParameter(cmd, "@nOrdenIntervencionId", nOrdenId, SqlDbType.Int);

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        lstPriorizados = (List<ELPriorizarAtencion>)ConvertirDataReaderALista<ELPriorizarAtencion>(drSQL);
                    }
                }
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }

            return lstPriorizados;
        }
    }
}
