
--- vista 1 mostrae nombre, apellidode todos vehiculos con precio mayor a 20000
CREATE VIEW vista_carros
AS
SELECT
c.Nombre, 
c.Apellido,
v.Precio
FROM tblClientes c 
JOIN tblVehiculos v ON c.ClienteID = v.VehiculoID
WHERE precio > 20000;

select * from vista_carros

--- vista 2 

CREATE VIEW vista_monto_total
AS
SELECT
c.Nombre,
c.Apellido, SUM(t.Monto) AS Monto_Total
FROM tblClientes   c
JOIN tblVentas t ON c.ClienteID = c.ClienteID
GROUP BY c.nombre, c.apellido;

select * from vista_monto_total

--- vista 3 
CREATE VIEW vista_venta 
AS
SELECT
    c.ClienteID AS ClienteID,
    v.Modelo AS Vehiculo_Modelo,
    v.Precio AS Monto_Venta
FROM tblVentas ve
JOIN tblClientes c ON ve.ClienteID = c.ClienteID
JOIN tblVehiculos v ON ve.VehiculoID = v.VehiculoID;

select * from vista_venta

---vista 4 pendiente no muestra datos
CREATE VIEW vista_clientes_varias
AS
SELECT
    c.ClienteID,
    c.Nombre,
    c.Apellido,
    COUNT(v.VentaID) AS Numero_Compras
FROM tblClientes c
JOIN tblVentas v ON c.ClienteID = v.ClienteID

GROUP BY c.ClienteID, c.Nombre, c.Apellido
having count (v.VentaID) > 1;


select * from vista_clientes_varias

select * from tblClientes
---vista 5 

CREATE VIEW vista_vehiculos_disponibl
AS
SELECT
    v.VehiculoID,
    v.Precio
FROM tblVehiculos v
WHERE v.VehiculoID = 1;  

Select * from vista_vehiculos_disponibl



------------ tipo select 
ALTER PROCEDURE usp_Vehiculos_mostrar
AS
BEGIN  
    
    SELECT * FROM tblVehiculos;
END;


exec usp_Vehiculos_mostrar; 


--------- tipo insert 

CREATE PROCEDURE usp_Vehiculos_insert 
    @Marca varchar (50),
    @Modelo varchar(50),
    @Año int,
    @Precio decimal(18,2),
    @Estado varchar(50)
AS
BEGIN
    
    INSERT INTO tblVehiculos(Marca, Modelo, Año, Precio, Estado)
    VALUES (@Marca, @Modelo, @Año, @Precio, @Estado);
END;


EXEC usp_Vehiculos_insert 
    @Marca = 'Toyota', 
    @Modelo = 'Corolla', 
    @Año = 2023, 
    @Precio = 25000.00, 
    @Estado = 'Nuevo';
	exec usp_Vehiculos_mostrar;

	----- actualizar
	ALTER PROCEDURE Usp_Vehiculos_Actualizar
	 @VehiculoID int,
    @Marca VARCHAR(50),
    @Modelo VARCHAR(50),
    @Año INT,
    @Precio DECIMAL(18,2),
    @Estado VARCHAR(50)
AS
BEGIN
    
    UPDATE dbo.tblVehiculos
    SET 
        Marca = @Marca,  
        Modelo = @Modelo,
        Año = @Año,
        Precio = @Precio,
        Estado = @Estado
    
	WHERE VehiculoID= @VehiculoID;

END;

select * from dbo.tblVehiculos

-------------ELIMINAR
ALTER PROCEDURE Usp_Vehiculos_Eliminar

	--Parametros de entrada para tabla cuentas
	(
	@VehiculoID int
	)
AS
BEGIN
	

	delete tblVehiculos
	WHERE @VehiculoID= VehiculoID;
END






