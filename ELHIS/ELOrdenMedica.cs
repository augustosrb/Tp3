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
        public string cOrdenMedId { get; set; }

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
