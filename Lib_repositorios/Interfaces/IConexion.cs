using Azure;
using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using lib_dominio.Nucleo;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Carritos>? Carritos { get; set; }

        DbSet<CategoriaProductos>? CategoriaProductos { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<CompraProveedores>? CompraProveedores { get; set; }
        DbSet<DetalleCarritos>? DetalleCarritos { get; set; }
        DbSet<DetalleCompras>? DetalleCompras { get; set; }
        DbSet<DetalleVentas>? DetalleVentas { get; set; }
        DbSet<Devoluciones>? Devoluciones { get; set; }
        DbSet<Empleados>? Empleados { get; set; }
        DbSet<Inventarios>? Inventarios { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Usuarios>? Usuarios { get; set; }
        DbSet<Ventas>? Ventas { get; set; }



        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}