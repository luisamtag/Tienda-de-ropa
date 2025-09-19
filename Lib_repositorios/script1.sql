CREATE DATABASE TiendaRopa;
GO

USE TiendaRopa;
GO

CREATE TABLE [Usuarios] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NOT NULL,
    [Apellido] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(150) UNIQUE NOT NULL,
    [Contraseña] NVARCHAR(255) NOT NULL,
    [Rol] NVARCHAR(50) NOT NULL CHECK (rol IN ('Cliente', 'Empleado', 'Administrador'))
);

CREATE TABLE [Clientes] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Usuario] INT NOT NULL REFERENCES [Usuarios] ([Id]),
    [Telefono] NVARCHAR(20),
    [Direccion] NVARCHAR(255),
    
);

CREATE TABLE [Empleados] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Usuario] INT NOT NULL REFERENCES [Usuarios] ([Id]),
    [cargo] NVARCHAR(100) NOT NULL,
    [salario] DECIMAL(10,2) NOT NULL,
);

CREATE TABLE [CategoriaProductos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NOT NULL UNIQUE,
    [Descripcion] NVARCHAR(255)
);

CREATE TABLE [Proveedores] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(150) NOT NULL,
    [Telefono] NVARCHAR(20),
    [Direccion] NVARCHAR(255),
    [Correo] NVARCHAR(150)
);

CREATE TABLE [Productos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Categoria] INT NOT NULL REFERENCES [CategoriaProductos] ([Id]),
    [Nombre] NVARCHAR(150) NOT NULL,
    [Descripcion] NVARCHAR(500),
    [Talla] NVARCHAR(10),
    [Color] NVARCHAR(50),
    [Precio] DECIMAL(10,2) NOT NULL,
    [Stock] INT NOT NULL DEFAULT 0,
);

CREATE TABLE [CompraProveedores] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Proveedor] INT NOT NULL REFERENCES [Proveedores] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Total] DECIMAL(12,2) NOT NULL,
);

CREATE TABLE [DetalleCompras] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [CompraProveedor] INT NOT NULL REFERENCES [CompraProveedores] ([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(10,2) NOT NULL,
);

CREATE TABLE [Ventas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Cliente] INT NOT NULL REFERENCES [Clientes] ([Id]),
	[Empleado] INT NOT NULL REFERENCES [Empleados] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Total] DECIMAL(12,2) NOT NULL,
);

CREATE TABLE [DetalleVentas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas] ([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(10,2) NOT NULL,
);

CREATE TABLE [Pagos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas] ([Id]),
    [Metodo_pago] NVARCHAR(50) NOT NULL CHECK (metodo_pago IN ('Efectivo', 'Tarjeta_Credito', 'Tarjeta_Debito', 'Transferencia', 'PayPal')),
    [Monto] DECIMAL(12,2) NOT NULL,
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE [Carritos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Cliente] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
);

CREATE TABLE [DetalleCarritos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Carrito] INT NOT NULL REFERENCES [Carritos] ([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Cantidad] INT NOT NULL,
);

CREATE TABLE [Inventarios] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Stock_actual] INT NOT NULL DEFAULT 0,
    [Stock_minimo] INT NOT NULL DEFAULT 5,
);

CREATE TABLE [Devoluciones] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Motivo] NVARCHAR(500) NOT NULL,
);

-- 1. Tabla Usuario
INSERT INTO [Usuarios]([Nombre], [Apellido], [Correo], [Contraseña], [Rol]) VALUES
('Juan', 'Pérez', 'juan@email.com', 'pass123', 'Cliente'),
('María', 'García', 'maria@email.com', 'pass456', 'Empleado'),
('Carlos', 'López', 'carlos@email.com', 'pass789', 'Cliente'),
('Ana', 'Rodríguez', 'ana@email.com', 'pass012', 'Empleado'),
('Luis', 'Martínez', 'luis@email.com', 'pass345', 'Cliente');

-- 2. Tabla Cliente
INSERT INTO [Clientes] ([Usuario],[Telefono], [Direccion]) VALUES
(1,'3001234567', 'Calle 10 #20-30'),
(2, '3009876543', 'Carrera 15 #25-35'),
(3, '3157894561', 'Avenida 80 #45-55');

-- Usuarios adicionales para completar 5 clientes
INSERT INTO [Usuarios] ([Nombre], [Apellido], [Correo], [Contraseña], [Rol]) VALUES
('Sandra', 'Vargas', 'sandra@email.com', 'pass678', 'Cliente'),
('Diego', 'Morales', 'diego@email.com', 'pass901', 'Cliente');

INSERT INTO [Clientes] ([Usuario],[Telefono], [Direccion]) VALUES
(6, '3201478523', 'Calle 50 #60-70'),
(7, '3108529637', 'Carrera 30 #40-50');

-- 3. Tabla Empleado
INSERT INTO [Usuarios] ([Nombre], [Apellido], [Correo], [Contraseña], [Rol]) VALUES
('Claudia', 'Jiménez', 'claudia@tienda.com', 'emp123', 'Empleado'),
('Roberto', 'Sánchez', 'roberto@tienda.com', 'emp456', 'Empleado'),
('Liliana', 'Ramírez', 'liliana@tienda.com', 'emp789', 'Empleado');

