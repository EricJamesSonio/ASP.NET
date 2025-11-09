📘 ASP.NET Core (C#)

Language: C#  
Framework: .NET 9 / ASP.NET Core (Web API)

---

## 🧩 Project Structure

**Program.cs**  
Entry point of your backend, like `server.js` in Node/Express

**Controllers/**  
Handles API endpoints (`[HttpGet]`, `[HttpPost]`), similar to Express routes

**Models/**  
Your data objects, like Mongoose schemas in Node  
Example: `User.cs` defines a `User` table in the database

**Data/**  
Database context (`DbContext`) that connects EF Core to MySQL  
Example: `AppDbContext.cs` manages tables and relationships

**Repositories/** *(Optional)*  
Abstracts database queries, separates data access logic from controllers

**Services/** *(Optional)*  
Handles business logic, validation, and processing

---

## ⚙️ Routing & API Endpoints

Controllers define routes:

```csharp
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers() { ... }

    [HttpPost]
    public IActionResult AddUser(User user) { ... }
}
