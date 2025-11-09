

1. **Install Swagger NuGet package**

```bash
dotnet add package Swashbuckle.AspNetCore
```

2. **Add `using` in Program.cs**

```csharp
using Microsoft.OpenApi.Models;
```

3. **Add Swagger services**

```csharp
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
```

4. **Enable Swagger middleware**

```csharp
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
```

5. **Run your API**

* Swagger UI will be available at: `http://localhost:5192/swagger/index.html`


