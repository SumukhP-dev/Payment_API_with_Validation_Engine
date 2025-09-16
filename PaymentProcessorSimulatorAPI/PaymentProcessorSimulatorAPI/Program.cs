using PaymentApi.Services;
using Swashbuckle.AspNetCore.SwaggerGen; // Ensure Swashbuckle is referenced
using Swashbuckle.AspNetCore.SwaggerUI;  // Ensure Swashbuckle is referenced
using Microsoft.OpenApi.Models;          // Optional, for OpenAPI types
using Swashbuckle.AspNetCore.Swagger;    // Add this using for UseSwagger extension methods

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// ✅ Add Swagger / OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register in-memory payment service
builder.Services.AddSingleton<IPaymentService, PaymentService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    // ✅ Enable Swagger UI
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();