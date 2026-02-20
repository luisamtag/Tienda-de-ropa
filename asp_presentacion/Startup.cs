using lib_presentaciones.Implementaciones; 
using lib_presentaciones.Interfaces; 
 
namespace asp_presentacion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            // Presentaciones 
            services.AddScoped<ICarritosPresentacion, CarritosPresentacion>();
            services.AddScoped<ICategoriaProductosPresentacion, CategoriaProductosPresentacion>();
            services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
            services.AddScoped<ICompraProveedoresPresentacion, CompraProveedoresPresentacion>();
            services.AddScoped<IDetalleCarritosPresentacion, DetalleCarritosPresentacion>();
            services.AddScoped<IDetalleComprasPresentacion, DetalleComprasPresentacion>();
            services.AddScoped<IDetalleVentasPresentacion, DetalleVentasPresentacion>();
            services.AddScoped<IDevolucionesPresentacion, DevolucionesPresentacion>();
            services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
            services.AddScoped<IInventariosPresentacion, InventariosPresentacion>();
            services.AddScoped<IPagosPresentacion, PagosPresentacion>();
            services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
            services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
            services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
            services.AddScoped<IVentasPresentacion, VentasPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.MapRazorPages();
            app.Run();
        }
    }
}