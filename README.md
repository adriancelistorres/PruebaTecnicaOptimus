# Proyecto CRUD de Productos + Tarea Automática (.NET MVC clásico + JQuery) 

Este proyecto permite realizar operaciones CRUD sobre una tabla de productos utilizando ASP.NET MVC clásico (.NET Framework) con Entity Framework. Además, incluye una tarea automática en segundo plano que se ejecuta cada 10 segundos.

---

## 📦 Requisitos previos

- Visual Studio 2019 o 2022
- SQL Server (Express o Developer)
- .NET Framework (MVC clásico)
- NuGet: EntityFramework (instalado por Visual Studio)

---

## 🛠️ Levantar la base de datos

1. Abre SQL Server Management Studio (SSMS)
2. Ejecuta el siguiente script:

```sql
USE master;
GO
CREATE DATABASE DBPRUEBAS;
GO
USE DBPRUEBAS;
GO
CREATE TABLE Producto (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(255),
    precio DECIMAL(10,2) NOT NULL,
    cantidad INT NOT NULL
);
```

---

## 🔌 Configurar la conexión a la base de datos

En el archivo `Web.config`, dentro de `<connectionStrings>`, asegúrate de tener esta configuración:

```xml
<connectionStrings>
  <add name="DBPRUEBASEntities"
       connectionString="metadata=res://*/Models.BDMODEL.csdl|res://*/Models.BDMODEL.ssdl|res://*/Models.BDMODEL.msl;
                         provider=System.Data.SqlClient;
                         provider connection string=&quot;
                         data source=LAPTOP-GS6BO76A;
                         initial catalog=DBPRUEBAS;
                         integrated security=True;
                         MultipleActiveResultSets=True;
                         App=EntityFramework&quot;"
       providerName="System.Data.EntityClient" />
</connectionStrings>
```

> Reemplaza `LAPTOP-GS6BO76A` con el nombre de tu servidor SQL si es distinto.

---

## 🔧 Funcionalidades del CRUD

- `Listar()` - Devuelve todos los productos en JSON
- `Obtener(int id)` - Devuelve un producto específico
- `Guardar(Producto producto)` - Inserta o actualiza un producto
- `Eliminar(int id)` - Elimina un producto

La vista utiliza:
- DataTables para mostrar los productos
- Bootstrap Modal para agregar/editar productos

---

## ⏱ Tarea automática

Ubicación: `App_Start/TareaAutomatica.cs`

Funcionalidad:
- Se ejecuta cada 10 segundos desde `Application_Start`
- Simula el envío de un correo escribiendo en `correo_log.txt`
- Copia `archivo.txt` desde `App_Data` con un nuevo nombre

Activación:

```csharp
protected void Application_Start()
{
    AreaRegistration.RegisterAllAreas();
    RouteConfig.RegisterRoutes(RouteTable.Routes);
    TareaAutomatica.Iniciar(); // Inicia la tarea automática
}
```

---

## 📁 Archivos generados por la tarea

- `/App_Data/correo_log.txt` - Registro simulado de correos enviados
- `/App_Data/archivo_copia_yyyyMMdd_HHmmss.txt` - Copias simuladas de `archivo.txt`

---

## ✅ Notas finales

- Asegúrate de tener permisos de escritura en `App_Data`
- El proyecto está preparado para ejecutarse con IIS Express desde Visual Studio (Levantar primero la BD)
