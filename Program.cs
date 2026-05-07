using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adds our Controllers to our container and configures our [ApiController] behavior.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        // Don't automatically validate request bodies, as we will do our own validation.
        options.SuppressModelStateInvalidFilter = true;
    }
);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Registers Swagger services to generate API documentation
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProjectDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// If something requires the IIsaacRepository interface, supply IsaacRepositoryEfImpl class.
builder.Services.AddScoped<IIsaacRepository, IsaacRepositoryEfImpl>();
builder.Services.AddScoped<IsaacService>();

// Exception handler.
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

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

// Actually use the exception handler please.
app.UseExceptionHandler(_ => { });

app.Run();