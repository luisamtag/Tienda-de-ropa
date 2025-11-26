using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ICarritosAplicacion
    {
        void Configurar(string StringConexion);
        List<Carritos> PorCliente(Carritos? entidad);
        List<Carritos> Listar();
        Carritos? Guardar(Carritos? entidad);
        Carritos? Modificar(Carritos? entidad);
        Carritos? Borrar(Carritos? entidad);
    }
}
