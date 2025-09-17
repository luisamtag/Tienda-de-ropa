using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int id { get; set; }

        public String? nombre { get; set; }
        public String? apellido { get; set; }
        public String? correo { get; set; }
        public String? contraseña { get; set; }
        public String? rol { get; set; }
    }
}
