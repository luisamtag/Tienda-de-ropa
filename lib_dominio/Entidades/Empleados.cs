using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public class Empleados
    {
        [Key]public int Id { get; set; }

        public int Usuario { get; set; }
        public String? Cargo { get; set; }
        public decimal Salario { get; set; }
        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
