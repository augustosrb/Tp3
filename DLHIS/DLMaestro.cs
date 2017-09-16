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
    public class DLMaestro : DLDBOBase
    {
        String strCon = ConfigurationManager.AppSettings["ERPHISConexion"].ToString();

        SqlCommand cmd = new SqlCommand();

        public List<ELMaestro> DL_ConsultarMaestro(int nTablaId)
        {

            List<ELMaestro> objListMaestro = new List<ELMaestro>();
  
            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GENERAL.USP_Buscar_Maestro";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@nTablaId", nTablaId == 0 ? 0 : nTablaId);


                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        objListMaestro = (List<ELMaestro>)ConvertirDataReaderALista<ELMaestro>(drSQL);
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

            return objListMaestro;
        }
    }
}
