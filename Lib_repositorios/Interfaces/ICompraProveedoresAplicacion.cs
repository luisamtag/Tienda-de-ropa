using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ICompraProveedoresAplicacion
    {
        void Configurar(string StringConexion);
        List<CompraProveedores> Listar();
        CompraProveedores? Guardar(CompraProveedores? entidad);
        CompraProveedores? Modificar(CompraProveedores? entidad);
        CompraProveedores? Borrar(CompraProveedores? entidad);
    }
}
