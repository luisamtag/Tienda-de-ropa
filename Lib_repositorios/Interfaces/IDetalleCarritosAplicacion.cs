using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IDetalleCarritosAplicacion
    {
        void Configurar(string StringConexion);
        List<DetalleCarritos> PorProducto(DetalleCarritos? entidad);
        List<DetalleCarritos> Listar();
        DetalleCarritos? Guardar(DetalleCarritos? entidad);
        DetalleCarritos? Modificar(DetalleCarritos? entidad);
        DetalleCarritos? Borrar(DetalleCarritos? entidad);
    }
}
