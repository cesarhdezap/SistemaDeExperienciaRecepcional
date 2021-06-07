using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class TrabajoRecepcional
    {
        public int ID { get; set; }
        [Required]
        public string Anteproyecto { get; set; }
        public EstadoDeTrabajoRecepcional EstadoDeTrabajoRecepcional { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public string LineaDeInvestigacion { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Debe seleccionar una opción")]
        public string Modalidad { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "La longitud del nombre debe ser mayor a 10 y menor que 255")]
        public string Nombre { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
        public TipoDeProyecto TipoDeProyecto { get; set; }
        public ICollection<LGAC> LGACs { get; set; }

        public void Guardar()
        {

        }

    }

    public enum EstadoDeTrabajoRecepcional
    {
        EnProceso,
        Abandonado,
        EnTramiteParaDefensa,
        Completado
    }
}
