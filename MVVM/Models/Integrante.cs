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
        public string NumeroDePersonal { get; set; }
        public TipoDeIntegrante TipoDeIntegrante { get; set; }
        public ICollection<LGAC> LGACsAplicadas { get; set; }

        public List<Integrante> ObtenerTodos(ApplicationDbContext context)
        {
            List<Integrante> integrantes = context.Integrantes.ToList();
            return integrantes;
        }

        /// <summary>
        /// Busca <see cref="Integrante"/> por nombre o numero de personal.
        /// </summary>
        /// <param name="cadenaDeBusqueda">Cadena a comparar con nombre o organización a buscar.</param>
        /// <param name="dbContext"></param>
        /// <returns>Una lista de integrantes filtrada por <paramref name="cadenaDeBusqueda"/>. Si no existe
        /// ninguna coincidencia regresa una lista vacía.</returns>
        public List<Integrante> BuscarIntegrantes(string cadenaDeBusqueda, ApplicationDbContext dbContext)
        {
            List<Integrante> sinodales = new List<Integrante>();
            cadenaDeBusqueda.Trim();
            if (!string.IsNullOrEmpty(cadenaDeBusqueda))
            {
                sinodales = dbContext.Integrantes
                    .Where(integrante => integrante.Nombre.Contains(cadenaDeBusqueda) || integrante.NumeroDePersonal.Contains(cadenaDeBusqueda)).ToList();
            }

            return sinodales;
        }
    }

    public enum TipoDeIntegrante
    {
        Integrante,
        Colaborador
    }
}
