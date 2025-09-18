using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public String? Telefono { get; set; }
        public String? Direccion { get; set; }
        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
