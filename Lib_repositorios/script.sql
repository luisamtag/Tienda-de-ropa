CREATE DATABASE TiendaRopa;
GO

USE TiendaRopa;
GO

CREATE TABLE Usuario (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    correo NVARCHAR(150) UNIQUE NOT NULL,
    contraseña NVARCHAR(255) NOT NULL,
    rol NVARCHAR(50) NOT NULL CHECK (rol IN ('Cliente', 'Empleado', 'Administrador'))
);

CREATE TABLE Cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    telefono NVARCHAR(20),
    direccion NVARCHAR(255),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario) ON DELETE CASCADE
);

CREATE TABLE Empleado (
    id_empleado INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    cargo NVARCHAR(100) NOT NULL,
    salario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario) ON DELETE CASCADE
);

CREATE TABLE CategoriaProducto (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE,
    descripcion NVARCHAR(255)
);

CREATE TABLE Proveedor (
    id_proveedor INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(150) NOT NULL,
    telefono NVARCHAR(20),
    direccion NVARCHAR(255),
    correo NVARCHAR(150)
);

CREATE TABLE Producto (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    id_categoria INT NOT NULL,
    nombre NVARCHAR(150) NOT NULL,
    descripcion NVARCHAR(500),
    talla NVARCHAR(10),
    color NVARCHAR(50),
    precio DECIMAL(10,2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    FOREIGN KEY (id_categoria) REFERENCES CategoriaProducto(id_categoria)
);

CREATE TABLE CompraProveedor (
    id_compra INT IDENTITY(1,1) PRIMARY KEY,
    id_proveedor INT NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    total DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (id_proveedor) REFERENCES Proveedor(id_proveedor)
);

CREATE TABLE DetalleCompra (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_compra INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_compra) REFERENCES CompraProveedor(id_compra) ON DELETE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

CREATE TABLE Venta (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT NOT NULL,
    id_empleado INT NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    total DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_empleado) REFERENCES Empleado(id_empleado)
);

CREATE TABLE DetalleVenta (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_venta) REFERENCES Venta(id_venta) ON DELETE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

CREATE TABLE Pago (
    id_pago INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL,
    metodo_pago NVARCHAR(50) NOT NULL CHECK (metodo_pago IN ('Efectivo', 'Tarjeta_Credito', 'Tarjeta_Debito', 'Transferencia', 'PayPal')),
    monto DECIMAL(12,2) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (id_venta) REFERENCES Venta(id_venta) ON DELETE CASCADE
);

CREATE TABLE Carrito (
    id_carrito INT IDENTITY(1,1) PRIMARY KEY,
    id_cliente INT NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente) ON DELETE CASCADE
);

CREATE TABLE DetalleCarrito (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_carrito INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    FOREIGN KEY (id_carrito) REFERENCES Carrito(id_carrito) ON DELETE CASCADE,
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto)
);

CREATE TABLE Inventario (
    id_inventario INT IDENTITY(1,1) PRIMARY KEY,
    id_producto INT NOT NULL UNIQUE,
    stock_actual INT NOT NULL DEFAULT 0,
    stock_minimo INT NOT NULL DEFAULT 5,
    FOREIGN KEY (id_producto) REFERENCES Producto(id_producto) ON DELETE CASCADE
);

CREATE TABLE Devolucion (
    id_devolucion INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL,
    fecha DATETIME NOT NULL DEFAULT GETDATE(),
    motivo NVARCHAR(500) NOT NULL,
    FOREIGN KEY (id_venta) REFERENCES Venta(id_venta)
);

-- 1. Tabla Usuario
INSERT INTO Usuario (nombre, apellido, correo, contraseña, rol) VALUES
('Juan', 'Pérez', 'juan@email.com', 'pass123', 'Cliente'),
('María', 'García', 'maria@email.com', 'pass456', 'Empleado'),
('Carlos', 'López', 'carlos@email.com', 'pass789', 'Cliente'),
('Ana', 'Rodríguez', 'ana@email.com', 'pass012', 'Empleado'),
('Luis', 'Martínez', 'luis@email.com', 'pass345', 'Cliente');

-- 2. Tabla Cliente
INSERT INTO Cliente (id_usuario, telefono, direccion) VALUES
(1, '3001234567', 'Calle 10 #20-30'),
(3, '3009876543', 'Carrera 15 #25-35'),
(5, '3157894561', 'Avenida 80 #45-55');

-- Usuarios adicionales para completar 5 clientes
INSERT INTO Usuario (nombre, apellido, correo, contraseña, rol) VALUES
('Sandra', 'Vargas', 'sandra@email.com', 'pass678', 'Cliente'),
('Diego', 'Morales', 'diego@email.com', 'pass901', 'Cliente');

INSERT INTO Cliente (id_usuario, telefono, direccion) VALUES
(6, '3201478523', 'Calle 50 #60-70'),
(7, '3108529637', 'Carrera 30 #40-50');

-- 3. Tabla Empleado
INSERT INTO Usuario (nombre, apellido, correo, contraseña, rol) VALUES
('Claudia', 'Jiménez', 'claudia@tienda.com', 'emp123', 'Empleado'),
('Roberto', 'Sánchez', 'roberto@tienda.com', 'emp456', 'Empleado'),
('Liliana', 'Ramírez', 'liliana@tienda.com', 'emp789', 'Empleado');

