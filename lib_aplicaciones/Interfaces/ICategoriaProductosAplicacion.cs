using lib_dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_aplicaciones.Interfaces
{
    public interface ICategoriaProductosAplicacion
    {
        void Configurar(string StringConexion);
        List<CategoriaProductos> Listar();
        CategoriaProductos? Guardar(CategoriaProductos? entidad);
        CategoriaProductos? Modificar(CategoriaProductos? entidad);
        CategoriaProductos? Borrar(CategoriaProductos? entidad);
    }
}
