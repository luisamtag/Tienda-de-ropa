using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ICategoriaProductosPresentacion
    {
        Task<List<CategoriaProductos>> Listar();
        Task<List<CategoriaProductos>> PorNombre(CategoriaProductos? entidad);
        Task<CategoriaProductos?> Guardar(CategoriaProductos? entidad);
        Task<CategoriaProductos?> Modificar(CategoriaProductos? entidad);
        Task<CategoriaProductos?> Borrar(CategoriaProductos? entidad);
    }
}
