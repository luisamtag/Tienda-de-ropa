
using lib_dominio.Entidades;

namespace lib_presentaciones.Interfaces
{
    
    
        public interface ICarritosPresentacion
        {
            Task<List<Carritos>> Listar();
            Task<List<Carritos>> PorCliente(Carritos? entidad);
            Task<Carritos?> Guardar(Carritos? entidad);
            Task<Carritos?> Modificar(Carritos? entidad);
            Task<Carritos?> Borrar(Carritos? entidad);
        }
    
}
