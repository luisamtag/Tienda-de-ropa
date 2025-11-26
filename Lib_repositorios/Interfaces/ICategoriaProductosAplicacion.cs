using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_repositorios.Interfaces
{
    public interface ICategoriaProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<CategoriaProductos> PorNombre(CategoriaProductos? entidad);
        List<CategoriaProductos> Listar();
        CategoriaProductos? Guardar(CategoriaProductos? entidad);
        CategoriaProductos? Modificar(CategoriaProductos? entidad);
        CategoriaProductos? Borrar(CategoriaProductos? entidad);
    }
}
