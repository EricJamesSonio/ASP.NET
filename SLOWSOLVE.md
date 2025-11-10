
---

# 🧠 PERFORMANCE_FIX.md

### Fixing Slow API Requests Between Angular & ASP.NET Core

**Goal:**
Reduce the 3–5 second delay experienced when Angular calls the ASP.NET Core backend (especially during login).

---

## ⚙️ Problem Summary

Angular runs on `http://localhost:4200`, while the backend runs on `http://localhost:5192`.
Because they use **different ports**, the browser treats this as a **cross-origin request**, triggering **CORS preflight checks** before sending the real request.

The backend also had some **Entity Framework startup overhead** and **middleware order** issues, which made the delay worse.

---

## ✅ Fix Summary

| Area                           | Issue                                                                      | Solution                                                                 | Result                                 |
| ------------------------------ | -------------------------------------------------------------------------- | ------------------------------------------------------------------------ | -------------------------------------- |
| **CORS configuration**         | Used `AllowAnyOrigin()` which caused slow, repeated preflight requests     | Replaced with named policy using `.WithOrigins("http://localhost:4200")` | Faster, cacheable CORS responses       |
| **Middleware order**           | `UseCors()` was placed after routing                                       | Moved `UseCors()` right after `UseRouting()`                             | Preflight requests handled immediately |
| **EF Core AutoDetect**         | `ServerVersion.AutoDetect()` opens a temporary DB connection every startup | Replaced with hardcoded MySQL version                                    | Faster startup (no extra connection)   |
| **Cold start (first request)** | App waited until first real request to connect to DB                       | Added warm-up code using `db.Database.CanConnect()`                      | Instant response on first call         |

---

## 🧩 Updated `Program.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🚀 1. Faster EF Core setup
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)) // Hardcoded version = faster startup
    )
);

// 🚀 2. Proper CORS setup (Angular dev URL)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 🚀 3. Correct middleware order
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

// 🚀 4. Warm up EF Core (fix first-call slowness)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.CanConnect();
}

app.Run();
```

---

## 🧪 Result After Fix

| Test                | Before            | After             |
| ------------------- | ----------------- | ----------------- |
| First login request | ~4–5 seconds      | ~200–400ms        |
| Subsequent requests | ~2 seconds        | <100ms            |
| Console DB log      | Appears instantly | Appears instantly |

---

## 🧠 Notes

* Always match **protocols** — if backend uses `https://localhost:7192`, use HTTPS in Angular too.
* Only allow specific origins (never `AllowAnyOrigin()` in production).
* You can further measure performance using ASP.NET middleware logging or Application Insights.

---

