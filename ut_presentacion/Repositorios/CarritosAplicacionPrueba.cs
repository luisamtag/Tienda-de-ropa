using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_aplicaciones.Implementaciones;
using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class CarritosAplicacionPrueba
    {
        private readonly IConexion? iConexion;
        private readonly CarritosAplicacion? CarritosAplicacion;
        private Carritos? entidad;

        public CarritosAplicacionPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");

            CarritosAplicacion = new CarritosAplicacion(iConexion);
            CarritosAplicacion.Configurar(iConexion.StringConexion!);
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
            var lista = CarritosAplicacion?.Listar();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Carritos()!;
            this.entidad = CarritosAplicacion?.Guardar(this.entidad)!;
            return this.entidad.Id > 0;
        }

        public bool Modificar()
        {
            this.entidad!.Cliente = 2;
            CarritosAplicacion?.Modificar(this.entidad);
            var reloaded = iConexion.Carritos!.Find(this.entidad.Id);
            return reloaded!.Cliente == 2;
        }

        public bool Borrar()
        {
            CarritosAplicacion.Borrar(this.entidad!);
            var gone = iConexion.Carritos!.Find(this.entidad.Id);
            return gone == null;
        }
    }
}
