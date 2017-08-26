using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELRequisitos
    {

        [ELColumn("nRequisitoId")]
        public int nRequisitoId { get; set; }

        [ELColumn("cRequisitoDescripcion")]
        public string cRequisitoDescripcion { get; set; }
    }
}
