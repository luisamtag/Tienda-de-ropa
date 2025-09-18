using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int Producto { get; set; }
        public int Stock_actual { get; set; }
        public int Stock_minimo { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
    }
}
