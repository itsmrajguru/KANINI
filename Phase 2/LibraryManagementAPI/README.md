# 📚 Library Management API

A robust, full-featured ASP.NET Core Web API for managing library operations including catalogs, circulation, users, and fines.

---

## ✨ Features

- **Authentication & Authorization**: Secure endpoints using JWT Bearer tokens. Role-based access control (Admin vs. Member).
- **Catalog Management**: Full CRUD operations for Books, Authors, and Categories.
- **Circulation System**: Issue and return books, track availability.
- **Fine Management**: Automatic or manual calculation and tracking of overdue fines.
- **Reporting & Analytics**: Endpoints to fetch library statistics.
- **Entity Framework Core**: Clean database interactions using EF Core (Code-First) and MySQL.
- **Swagger Integration**: Easy-to-use UI for testing endpoints directly from the browser with built-in token support.

---

## 🛠️ Tech Stack

- **Framework**: .NET 8 (ASP.NET Core Web API)
- **Database**: MySQL (Pomelo.EntityFrameworkCore.MySql)
- **ORM**: Entity Framework Core
- **Authentication**: JWT (JSON Web Tokens)

---

## 🚀 Setup & Installation

### 1. Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/installer/) (Running locally or hosted)

### 2. Configuration (`appsettings.json`)
You need to configure your database connection and JWT secrets before running the application.

1. Locate `appsettings.Example.json` in the root directory.
2. Create a new file named `appsettings.json` and copy the contents from the example file into it.
3. Update the `DefaultConnection` string with your MySQL credentials:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Port=3306;Database=LibraryDB;User=root;Password=YOUR_MYSQL_PASSWORD;"
   }
   ```
4. Update the `Jwt` section if you wish to use custom signing keys (otherwise the default works for local dev). Ensure that for local development `Jwt:Key` is provided (typically via `dotnet user-secrets` or added directly to `appsettings.json`).

### 3. Database Migration
The project uses EF Core Code-First migrations to structure the database. To create the tables, run the following commands in the root directory:

```bash
# Update your database to the latest migration
dotnet ef database update
```
*(Note: A `SeedData.sql` script is also available in the root if you wish to populate the database with dummy categories, authors, and books manually).*

### 4. Run the Application
Start the development server:
```bash
dotnet run
```
The API will start on a local port (e.g., `http://localhost:5080`).

---

## 🧪 Testing with Swagger & Roles

Once the app is running, navigate to `http://localhost:<PORT>/swagger` in your browser. Swagger UI is configured to accept JWT tokens. 

### Role Credentials for Testing
The application uses two primary roles: **Admin** and **Member**. 

To test role-based endpoints, you must first register users and then login to get their JWT tokens.

#### 1. Creating an Admin User
Send a POST request to `/api/auth/register` with the `Role` set to `1` (which maps to Admin enum) or simply `"Admin"` (depending on enum parsing config):
```json
{
  "username": "AdminUser",
  "email": "admin@library.com",
  "password": "Password123!",
  "role": "Admin"
}
```

#### 2. Creating a Member User
Send a POST request to `/api/auth/register` (Role defaults to `Member` if omitted):
```json
{
  "username": "RegularMember",
  "email": "member@library.com",
  "password": "Password123!"
}
```

#### 3. Getting your JWT Token
Send a POST request to `/api/auth/login` using either of the accounts you created:
```json
{
  "email": "admin@library.com",
  "password": "Password123!"
}
```
*The response will include a `token`.*

#### 4. Authenticating in Swagger
1. Copy the `token` from the login response.
2. Click the **Authorize (Lock)** icon at the top of the Swagger page.
3. Paste the token in the value box (Format: `Bearer <your_token>`).
4. You can now access protected endpoints!

---

## 📂 Project Structure

- `Controllers/`: API endpoint handlers.
- `Services/`: Core business logic and database interactions.
- `Interfaces/`: Contracts for Dependency Injection.
- `Models/`: Database entities (Books, Members, Issues, etc.).
- `DTOs/`: Data Transfer Objects for API requests/responses.
- `Data/`: EF Core `LibraryDbContext`.
- `Migrations/`: Auto-generated database schema versions.
- `Middleware/`: Custom error handling.

---
*Happy Coding!* 🚀
