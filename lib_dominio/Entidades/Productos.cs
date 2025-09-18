using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
   public class Productos
    {
        public int Id { get; set; }
        public int Categoria { get; set; }
        public String? Nombre { get; set; }
        public String? Descripcion { get; set; }
        public String? Talla { get; set; }
        public String? Color { get; set; }
        public Decimal Precio { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Categoria")] public CategoriaProductos? _Categoria { get; set; }
    }
}
