using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class DetalleCarritos
    {
        [Key]public int Id { get; set; }
        public int Carrito { get; set; }
        public int Producto { get; set; }
        public int Cantidad { get; set; }
        [ForeignKey("Carrito")] public Carritos? _Carrito { get; set; }
        [ForeignKey("Producto")] public Productos? _Producto { get; set; }
    }
}
