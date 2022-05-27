## Directorio para la prueba 1 ##
create database evaluacionTecnica

use evaluacionTecnica


create table usuarios (
userId int identity (1,1) not null primary key, 
Login varchar (100),
Nombre varchar (100),
Paterno varchar (100),
Materno varchar (100)
)

create table empleados(
userId int Foreign key References usuarios(userId), 
Sueldo decimal, 
FechaIngreso date
)

Depuración 
DELETE empleados WHERE userId NOT IN ( 6,7,9,10)
DELETE usuarios WHERE userId NOT IN ( 6,7,9,10)

Actualizar el dato Sueldo en un 10%
UPDATE empleados SET Sueldo = ISNULL(Sueldo + Sueldo*.10,Sueldo) WHERE FechaIngreso BETWEEN '2000-01-01' AND '2001-12-31'

Realiza una consulta para traer el nombre de usuario y fecha de ingreso de los usuarios que gananen mas de 10000 y su apellido comience con T ordernado del mas reciente al mas antiguo
SELECT U.Nombre,E.FechaIngreso FROM usuarios U 
INNER JOIN empleados E ON E.userId = U.userId
WHERE E.Sueldo > 10000 AND U.Paterno LIKE 'T%' 
ORDER BY FechaIngreso DESC