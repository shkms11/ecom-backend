using EcommerceAPI.Application; // <-- add this
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigins = new[]
{
    "http://localhost:5173", // Vite
    "http://localhost:3000", // CRA
};

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "ReactCors",
        policy =>
        {
            policy.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        }
    );
});

// Application layer (MediatR, FluentValidation, pipeline behaviors)
builder.Services.AddApplication();

// Controllers
builder.Services.AddControllers();

// OpenAPI / Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

// CORS
app.UseCors("ReactCors");

// Dev-only OpenAPI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Later you will add app.UseAuthentication() here once JWT is wired
app.UseAuthorization();

app.MapControllers();

app.Run();
