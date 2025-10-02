-- Crear base de datos
CREATE DATABASE TiendaRopa;
GO

USE TiendaRopa;
GO

-- =========================
-- TABLAS
-- =========================

CREATE TABLE [Usuarios] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NOT NULL,
    [Apellido] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(150) NOT NULL,
    [Contraseña] NVARCHAR(255) NOT NULL,
    [Rol] NVARCHAR(50) NOT NULL CHECK ([Rol] IN ('Cliente', 'Empleado', 'Administrador'))
);

CREATE TABLE [Clientes] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Usuario] INT NOT NULL REFERENCES [Usuarios] ([Id]),
    [Telefono] NVARCHAR(20),
    [Direccion] NVARCHAR(255)
);

CREATE TABLE [Empleados] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Usuario] INT NOT NULL REFERENCES [Usuarios] ([Id]),
    [Cargo] NVARCHAR(100) NOT NULL,
    [Salario] DECIMAL(10,2) NOT NULL
);

CREATE TABLE [CategoriaProductos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Nombre] NVARCHAR(100) NOT NULL,
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
    [Stock] INT NOT NULL DEFAULT 0
);

CREATE TABLE [CompraProveedores] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Proveedor] INT NOT NULL REFERENCES [Proveedores] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Total] DECIMAL(12,2) NOT NULL
);

CREATE TABLE [DetalleCompras] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [CompraProveedor] INT NOT NULL REFERENCES [CompraProveedores] ([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(10,2) NOT NULL
);

CREATE TABLE [Ventas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Cliente] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [Empleado] INT NOT NULL REFERENCES [Empleados] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Total] DECIMAL(12,2) NOT NULL
);

CREATE TABLE [DetalleVentas] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas] ([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(10,2) NOT NULL
);

CREATE TABLE [Pagos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas] ([Id]),
    [Metodo_pago] NVARCHAR(50) NOT NULL CHECK ([Metodo_pago] IN ('Efectivo', 'Tarjeta_Credito', 'Tarjeta_Debito', 'Transferencia', 'PayPal')),
    [Monto] DECIMAL(12,2) NOT NULL,
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [Carritos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Cliente] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE [DetalleCarritos] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Carrito] INT NOT NULL REFERENCES [Carritos] ([Id]),
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Cantidad] INT NOT NULL
);

CREATE TABLE [Inventarios] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Producto] INT NOT NULL REFERENCES [Productos] ([Id]),
    [Stock_actual] INT NOT NULL DEFAULT 0,
    [Stock_minimo] INT NOT NULL DEFAULT 5
);

CREATE TABLE [Devoluciones] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Venta] INT NOT NULL REFERENCES [Ventas] ([Id]),
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Motivo] NVARCHAR(500) NOT NULL
);

-- =========================
-- DATOS
-- =========================

-- Usuarios base
INSERT INTO [Usuarios] ([Nombre], [Apellido], [Correo], [Contraseña], [Rol]) VALUES
('Juan', 'Pérez', 'juan@email.com', 'pass123', 'Cliente'),        -- Id 1
('María', 'García', 'maria@email.com', 'pass456', 'Empleado'),    -- Id 2
('Carlos', 'López', 'carlos@email.com', 'pass789', 'Cliente'),    -- Id 3
('Ana', 'Rodríguez', 'ana@email.com', 'pass012', 'Empleado'),     -- Id 4
('Luis', 'Martínez', 'luis@email.com', 'pass345', 'Cliente');     -- Id 5

-- Clientes
INSERT INTO [Clientes] ([Usuario],[Telefono],[Direccion]) VALUES
(1,'3001234567','Calle 10 #20-30'),
(3,'3157894561','Avenida 80 #45-55'),
(5,'3009876543','Carrera 15 #25-35');

-- Más usuarios para clientes
INSERT INTO [Usuarios] ([Nombre],[Apellido],[Correo],[Contraseña],[Rol]) VALUES
('Sandra','Vargas','sandra@email.com','pass678','Cliente'),       -- Id 6
('Diego','Morales','diego@email.com','pass901','Cliente');        -- Id 7

INSERT INTO [Clientes] ([Usuario],[Telefono],[Direccion]) VALUES
(6,'3201478523','Calle 50 #60-70'),
(7,'3108529637','Carrera 30 #40-50');

-- Más usuarios para empleados
INSERT INTO [Usuarios] ([Nombre],[Apellido],[Correo],[Contraseña],[Rol]) VALUES
('Claudia','Jiménez','claudia@tienda.com','emp123','Empleado'),   -- Id 8
('Roberto','Sánchez','roberto@tienda.com','emp456','Empleado'),   -- Id 9
('Liliana','Ramírez','liliana@tienda.com','emp789','Empleado');   -- Id 10

