using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class ProyectoDeInvestigacion : TipoDeProyecto
    {
        public DateTime FechaDeInicio { get; set; }
        public string Nombre { get; set; }
        public ICollection<TrabajoRecepcional> TrabajoRecepcionales { get; set; }
    }
}
