using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELOrdenMedica
    {

        [ELColumn("nOrdenMedId")]
        public int nOrdenMedId { get; set; }

        [ELColumn("cIdOrden")]
        public string cIdOrden { get; set; }

        [ELColumn("cNomCompleto")]
        public string cNomCompleto { get; set; }

        [ELColumn("cSexo")]
        public string cSexo { get; set; }

        [ELColumn("cNroDocumento")]
        public string cNroDocumento { get; set; }

        [ELColumn("dFechaIntervencion")]
        public DateTime dFechaIntervencion { get; set; }

        [ELColumn("cTipoIntNombre")]
        public string cTipoIntNombre { get; set; }

        [ELColumn("cFechaIntervencion")]
        public string cFechaIntervencion { get; set; }


    }
}
