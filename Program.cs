using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Registers Swagger services to generate API documentation
builder.Services.AddSwaggerGen(); // Add this above the line below.

builder.Services.AddDbContext<ProjectDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Enables middleware to generate the Swagger JSON document
    app.UseSwaggerUI(); // Enables the Swagger UI to visualize and interact with the API
}

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
