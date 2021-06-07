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
    }
}
