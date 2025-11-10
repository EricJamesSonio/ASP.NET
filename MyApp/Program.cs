using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.DataSeed; // 👈 Add this namespace if you’ll put seeds in a separate folder
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ---------------------
// 1️⃣ Add services
// ---------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32))
    )
);

// ---------------------
// 2️⃣ Configure CORS
// ---------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// ---------------------
// 3️⃣ Middleware
// ---------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

// ---------------------
// 4️⃣ Seed database
// ---------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // Ensures DB exists
    DbSeeder.Seed(db);     // 👈 Call your seeding method here
}

app.Run();
