using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
   public class Proveedores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Direccion { get; set; }
        public String? Correo { get; set; }
    }
}
