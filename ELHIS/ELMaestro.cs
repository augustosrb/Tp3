using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELMaestro
    {
        [ELColumn("nItemId")]
        public int nItemId { get; set; }

        [ELColumn("cMaestroDescripcion")]
        public string cMaestroDescripcion { get; set; }

        [ELColumn("nMaestroId")]
        public int nMaestroId { get; set; }

        [ELColumn("nTablaId")]
        public int nTablaId { get; set; }

        [ELColumn("cEliminado")]
        public string cEliminado { get; set; }
    }
}
