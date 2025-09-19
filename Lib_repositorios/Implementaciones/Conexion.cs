using Azure;
using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using static lib_dominio.Nucleo.Enumerables;

namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.Property(u => u.Rol)
                        .IsRequired()
                        .HasMaxLength(50);
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.Property(p => p.Metodo_pago)
                    .HasConversion<string>()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Carritos>(entity =>
            {
                entity.HasOne(c => c.ClienteNavigation)
                      .WithMany()
                      .HasForeignKey(c => c.Cliente);
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Carritos>? Carritos { get; set; }

        public DbSet<CategoriaProductos>? CategoriaProductos { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<CompraProveedores>? CompraProveedores { get; set; }
        public DbSet<DetalleCarritos>? DetalleCarritos { get; set; }
        public DbSet<DetalleCompras>? DetalleCompras { get; set; }
        public DbSet<DetalleVentas>? DetalleVentas { get; set; }
        public DbSet<Devoluciones>? Devoluciones { get; set; }
        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }

        public DbSet<Productos>? Productos { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }

        public DbSet<Ventas>? Ventas { get; set; }

    }
}