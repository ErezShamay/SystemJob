using System;
using System.Timers;

namespace Tangelo.MyJobSceduler
{
    public class JobRunner
    {
        private Timer _timer; //each time the timer is being called it allocates a new thread and handel it 
        private Action _action; //the request for allocate from timer
        private JobDetails _jobDetails; //job details

        public JobStatus Status { get; private set; }

        public JobRunner(Action action, JobDetails jobDetails)
        {
            _jobDetails = jobDetails;

            _timer = new Timer();
            _timer.Interval = TimeSpan.FromSeconds((int)jobDetails.IntervaL).TotalMilliseconds;
            _timer.Elapsed += Timer_Elapsed; // is the init for the whole process
            _timer.AutoReset = _jobDetails.IsRunnable;
            _action = action;

            Status = JobStatus.New;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {

                Status = JobStatus.Running;
                _action();
                Status = JobStatus.Done;
            }
            catch (Exception ex)
            {
                Status = JobStatus.Failed;
                Console.WriteLine(ex);
            }
        }

        public void Start()
        {
            _timer.Start();
        }
    }
}
