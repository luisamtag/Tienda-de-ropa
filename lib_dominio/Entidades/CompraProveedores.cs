using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class CompraProveedores
    {
        public int Id { get; set; }
        public int Proveedor { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public Decimal Total { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
    }
}
