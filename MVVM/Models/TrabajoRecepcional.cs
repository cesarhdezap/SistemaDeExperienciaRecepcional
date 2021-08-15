using MVVM.Data;
using MVVM.Models.ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class TrabajoRecepcional
    {
        public int ID { get; set; }
        public byte[] Anteproyecto { get; set; }
        public EstadoDeTrabajoRecepcional EstadoDeTrabajoRecepcional { get; set; }
        public DateTime FechaDeInicio { get; set; }
        [Required(ErrorMessage = "Debe ingresar una línea de investigación")]
        [StringLength(255, MinimumLength = 3)]
        public string LineaDeInvestigacion { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Debe seleccionar una modalidad")]
        public string Modalidad { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "La longitud del nombre debe ser mayor a 10 y menor que 255")]
        public string Nombre { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
        public ICollection<Direccion> Direcciones { get; set; }
        
        public TipoDeProyecto TipoDeProyecto { get; set; }
        [Required(ErrorMessage = "Debe seleccionar al menos una LGAC")]
        public ICollection<LGAC> LGACs { get; set; }

        public TrabajoRecepcional()
        {
            //Esto es para evitar problemas donde asp net core crea el objeto y no puede crear TipoDeProyecto por que es abstracto
            TipoDeProyecto = new ProyectoDeInvestigacion();
        }

        /// <summary>
        /// Agrega una <see cref="Direccion"/> a <see cref="Direcciones"/>
        /// </summary>
        /// <param name="idRevisorDeTrabajoRecepcional">ID del <see cref="RevisorDeTrabajoRecepcional"/></param>
        /// <param name="tipoDeSinodal"></param>
        /// <param name="context"></param>
        /// <exception cref="InvalidOperationException">
        /// Se tira cuando el <see cref="RevisorDeTrabajoRecepcional"/> no es entrado con la id provista.
        /// </exception>
        public void AgregarDireccion(int idRevisorDeTrabajoRecepcional, TipoDeSinodal tipoDeSinodal, ApplicationDbContext context)
        {
            RevisorDeTrabajoRecepcional revisor = new Integrante();
            revisor = revisor.ObtenerPorID(idRevisorDeTrabajoRecepcional, context);

            if (revisor != null)
            {
                Direcciones.Add(new Direccion()
                {
                    FechaDeInicio = DateTime.Now,
                    Tipo = tipoDeSinodal,
                    Revisor = revisor
                });
            }
            else
            {
                throw new InvalidOperationException("No se encontró el director");
            }
        }

        public void Guardar(ApplicationDbContext context)
        {
            context.TrabajosRecepcionales.Add(this);
            context.SaveChanges();
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
