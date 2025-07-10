# Deal Management API

This is the backend Web API service for the **Deal Management System**. Build using **ASP.NET Core Web API** and provides endpoints for managing deals and hotels, including CRUD operations.

## 🚀 Features

- RESTful API endpoints for Deals and hotels
- Supports Create, Read, Update, Delete (CRUD)
- Integrates with a frontend Angular app
- Follows common oatterns and strategies

## 🛠️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- Automapper and FluentValidation
- SQL Server

## 📦 Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/) 

## 📥 Clone the Repository

1. Open **Visual Studio**
2. Go to **File -> Clone Repository
3. Paste GitHub Repository
```bash
https://github.com/virokalu/DealManagement.git
```

4. Choose a local path and click **Clone**.

## 🔌 Check the Connection String

Open the file: `appsettings.json` in the root of your project.
Update or verify the connection string inside the `ConnectionStrings` section:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=DealDb;Trusted_Connection=True;"
  }
}
```

## ⚙️ Apply EF Core Migrations

Visual Studio will Create the database on Run. if not Open **Package Manager Console**
1. View->Other Windows->Package Manager Console
2. Run
```bash
Update-Database
```

## ▶️ Run the Application

Click the green ▶️ button or press `F5`.
It will launch the API and open Swagger UI at,
```bash
https://localhost:7222/
```
GET, POST, PUT, DELETE endpoints are in Postman API Collection, Which I included in the repository and also in the Email
