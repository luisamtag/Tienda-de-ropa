using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class EmpleadosPrueba
    {
        private readonly IConexion? iConexion;
        private List<Empleados>? lista;
        private Empleados? entidad;

        public EmpleadosPrueba()
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
            // Crear un Usuario con rol Empleado
            var usuario = new Usuarios
            {
                Nombre = "EmpleadoPrueba",
                Apellido = "Temporal",
                Correo = "empleado" + DateTime.Now.ToString("yyyyMMddHHmmss") + "@test.com",
                Contraseña = "12345",
                Rol = TipoRol.Empleado   // Usamos el enum, no string
            };

            this.iConexion!.Usuarios!.Add(usuario);
            this.iConexion.SaveChanges();

            // Guardar el Empleado asociado al Usuario creado
            this.entidad = new Empleados
            {
                Usuario = usuario.Id,   // Aquí ya tienes el ID real
                Cargo = "Vendedor",
                Salario = 1200000
            };

            this.iConexion.Empleados!.Add(this.entidad);
            this.iConexion.SaveChanges();

            return this.entidad.Id > 0;
        }



        public bool Modificar()
        {
            this.entidad!.Cargo = "Vendedor";
            this.entidad.Salario = 1200000;
            var entry = this.iConexion!.Entry<Empleados>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Listar()
        {
            this.lista = this.iConexion!.Empleados!.ToList();
            return lista.Count > 0;
        }
        public bool Borrar()
        {
            if (this.entidad != null)
            {
                var usuario = this.iConexion!.Usuarios!
                    .FirstOrDefault(u => u.Id == this.entidad.Usuario);

                if (usuario != null)
                {
                    this.iConexion!.Usuarios.Attach(usuario); 
                    this.iConexion.Usuarios.Remove(usuario);
                }

                this.iConexion!.Empleados.Attach(this.entidad);
                this.iConexion.Empleados.Remove(this.entidad);
            }

            this.iConexion!.SaveChanges();
            return true;
        }





    }
}