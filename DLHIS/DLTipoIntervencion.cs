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
    public class DLTipoIntervencion : DLDBOBase
    {
        String strCon = ConfigurationManager.AppSettings["ERPHISConexion"].ToString();
        SqlCommand cmd = new SqlCommand();

        public List<ELTipoIntervencion> DL_ConsultarTipoInternvencion()
        {
            List<ELTipoIntervencion> lstTipoIntervencion = new List<ELTipoIntervencion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_Buscar_Tipo_Intervencion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        lstTipoIntervencion = (List<ELTipoIntervencion>)ConvertirDataReaderALista<ELTipoIntervencion>(drSQL);
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

            return lstTipoIntervencion;
        }
    }
}