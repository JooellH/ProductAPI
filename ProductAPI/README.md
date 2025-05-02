# ProductAPI - ASP.NET Core Web API

## 🎯 Descripción
API REST creada con ASP.NET Core 6 para gestionar productos y sus categorías. Incluye funcionalidades CRUD, validaciones, uso de AutoMapper, Swagger y estructura por capas.

## 🧱 Tecnologías
- .NET 6
- Entity Framework Core
- MySql (Code First)
- AutoMapper
- Swagger (Swashbuckle)
- DataAnnotations

## ▶️ Cómo ejecutar

1. Clona o descomprime el proyecto.
2. Asegúrate de tener instalado:
   - .NET 6 SDK
   - MySql
3. En `appsettings.json`, ajusta la cadena de conexión.
4. Ejecuta los siguientes comandos:

```bash
# Restaurar paquetes
dotnet restore

# Aplicar migraciones (crear DB)
dotnet ef migrations add InitialCreate
dotnet ef database update

# Ejecutar la API
dotnet run
```

5. Abre Swagger en: `http://localhost:5000/swagger` (según tu configuración).

## 📦 Endpoints principales

### Categorías
- `GET /api/categorias`
- `GET /api/categorias/{id}`
- `POST /api/categorias`
- `DELETE /api/categorias/{id}`

### Productos
- `GET /api/productos`
- `GET /api/productos/{id}`
- `POST /api/productos`
- `PUT /api/productos/{id}`
- `DELETE /api/productos/{id}`