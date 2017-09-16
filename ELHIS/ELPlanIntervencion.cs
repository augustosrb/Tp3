using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELPlanIntervencion
    {
        [ELColumn("cNombres")]
        public string cNombres { get; set; }

        [ELColumn("nOrdenIntervencionId")]
        public int nOrdenIntervencionId { get; set; }

        [ELColumn("nTipoIntervencionId")]
        public int nTipoIntervencionId { get; set; }

        [ELColumn("cTipoIntNombre")]
        public string cTipoIntNombre { get; set; }

        [ELColumn("dFecha")]
        public DateTime dFecha { get; set; }

        [ELColumn("cFecha")]
        public string cFecha { get; set; }

        [ELColumn("nCantMedicos")]
        public int nCantMedicos { get; set; }

        [ELColumn("nCantReq")]
        public int nCantReq { get; set; }
    }
}