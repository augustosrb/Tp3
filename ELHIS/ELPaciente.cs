using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELPaciente
    {
        [ELColumn("nPacienteId")]
        public int nPacienteId { get; set; }

        [ELColumn("cDNI")]
        public string cDNI { get; set; }

        [ELColumn("cNombres")]
        public string cNombres { get; set; }

        [ELColumn("cApePaterno")]
        public string cApePaterno { get; set; }

        [ELColumn("cApeMaterno")]
        public string cApeMaterno { get; set; }

        [ELColumn("cFecNac")]
        public string cFecNac { get; set; }

        [ELColumn("cSexo")]
        public string cSexo { get; set; }

        [ELColumn("cCodigoHC")]
        public string cCodigoHC { get; set; }

        [ELColumn("nEdad")]
        public int nEdad { get; set; }

        public Boolean bExiste { get; set; }

        public List<ELOrdenMedica> lstOrdenMedica { get; set; }

        public List<ELRequisitos> lstRequisitos { get; set; }
    }
}
