using Hangfire;
using Microsoft.EntityFrameworkCore;
using MyApp.Application;
using MyApp.Domain;
using MyApp.Infrastructure;
using MyApp.Worker;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(AppContext.BaseDirectory);
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Register Repository and Job
        services.AddScoped<IRepository<DataEntity>, Repository<DataEntity>>();
        services.AddScoped<DataUpsertJob>();

        // Configure Hangfire
        services.AddHangfire(config => config.UseSqlServerStorage(connectionString));
        services.AddHangfireServer();

        services.AddHostedService<Worker>();
    })
    .Build();
    
await builder.RunAsync();
