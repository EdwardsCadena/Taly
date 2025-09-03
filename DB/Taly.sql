-- 1. Crear BD
IF DB_ID('DBClientes') IS NULL
BEGIN
  CREATE DATABASE DBClientes;
END
GO

USE DBClientes;
GO

-- 2. Crear tabla Clientes
IF OBJECT_ID('dbo.Clientes', 'U') IS NULL
BEGIN
  CREATE TABLE dbo.Clientes (
      ClienteId        INT IDENTITY(1,1) PRIMARY KEY,
      Identificacion   VARCHAR(20)  NOT NULL UNIQUE,
      Nombres          VARCHAR(100) NOT NULL,
      Apellidos        VARCHAR(100) NOT NULL,
      Email            VARCHAR(150) NULL,
      Telefono         VARCHAR(30)  NULL,
      FechaRegistro    DATETIME2     NOT NULL DEFAULT SYSUTCDATETIME(),
      Activo           BIT           NOT NULL DEFAULT(1)
  );
END
GO

-- 3. Semillas de prueba
IF NOT EXISTS(SELECT 1 FROM dbo.Clientes WHERE Identificacion = '1234567890')
BEGIN
  INSERT INTO dbo.Clientes (Identificacion, Nombres, Apellidos, Email, Telefono)
  VALUES
  ('1234567890','Laura','Gómez','laura.gomez@example.com','3001234567'),
  ('9876543210','Carlos','Pérez','carlos.perez@example.com','3017654321');
END
GO

-- 4. Stored Procedure para obtener cliente por identificación
IF OBJECT_ID('dbo.sp_ObtenerClientePorIdentificacion', 'P') IS NOT NULL
  DROP PROCEDURE dbo.sp_ObtenerClientePorIdentificacion;
GO

CREATE PROCEDURE dbo.sp_ObtenerClientePorIdentificacion
  @Identificacion VARCHAR(20)
AS
BEGIN
  SET NOCOUNT ON;

  SELECT TOP 1
    c.ClienteId,
    c.Identificacion,
    c.Nombres,
    c.Apellidos,
    c.Email,
    c.Telefono,
    c.FechaRegistro,
    c.Activo
  FROM dbo.Clientes c
  WHERE c.Identificacion = @Identificacion;
END
GO
