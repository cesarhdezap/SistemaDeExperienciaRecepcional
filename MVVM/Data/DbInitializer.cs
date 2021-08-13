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

            if (!context.Profesores.Any())
            {
                var profesores = new Profesor[]
                {
                    new Profesor() {Nombre = "OSCAR MONTIEL CORDOBA", NombreDeUsuario = "omontielc", NumeroDePersonal = "01020304"}
                };
                context.Profesores.AddRange(profesores);
                context.SaveChanges();
            }
            
            if(!context.ExperienciasEducativas.Any())
            {
                var experienciasEducativas = new ExperienciaEducativa[]
                {
                    new ExperienciaEducativa() {
                        Nombre = "Proyecto Guiado",
                        EstadoAbierto = true,
                        NRC = "38081",
                        Periodo = "AGO21 - FEB22",
                        Seccion = "1",
                        Alumnos = context.Alumnos.ToList(),
                        Profesor = context.Profesores.FirstOrDefault()
                    }
                };
                context.ExperienciasEducativas.AddRange(experienciasEducativas);
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

            if (!context.ProyectoDeInvestigaciones.Any())
            {
                var proyectos = new ProyectoDeInvestigacion[]
                {
                    new ProyectoDeInvestigacion() {FechaDeInicio = System.DateTime.Now, Nombre = "Desarrollo de Software con una Arquitectura de Microservicios"},
                    new ProyectoDeInvestigacion() {FechaDeInicio = System.DateTime.Now, Nombre = "Contribución del Perfil Psico-Endrocrinológico al Diagnóstico de la Mujer al Diagnóstico Serológico y Radiológico temprano del Carcinoma Duetal de la Mama"},
                    new ProyectoDeInvestigacion() {FechaDeInicio = System.DateTime.Now, Nombre = "Ninguno"}
                };
                context.ProyectoDeInvestigaciones.AddRange(proyectos);
                context.SaveChanges();
            }

            if (!context.PLADEAFEIs.Any())
            {
                var pladeas = new PLADEAFEI[]
                {
                    new PLADEAFEI() {Accion = "3. Contar con programas educativos reconocidos por su calidad", ObjetivoGeneral = "OG: 3", Periodo = "FEB 21 - JUN 21"},
                    new PLADEAFEI() {Accion = "4. Investigación, innovación y desarrollo tecnológico", ObjetivoGeneral = "OG: 4", Periodo = "FEB 21 - JUN 21"},
                };
                context.PLADEAFEIs.AddRange(pladeas);
                context.SaveChanges();
            }

            if (!context.Vinculaciones.Any())
            {
                var vinculaciones = new Vinculacion[]
                {
                    new Vinculacion() {FechaDeInicioDeConvenio = new System.DateTime(2016,1, 26), OrganizacionVinculada = "Laboratorio de Mamíferos Marinos (LabMMar, IIB-ICIMAP)", CopiaConvenio = 0},
                    new Vinculacion() {FechaDeInicioDeConvenio = new System.DateTime(2016,1, 26), OrganizacionVinculada = "Instituto de Ciencias Marinas y Pesquerías (ICIMAP)", CopiaConvenio = 0},
                };
                context.Vinculaciones.AddRange(vinculaciones);
                context.SaveChanges();
            }

            if (!context.LGACs.Any())
            {
                var lgacs = new LGAC[]
                {
                    new LGAC() {Nombre = "Tecnologías de software", Descripcion = "LGAC de TS"},
                    new LGAC() {Nombre = "Gestión, Modelado y Desarrollo de Software", Descripcion = "LGAC de GMDS"},
                    new LGAC() {Nombre = "Instituto de Ciencias Marinas y Pesquerías", Descripcion = "LGAC de ICMP"},
                    new LGAC() {Nombre = "Instituto de Investigaciones Biológicas", Descripcion = "LGAC de IIB"},
                };
                context.LGACs.AddRange(lgacs);
                context.SaveChanges();
            }

        }

    }
}
