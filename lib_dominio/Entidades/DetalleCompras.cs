using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class DetalleCompras
    {
        [Key]public int Id { get; set; }
        public int CompraProveedor { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        [ForeignKey("CompraProveedor")] public CompraProveedores? _CompraProveedor { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }
    }
}
