
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{


    public interface IDetalleCarritosPresentacion
    {
        Task<List<DetalleCarritos>> Listar();
        Task<List<DetalleCarritos>> PorProducto(DetalleCarritos? entidad);
        Task<DetalleCarritos?> Guardar(DetalleCarritos? entidad);
        Task<DetalleCarritos?> Modificar(DetalleCarritos? entidad);
        Task<DetalleCarritos?> Borrar(DetalleCarritos? entidad);
    }

}
