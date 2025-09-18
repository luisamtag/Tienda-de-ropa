using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Ventas
    {
        [Key]public int Id { get; set; }
        public int Cliente { get; set; }
        public int Empleado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Decimal Total { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Empleado")] public Empleados? _Empleado { get; set; }
    }
}