-- Empleados (coherentes con los usuarios de rol Empleado)
INSERT INTO [Empleados] ([Usuario],[Cargo],[Salario]) VALUES
(2,'Vendedor',1200000),
(4,'Gerente',2500000),
(8,'Cajero',1100000),
(9,'Supervisor',1800000),
(10,'Inventario',1400000);

-- Categorías
INSERT INTO [CategoriaProductos] ([Nombre],[Descripcion]) VALUES
('Camisetas','Camisetas para hombre y mujer'),
('Pantalones','Pantalones casuales y formales'),
('Zapatos','Calzado deportivo y formal'),
('Accesorios','Cinturones y complementos'),
('Chaquetas','Chaquetas y abrigos');

-- Productos
INSERT INTO [Productos] ([Categoria],[Nombre],[Descripcion],[Talla],[Color],[Precio],[Stock]) VALUES
(1,'Camiseta Básica Cotton','Camiseta de algodón','M','Blanco',25000,50),
(2,'Jeans Slim Fit Levis','Pantalón jean','32','Azul',80000,30),
(3,'Tenis Adidas Running','Zapatos para deporte','42','Negro',150000,20),
(4,'Cinturón Cuero Genuino','Cinturón de cuero','L','Café',60000,25),
(5,'Chaqueta Bomber','Chaqueta moderna','XL','Gris',120000,15);

-- Proveedores
INSERT INTO [Proveedores] ([Nombre],[Telefono],[Direccion],[Correo]) VALUES
('Textiles SA','6015551234','Zona Industrial 1','ventas@textiles.com'),
('Moda Ltda','6015559876','Centro Comercial 2','info@moda.com'),
('Confecciones','6025554567','Parque Industrial 3','pedidos@confecciones.com'),
('Calzado Pro','6015552345','Barrio Centro 4','contacto@calzado.com'),
('Accesorios Mix','6015558901','Mall Principal 5','ventas@accesorios.com');

-- Compras a proveedores
INSERT INTO [CompraProveedores] ([Proveedor],[Fecha],[Total]) VALUES
(1,'2024-08-15',1500000),
(2,'2024-08-20',2000000),
(3,'2024-08-25',1800000),
(4,'2024-09-01',2200000),
(5,'2024-09-05',1600000);

-- Detalle compras
INSERT INTO [DetalleCompras] ([CompraProveedor],[Producto],[Cantidad],[Precio]) VALUES
(1,1,50,20000),
(2,2,30,70000),
(3,3,20,130000),
(4,4,25,50000),
(5,5,15,100000);

-- Ventas (clientes 1–5, empleados 1–5)
INSERT INTO [Ventas] ([Cliente],[Empleado],[Fecha],[Total]) VALUES
(1,1,'2024-09-10',105000),
(2,2,'2024-09-11',80000),
(3,3,'2024-09-12',150000),
(4,4,'2024-09-13',60000),
(5,5,'2024-09-14',120000);

-- Detalle ventas
INSERT INTO [DetalleVentas] ([Venta],[Producto],[Cantidad],[Precio]) VALUES
(1,1,2,25000),
(2,2,1,80000),
(3,3,1,150000),
(4,4,1,60000),
(5,5,1,120000);

-- Pagos
INSERT INTO [Pagos] ([Venta],[Metodo_pago],[Monto],[Fecha]) VALUES
(1,'Efectivo',105000,'2024-09-10'),
(2,'Tarjeta_Credito',80000,'2024-09-11'),
(3,'Tarjeta_Debito',150000,'2024-09-12'),
(4,'Transferencia',60000,'2024-09-13'),
(5,'PayPal',120000,'2024-09-14');

-- Carritos
INSERT INTO [Carritos] ([Cliente],[Fecha]) VALUES
(1,'2024-09-15'),
(2,'2024-09-15'),
(3,'2024-09-15'),
(4,'2024-09-15'),
(5,'2024-09-15');

-- Detalle carritos
INSERT INTO [DetalleCarritos] ([Carrito],[Producto],[Cantidad]) VALUES
(1,1,2),
(2,2,1),
(3,3,1),
(4,4,3),
(5,5,1);

-- Inventario
INSERT INTO [Inventarios] ([Producto],[Stock_actual],[Stock_minimo]) VALUES
(1,50,10),
(2,30,8),
(3,20,5),
(4,25,7),
(5,15,3);

-- Devoluciones
INSERT INTO [Devoluciones] ([Venta],[Fecha],[Motivo]) VALUES
(1,'2024-09-11','Talla incorrecta'),
(2,'2024-09-12','Producto defectuoso'),
(3,'2024-09-13','No le gustó'),
(4,'2024-09-14','Color equivocado'),
(5,'2024-09-15','Llegó tarde');

-- =========================
-- VERIFICACIÓN RÁPIDA
-- =========================
SELECT * FROM Usuarios;
SELECT * FROM Clientes;
SELECT * FROM Empleados;
SELECT * FROM CategoriaProductos;
SELECT * FROM Productos;
SELECT * FROM Ventas;
