
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{


    public interface ICompraProveedoresPresentacion
    {
        Task<List<CompraProveedores>> Listar();
        Task<List<CompraProveedores>> PorProveedor(CompraProveedores? entidad);
        Task<CompraProveedores?> Guardar(CompraProveedores? entidad);
        Task<CompraProveedores?> Modificar(CompraProveedores? entidad);
        Task<CompraProveedores?> Borrar(CompraProveedores? entidad);
    }

}