using System;

namespace Tangelo.MyJobSceduler
{
    public class JobDetails
    {
        public Guid JobId { get; set; }
        public string Name { get; set; }
        public JobInterval IntervaL { get; set; }
        public bool IsRunnable { get; set; }
    }
}
