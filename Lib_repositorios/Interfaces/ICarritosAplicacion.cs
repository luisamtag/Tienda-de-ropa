using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ICarritosAplicacion
    {
        void Configurar(string StringConexion);
        List<Carritos> Listar();
        Carritos? Guardar(Carritos? entidad);
        Carritos? Modificar(Carritos? entidad);
        Carritos? Borrar(Carritos? entidad);
    }
}
