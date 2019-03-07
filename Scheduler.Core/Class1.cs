using System;

namespace Scheduler.Core
{
    public class Jobs
    {

        public static void MyJob()
        {
            Console.WriteLine($"Job Run {DateTime.Now}");
        }
            
    }
}
