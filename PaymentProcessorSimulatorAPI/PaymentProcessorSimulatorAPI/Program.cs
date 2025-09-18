using Microsoft.OpenApi.Models;           // For OpenAPI/Swagger
using PaymentApi.Services;                // Your custom services namespace
using PaymentProcessingApi.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// ✅ Add Swagger / OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Payment Processing API",
        Version = "v1",
        Description = "An API for handling payment processing with Swagger documentation."
    });
});

// Register your Payment Service
builder.Services.AddSingleton<IPaymentService, PaymentService>();
builder.Services.AddSingleton<S3Service>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    // ✅ Enable Swagger middleware
    app.UseSwagger();

    // ✅ Enable Swagger UI at root URL (/)
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Processing API v1");
        options.RoutePrefix = string.Empty; // Swagger UI served at http://localhost:5000/
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();