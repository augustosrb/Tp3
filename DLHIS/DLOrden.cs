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
    public class DLOrden : DLDBOBase
    {
        String strCon = ConfigurationManager.AppSettings["ERPHISConexion"].ToString();

        SqlCommand cmd = new SqlCommand();

        public List<ELOrdenIntervencion> DL_ConsultarOI(string documento, int estado)
        {

            List<ELOrdenIntervencion> objListaOrdenIntervencion = new List<ELOrdenIntervencion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_Consultar_Orden_Intervencion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@cNroDocumento", documento == "" ? "" : documento);
                    cmd.Parameters.AddWithValue("@nItemId", estado == 0 ? 0 : estado);

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        objListaOrdenIntervencion = (List<ELOrdenIntervencion>)ConvertirDataReaderALista<ELOrdenIntervencion>(drSQL);
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

            return objListaOrdenIntervencion;
        }

        public List<ELOrdenMedica> DL_ConsultarOM(string dni)
        {
            List<ELOrdenMedica> objListaOrdenMedica= new List<ELOrdenMedica>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_Consultar_Orden_Medica";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@cNroDocumento", dni == "" ? "" : dni);

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        objListaOrdenMedica = (List<ELOrdenMedica>)ConvertirDataReaderALista<ELOrdenMedica>(drSQL);
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

            return objListaOrdenMedica;
        }

        public ELPaciente DL_BuscarPaciente(string dni, string hc)
        {
            ELPaciente objPaciente = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "GHS.USP_Consultar_Paciente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@cNroDocumento", dni == "" ? "" : dni);
                    cmd.Parameters.AddWithValue("@cNroHistoriaClinica", hc == "" ? "" : hc);

                    SqlDataReader drSQL = fLeer(cmd);
                    if (drSQL.HasRows == false)
                    {
                        objPaciente = new ELPaciente();
                    }
                    else
                    {
                        while (drSQL.Read())
                        {
                            objPaciente = new ELPaciente();
                            objPaciente.nPacienteId = drSQL["nPacienteId"].Equals(System.DBNull.Value) ? 0 : Convert.ToInt32(drSQL["nPacienteId"]);
                            objPaciente.cNomCompleto = drSQL["cNomCompleto"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cNomCompleto"]);
                            objPaciente.cApePaterno = drSQL["cApePaterno"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cApePaterno"]);
                            objPaciente.cApeMaterno = drSQL["cApeMaterno"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cApeMaterno"]);
                            objPaciente.cNroHistoriaClinica = drSQL["cNroHistoriaClinica"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cNroHistoriaClinica"]);
                            objPaciente.cFechaNacimiento = drSQL["cFechaNacimiento"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cFechaNacimiento"]);
                            objPaciente.cNombres = drSQL["cNombres"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cNombres"]);    
                            objPaciente.nEdad = drSQL["nEdad"].Equals(System.DBNull.Value) ? 0 : Convert.ToInt32(drSQL["nEdad"]);
                            objPaciente.cSexo = drSQL["cSexo"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cSexo"]);
                            objPaciente.cMaestroDescripcion = drSQL["cMaestroDescripcion"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cMaestroDescripcion"]);
                            objPaciente.cNroDocumento = drSQL["cNroDocumento"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cNroDocumento"]);
                            objPaciente.cAlergias = drSQL["cAlergias"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cAlergias"]);
                            
                        }
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

            return objPaciente;
        }
        
        public string DL_Insertar_SOAP(int nHistoriaClinica, string cSubjetivo, string cApreciacion)
        {
            string res = "";

            try
            {
                cmd.Connection = NewConnection(strCon);
                cmd.CommandText = "GHS.USP_Insertar_SOAP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                pAddParameter(cmd, "@nHistoriaClinica", nHistoriaClinica, SqlDbType.Int);
                pAddParameter(cmd, "@cSubjetivo", cSubjetivo, SqlDbType.VarChar);
                pAddParameter(cmd, "@cApreciacion", cApreciacion, SqlDbType.VarChar);

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


        public string DL_registrarOrden(int habreposo, int nOrdenMedId)
        {
            string res = "";

            try
            {
                cmd.Connection = NewConnection(strCon);
                cmd.CommandText = "GHS.USP_Insertar_Orden_Intervencion";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                pAddParameter(cmd, "@nOrdenMedId", nOrdenMedId, SqlDbType.Int);
                pAddParameter(cmd, "@nAmbienteId", habreposo, SqlDbType.Int);

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
