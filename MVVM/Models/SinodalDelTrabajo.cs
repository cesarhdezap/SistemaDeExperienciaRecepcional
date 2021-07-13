using MVVM.Data;
using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class SinodalDelTrabajo : RevisorDeTrabajoRecepcional
    {
        public string CorreoElectronico { get; set; }
        public string Organizacion { get; set; }
        public string Telefono { get; set; }

        public List<SinodalDelTrabajo> ObtenerTodos(ApplicationDbContext context)
        {

            List<SinodalDelTrabajo> sinodales = context.SinodalesDelTrabajo.ToList();
            return sinodales;
        }

        /// <summary>
        /// Busca <see cref="SinodalDelTrabajo"/> por nombre o organización.
        /// </summary>
        /// <param name="cadenaDeBusqueda">Cadena a comparar con nombre o organización a buscar.</param>
        /// <param name="dbContext"></param>
        /// <returns>Una lista de sinodales del trabajo filtrada por <paramref name="cadenaDeBusqueda"/>. Si no existe
        /// ninguna coincidencia regresa una lista vacía.</returns>
        public List<SinodalDelTrabajo> BuscarSinodales(string cadenaDeBusqueda, ApplicationDbContext dbContext)
        {
            List<SinodalDelTrabajo> sinodales = new List<SinodalDelTrabajo>();
            cadenaDeBusqueda.Trim();
            if (!string.IsNullOrEmpty(cadenaDeBusqueda))
            {
                sinodales = dbContext.SinodalesDelTrabajo
                    .Where(sinodal => sinodal.Nombre.Contains(cadenaDeBusqueda) || sinodal.Organizacion.Contains(cadenaDeBusqueda)).ToList();
            }

            return sinodales;
        }
    }
}
