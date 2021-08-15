using MVVM.Data;
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

        /// <summary>
        /// Busca el <see cref="RevisorDeTrabajoRecepcional"/> por id en los integrantes y sinodales
        /// </summary>
        /// <param name="id">ID del Integrente o Sinodal</param>
        /// <param name="context"></param>
        /// <returns>El Integrante o Sinodal como <see cref="RevisorDeTrabajoRecepcional"/> o null si no se encontro.</returns>
        public RevisorDeTrabajoRecepcional ObtenerPorID(int id, ApplicationDbContext context)
        {
            RevisorDeTrabajoRecepcional revisor = context.Integrantes.Find(id);
            if (revisor == null)
            {
                revisor = context.SinodalesDelTrabajo.Find(id);
            }

            return revisor;
        }
    }
}
