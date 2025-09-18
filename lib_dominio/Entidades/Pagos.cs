using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public enum MetodoP
    {
        Efectivo,
        Tarjeta_Credito,
        Tarjeta_Debito,
        Transferencia,
        Paypal
    }

    public class Pagos
    {
        [Key]public int Id { get; set; }
        public string? Venta { get; set; }
        public Decimal Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public MetodoP Metodo_pago { get; set; }
        [ForeignKey("Venta")] public Ventas? _Venta { get; set; }
    }

}
