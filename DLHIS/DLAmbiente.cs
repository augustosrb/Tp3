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
    public class DLAmbiente : DLDBOBase
    {
        String strCon = ConfigurationManager.AppSettings["ERPHISConexion"].ToString();

        SqlCommand cmd = new SqlCommand();

        public List<ELAmbiente> DL_ConsultarAmbiente(int nTipoAmbienteId, int nAmbienteId)
        {
        
            List<ELAmbiente> objListAmbiente = new List<ELAmbiente>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_Buscar_Ambiente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@nTipoAmbienteId", nTipoAmbienteId == 0 ? 0 : nTipoAmbienteId);
                    cmd.Parameters.AddWithValue("@nAmbienteId", nAmbienteId == 0 ? 0 : nAmbienteId);

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        objListAmbiente = (List<ELAmbiente>)ConvertirDataReaderALista<ELAmbiente>(drSQL);
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

            return objListAmbiente;
        }
    }
}
