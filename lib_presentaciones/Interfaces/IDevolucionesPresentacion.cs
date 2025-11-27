
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{


    public interface IDevolucionesPresentacion
    {
        Task<List<Devoluciones>> Listar();
        Task<List<Devoluciones>> PorVenta(Devoluciones? entidad);
        Task<Devoluciones?> Guardar(Devoluciones? entidad);
        Task<Devoluciones?> Modificar(Devoluciones? entidad);
        Task<Devoluciones?> Borrar(Devoluciones? entidad);
    }

}