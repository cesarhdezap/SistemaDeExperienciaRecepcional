using MVVM.Data;
using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class Integrante : RevisorDeTrabajoRecepcional
    {
        public int ID { get; set; }
        public string NumeroDePersonal { get; set; }
        public TipoDeIntegrante TipoDeIntegrante { get; set; }
        public ICollection<LGAC> LGACsAplicadas { get; set; }

        public List<Integrante> ObtenerTodos(ApplicationDbContext context)
        {
            List<Integrante> integrantes = context.Integrantes.ToList();
            return integrantes;
        }
    }

    public enum TipoDeIntegrante
    {
        Integrante,
        Colaborador
    }
}
