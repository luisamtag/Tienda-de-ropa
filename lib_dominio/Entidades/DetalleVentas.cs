using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class DetalleVentas
    {
        public int Id { get; set; }
        public int Venta { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
    }
}
