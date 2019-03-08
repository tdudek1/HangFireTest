using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Scheduler.Web.Pages
{
	public class IndexModel : PageModel
	{
		[BindProperty]
		public String Cron { get; set; }
		[BindProperty]
		public String Delay { get; set; }
		[BindProperty]
		public String CronName { get; set; }

		public void OnGet()
		{

		}

		public void OnPostDelay()
		{
			var time = DateTime.Now;
			BackgroundJob.Schedule(() => Console.WriteLine($"Delay Job {time}"), TimeSpan.FromSeconds(int.Parse(this.Delay)));
		}

		public void OnPostCron()
		{
			RecurringJob.AddOrUpdate(CronName, () => Console.WriteLine($"Recurring Job {CronName}"), Cron);
		}
	}
}
