using Hangfire;
using MyApp.Application;

namespace MyApp.Worker 
{ 
    public class Worker : BackgroundService 
    { 
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) 
        { 
            RecurringJob.AddOrUpdate<DataUpsertJob>(job => job.Execute(), Cron.Hourly); 
            await Task.Delay(Timeout.Infinite, stoppingToken); 
        } 
    } 
}
