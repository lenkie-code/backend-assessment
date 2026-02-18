using BackendAssessment.Api.Middleware;
using BackendAssessment.Infrastructure.Persistence;
using Hangfire;
using Hangfire.PostgreSql;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Serilog;

// Configure Serilog for structured logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .Enrich.FromLogContext()
    .CreateLogger();

try
{
    Log.Information("Starting BackendAssessment API");

    var builder = WebApplication.CreateBuilder(args);

    // Use Serilog
    builder.Host.UseSerilog();

    // Add Controllers (traditional controller routing)
    builder.Services.AddControllers();

    // Register MediatR v14 — scan the Application assembly for handlers
    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssemblyContaining<Program>());

    // Register EF Core with PostgreSQL
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Register MassTransit v8 with RabbitMQ
    builder.Services.AddMassTransit(x =>
    {
        x.UsingRabbitMq((context, cfg) =>
        {
            cfg.Host(builder.Configuration.GetValue<string>("RabbitMQ:Host") ?? "localhost", "/", h =>
            {
                h.Username(builder.Configuration.GetValue<string>("RabbitMQ:Username") ?? "guest");
                h.Password(builder.Configuration.GetValue<string>("RabbitMQ:Password") ?? "guest");
            });

            cfg.ConfigureEndpoints(context);
        });
    });

    // Register Hangfire with PostgreSQL storage
    builder.Services.AddHangfire(config =>
        config.UsePostgreSqlStorage(options =>
            options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection") ?? "")));
    builder.Services.AddHangfireServer();

    // Register Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Apply EF Core migrations on startup
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate();
    }

    // Configure middleware pipeline
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // Log HTTP requests
    app.UseSerilogRequestLogging();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthorization();

    // Hangfire dashboard — allow remote access in development (runs inside Docker)
    app.UseHangfireDashboard("/hangfire", new DashboardOptions
    {
        Authorization = new[] { new HangfireAllowAllAuthorizationFilter() }
    });

    // Map traditional controllers
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

/// <summary>
/// Allows all requests to the Hangfire dashboard (development use only).
/// Required because the app runs inside Docker, making browser requests appear non-local.
/// </summary>
public class HangfireAllowAllAuthorizationFilter : Hangfire.Dashboard.IDashboardAuthorizationFilter
{
    public bool Authorize(Hangfire.Dashboard.DashboardContext context) => true;
}
