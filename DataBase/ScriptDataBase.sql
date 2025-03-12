-- Verifica si la base de datos existe antes de crearla
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'LibraryDB')
BEGIN
    CREATE DATABASE LibraryDB;
    PRINT 'Base de datos LibraryDB creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La base de datos LibraryDB ya existe.';
END
GO

-- Usar la base de datos recién creada
USE LibraryDB;
GO

-- Verifica y crea la tabla de Autores
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Authors')
BEGIN
    CREATE TABLE Authors (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        FullName NVARCHAR(255) NOT NULL,
        BirthDate DATE NOT NULL,
        City NVARCHAR(100) NOT NULL,
        Email NVARCHAR(255) NOT NULL UNIQUE
    );
    PRINT 'Tabla Authors creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Authors ya existe.';
END
GO

-- Verifica y crea la tabla de Libros
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Books')
BEGIN
    CREATE TABLE Books (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Title NVARCHAR(255) NOT NULL,
        Year INT NOT NULL CHECK (Year >= 1000 AND Year <= YEAR(GETDATE())), -- Valida año lógico
        Genre NVARCHAR(100) NOT NULL,
        PageCount INT NOT NULL CHECK (PageCount > 0), -- Evita valores negativos
        AuthorId INT NOT NULL,
        CONSTRAINT FK_Books_Authors FOREIGN KEY (AuthorId) REFERENCES Authors(Id) ON DELETE CASCADE
    );
    PRINT 'Tabla Books creada exitosamente.';
END
ELSE
BEGIN
    PRINT 'La tabla Books ya existe.';
END
GO
