using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVVM.Models
{
    public class LGAC
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<LGAC> ObtenerTodos(ApplicationDbContext context)
        {
            List<LGAC> lgacs = context.LGACs.ToList();
            return lgacs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="context"></param>
        /// <returns>La <see cref="LGAC"/> por id o null si no es encontrada.</returns>
        public LGAC ObtenerPorID(int id, ApplicationDbContext context)
        {
            LGAC lgac = new LGAC();
            lgac = context.LGACs.Find(id);

            return lgac;
        }
    }
}
