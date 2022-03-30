using System.Collections.Generic;

namespace Tangelo.MyJobSceduler
{
    public class MyJobScheduler
    {
        private readonly List<JobRunner> _allJobs;
      

        public MyJobScheduler()
        {
            _allJobs = new List<JobRunner>();
        }

        public void AddJob(IJob job, JobDetails jobDetails)
        {
            var jobRunManager = new JobRunner(job.Execute, jobDetails);
            _allJobs.Add(jobRunManager);
        }

        public void Start()
        {
            foreach (var job in _allJobs)
            {
                job.Start();
            }
        }
    }
}
