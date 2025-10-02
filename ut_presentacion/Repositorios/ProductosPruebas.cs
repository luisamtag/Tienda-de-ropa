using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
[TestClass]
public class ProductosPruebas
    {
    private readonly IConexion? iConexion;
    private List<Productos>? lista;
    private Productos? entidad;

    public ProductosPruebas()
    {
        iConexion = new Conexion();
        iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
    }

    [TestMethod]
    public void Ejecutar()
    {
        Assert.AreEqual(true, Guardar());
        Assert.AreEqual(true, Modificar());
        Assert.AreEqual(true, Listar());
        Assert.AreEqual(true, Borrar());
    }

    public bool Listar()
    {
        this.lista = this.iConexion!.Productos!.ToList();
        return lista.Count > 0;
    }

        public bool Guardar()
        {
            // Primero aseguro que haya al menos una categoría en la BD
            var categoria = this.iConexion!.CategoriaProductos!.FirstOrDefault();
            if (categoria == null)
            {
                // Si no existe, creo una
                categoria = new CategoriaProductos
                {
                    Nombre = "CategoriaPrueba"
                };
                this.iConexion!.CategoriaProductos!.Add(categoria);
                this.iConexion!.CategoriaProductos!.Add(categoria);
                this.iConexion.SaveChanges();
            }

            // Ahora sí, creo el producto usando esa categoría existente
            this.entidad = new Productos
            {
                Nombre = "Zapatos prueba",
                Precio = 120000,
                Stock = 10,
                Categoria = categoria.Id
            };

            this.iConexion.Productos!.Add(this.entidad);
            this.iConexion.SaveChanges();

            return this.entidad.Id > 0;
        }

        public bool Modificar()
    {
        this.entidad!.Color = "rojo";
        var entry = this.iConexion!.Entry<Productos>(this.entidad);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();
        return true;
    }

    public bool Borrar()
    {
        this.iConexion!.Productos!.Remove(this.entidad!);
        this.iConexion!.SaveChanges();
        return true;
    }
}
}
