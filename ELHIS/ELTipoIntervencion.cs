using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELTipoIntervencion
    {
        [ELColumn("nTipoIntervencionId")]
        public int nTipoIntervencionId { get; set; }

        [ELColumn("cTipoIntNombre")]
        public string cTipoIntNombre { get; set; }      
    }
}
