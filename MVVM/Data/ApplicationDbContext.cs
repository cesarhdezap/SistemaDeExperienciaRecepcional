using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Integrante> Integrantes { get; set; }
        public DbSet<LGAC> LGACs { get; set; }
        public DbSet<PLADEAFEI> PLADEAFEIs { get; set; }
        public DbSet<ProyectoDeInvestigacion> ProyectoDeInvestigaciones { get; set; }
        public DbSet<SinodalDelTrabajo> SinodalesDelTrabajo { get; set; }
        public DbSet<TrabajoRecepcional> TrabajosRecepcionales { get; set; }
        public DbSet<Vinculacion> Vinculaciones { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<ExperienciaEducativa> ExperienciasEducativas { get; set; }
    }
}
