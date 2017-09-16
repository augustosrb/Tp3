using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELHIS
{
    public class ELPriorizarAtencion
    {
        [ELColumn("nPacienteId")]
        public int nPacienteId { get; set; }

        [ELColumn("nOrdenIntervencionId")]
        public int nOrdenIntervencionId { get; set; }

        [ELColumn("cNombres")]
        public string cNombres { get; set; }

        [ELColumn("cTipoIntNombre")]
        public string cTipoIntNombre { get; set; }

        [ELColumn("cAmbienteNombre")]
        public string cAmbienteNombre { get; set; }

        [ELColumn("cPorcentaje")]
        public string cPorcentaje { get; set; }

        [ELColumn("cColor")]
        public string cColor { get; set; }

        [ELColumn("cSexo")]
        public string cSexo { get; set; }

        [ELColumn("nEdad")]
        public int nEdad { get; set; }

        [ELColumn("nActividadesId")]
        public int nActividadesId { get; set; }

        [ELColumn("cActividadesNombre")]
        public string cActividadesNombre { get; set; }

        [ELColumn("nAtendido")]
        public int nAtendido { get; set; }

    }
}