------Descripci�n general------

Es un sistema de inventario donde podemos manejar entrada y salida de varios almacenes que tengamos registrados. Tenemos como p�gina principal una lista de la cantidad de art�culos registrados en total de todos los almacenes, a la izquierda tenemos un men� desplegable con todas las vistas del sistema.

Cuenta con m�dulos para registro de art�culos, registro de almacenes, registro de marcas, registro de categor�as y registro de proveedores todos estos con sus respectivas vistas para listarlos. Tambi�n contamos con un m�dulo donde asignamos los art�culos y cantidades del mismo al almac�n donde se quiera, siempre y cuando las cantidades no excedan la capacidad del almac�n seleccionado.

Podemos ver tambi�n las transacciones realizadas de entrada y salida en nuestro men� desplegable.

----------------------------------------------------------------------------------------------------------------------------


------Tecnolog�as implementadas------

*Visual Studio 2017 community
   -Asp.Net MVC 5
   -Entity Framework (Code First)
   -bootstrap (Para el front end)
   -pagedlist mvc (Para la paginaci�n)

*Microsoft SQL Server 2017 developer edition

----------------------------------------------------------------------------------------------------------------------------


------Consideraciones para iniciar el proyecto------

*Correr el script (MardomV1.sql este tiene datos de prueba o MardomV2.sql) de la BD (Base de Datos) en una versi�n de MS-SQL Server 2014 o superior.
*De no querer utilizar el login principal para acceder a la BD desde el sistema debe crear uno con todos los permisos necesarios.
*Colocar en el Web.config del sistema el usuario y password para la conexi�n a la BD.
*En caso de no utilizar datos de prueba debe registrar primero las marcas, categor�as, proveedores, almacenes y art�culos.
*En caso de no utilizar datos de prueba es necesario ingresar por BD en la tabla tipoMovimiento Entrada con el id = 1 y Salida con el id = 2, esto porque no se consider� pertinente crear un m�dulo para crear 2 registros �nicos.

----------------------------------------------------------------------------------------------------------------------------

Para cualquier informaci�n adicional favor contactarme.

Johan P�rez



