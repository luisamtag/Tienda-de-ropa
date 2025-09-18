using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Devoluciones
    {
        public int Id { get; set; }
        public int Venta { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public String? Motivo { get; set; }
        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
    }
}
