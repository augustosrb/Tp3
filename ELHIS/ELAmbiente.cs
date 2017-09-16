using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELAmbiente
    {

        [ELColumn("nAmbienteId")]
        public int nAmbienteId { get; set; }

        [ELColumn("cAmbienteNombre")]
        public string cAmbienteNombre { get; set; }

        public int nAmbienteRelacionId { get; set; }
         
        public int nTipoAmbienteId { get; set; }
    }
}
