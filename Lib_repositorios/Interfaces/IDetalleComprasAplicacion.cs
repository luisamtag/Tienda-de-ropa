using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IDetalleComprasAplicacion
    {
        void Configurar(string StringConexion);
        List<DetalleCompras> Listar();
        DetalleCompras? Guardar(DetalleCompras? entidad);
        DetalleCompras? Modificar(DetalleCompras? entidad);
        DetalleCompras? Borrar(DetalleCompras? entidad);
    }
}
