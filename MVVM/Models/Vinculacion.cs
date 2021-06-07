using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class Vinculacion : TipoDeProyecto
    {
        public int CopiaConvenio { get; set; } //File
        public DateTime FechaDeInicioDeConvenio { get; set; }
        public string OrganizacionVinculada { get; set; }
    }
}
