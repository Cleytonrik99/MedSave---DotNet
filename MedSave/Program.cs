using HealthChecks.UI.Client;
using MedSave.Context;
using MedSave.Repositories;
using MedSave.Services;
using MedSave.Services.Manufacturer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddOracle(
        connectionString: connectionString, 
        name: "oracle-database", 
        failureStatus: HealthStatus.Degraded,
        tags: new[]{"db", "oracle", "sql"},
        timeout: TimeSpan.FromSeconds(10)
    );

builder.Services.AddHealthChecksUI(options =>
    {
        options.SetEvaluationTimeInSeconds(15);
        options.MaximumHistoryEntriesPerEndpoint(50);
        options.SetApiMaxActiveRequests(1);
        options.AddHealthCheckEndpoint("Health Check General", "/health");
        options.AddHealthCheckEndpoint("Health Check Database", "/health/database");
    })
    .AddInMemoryStorage();

// ==============================
// DbContext
// ==============================
builder.Services.AddDbContext<MedSaveContext>();


// ==============================
// Users Repositories
// ==============================
builder.Services.AddScoped<UsersSysRepository>();
builder.Services.AddScoped<ContactUserRepository>();


// ==============================
// Stock Repositories
// ==============================
builder.Services.AddScoped<IStockRepository, StockRepository>();


// ==============================
// Manufacturer Repositories
// ==============================
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
builder.Services.AddScoped<IAddressManufacturerRepository, AddressManufacturerRepository>();
builder.Services.AddScoped<IContactManufacturerRepository, ContactManufacturerRepository>();


// ==============================
// Services
// ==============================
builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<IUsersSysService, UsersSysService>();
builder.Services.AddScoped<IStockService, StockService>();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecks("/health/database", new HealthCheckOptions
{
    Predicate = (check) => check.Tags.Contains("db"),
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecksUI(options =>
{
    options.UIPath = "/health-ui";
});

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedSave API v1");
    c.RoutePrefix = "swagger";
});

app.MapGet("/healthCheckSimples", () => "Application live with Health Checks");

app.MapControllers();

app.Run();









/*

        // ==============================
        // Swagger + XML comments
        // ==============================
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "NeuroTrack API",
                Version = "v1",
                Description = "API RESTful da solução NeuroTrack para monitoramento de estresse digital (scores, previsões, limites e logs diários)."
            });

            // Inclui comentários XML (///) dos controllers e DTOs
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        });

*/