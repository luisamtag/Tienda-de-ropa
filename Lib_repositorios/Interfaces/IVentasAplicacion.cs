using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IVentasAplicacion
    {
        void Configurar(string StringConexion);
        List<Ventas> PorCliente(Ventas? entidad);

        List<Ventas> Listar();
        Ventas? Guardar(Ventas? entidad);
        Ventas? Modificar(Ventas? entidad);
        Ventas? Borrar(Ventas? entidad);
    }
}
