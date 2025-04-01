
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!);
    opts.DatabaseSchemaName = "catalog";

    opts.AutoCreateSchemaObjects = AutoCreate.CreateOrUpdate;
    opts.CreateDatabasesForTenants(c =>
    {
        c.MaintenanceDatabase("Host=catalogdb;Port=5432;Username=postgres;Password=postgres");
        c.ForTenant()
            .CheckAgainstPgDatabase()
            .WithOwner("postgres")
            .WithEncoding("UTF-8")
            .ConnectionLimit(-1);
    });
    opts.Logger(new ConsoleMartenLogger());
}).UseLightweightSessions().ApplyAllDatabaseChangesOnStartup();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddHealthChecks()
                .AddNpgSql(builder.Configuration.GetConnectionString("DefaultConnection")!);

var app = builder.Build();


// Configure the HTTP request pipeline.

app.MapCarter();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health",

    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

    }
);



app.Run();
