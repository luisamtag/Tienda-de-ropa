using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
   public class Carritos
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public int Empleado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
