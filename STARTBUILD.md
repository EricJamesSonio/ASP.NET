
---

## **Step 1 — Set up your .NET project**

1. Open a terminal/PowerShell in your projects folder.
2. Create a new Web API project:

   ```bash
   dotnet new webapi -n MyApp
   ```

   This generates:

   * `Program.cs` (main entry point)
   * `Controllers/WeatherForecastController.cs` (sample controller)
   * `appsettings.json` (config file)
3. Open the solution in VS Code or Visual Studio:

   ```bash
   code MyApp
   ```

---

## **Step 2 — Configure MySQL with EF Core**

1. Install EF Core packages:

   ```bash
   dotnet add package Pomelo.EntityFrameworkCore.MySql
   dotnet add package Microsoft.EntityFrameworkCore.Design
   ```
2. Update `appsettings.json` to include your MySQL connection:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;port=3306;database=myappdb;user=root;password=YOUR_PASSWORD"
     }
   }
   ```
3. Create `Data/AppDbContext.cs`:

   ```csharp
   using Microsoft.EntityFrameworkCore;
   using MyApp.Models;

   namespace MyApp.Data
   {
       public class AppDbContext : DbContext
       {
           public AppDbContext(DbContextOptions<AppDbContext> options)
               : base(options) { }

           public DbSet<User> Users { get; set; }
           public DbSet<Candidate> Candidates { get; set; }
           public DbSet<Vote> Votes { get; set; }
       }
   }
   ```

---

## **Step 3 — Create Models**

Example: `Models/User.cs`

```csharp
namespace MyApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
```

Other models for voting system:

* `Candidate.cs`
* `Vote.cs`
* `Electron.cs` (optional, if you want a separate entity for voters)

---

## **Step 4 — Set up Program.cs**

Here’s a **minimal but production-ready version**:

```csharp
using Microsoft.EntityFrameworkCore;
using MyApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Configure MySQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Optional: CORS for Angular frontend
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable CORS
app.UseCors();

app.MapControllers();

app.Run();
```

✅ Notes:

* No Swagger needed for production.
* CORS allows your Angular app to call this API without being blocked by the browser.

---

## **Step 5 — Add Controllers**

Example: `Controllers/UserController.cs`

```csharp
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
```

* Repeat similar structure for `CandidateController` and `VoteController`.

---

## **Step 6 — Create Migrations & Database**

1. Add initial migration:

   ```bash
   dotnet ef migrations add InitialCreate
   ```
2. Update the database:

   ```bash
   dotnet ef database update
   ```
3. Check MySQL — a database `myappdb` should exist with tables for `Users`, `Candidates`, and `Votes`.

---

## **Step 7 — Test API**

1. Start the API:

   ```bash
   dotnet run
   ```
2. Your endpoints will run on: `http://localhost:5000/api/user` (or whichever controller).
3. You can test using Postman, VS Code REST Client (`MyApp.http`), or directly with Angular later.

---

## **Step 8 — Prepare Angular client**

1. Install Angular globally (if you haven’t):

   ```bash
   npm install -g @angular/cli
   ```
2. Create project:

   ```bash
   ng new myapp-frontend
   ```
3. In `angular.json`, make sure your `proxy.conf.json` points to your backend:

   ```json
   {
     "/api": {
       "target": "http://localhost:5000",
       "secure": false
     }
   }
   ```
4. Run Angular with proxy:

   ```bash
   ng serve --proxy-config proxy.conf.json
   ```
5. Your Angular frontend can now call the ASP.NET Core backend API.

---

💡 **Summary:**
We set up a **C# ASP.NET Core Web API with EF Core + MySQL**, created a **voting system database**, added controllers, tested the API, and made it ready for an **Angular frontend**.

---


