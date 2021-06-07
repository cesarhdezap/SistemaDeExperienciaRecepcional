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
        [BindProperty]
        public int IDAlumnoSeleccionado { get; set; }
        [BindProperty]
        public TrabajoRecepcional TrabajoRecepcional { get; set; }
        [BindProperty(SupportsGet = true)]
        public string TerminoDeBusqueda { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool GuardadoExitoso { get; set; }


        public RegistrarTrabajoRecepcionalModel(ApplicationDbContext applicationDbContext)
        {
            DbContext = applicationDbContext;

            var alumno = new Alumno();
            AlumnosDelMaestro = new List<Alumno>() { alumno.CargarPorId(1, DbContext), alumno.CargarPorId(2, DbContext), alumno.CargarPorId(3, DbContext) };

            if (!string.IsNullOrEmpty(TerminoDeBusqueda))
            {
                TerminoDeBusqueda.Trim();
                if (!string.IsNullOrEmpty(TerminoDeBusqueda))
                {
                    TerminoDeBusqueda = TerminoDeBusqueda.ToLower();
                    AlumnosDelMaestro = AlumnosDelMaestro.Where(alumno => alumno.Nombre.ToLower().Contains(TerminoDeBusqueda) || alumno.Matricula.ToLower().Contains(TerminoDeBusqueda)).ToList();
                }
            }

            Integrantes = new List<Integrante>();
            Sinodales = new List<SinodalDelTrabajo>();
            var sinodales = new SinodalDelTrabajo();
            var integrantes = new Integrante();
            Integrantes.AddRange(integrantes.ObtenerTodos(DbContext));
            Sinodales.AddRange(sinodales.ObtenerTodos(DbContext));
        }

        public void OnGet()
        {
            
        }

        public void OnPost()
        {
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

    public enum PasosRegistrarTrabajoRecepcional
    {
        Identificadores,
        SeleccionarAlumnos,
        SeleccionarTipoDeProyecto,
        SeleccionarProyecto,
        LineaDeInvestigacion,
        SeleccionarOpcionDeSinodal,
        BuscarSinodal
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
