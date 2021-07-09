using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class Direccion
    {
        public int ID { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public TipoDeSinodal Tipo { get; set; }
        public RevisorDeTrabajoRecepcional Revisor { get; set; }
        public TrabajoRecepcional TrabajoRecepcional { get; set; }

    }

    public enum TipoDeSinodal
    {
        Director,
        Codirector,
        Sinodal
    }
}
