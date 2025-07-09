# 📁 ProjectManagement API

A clean and extensible ASP.NET Core Web API for managing **Projects** and their associated **Tasks**. Built using modern design patterns like **MediatR**, **CQRS**, **Clean Architecture**, and **Entity Framework Core**.

---

## 🚀 Features

- 🔁 CRUD operations for **Projects**
- 🧩 Add, update, and delete **Tasks** under each project
- 🔍 Pagination and filtering support
- ✅ Built-in Swagger documentation for easy API testing
- 🧱 Clean Architecture for maintainability
- 🧭 CQRS pattern with MediatR for separation of commands and queries

---

## 🛠️ Tech Stack

- ASP.NET Core 7 / 8
- Entity Framework Core (SQL Server)
- MediatR (CQRS)
- AutoMapper
- Swagger (Swashbuckle)
- FluentValidation (optional)
- Clean Architecture principles

---

## 📂 Project Structure

ProjectManagement
├── ProjectManagement.API # API layer (controllers, startup)
├── ProjectManagement.Application # Application layer (CQRS handlers, DTOs, interfaces)
├── ProjectManagement.Domain # Core business models/entities
├── ProjectManagement.Infrastructure # Data access, EF DbContext, services


---

## 📡 API Endpoints

| Method | Endpoint                          | Description                    |
|--------|-----------------------------------|--------------------------------|
| GET    | `/api/projects`                   | Get all projects (filterable)  |
| GET    | `/api/projects/{id}`              | Get project details by ID      |
| POST   | `/api/projects`                   | Create a new project           |
| PUT    | `/api/projects/{id}`              | Update an existing project     |
| DELETE | `/api/projects/{id}`              | Delete a project               |
| POST   | `/api/projects/{projectId}/tasks` | Add task to a project          |
| PUT    | `/api/tasks/{id}`                 | Update a task                  |
| DELETE | `/api/tasks/{id}`                 | Delete a task                  |

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 7/8 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server (LocalDB or full instance)

### Setup

1. **Clone the repository**

```bash
git clone https://github.com/yourusername/ProjectManagement.git
cd ProjectManagement

Update connection string

In appsettings.json (inside ProjectManagement.API):

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ProjectManagementDB;Trusted_Connection=True;"
}
Run EF migrations
cd ProjectManagement.API
dotnet ef database update

Run the API
dotnet run
Open Swagger UI

Visit: http://localhost:5000/swagger (depending on port)
