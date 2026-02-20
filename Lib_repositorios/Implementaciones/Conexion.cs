using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        // si desea, puede continuar con esta parte, creo que aqui se hace la conexion ya que se llama a los datos en especifico
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //          Ventas   
            modelBuilder.Entity<DetalleVentas>()
                .HasOne(r => r._Producto)
                .WithMany()
                .HasForeignKey(r => r.Producto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DetalleVentas>()
                .HasOne(r => r._Cantidad)
                .WithMany()
                .HasForeignKey(r => r.Cantidad)
                .OnDelete(DeleteBehavior.Cascade);

            //              PAGOS 
            modelBuilder.Entity<Pagos>()
                .HasOne(p => p._Monto)
                .WithMany()
                .HasForeignKey(p => p.Monto)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pagos>()
    .HasOne(p => p.Metodo_pago)
    .WithMany()
    .HasForeignKey(p => p.Metodo_pago)
    .OnDelete(DeleteBehavior.Cascade);

            //          INVENTARIOS 
            modelBuilder.Entity<Inventarios>()
                .HasOne(i => i._Finca)
                .WithMany()
                .HasForeignKey(i => i.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            //       MANTENIMIENTOS 
            modelBuilder.Entity<Mantenimientos>()
                .HasOne(m => m._Finca)
                .WithMany()
                .HasForeignKey(m => m.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            //          RESEÑAS 
            modelBuilder.Entity<Reseñas>()
                .HasOne(r => r._Finca)
                .WithMany()
                .HasForeignKey(r => r.Finca)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reseñas>()
                .HasOne(r => r._Cliente)
                .WithMany()
                .HasForeignKey(r => r.Cliente)
                .OnDelete(DeleteBehavior.Cascade);

            //       RESERVA SERVICIOS 
            modelBuilder.Entity<ReservaServicios>()
                .HasOne(rs => rs._Reserva)
                .WithMany()
                .HasForeignKey(rs => rs.Reserva)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReservaServicios>()
                .HasOne(rs => rs._Servicio)
                .WithMany()
                .HasForeignKey(rs => rs.Servicio)
                .OnDelete(DeleteBehavior.Cascade);

            //      RESERVA PROMOCIONES 
            modelBuilder.Entity<ReservaPromociones>()
                .HasOne(rp => rp._Reserva)
                .WithMany()
                .HasForeignKey(rp => rp.Reserva)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReservaPromociones>()
                .HasOne(rp => rp._Promocion)
                .WithMany()
                .HasForeignKey(rp => rp.Promocion)
                .OnDelete(DeleteBehavior.Cascade);

            //          TAREAS 
            modelBuilder.Entity<Tareas>()
                .HasOne(t => t._Empleado)
                .WithMany()
                .HasForeignKey(t => t.Empleado)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tareas>()
                .HasOne(t => t._Finca)
                .WithMany()
                .HasForeignKey(t => t.Finca)
                .OnDelete(DeleteBehavior.Cascade);

        }

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
                    .HasConversion(
                        v => v.ToString(), // Enum → string
                        v => (TipoRol)Enum.Parse(typeof(TipoRol), v) // string → Enum
                    )
                    .HasMaxLength(50)
                    .IsRequired();
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.Property(p => p.Metodo_pago)
                    .HasConversion<string>()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Carritos>(entity =>
            {
                entity.HasOne(c => c.ClienteRef)
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