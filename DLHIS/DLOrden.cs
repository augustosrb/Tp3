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

        public List<ELOrdenIntervencion> DL_ConsultarOI()
        {

            List<ELOrdenIntervencion> objListaOrdenIntervencion = new List<ELOrdenIntervencion>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "USP_ConsultarOI";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

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

        public List<ELOrdenMedica> DL_BuscarOrdenMedica(string dni)
        {
            List<ELOrdenMedica> objListaOrdenMedica= new List<ELOrdenMedica>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "USP_ConsultarOM";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@cDNI", dni == "" ? "" : dni);

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

        public List<ELRequisitos> DL_BuscarRequisitos(int tipointervencion)
        {
            List<ELRequisitos> objListaRequisitos = new List<ELRequisitos>();

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "USP_ConsultarREQ";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@nTipoIntId", tipointervencion == 0 ? 0 : tipointervencion);

                    SqlDataReader drSQL = fLeer(cmd);

                    if (drSQL.HasRows)
                    {
                        objListaRequisitos = (List<ELRequisitos>)ConvertirDataReaderALista<ELRequisitos>(drSQL);
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

            return objListaRequisitos;
        }

        public ELPaciente DL_BuscarPaciente(string dni)
        {
            ELPaciente objPaciente = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "USP_buscarPaciente";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@cDNI", dni == "" ? "" : dni);

                    SqlDataReader drSQL = fLeer(cmd);
                    if (drSQL.HasRows == false)
                    {
                        objPaciente = new ELPaciente();
                        objPaciente.bExiste = false;
                    }
                    else
                    {
                        while (drSQL.Read())
                        {
                            objPaciente = new ELPaciente();
                            objPaciente.cApePaterno = drSQL["cApePaterno"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cApePaterno"]);
                            objPaciente.cApeMaterno = drSQL["cApeMaterno"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cApeMaterno"]);
                            objPaciente.cNombres = drSQL["cNombres"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cNombres"]);
                            objPaciente.cFecNac = drSQL["cFecNac"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cFecNac"]);
                            objPaciente.cCodigoHC = drSQL["cCodigoHC"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cCodigoHC"]);
                            objPaciente.cFecNac = drSQL["cFecNac"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cFecNac"]);
                            objPaciente.cSexo = drSQL["cSexo"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["cSexo"]);
                            objPaciente.nEdad = drSQL["nEdad"].Equals(System.DBNull.Value) ? 0 : Convert.ToInt32(drSQL["nEdad"]);
                            objPaciente.bExiste = true;
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

        public String DL_MantenimientoOrden(ELPaciente objPaciente)
        {
            String strResultado = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "USP_InsertarOI";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@nPacienteId", objPaciente.nPacienteId == 0 ? 0 : objPaciente.nPacienteId);
                    cmd.Parameters.AddWithValue("@nHabitacionId", 1== 0 ? 0 : 1);
                    cmd.Parameters.AddWithValue("@nTipointId", 1 == 0 ? 0 : 1);
                    cmd.Parameters.AddWithValue("@nEstadoId", 1 == 0 ? 0 : 1);
                    strResultado = fEjecutar(cmd);
                }
            }
            catch (Exception e)
            {
                strResultado = "";
                ELog.Save(this, e);
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }

            return strResultado;
        }
    }
}
