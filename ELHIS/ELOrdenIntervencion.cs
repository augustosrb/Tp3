using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELOrdenIntervencion
    {
        [ELColumn("IdOrden")]
        public string Id { get; set; }

        [ELColumn("DNI")]
        public string DNI { get; set; }

        [ELColumn("ApeNom")]
        public string ApeNom { get; set; }  

        [ELColumn("Sede")]
        public string Sede { get; set; }

        [ELColumn("TipoInt")]
        public string TipoInt { get; set; }

        [ELColumn("Fecha")]
        public string Fecha { get; set; }

        [ELColumn("Estado")]
        public string Estado { get; set; }

        [ELColumn("nOrdenIntId")]
        public int nOrdenIntId { get; set; } 

        public int EstadoId { get; set; }

        public string Medico { get; set; }

        public int TipoIntId { get; set; }

        public DateTime fecha_nacimiento { get; set; }

    }
}