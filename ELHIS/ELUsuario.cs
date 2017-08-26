using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELUsuario
    {

        [ELColumn("id")]
        public int Id { get; set; }

        [ELColumn("login")]
        public string Login { get; set; }

        [ELColumn("correo")]
        public string Correo { get; set; }

        [ELColumn("password")]
        public string Password{ get; set; }

        [ELColumn("nombre")]
        public string Nombre { get; set; }

        [ELColumn("apellido")]
        public string Apellido { get; set; }

        [ELColumn("sexo")]
        public byte? Sexo { get; set; }

        [ELColumn("fec_nac")]
        public string FechaNacimiento { get; set; }

        [ELColumn("NombreCompleto")]
        public string NombreCompleto { get; set; }

    }
}
