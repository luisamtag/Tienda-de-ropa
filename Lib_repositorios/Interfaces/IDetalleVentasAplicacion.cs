using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IDetalleVentasAplicacion
    {
        void Configurar(string StringConexion);
        List<DetalleVentas> PorVenta(DetalleVentas? entidad);
        List<DetalleVentas> Listar();
        DetalleVentas? Guardar(DetalleVentas? entidad);
        DetalleVentas? Modificar(DetalleVentas? entidad);
        DetalleVentas? Borrar(DetalleVentas? entidad);
    }
}