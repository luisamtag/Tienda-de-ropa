using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface IInventariosAplicacion
    {
        void Configurar(string StringConexion);
        List<Inventarios> PorProducto(Inventarios? entidad);
        List<Inventarios> Listar();
        Inventarios? Guardar(Inventarios? entidad);
        Inventarios? Modificar(Inventarios? entidad);
        Inventarios? Borrar(Inventarios? entidad);
    }
}