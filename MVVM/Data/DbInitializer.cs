using MVVM.Models;
using System.Linq;

namespace MVVM.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Alumnos.Any())
            {
                var alumnos = new Alumno[]
            {
                new Alumno() { Nombre = "CORDERO-CAVA SALVADOR ", CorreoElectronico = "salvador@correo.com", Matricula = "S01010101" },
                new Alumno() { Nombre = "VALLE-PALOMINO ANA BELEN ", CorreoElectronico = "ana@correo.com", Matricula = "S01010102" },
                new Alumno() { Nombre = "GALDON-BORJA EMILIO ", CorreoElectronico = "emilio@correo.com", Matricula = "S01010103" }
            };

                context.Alumnos.AddRange(alumnos);
                context.SaveChanges();
            }

            if (!context.SinodalesDelTrabajo.Any())
            {
                var sinodales = new SinodalDelTrabajo[]
                {
                    new SinodalDelTrabajo() { Nombre = "SERRAT-SALGUEIRO ANTONIO", CorreoElectronico = "santonio@correo.com", Organizacion = "UV FEI", Telefono = "1111111111"},
                    new SinodalDelTrabajo() { Nombre = "QUERO-NAVAS FELIX", CorreoElectronico = "qfelix@correo.com", Organizacion = "UV FEI", Telefono = "1111111112"},
                    new SinodalDelTrabajo() { Nombre = "AGULLO-BERNAL REYNALDO", CorreoElectronico = "areynaldo@correo.com", Organizacion = "UV FEI", Telefono = "1111111113"}
                };

                context.SinodalesDelTrabajo.AddRange(sinodales);
                context.SaveChanges();
            }

            if (!context.Integrantes.Any())
            {
                var integrantes = new Integrante[]
                {
                    new Integrante() { Nombre = "SALES-GAYA LUCIO", NumeroDePersonal = "NP000001", TipoDeIntegrante = TipoDeIntegrante.Integrante},
                    new Integrante() { Nombre = "FERRANDIZ-JIMENEZ AMELIA AURELIA", NumeroDePersonal = "NP000002", TipoDeIntegrante = TipoDeIntegrante.Colaborador},
                };

                context.Integrantes.AddRange(integrantes);
                context.SaveChanges();
            }


        }

    }
}
