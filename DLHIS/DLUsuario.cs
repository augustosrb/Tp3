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
    public class DLUsuario : DLDBOBase
    {
        String strCon = ConfigurationManager.AppSettings["ERPHISConexion"].ToString();

        SqlCommand cmd = new SqlCommand();

        public ELUsuario DL_Autenticar(ELUsuario elObj)
        {
            ELUsuario objUsuario = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    cmd.Connection = conn;
                    cmd.CommandText = "USP_Autenticar";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@Login", elObj.Login == "" ? "" : elObj.Login);
                    cmd.Parameters.AddWithValue("@Password", elObj.Password == "" ? "" : elObj.Password);

                    SqlDataReader drSQL = fLeer(cmd);

                    while (drSQL.Read())
                    {
                        objUsuario = new ELUsuario();
                        objUsuario.Id = drSQL["id"].Equals(System.DBNull.Value) ? 0 : Convert.ToInt32(drSQL["id"]);
                        objUsuario.NombreCompleto = drSQL["NombreCompleto"].Equals(System.DBNull.Value) ? "" : Convert.ToString(drSQL["NombreCompleto"]);
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

            return objUsuario;
        }

        public ELUsuario ObtenerUsuarioLogeado(int id)
        {
            var usuario = new ELUsuario();

            try
            {
                using (var conn = new SqlConnection(strCon))
                {
                    conn.Open();

                    var query = new SqlCommand("select * from usuario where id = @id", conn);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            usuario.Nombre = dr["Nombre"].ToString();
                            usuario.Apellido = dr["Apellido"].ToString();
                            usuario.NombreCompleto = usuario.Nombre + " " + usuario.Apellido;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return usuario;
        }
    }
}
