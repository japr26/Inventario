------Descripción general------

Es un sistema de inventario donde podemos manejar entrada y salida de varios almacenes que tengamos registrados. Tenemos como página principal una lista de la cantidad de artículos registrados en total de todos los almacenes, a la izquierda tenemos un menú desplegable con todas las vistas del sistema.

Cuenta con módulos para registro de artículos, registro de almacenes, registro de marcas, registro de categorías y registro de proveedores todos estos con sus respectivas vistas para listarlos. También contamos con un módulo donde asignamos los artículos y cantidades del mismo al almacén donde se quiera, siempre y cuando las cantidades no excedan la capacidad del almacén seleccionado.

Podemos ver también las transacciones realizadas de entrada y salida en nuestro menú desplegable.

----------------------------------------------------------------------------------------------------------------------------


------Tecnologías implementadas------

*Visual Studio 2017 community

   -Asp.Net MVC 5

   -Entity Framework (Code First)

   -bootstrap (Para el front end)

   -pagedlist mvc (Para la paginación)

*Microsoft SQL Server 2017 developer edition

----------------------------------------------------------------------------------------------------------------------------


------Consideraciones para iniciar el proyecto------

*Correr el script (MardomV1.sql este tiene datos de prueba o MardomV2.sql) de la BD (Base de Datos), modificando la ruta donde se crearan el MDF y el LDF. Debe correrse en una versión de MS-SQL Server 2014 o superior.

*De no querer utilizar su usuario principal (sql authentication) para acceder a la BD desde el sistema debe crear uno con todos los permisos necesarios.

*Colocar en el Web.config del sistema el usuario y password para la conexión a la BD.

*En caso de no utilizar datos de prueba debe registrar primero las marcas, categorías, proveedores, almacenes y artículos.

*En caso de no utilizar datos de prueba es necesario ingresar por BD en la tabla tipoMovimiento Entrada con el id = 1 y Salida con el id = 2, esto porque no se consideró pertinente crear un módulo para crear 2 registros únicos.

----------------------------------------------------------------------------------------------------------------------------

Para cualquier información adicional favor contactarme.

Johan Pérez



