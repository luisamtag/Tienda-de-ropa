
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{


    public interface IDetalleComprasPresentacion
    {
        Task<List<DetalleCompras>> Listar();
        Task<List<DetalleCompras>> PorCompraProveedor(DetalleCompras? entidad);
        Task<DetalleCompras?> Guardar(DetalleCompras? entidad);
        Task<DetalleCompras?> Modificar(DetalleCompras? entidad);
        Task<DetalleCompras?> Borrar(DetalleCompras? entidad);
    }

}