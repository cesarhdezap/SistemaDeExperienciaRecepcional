using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class ExperienciaEducativa
    {
        public int ID { get; set; }
        public bool EstadoAbierto { get; set; }
        public string Nombre { get; set; }
        public string NRC { get; set; }
        public string Periodo { get; set; }
        public string Seccion { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
        public Profesor Profesor { get; set; }
    }
}