INSERT INTO Empleado (id_usuario, cargo, salario) VALUES
(2, 'Vendedor', 1200000),
(4, 'Gerente', 2500000),
(8, 'Cajero', 1100000),
(9, 'Supervisor', 1800000),
(10, 'Inventario', 1400000);

-- 4. Tabla CategoriaProducto
INSERT INTO CategoriaProducto (nombre, descripcion) VALUES
('Camisetas', 'Camisetas para hombre y mujer'),
('Pantalones', 'Pantalones casuales y formales'),
('Zapatos', 'Calzado deportivo y formal'),
('Accesorios', 'Cinturones y complementos'),
('Chaquetas', 'Chaquetas y abrigos');

-- 5. Tabla Proveedor
INSERT INTO Proveedor (nombre, telefono, direccion, correo) VALUES
('Textiles SA', '6015551234', 'Zona Industrial 1', 'ventas@textiles.com'),
('Moda Ltda', '6015559876', 'Centro Comercial 2', 'info@moda.com'),
('Confecciones', '6025554567', 'Parque Industrial 3', 'pedidos@confecciones.com'),
('Calzado Pro', '6015552345', 'Barrio Centro 4', 'contacto@calzado.com'),
('Accesorios Mix', '6015558901', 'Mall Principal 5', 'ventas@accesorios.com');

-- 6. Tabla Producto
INSERT INTO Producto (id_categoria, nombre, descripcion, talla, color, precio, stock) VALUES
(1, 'Camiseta Básica', 'Camiseta de algodón', 'M', 'Blanco', 25000, 50),
(2, 'Jeans Clásico', 'Pantalón jean', '32', 'Azul', 80000, 30),
(3, 'Tenis Deportivos', 'Zapatos para deporte', '42', 'Negro', 150000, 20),
(4, 'Cinturón Cuero', 'Cinturón de cuero', 'L', 'Café', 60000, 25),
(5, 'Chaqueta Casual', 'Chaqueta moderna', 'XL', 'Gris', 120000, 15);

-- 7. Tabla CompraProveedor
INSERT INTO CompraProveedor (id_proveedor, fecha, total) VALUES
(1, '2024-08-15', 1500000),
(2, '2024-08-20', 2000000),
(3, '2024-08-25', 1800000),
(4, '2024-09-01', 2200000),
(5, '2024-09-05', 1600000);

-- 8. Tabla DetalleCompra
INSERT INTO DetalleCompra (id_compra, id_producto, cantidad, precio) VALUES
(1, 1, 50, 20000),
(2, 2, 30, 70000),
(3, 3, 20, 130000),
(4, 4, 25, 50000),
(5, 5, 15, 100000);

-- 9. Tabla Venta
INSERT INTO Venta (id_cliente, id_empleado, fecha, total) VALUES
(1, 1, '2024-09-10', 105000),
(2, 2, '2024-09-11', 80000),
(3, 3, '2024-09-12', 150000),
(4, 4, '2024-09-13', 60000),
(5, 5, '2024-09-14', 120000);

-- 10. Tabla DetalleVenta
INSERT INTO DetalleVenta (id_venta, id_producto, cantidad, precio) VALUES
(1, 1, 2, 25000),
(2, 2, 1, 80000),
(3, 3, 1, 150000),
(4, 4, 1, 60000),
(5, 5, 1, 120000);

-- 11. Tabla Pago
INSERT INTO Pago (id_venta, metodo_pago, monto, fecha) VALUES
(1, 'Efectivo', 105000, '2024-09-10'),
(2, 'Tarjeta_Credito', 80000, '2024-09-11'),
(3, 'Tarjeta_Debito', 150000, '2024-09-12'),
(4, 'Transferencia', 60000, '2024-09-13'),
(5, 'PayPal', 120000, '2024-09-14');

-- 12. Tabla Carrito
INSERT INTO Carrito (id_cliente, fecha) VALUES
(1, '2024-09-15'),
(2, '2024-09-15'),
(3, '2024-09-15'),
(4, '2024-09-15'),
(5, '2024-09-15');

-- 13. Tabla DetalleCarrito
INSERT INTO DetalleCarrito (id_carrito, id_producto, cantidad) VALUES
(1, 1, 2),
(2, 2, 1),
(3, 3, 1),
(4, 4, 3),
(5, 5, 1);

-- 14. Tabla Inventario
INSERT INTO Inventario (id_producto, stock_actual, stock_minimo) VALUES
(1, 50, 10),
(2, 30, 8),
(3, 20, 5),
(4, 25, 7),
(5, 15, 3);

-- 15. Tabla Devolucion
INSERT INTO Devolucion (id_venta, fecha, motivo) VALUES
(1, '2024-09-11', 'Talla incorrecta'),
(2, '2024-09-12', 'Producto defectuoso'),
(3, '2024-09-13', 'No le gustó'),
(4, '2024-09-14', 'Color equivocado'),
(5, '2024-09-15', 'Llegó tarde');