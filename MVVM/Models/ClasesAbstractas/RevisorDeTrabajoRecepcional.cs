using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models.ClasesAbstractas
{
    public abstract class RevisorDeTrabajoRecepcional
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
    }
}
