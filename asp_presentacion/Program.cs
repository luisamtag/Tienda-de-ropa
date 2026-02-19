using asp_presentacion;
using lib_presentaciones.Interfaces;
using lib_presentaciones.Implementaciones;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddScoped<ICarritosPresentacion, CarritosPresentacion>();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<ICategoriaProductosPresentacion, CategoriaProductosPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<ICompraProveedoresPresentacion, CompraProveedoresPresentacion>();
builder.Services.AddScoped<IDetalleCarritosPresentacion, DetalleCarritosPresentacion>();
builder.Services.AddScoped<IDetalleComprasPresentacion, DetalleComprasPresentacion>();
builder.Services.AddScoped<IDetalleVentasPresentacion, DetalleVentasPresentacion>();
builder.Services.AddScoped<IDevolucionesPresentacion, DevolucionesPresentacion>();
builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
builder.Services.AddScoped<IInventariosPresentacion, InventariosPresentacion>();
builder.Services.AddScoped<IPagosPresentacion, PagosPresentacion>();
builder.Services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IVentasPresentacion, VentasPresentacion>();

//var startup = new Startup(builder.Configuration);
//startup.ConfigureServices(builder.Services);

var app = builder.Build();
//startup.Configure(app, app.Environment);
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