using Hangfire;
using Scheduler.Core;
using System;

namespace Scheduler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("Server=localhost;Database=scheduler;Trusted_Connection=True;");
			GlobalConfiguration.Configuration.UseColouredConsoleLogProvider();

            Console.WriteLine("Running...");

            var w = new BackgroundJobServer();

            RecurringJob.AddOrUpdate("myjob", () => Jobs.MyJob(), Cron.Minutely);

            Console.ReadLine();
            w.Dispose();
        }
        
    }
}
