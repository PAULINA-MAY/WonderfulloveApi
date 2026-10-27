
using Microsoft.EntityFrameworkCore;
using Wonderfullove.Data;
using Wonderfullove.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios
builder.Services.AddScoped<InterfaceProducto, ProductosService>();

// Configurar la conexión a SQL Server
builder.Services.AddDbContext<WonderFulLoveContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

// Configurar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
