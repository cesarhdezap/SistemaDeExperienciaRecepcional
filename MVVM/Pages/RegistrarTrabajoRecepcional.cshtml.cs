using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVVM.Data;
using MVVM.Models;
using MVVM.Models.ClasesAbstractas;

namespace MVVM.Pages
{
    public class RegistrarTrabajoRecepcionalModel : PageModel
    {
        private Profesor Profesor { get; set;}
        private ApplicationDbContext DbContext { get; set; }
        public List<Alumno> AlumnosDelMaestro { get; set; }
        public List<SinodalDelTrabajo> Sinodales { get; set; }
        public List<Integrante> Integrantes { get; set; }
        public List<LGAC> LGACs { get; set; }


        [BindProperty]
        public int IDAlumnoSeleccionado { get; set; }
        [BindProperty]
        public TrabajoRecepcional TrabajoRecepcional { get; set; }
        [BindProperty]
        public string TipoDeProyecto { get; set; }
        [BindProperty]
        public List<int> IDLGACSeleccionadas { get; set; }
        [BindProperty]
        public string IDDirector { get; set; }
        [BindProperty]
        public string IDCodirector { get; set; }
        [BindProperty]
        public string IDSinodal { get; set; }


        public RegistrarTrabajoRecepcionalModel(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;

            AlumnosDelMaestro = new List<Alumno>();
            Integrantes = new List<Integrante>();
            Sinodales = new List<SinodalDelTrabajo>();
            LGACs = new List<LGAC>();
            Profesor = new Profesor() { ID = 1 };
        }

        public IActionResult OnGet()
        {
            var alumno = new Alumno();            
            try
            {
                AlumnosDelMaestro = alumno.ObtenerAlumnosPorIDDeProfesor(Profesor.ID, DbContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudieron obtener los alumnos del profesor.");
            }

            var sinodales = new SinodalDelTrabajo();
            var integrantes = new Integrante();
            try
            {
                Integrantes.AddRange(integrantes.ObtenerTodos(DbContext));
                Sinodales.AddRange(sinodales.ObtenerTodos(DbContext));
            }
            catch(Microsoft.Data.SqlClient.SqlException ex)
            {
                return BadRequest(ex.Message);
            }

            var lgac = new LGAC();
            LGACs.AddRange(lgac.ObtenerTodos(DbContext));

            return Page();
        }

        public IActionResult OnGetAlumnos(string cadenaDeBusqueda)
        {
            var alumno = new Alumno();
            if (!string.IsNullOrEmpty(cadenaDeBusqueda))
            {
                List<Alumno> alumnosDelProfesor;
                try
                {
                    alumnosDelProfesor = alumno.ObtenerAlumnosPorIDDeProfesor(Profesor.ID, DbContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, "No se pudieron obtener los alumnos del profesor.");
                }

                
                cadenaDeBusqueda.Trim();
                List<Alumno> alumnosFiltrados = new List<Alumno>();
                if (!string.IsNullOrEmpty(cadenaDeBusqueda))
                {
                    alumnosFiltrados = alumnosDelProfesor.Where(alumno => alumno.Nombre.Contains(cadenaDeBusqueda) || alumno.Matricula.Contains(cadenaDeBusqueda)).ToList();
                }

                if (alumnosFiltrados.Count > 0)
                {
                    return new OkObjectResult(alumnosFiltrados);
                }
                else
                {
                    return NotFound("No se encontro la cadena " + cadenaDeBusqueda);
                }
            }
            else
            {
                List<Alumno> alumnosDelProfesor = new List<Alumno>();
                try
                {
                    alumnosDelProfesor = alumno.ObtenerAlumnosPorIDDeProfesor(Profesor.ID, DbContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return StatusCode(StatusCodes.Status500InternalServerError, "No se pudieron obtener los alumnos del profesor.");
                }
                return new OkObjectResult(alumnosDelProfesor);
            }
        }

        public IActionResult OnGetVinculaciones()
        {
            var vinculacion = new Vinculacion();
            var vinculaciones = vinculacion.ObtenerTodos(DbContext);
            return new OkObjectResult(vinculaciones);
        }

        public IActionResult OnGetPladeasfei()
        {
            var pladeafei = new PLADEAFEI();
            var pladeasfei = pladeafei.ObtenerTodos(DbContext);
            return new OkObjectResult(pladeasfei);
        }

        public IActionResult OnGetProyectosDeInvestigacion()
        {
            var proyectoDeInvestigacion = new ProyectoDeInvestigacion();
            var proyectosDeInvestigacion = proyectoDeInvestigacion.ObtenerTodos(DbContext);
            return new OkObjectResult(proyectosDeInvestigacion);
        }

        public IActionResult OnGetSinodales(string cadenaDeBusqueda)
        {
            SinodalDelTrabajo sinodal = new SinodalDelTrabajo();
            if (!string.IsNullOrEmpty(cadenaDeBusqueda))
            {
                var sinodales = sinodal.BuscarSinodales(cadenaDeBusqueda, DbContext);
                if (sinodales.Count > 0)
                {
                    return new OkObjectResult(sinodales);
                }
                else
                {
                    return NotFound("No se encontro la cadena " + cadenaDeBusqueda);
                }
            }
            else
            {
                var sinodales = sinodal.ObtenerTodos(DbContext);
                return new OkObjectResult(sinodales);
            }
        }

        public IActionResult OnGetIntegrantes(string cadenaDeBusqueda)
        {
            Integrante integrante = new Integrante();
            if (!string.IsNullOrEmpty(cadenaDeBusqueda))
            {
                var integrantes = integrante.BuscarIntegrantes(cadenaDeBusqueda, DbContext);
                if (integrantes.Count > 0)
                {
                    return new OkObjectResult(integrantes);
                }
                else
                {
                    return NotFound("No se encontro la cadena " + cadenaDeBusqueda);
                }
            }
            else
            {
                var integrantes = integrante.ObtenerTodos(DbContext);
                return new OkObjectResult(integrantes);
            }
        }


        public void OnPost()
        {
            //set fecha de inicio
            //set estado del proyecto
            //if(ModelState.IsValid)
            //{
            //    GuardadoExitoso = true;
            //    return Page();
            //}
            //else
            //{
            //    return RedirectToPage("/Index");
            //}
        }
    }

    public enum Modalidades
    {
        PrácticoTecnico,
        Tesis,
        Tesina,
        Monografía,
        RSL
    }
}
