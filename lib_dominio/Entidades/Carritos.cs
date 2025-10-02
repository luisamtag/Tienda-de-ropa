using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Carritos
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ClienteRef))]
        public int Cliente { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Clientes ClienteRef { get; set; } = null!;
    }
}
