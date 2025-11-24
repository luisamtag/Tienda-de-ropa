using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface IDetalleCarritosAplicacion
    {
        void Configurar(string StringConexion);
        List<DetalleCarritos> Listar();
        DetalleCarritos? Guardar(DetalleCarritos? entidad);
        DetalleCarritos? Modificar(DetalleCarritos? entidad);
        DetalleCarritos? Borrar(DetalleCarritos? entidad);
    }
}
