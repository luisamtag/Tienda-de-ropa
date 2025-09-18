using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Usuarios? Usuarios()
        {
            var entidad = new Usuarios();
            entidad.Nombre = "Pruebas-" + DateTime.Now.ToString("yyyyMMddhhmmss");
            
            entidad.Apellido = "Pruebas";
            
            entidad.Correo = "Pruebas";
            
            entidad.Contraseña = "Pruebas";
            
            entidad.Rol = "no se que poner aqui"; 
            
            return entidad;
       


        }

    }
}