using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class JobTrigger
    {
        public JobTrigger()
        {
            this.JobLogs = new List<JobLog>();
        }

        public int JobTriggerId { get; set; }
        public int JobId { get; set; }
        
        public int JobTriggerStatusEnum { get; set; }

        public JobTriggerStatus JobTriggerStatus
        {
            get { return (JobTriggerStatus) JobTriggerStatusEnum; }
            set { JobTriggerStatusEnum = (int) value; }
        }

        public DateTime? StartExecutionDate { get; set; }
        public DateTime? EndExecutionDate { get; set; }
        public string XmlTableExecutionLog { get; set; }
        public string SerializedJob { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Enabled { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<JobLog> JobLogs { get; set; }
    }
}
