using Hangfire;
using Scheduler.Core;
using System;

namespace Scheduler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=server;Database=scheduler;User Id=sa;Password=DockerSQL1!; ");

            Console.WriteLine("Running...");

            var w = new BackgroundJobServer();

            RecurringJob.AddOrUpdate("myjob", () => Jobs.MyJob(), Cron.Minutely);

            Console.ReadKey();
            w.Dispose();
        }
        
    }
}
