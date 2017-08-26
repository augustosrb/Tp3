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
    public class BLUsuario
    {
        DLUsuario dl = new DLUsuario();

        private ResponseModel rm = new ResponseModel();

        public ResponseModel Acceder(ELUsuario usuario)
        {
            try
            {
                // Encriptamos la contraseña para comparar
                usuario.Password = HashHelper.MD5(usuario.Password);

                var _usuario = dl.DL_Autenticar(usuario);

                if (_usuario != null)
                {
                    SessionHelper.AddUserToSession(_usuario.Id.ToString());

                    rm.SetResponse(true);
                    rm.href = "inicio";
                }
                else
                {
                    rm.SetResponse(false, "El usuario ingresado no existe");
                }
            }
            catch (Exception e)
            {
                ELog.Save(this, e);
            }

            return rm;
        }

        public ELUsuario Obtener(int id)
        {
            DLUsuario dl = new DLUsuario();

            return dl.ObtenerUsuarioLogeado(id);
        }
    }
}