INSERT INTO [Empleados] ([Usuario], [Cargo], [Salario]) VALUES
(2, 'Vendedor', 1200000),
(4, 'Gerente', 2500000),
(8, 'Cajero', 1100000),
(9, 'Supervisor', 1800000),
(10, 'Inventario', 1400000);

-- 4. Tabla CategoriaProducto
INSERT INTO [CategoriaProductos] ([Nombre], [Descripcion]) VALUES
('Camisetas', 'Camisetas para hombre y mujer'),
('Pantalones', 'Pantalones casuales y formales'),
('Zapatos', 'Calzado deportivo y formal'),
('Accesorios', 'Cinturones y complementos'),
('Chaquetas', 'Chaquetas y abrigos');

-- 5. Tabla Producto
INSERT INTO [Productos] ([Categoria], [Nombre], [Descripcion], [Talla], [Color], [Precio], [Stock]) VALUES
(1,'Camiseta Básica Cotton' ,'Camiseta de algodón', 'M', 'Blanco', 25000, 50),
(2,'Jeans Slim Fit Levis' ,'Pantalón jean', '32', 'Azul', 80000, 30),
(3, 'Tenis Adidas Running','Zapatos para deporte', '42', 'Negro', 150000, 20),
(4, 'Cinturón Cuero Genuino', 'Cinturón de cuero', 'L', 'Café', 60000, 25),
(5, 'Chaqueta Bomber', 'Chaqueta moderna', 'XL', 'Gris', 120000, 15);

-- 6. Tabla Proveedor
INSERT INTO [Proveedores] ([Nombre], [Telefono], [Direccion], [Correo]) VALUES
('Textiles SA', '6015551234', 'Zona Industrial 1', 'ventas@textiles.com'),
('Moda Ltda', '6015559876', 'Centro Comercial 2', 'info@moda.com'),
('Confecciones', '6025554567', 'Parque Industrial 3', 'pedidos@confecciones.com'),
('Calzado Pro', '6015552345', 'Barrio Centro 4', 'contacto@calzado.com'),
('Accesorios Mix', '6015558901', 'Mall Principal 5', 'ventas@accesorios.com');

-- 7. Tabla CompraProveedor
INSERT INTO [CompraProveedores] ([Proveedor], [Fecha], [Total]) VALUES
(1, '2024-08-15', 1500000),
(2, '2024-08-20', 2000000),
(3, '2024-08-25', 1800000),
(4, '2024-09-01', 2200000),
(5, '2024-09-05', 1600000);

-- 8. Tabla DetalleCompra
INSERT INTO [DetalleCompras] ([CompraProveedor], [Producto], [Cantidad], [Precio]) VALUES
(1, 1, 50, 20000),
(2, 2, 30, 70000),
(3, 3, 20, 130000),
(4, 4, 25, 50000),
(5, 5, 15, 100000);

-- 9. Tabla Venta
INSERT INTO [Ventas] ([Cliente], [Empleado], [Fecha], [Total]) VALUES
(2, 1, '2024-09-10', 105000),
(3, 2, '2024-09-11', 80000),
(4, 3, '2024-09-12', 150000),
(5, 4, '2024-09-13', 60000),
(6, 5, '2024-09-14', 120000);

-- 10. Tabla DetalleVenta
INSERT INTO [DetalleVentas] ([Venta], [Producto], [Cantidad], [Precio]) VALUES
(4, 1, 2, 25000),
(5, 2, 1, 80000),
(6, 3, 1, 150000),
(7, 4, 1, 60000),
(8, 5, 1, 120000);

-- 11. Tabla Pago
INSERT INTO [Pagos] ([Venta], [Metodo_pago], [Monto], [Fecha]) VALUES
(4, 'Efectivo', 105000, '2024-09-10'),
(5, 'Tarjeta_Credito', 80000, '2024-09-11'),
(6, 'Tarjeta_Debito', 150000, '2024-09-12'),
(7, 'Transferencia', 60000, '2024-09-13'),
(8, 'PayPal', 120000, '2024-09-14');

-- 12. Tabla Carrito
INSERT INTO [Carritos] ([Cliente], [Fecha]) VALUES
(2, '2024-09-15'),
(3, '2024-09-15'),
(4, '2024-09-15'),
(5, '2024-09-15'),
(6, '2024-09-15');

-- 13. Tabla DetalleCarrito
INSERT INTO [DetalleCarritos] ([Carrito],[Producto], [Cantidad]) VALUES
(3, 1, 2),
(4, 2, 1),
(5, 3, 1),
(6, 4, 3),
(7, 5, 1);

-- 14. Tabla Inventario
INSERT INTO [Inventarios] ([Producto], [Stock_actual], [Stock_minimo]) VALUES
(1, 50, 10),
(2, 30, 8),
(3, 20, 5),
(4, 25, 7),
(5, 15, 3);

-- 15. Tabla Devolucion
INSERT INTO [Devoluciones] ([Venta], [Fecha], [Motivo]) VALUES
(4, '2024-09-11', 'Talla incorrecta'),
(5, '2024-09-12', 'Producto defectuoso'),
(6, '2024-09-13', 'No le gustó'),
(7, '2024-09-14', 'Color equivocado'),
(8, '2024-09-15', 'Llegó tarde');