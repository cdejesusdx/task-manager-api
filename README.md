# 📝 Task Manager API (.NET 9 + Onion Architecture)

API RESTful para la gestión de tareas, desarrollada con ASP.NET Core 9 siguiendo los principios de Clean Architecture, Onion Architecture y el patrón Repository.

---

## 🚀 Tecnologías utilizadas

- ASP.NET Core 9
- Entity Framework Core (InMemory)
- Onion Architecture + Repository Pattern
- Swagger (OpenAPI)
- AutoMapper
- SOLID Principles

---

## 📁 Estructura del proyecto

```
src/
├── InsolTech.TaskManager.Api/             # Proyecto principal ASP.NET Core
├── InsolTech.TaskManager.Application/     # Lógica y servicios de aplicación
├── InsolTech.TaskManager.Domain/          # Entidades y contratos
└── InsolTech.TaskManager.Infrastructure/  # Repositorios e infraestructura
```

---

## 🧪 Instrucciones para ejecutar

```bash
git clone https://github.com/cdejesusdx/task-manager-api.git
cd task-manager-api

dotnet restore
dotnet run --project src/InsolTech.TaskManager.Api
```

Una vez iniciado, accede a la documentación Swagger en:

```
https://localhost:44366/swagger/index.html
```

---

## 📌 Funcionalidades

- Crear, listar, actualizar y eliminar tareas
- Cambiar estado de la tarea (Pendiente, En Progreso, Completada)
- Paginación de tareas
- Manejo global de errores
- Validaciones con FluentValidation
- Documentación de endpoints con Swagger + XML comments

---

## ✅ Estado

✅ Finalizado y funcional