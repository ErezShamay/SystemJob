using System;

namespace Tangelo.MyJobSceduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var myJobScheduler = new MyJobScheduler();
            myJobScheduler.AddJob(new Job1(), new JobDetails { JobId = Guid.NewGuid(), Name = "Job1", IntervaL = JobInterval.Hour, IsRunnable = false });
            myJobScheduler.AddJob(new Job2(), new JobDetails { JobId = Guid.NewGuid(),Name = "Job2", IntervaL = JobInterval.SixHours, IsRunnable = true });

            myJobScheduler.Start();

            Console.WriteLine("MyJobScheduler is running");
            Console.WriteLine("Type 'Stop' to stop");

            while (Console.ReadLine().ToLower() != "stop")
            { }

            Console.WriteLine("MyJobScheduler Stopped!!!!");
        }
    }

    public class Job1 : IJob
    {
        public void Execute()
        {
            System.Console.WriteLine("In Job 1");
        }
    }

    public class Job2 : IJob
    {
        public void Execute()
        {
            System.Console.WriteLine("In Job 2");
        }
    }
}
