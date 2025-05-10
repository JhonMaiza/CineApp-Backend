CREATE PROCEDURE [dbo].[spGetMovieByName]
    @Name NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM Movies
    WHERE LOWER(Name) LIKE '%' + LOWER(@Name) + '%' AND IsDeleted = 0
END;
GO

USE [CineApp];
GO

-- Insertar cines
INSERT INTO [dbo].[Cinema] ([Name], [State]) VALUES 
    ('Cine Norte', 1), 
    ('Cine Sur', 1);
GO

-- Insertar peliculas
INSERT INTO [dbo].[Movies] ([Name], [Duration], [IsDeleted]) VALUES 
    ('El Viaje Infinito', 120, 0),
    ('La ultima Frontera', 105, 0),
    ('Sombras del Pasado', 98, 0),
    ('Comedia Invisible', 110, 1),
    ('Drama Perdido', 95, 1);
GO

-- Asignar peliculas a cines (con fechas pasadas, actuales y futuras)
INSERT INTO [dbo].[CinemaMovies] ([CinemaId], [MovieId], [ReleaseDate], [EndDate]) VALUES 
    (1, 1, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, 10, GETDATE())),
    (1, 2, DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, -15, GETDATE())),
    (2, 3, GETDATE(), DATEADD(DAY, 20, GETDATE())),
    (2, 4, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -5, GETDATE())),
    (1, 5, DATEADD(DAY, 5, GETDATE()), DATEADD(DAY, 15, GETDATE()));
GO

select * from movies
select * from CinemaMovies
select * from Cinema