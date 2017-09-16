using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELOrdenIntervencion
    {
        [ELColumn("nOrdenIntervencionId")]
        public int nOrdenIntervencionId { get; set; }

        [ELColumn("cIdIntervencion")]
        public string cIdIntervencion { get; set; }

        [ELColumn("cNomCompleto")]
        public string cNomCompleto { get; set; }

        [ELColumn("cSexo")]
        public string cSexo { get; set; }  

        [ELColumn("cNroDocumento")]
        public string cNroDocumento { get; set; }


        public DateTime dFechaIntervencion { get; set; }

        [ELColumn("cFechaIntervencion")]
        public string cFechaIntervencion { get; set; }

        [ELColumn("cSede")]
        public string cSede { get; set; }

        [ELColumn("cEstado")]
        public string cEstado { get; set; }

        [ELColumn("cTipoIntNombre")]
        public string cTipoIntNombre { get; set; }

    }
}