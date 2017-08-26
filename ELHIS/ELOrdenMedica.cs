using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELOrdenMedica
    {

        [ELColumn("cOrdenMedId")]
        public int cOrdenMedId { get; set; }

        [ELColumn("IdOrden")]
        public int IdOrden { get; set; }

        [ELColumn("DNI")]
        public string Dni { get; set; }

        [ELColumn("ApeNom")]
        public string Apenom { get; set; }

        [ELColumn("TipoInt")]
        public string TipoInt { get; set; }

        [ELColumn("Estado")]
        public string Estado { get; set; }


        [ELColumn("nOrdenMedId")]
        public int nOrdenMedId { get; set; }

        [ELColumn("cTipoIntNombre")]
        public string cTipoIntNombre { get; set; }

        [ELColumn("dtFechaEmi")]
        public string dtFechaEmi { get; set; }

        [ELColumn("cEstadoNombre")]
        public string cEstadoNombre { get; set; }
    }
}
