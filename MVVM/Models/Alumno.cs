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
            var alumno = context.Alumnos.FirstOrDefault(alumno => alumno.ID == idAlumno);
            return alumno;
        }
    }

    
}
