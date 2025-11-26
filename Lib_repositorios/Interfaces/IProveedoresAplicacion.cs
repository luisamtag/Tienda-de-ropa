using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IProveedoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Proveedores> PorNombre(Proveedores? entidad);
        List<Proveedores> Listar();
        Proveedores? Guardar(Proveedores? entidad);
        Proveedores? Modificar(Proveedores? entidad);
        Proveedores? Borrar(Proveedores? entidad);
    }
}
