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

        [ELColumn("cNomCompleto")]
        public string cNomCompleto { get; set; }

        [ELColumn("cApePaterno")]
        public string cApePaterno { get; set; }

        [ELColumn("cApeMaterno")]
        public string cApeMaterno { get; set; }

        [ELColumn("cNombres")]
        public string cNombres { get; set; }

        [ELColumn("nEdad")]
        public int nEdad { get; set; }

        [ELColumn("cSexo")]
        public string cSexo { get; set; }

        [ELColumn("cMaestroDescripcion")]
        public string cMaestroDescripcion { get; set; }

        [ELColumn("cNroDocumento")]
        public string cNroDocumento { get; set; }

        [ELColumn("cNroHistoriaClinica")]
        public string cNroHistoriaClinica { get; set; }

        [ELColumn("cFechaNacimiento")]
        public string cFechaNacimiento { get; set; }

        [ELColumn("cAlergias")]
        public string cAlergias { get; set; }

        public List<ELOrdenMedica> lstOrdenMedica{ get; set; }
    }
}
