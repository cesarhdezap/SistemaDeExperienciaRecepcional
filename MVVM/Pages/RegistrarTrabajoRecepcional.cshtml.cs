using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
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
        private IWebHostEnvironment Environment;


        [BindProperty]
        public int IDAlumnoSeleccionado { get; set; }
        [BindProperty]
        public IFormFile ArchivoDeAnteproyecto { get; set; }
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


        public RegistrarTrabajoRecepcionalModel(ApplicationDbContext applicationDbContext, IWebHostEnvironment _environment)
        {
            DbContext = applicationDbContext;
            Environment = _environment;

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


        public IActionResult OnPost()
        {
            TrabajoRecepcional.FechaDeInicio = DateTime.Now;
            TrabajoRecepcional.EstadoDeTrabajoRecepcional = EstadoDeTrabajoRecepcional.EnProceso;
            if (Enum.TryParse(typeof(Modalidades), TrabajoRecepcional.Modalidad, out var modalidad))
            {
                TrabajoRecepcional.Modalidad = modalidad.ToString();
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error, modalidad no encontrada.");
            }

            if (!string.IsNullOrEmpty(IDDirector))
            {
                TrabajoRecepcional.Direcciones = new List<Direccion>();
                int.TryParse(IDDirector, out int idDirector);
                TrabajoRecepcional.AgregarDireccion(idDirector, TipoDeSinodal.Director, DbContext);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error, no se encontro un director con la id proporcionada.");
            }

            if (!string.IsNullOrEmpty(IDCodirector))
            {
                TrabajoRecepcional.Direcciones = new List<Direccion>();
                int.TryParse(IDCodirector, out int idCodirector);
                TrabajoRecepcional.AgregarDireccion(idCodirector, TipoDeSinodal.Codirector, DbContext);
            }

            if (!string.IsNullOrEmpty(IDSinodal))
            {
                TrabajoRecepcional.Direcciones = new List<Direccion>();
                int.TryParse(IDSinodal, out int idSinodal);
                TrabajoRecepcional.AgregarDireccion(idSinodal, TipoDeSinodal.Sinodal, DbContext);
            }

            Alumno alumno = new Alumno();
            try
            {
                alumno = alumno.CargarPorId(IDAlumnoSeleccionado, DbContext);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, " + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error, " + ex.Message);
            }

            TrabajoRecepcional.Alumnos = new List<Alumno>
            {
                alumno
            };

            if (TipoDeProyecto == "proyectoDeInvestigacion")
            {
                TipoDeProyecto proyecto = new ProyectoDeInvestigacion();
                proyecto = proyecto.ObtenerPorID(TrabajoRecepcional.TipoDeProyecto.ID, DbContext);
                TrabajoRecepcional.TipoDeProyecto = proyecto;
            }
            else if (TipoDeProyecto == "vinculacion")
            {
                TipoDeProyecto vinculacion = new Vinculacion();
                vinculacion = vinculacion.ObtenerPorID(TrabajoRecepcional.TipoDeProyecto.ID, DbContext);
                TrabajoRecepcional.TipoDeProyecto = vinculacion;
            }
            else if (TipoDeProyecto == "pladeafei")
            {
                TipoDeProyecto pladeafei = new PLADEAFEI();
                pladeafei = pladeafei.ObtenerPorID(TrabajoRecepcional.TipoDeProyecto.ID, DbContext);
                TrabajoRecepcional.TipoDeProyecto = pladeafei;
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error, no se proporcino un tipo de proyecto.");
            }

            TrabajoRecepcional.LGACs = new List<LGAC>();
            foreach (int idLGAC in IDLGACSeleccionadas)
            {
                var lgac = new LGAC();
                lgac = lgac.ObtenerPorID(idLGAC, DbContext);
                if (lgac != null)
                {
                    TrabajoRecepcional.LGACs.Add(lgac);
                }
            }

            if (ArchivoDeAnteproyecto != null)
            {
                if (ArchivoDeAnteproyecto.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        ArchivoDeAnteproyecto.CopyTo(memoryStream);
                        var fileBytes = memoryStream.ToArray();
                        TrabajoRecepcional.Anteproyecto = fileBytes;
                    }
                }

            }

            try
            {
                //TrabajoRecepcional.Guardar(DbContext);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error al guardar el trabajo recepcional: " + ex.Message);
            }


            return new OkObjectResult("Trabajo recepcional guardado.");
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
