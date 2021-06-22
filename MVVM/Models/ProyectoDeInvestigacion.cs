using MVVM.Data;
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
        public List<ProyectoDeInvestigacion> ObtenerTodos(ApplicationDbContext context)
        {
            List<ProyectoDeInvestigacion> proyectos = context.ProyectoDeInvestigaciones.ToList();
            return proyectos;
        }
    }
}
