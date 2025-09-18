using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class CategoriaProductosPrueba
    {
        private readonly IConexion? iConexion;
        private List<CategoriaProductos>? lista;
        private CategoriaProductos? entidad;

        public CategoriaProductosPrueba()
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
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.CategoriaProductos()!;
            this.iConexion!.CategoriaProductos!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "Camisetas";
            this.entidad.Descripcion = "Camisetass para hombre y muje";
            var entry = this.iConexion!.Entry<CategoriaProductos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Listar()
        {
            this.lista = this.iConexion!.CategoriaProductos!.ToList();
            return lista.Count > 0;
        }
        public bool Borrar()
        {
            this.iConexion!.CategoriaProductos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}
