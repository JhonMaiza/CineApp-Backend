# CineApp - Base de Datos

Este proyecto utiliza Entity Framework Core para la creación y gestión de la base de datos. A continuación, se describen los pasos seguidos para construir la estructura y poblar las tablas principales.

## Creación de la Base de Datos

La base de datos se generó mediante migraciones usando Entity Framework Core.

### Comandos utilizados:
```bash
Add-Migration NombreDeLaMigracion
Update-Database
```

## Creación de la Base de Datos
Una vez aplicada la migración, se puede ejecutar el script CineAppDB para insertar datos de prueba y crear un procedimiento almacenado que permite buscar películas por nombre.