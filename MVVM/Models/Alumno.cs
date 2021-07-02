using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string CorreoElectronico { get; set; }

        public Alumno CargarPorId(int idAlumno, ApplicationDbContext context)
        {
            // Microsoft.Data.SqlClient.SqlException cuando no existe
            var alumno = context.Alumnos.FirstOrDefault(alumno => alumno.ID == idAlumno);
            return alumno;
        }

        /// <summary>
        /// Busca alumnos por nombre o matrícula
        /// </summary>
        /// <param name="cadenaDeBusqueda"></param>
        /// <param name="context"></param>
        /// <returns><see cref="List{Alumno}"/> Con los alumnos encontrados o vacio si no encontro ninguno</returns>
        public List<Alumno> BuscarAlumno(string cadenaDeBusqueda, ApplicationDbContext context)
        {
            List<Alumno> alumnos = new List<Alumno>();
            cadenaDeBusqueda.Trim();
            if (!string.IsNullOrEmpty(cadenaDeBusqueda))
            {
                alumnos = context.Alumnos.Where(alumno => alumno.Nombre.Contains(cadenaDeBusqueda) || alumno.Matricula.Contains(cadenaDeBusqueda)).ToList();
            }

            return alumnos;
        }

        public List<Alumno> ObtenerTodos(ApplicationDbContext context)
        {
            List<Alumno> alumnos = context.Alumnos.ToList();
            return alumnos;
        }
    }

    
}
