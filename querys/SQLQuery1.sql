CREATE DATABASE electronica;
USE electronica;

CREATE TABLE CATEGORIAS (
	id_categoria int primary key identity,
	nombre_categoria varchar(200)
)

INSERT INTO CATEGORIAS (nombre_categoria) VALUES ('CATEGORIA 1')
INSERT INTO CATEGORIAS (nombre_categoria) VALUES ('CATEGORIA 2')
INSERT INTO CATEGORIAS (nombre_categoria) VALUES ('CATEGORIA 3')

CREATE TABLE PRODUCTOS (
	id_producto int primary key identity,
	id_categoria int references CATEGORIAS(id_categoria), 
	nombre_producto varchar(500),
	fecha_altaregistro date,
	fecha_bajaregistro date
)

INSERT INTO PRODUCTOS (id_categoria, nombre_producto, fecha_altaregistro, fecha_bajaregistro) 
VALUES (1, 'RADIOS', GETDATE(), NULL)
INSERT INTO PRODUCTOS (id_categoria, nombre_producto, fecha_altaregistro, fecha_bajaregistro) 
VALUES (1, 'TV', GETDATE(), NULL)
INSERT INTO PRODUCTOS (id_categoria, nombre_producto, fecha_altaregistro, fecha_bajaregistro) 
VALUES (1, 'JUEGOS', GETDATE(), NULL)

-- CREACION DE FUNCIONES PARA OBTENER DATOS
CREATE FUNCTION fn_categorias()
RETURNS TABLE
AS
RETURN
	SELECT * FROM CATEGORIAS

CREATE FUNCTION fn_productos()
RETURNS TABLE
AS
RETURN
	SELECT p.id_producto, p.nombre_producto, c.id_categoria, c.nombre_categoria,
	CONVERT(CHAR(10), p.fecha_altaregistro, 103)[fechaContrato], 
	CONVERT(CHAR(10), p.fecha_bajaregistro, 103)[fechaBaja]
	FROM PRODUCTOS p
	INNER JOIN CATEGORIAS c ON c.id_categoria = p.id_categoria

CREATE FUNCTION fn_producto(@idProducto int)
RETURNS TABLE
AS
RETURN
	SELECT p.id_producto, p.nombre_producto, c.id_categoria, c.nombre_categoria,
	CONVERT(CHAR(10), p.fecha_altaregistro, 103)[fechaContrato], 
	CONVERT(CHAR(10), p.fecha_bajaregistro, 103)[fechaBaja]
	FROM PRODUCTOS p
	INNER JOIN CATEGORIAS c ON c.id_categoria = p.id_categoria
	WHERE p.id_producto = @idProducto


-- PROCEDIMIENTOS ALMACENADOS
CREATE PROC sp_crearProducto(
	@NombreProducto varchar(500),
	@IdCategoria int,
	@FechaAlta varchar(10),
	@FechaBaja varchar(10)
) 
AS
BEGIN
	INSERT INTO PRODUCTOS(nombre_producto, id_categoria, fecha_altaregistro, fecha_bajaregistro) 
	VALUES (@NombreProducto, @IdCategoria, CONVERT(DATE, @FechaAlta), CONVERT(DATE, @FechaBaja))
END

CREATE PROC sp_editarProducto(
	@IdProducto int,
	@NombreProducto varchar(500),
	@IdCategoria int,
	@FechaAlta varchar(10),
	@FechaBaja varchar(10)
) 
AS
BEGIN
	UPDATE PRODUCTOS SET
	nombre_producto = @NombreProducto,
	id_categoria = @IdCategoria,
	fecha_altaregistro = @FechaAlta,
	fecha_bajaregistro = @FechaBaja
	WHERE id_producto = @IdProducto
END


-- SE MODIFICO EL STORE, QUITANDOLE PARAMETROS QUE NO SE OCUPABAN

ALTER PROC sp_eliminarProducto(
	@IdProducto int
) 
AS
BEGIN
	DELETE FROM PRODUCTOS
	WHERE id_producto = @IdProducto
END



