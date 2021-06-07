using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class PLADEAFEI : TipoDeProyecto
    {
        public string Accion { get; set; }
        public int ArchivoPLADEA { get; set; } // File
        public string ObjetivoGeneral { get; set; }
        public string Periodo { get; set; }

    }
}
