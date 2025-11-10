using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ---------------------
// 1️⃣  Add services
// ---------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🧠 Hardcode the MySQL version instead of AutoDetect (avoids slow startup)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)) // ← change to your version
    )
);

// ---------------------
// 2️⃣  Configure CORS properly (fast, cacheable)
// ---------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")  // ✅ your Angular dev server
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// ---------------------
// 3️⃣  Middleware order (important!)
// ---------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();             // must come first
app.UseCors("AllowAngular");  // then CORS
app.UseAuthorization();       // then auth (if any)
app.MapControllers();         // finally, your controllers

// ---------------------
// 4️⃣  (Optional) Warm up the DB so first request is fast
// ---------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.CanConnect();
}

app.Run();
