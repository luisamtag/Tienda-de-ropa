using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    public enum TipoRol
    {
        Cliente,
        Empleado,
        Administrador
    }
    public class Usuarios
    {
        [Key]public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Apellido { get; set; }
        public String? Correo { get; set; }
        public String? Contraseña { get; set; }
       
        [Required(ErrorMessage = "El rol es requerido")]
        public TipoRol Rol { get; set; }
    }
}
