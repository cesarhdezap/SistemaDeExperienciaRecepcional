using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVVM.Models
{
    public class Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string CorreoElectronico { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="Microsoft.Data.SqlClient.SqlException">Ocurre cuando la base de datos no ha sido 
        /// conectada u ocurrió un error con SQLServer.</exception>
        /// <exception cref="InvalidOperationException">
        /// Ocurre cuando surge un error al inicializar la base de datos después de la aplicación.</exception>
        public Alumno CargarPorId(int idAlumno, ApplicationDbContext context)
        {
            Alumno alumno = new Alumno();
            alumno = context.Alumnos.FirstOrDefault(alumno => alumno.ID == idAlumno);

            return alumno;
        }

        /// <summary>
        /// Busca alumnos por nombre o matrícula
        /// </summary>
        /// <param name="cadenaDeBusqueda"></param>
        /// <param name="context"></param>
        /// <returns><see cref="List{Alumno}"/> Con los alumnos encontrados o vacío si no encontro ninguno</returns>
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
