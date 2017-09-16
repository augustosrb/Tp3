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
    public class DLPlanIntervencion : DLDBOBase
    {
        String strCon = ConfigurationManager.AppSettings["ERPHISConexion"].ToString();
        SqlCommand cmd = new SqlCommand();

        public List<ELPlanIntervencion> DL_ConsultarPlan(DateTime dtFecha, int nTipoInt)
        {
            List<ELPlanIntervencion> lstPlanIntervencion = new List<ELPlanIntervencion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_Buscar_Plan";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    pAddParameter(cmd, "@dtFecha", dtFecha, SqlDbType.Date);
                    pAddParameter(cmd, "@nTipoIntervencionId", nTipoInt, SqlDbType.Int);

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        lstPlanIntervencion = (List<ELPlanIntervencion>)ConvertirDataReaderALista<ELPlanIntervencion>(drSQL);
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

            return lstPlanIntervencion;
        }

        public string DL_Insertar_RequisitoPlan(int nOrdenIntervencionId, string cRequisitoDesc, int nCantidad)
        {
            string res = "";

            try
            {
                cmd.Connection = NewConnection(strCon);
                cmd.CommandText = "GHS.USP_MNT_Plan_Intervencion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                pAddParameter(cmd, "@nOrdenIntervencionId", nOrdenIntervencionId, SqlDbType.Int);
                pAddParameter(cmd, "@cRequisitoDesc", cRequisitoDesc, SqlDbType.VarChar);
                pAddParameter(cmd, "@nCantidad", nCantidad, SqlDbType.Int);

                res = fEjecutar(cmd);
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

            return res;
        }
    }
}
