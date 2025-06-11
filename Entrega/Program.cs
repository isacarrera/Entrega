using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Entity.Context;
using Data;
using Busines;
using Entity.DTOs;

var builder = WebApplication.CreateBuilder(args);

// === Servicios ===
builder.Services.AddRazorPages();
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Inyección de dependencias
builder.Services.AddScoped<ClienteData>();
builder.Services.AddScoped<ClienteBusines>();

builder.Services.AddScoped<ProductoData>();
builder.Services.AddScoped<ProductoBusines>();
builder.Services.AddScoped<PedidoData>();
builder.Services.AddScoped<PedidoBusines>();
builder.Services.AddScoped<PedidoProductoData>();
builder.Services.AddScoped<PedidoProductoBusines>();


// === Build app ===
var app = builder.Build();

// === Middleware ===
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(); // Accedé a /swagger
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
