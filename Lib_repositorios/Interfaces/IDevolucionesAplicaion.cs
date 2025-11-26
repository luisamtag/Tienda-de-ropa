using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IDevolucionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Devoluciones> PorVenta(Devoluciones? entidad);
        List<Devoluciones> Listar();
        Devoluciones? Guardar(Devoluciones? entidad);
        Devoluciones? Modificar(Devoluciones? entidad);
        Devoluciones? Borrar(Devoluciones? entidad);
    }
}