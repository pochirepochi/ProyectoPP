# ProyectoPP

Sistema de escritorio para **gestión de usuarios, clientes y ajustes de venta**, desarrollado en C# (Windows Forms) con SQL Server. Proyecto Integrador, 2.º cuatrimestre · Grupo 6.

## ¿Qué hace?

**Seguridad y usuarios**
- Inicio de sesión con contraseñas cifradas (SHA-256) y pantalla según el rol (Administrador, Vendedor, Usuario).
- Alta, modificación y baja lógica de usuarios; el nombre de usuario y la contraseña se generan y se envían por correo.
- Política de contraseña configurable y historial: no se pueden reutilizar las últimas 3.
- 5 preguntas de seguridad obligatorias en el primer ingreso y recuperación de contraseña por correo.

**Ventas y clientes**
- Alta, modificación, baja y reactivación de clientes, con contacto y domicilio (provincia, partido y localidad en cascada).
- Validación de CUIT/DNI (prefijo y dígito verificador) y control de duplicados.
- Emisión de notas de crédito y de débito sobre facturas de un cliente.
- Reportes de alertas de crédito e historial de notas, con filtros por texto, estado, monto y fechas.
- Auditoría de cambios en la base de datos.

## Tecnologías

| Componente | Tecnología |
|---|---|
| Lenguaje y plataforma | C# · .NET 10 |
| Interfaz | Windows Forms |
| Base de datos | Microsoft SQL Server (procedimientos almacenados) |
| Acceso a datos | ADO.NET · Microsoft.Data.SqlClient |
| Correo | SMTP (Gmail) |

## Arquitectura

Arquitectura en 4 capas: cada una solo llama a la de abajo, y las entidades las comparten todas.

```
Proyecto PP/            Presentación (formularios Windows Forms)
Capa Logica/            Reglas de negocio, validaciones, reportes, correo
Capa Datos/             Acceso a SQL Server mediante procedimientos almacenados
Capa Entidades/         Clases de datos (Cliente, FacturaVenta, Sesion, etc.)
Base de Datos/          Scripts SQL
```

> Las carpetas `CapaDatos`, `CapaEntidades` y `Capa Vista` son copias de una versión anterior y no forman parte de la solución vigente.

## Requisitos

- Windows 10 u 11
- Visual Studio con la carga de trabajo "Desarrollo de escritorio con .NET" y el SDK de .NET 10
- SQL Server (alcanza con la edición Express) y SQL Server Management Studio
- Git

## Instalación

1. Clonar el repositorio:
   ```
   git clone https://github.com/pochirepochi/ProyectoPP.git
   ```
2. Abrir SQL Server Management Studio y ejecutar el script `Proyecto PP/Base de Datos/BBDD unificadas.txt`. Crea la base `ProyectoPP` con sus tablas, procedimientos y datos de prueba.
   > ⚠️ El script elimina y vuelve a crear las tablas: borra los datos existentes.
3. En `Capa Datos/Conexion.cs`, cambiar `Data Source=` por el nombre de tu servidor SQL (por ejemplo `localhost` o `.\SQLEXPRESS`).
4. En `Capa Logica/Enviarmail.cs`, configurar una cuenta de Gmail propia con su contraseña de aplicación. Sin esto no funciona el envío de correos (alta de usuarios y recuperación de contraseña).
5. Abrir `Proyecto PP/Proyecto PP.slnx` en Visual Studio.
6. Establecer como proyecto de inicio el de presentación (`Capa Vista`, dentro de la carpeta `Proyecto PP`).
7. Compilar y ejecutar con **F5**.

## Roles

| Rol | Pantalla al ingresar | Funciones |
|---|---|---|
| Administrador | Administración de usuarios | Alta, modificación y baja de usuarios |
| Vendedor | Menú principal | Clientes, ajustes de venta (notas de crédito y débito) y reportes |
| Usuario | Pantalla de usuario | Cambiar su contraseña y sus preguntas de seguridad |

## Base de datos

La base `ProyectoPP` tiene 17 tablas en dos módulos:

- **Seguridad:** `Usuarios`, `Roles`, `Usuarios_Roles`, `contraseña`, `Historial_Contraseñas`, `Catalogo_Preguntas`, `Respuestas_Seguridad`, `Auditoria_Cambios`.
- **Ventas:** `Clientes`, `Contactos_Clientes`, `Direcciones_Clientes`, `Provincias`, `Partidos`, `Localidades`, `Facturas_Venta`, `Notas_Credito_Venta`, `Notas_Debito_Venta`.

Todo el acceso se hace con procedimientos almacenados parametrizados.

## Documentación

La documentación completa (técnica y de usuario, casos de uso, diagramas de flujo y capturas de interfaz) está en el documento del proyecto. Se recomienda agregarlo al repositorio en una carpeta `docs/`.

## Limitaciones conocidas

- Las credenciales de correo, la clave AES y la cadena de conexión están en el código; deberían moverse a un archivo de configuración o variables de entorno.
- El usuario de auditoría en clientes y notas está fijo (id 1) en lugar de tomarse de la sesión activa.
- Las contraseñas se guardan con SHA-256 sin sal.
- No hay límite de intentos fallidos de inicio de sesión ni pruebas automatizadas.
- Los reportes no se pueden exportar.

## Autor

Nehuen Aispuru · Proyecto Integrador, Grupo 6.
