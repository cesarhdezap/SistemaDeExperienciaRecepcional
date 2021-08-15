using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models.ClasesAbstractas
{
    public abstract class TipoDeProyecto
    {
        public int ID { get; set; }

        public TipoDeProyecto() { }

        /// <summary>
        /// Busca el <see cref="TipoDeProyecto"/> en los <see cref="ProyectoDeInvestigacion"/>, <see cref="Vinculacion"/>
        /// y <see cref="PLADEAFEI"/>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns>El <see cref="TipoDeProyecto"/> por id o null si no es encontrado</returns>
        public TipoDeProyecto ObtenerPorID(int id, ApplicationDbContext context)
        {
            TipoDeProyecto tipoDeProyecto = context.ProyectoDeInvestigaciones.Find(id);
            if (tipoDeProyecto == null)
            {
                tipoDeProyecto = context.Vinculaciones.Find(id);
                if (tipoDeProyecto == null)
                {
                    tipoDeProyecto = context.PLADEAFEIs.Find(id);
                }
            }

            return tipoDeProyecto;
        }
    }
}
