using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lib_dominio.Entidades;
using lib_dominio.Nucleo;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Usuarios? Usuarios()
        {
            var entidad = new Usuarios();
            entidad.Nombre = "Juan-" + DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
            entidad.Apellido = "Perez";
            entidad.Correo = "juan@email.com";
            entidad.Contraseña = "pass123";
            entidad.Rol = TipoRol.Cliente;
            return entidad;
        }

        public static Clientes? Clientes() 
        {
            var entidad = new Clientes();
            entidad.Telefono = "3001234567";
            entidad.Direccion = "Calle 10 #20-30";
            return entidad;
        }
        public static Empleados? Empleados() 
        {
            var entidad = new Empleados();
            entidad.Cargo = "Vendedor";
            entidad.Salario = 12000000;
            return entidad;
        }
        public static CategoriaProductos? CategoriaProductos() 
        {
            var entidad = new CategoriaProductos();
            entidad.Nombre = "Camisetas";
            entidad.Descripcion = "Camisetas para hombre y mujer";
            return entidad;
        }
        public static Proveedores? Proveedores()
        {
            var entidad = new Proveedores();
            entidad.Nombre = "Textiles SA";
            entidad.Telefono = "6015551234";
            entidad.Direccion = "Zona Industrial 1";
            entidad.Correo = "ventas@textiles.com";
            return entidad;
        }
        public static Productos? Productos() 
        {
            var entidad = new Productos();
            entidad.Nombre = "Camiseta Básica";
            entidad.Descripcion = "Camiseta de algodón";
            entidad.Talla = "M";
            entidad.Color = "Blanco";
            entidad.Precio = 25000;
            entidad.Stock = 50;
            return entidad;

        }
        public static CompraProveedores? CompraProveedores() 
        {
            var entidad = new CompraProveedores();
            entidad.Proveedor = 1;
            entidad.Fecha = DateTime.Parse("2024-08-15");
            entidad.Total = 15000000;
            return entidad;
        }
        public static DetalleCompras? DetalleCompras() 
        {
            var entidad = new DetalleCompras();
            entidad.Producto = 1;
            entidad.Cantidad = 50;
            entidad.Precio = 20000;
            return entidad;
        }
        public static Ventas? Ventas() 
        {
            var entidad = new Ventas();
            entidad.Cliente = 1;
            entidad.Empleado = 1 ;
            entidad.Fecha = DateTime.Parse("2024-09-10");
            entidad.Total = 105000;
            return entidad;
        }
        public static DetalleVentas? DetalleVentas() 
        {
            var entidad = new DetalleVentas();
            entidad.Venta = 1;
            entidad.Producto = 1;
            entidad.Cantidad = 2;
            entidad.Precio = 25000;
            return entidad;
        }
        public static Pagos? Pagos() 
        {
            var entidad = new Pagos();
            entidad.Venta = "1";
            entidad.Metodo_pago = MetodoP.Efectivo;
            entidad.Monto = 105000;
            entidad.Fecha = DateTime.Parse("2024-09-10");
            return entidad;
        }
        public static Carritos? Carritos() 
        {
            var entidad = new Carritos();
            entidad.Cliente = 1;
            entidad.Fecha = DateTime.Parse("2024-09-15");
            return entidad;
        }
        public static DetalleCarritos? DetalleCarritos() 
        {
            var entidad = new DetalleCarritos();
            entidad.Carrito = 1;
            entidad.Producto = 1;
            entidad.Cantidad = 2;
            return entidad;
        }
        public static Inventarios? Inventarios() 
        {
            var entidad = new Inventarios();
            entidad.Producto = 1;
            entidad.Stock_actual = 50;
            entidad.Stock_minimo = 10;
            return entidad;

        }
        public static Devoluciones? Devoluciones() 
        {
            var entidad = new Devoluciones();
            entidad.Venta = 1;
            entidad.Fecha = DateTime.Parse("2024-09-11");
            entidad.Motivo = "Talla incorrecta";
            return entidad;
        }
    }
}