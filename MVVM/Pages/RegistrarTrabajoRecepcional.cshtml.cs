using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVVM.Data;
using MVVM.Models;
using MVVM.Models.ClasesAbstractas;

namespace MVVM.Pages
{
    public class RegistrarTrabajoRecepcionalModel : PageModel
    {
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

        public RegistrarTrabajoRecepcionalModel(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;

            AlumnosDelMaestro = new List<Alumno>();
            Integrantes = new List<Integrante>();
            Sinodales = new List<SinodalDelTrabajo>();
            LGACs = new List<LGAC>();
        }

        public void OnGet()
        {
            var alumno = new Alumno();
            AlumnosDelMaestro.AddRange(new Alumno[] { alumno.CargarPorId(1, DbContext), alumno.CargarPorId(2, DbContext), alumno.CargarPorId(3, DbContext) });

            var sinodales = new SinodalDelTrabajo();
            var integrantes = new Integrante();
            Integrantes.AddRange(integrantes.ObtenerTodos(DbContext));
            Sinodales.AddRange(sinodales.ObtenerTodos(DbContext));

            var lgac = new LGAC();
            LGACs.AddRange(lgac.ObtenerTodos(DbContext));
            //cachar todas las peticiones y si son null ponerlas empty en el modelo
        }

        public IActionResult OnGetAlumnos(string cadenaDeBusqueda)
        {
            //validar paginacion, cuando existan muchos alumnos
            //validar que get alumnos solo cargue los alumnos del maestro
            //hacer pruebas de rendimiento para ver si hace falta paginacion
            var alumno = new Alumno();
            if (!string.IsNullOrEmpty(cadenaDeBusqueda))
            {
                var alumnos = alumno.BuscarAlumno(cadenaDeBusqueda, DbContext);
                if (alumnos.Count > 0)
                {
                    return new OkObjectResult(alumnos);
                }
                else
                {
                    return NotFound("No se encontro la cadena " + cadenaDeBusqueda);
                }
            }
            else
            {
                var alumnos = alumno.ObtenerTodos(DbContext);
                return new OkObjectResult(alumnos);
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

        public IActionResult OnGetSinodales()
        {
            var sinodal = new SinodalDelTrabajo();
            var sinodales = sinodal.ObtenerTodos(DbContext);
            return new OkObjectResult(sinodales);
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
