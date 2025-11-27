
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{


    public interface IDetalleVentasPresentacion
    {
        Task<List<DetalleVentas>> Listar();
        Task<List<DetalleVentas>> PorVenta(DetalleVentas? entidad);
        Task<DetalleVentas?> Guardar(DetalleVentas? entidad);
        Task<DetalleVentas?> Modificar(DetalleVentas? entidad);
        Task<DetalleVentas?> Borrar(DetalleVentas? entidad);
    }

}