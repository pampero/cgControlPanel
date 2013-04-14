using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class Job
    {
        public Job()
        {
            this.Logs = new List<JobLog>();
            this.Triggers = new List<JobTrigger>();
        }

        public int JobId { get; set; }
        public int JobTypeEnum { get; set; }

        public JobType JobType
        {
            get { return (JobType) JobTypeEnum; }
            set { JobTypeEnum = (int) value; }
        }

        public int JobStatusEnum { get; set; }

        public JobStatus JobStatus
        {
            get { return (JobStatus) JobStatusEnum; }
            set { JobStatusEnum = (int) value; }
        }

        public int ExecutionDays { get; set; }
        
        public int LastExecutionStatusEnum { get; set; }

        public LastExecutionStatus LastExecutionStatus
        {
            get { return (LastExecutionStatus) LastExecutionStatusEnum; }
            set { LastExecutionStatusEnum = (int) value; }
        }

        public bool IsFavorite { get; set; }
        public bool IsDaily { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string InputSchemaProcedure { get; set; }
        public string FixedParametersProcedure { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SCHED_NAME { get; set; }
        public string JOB_NAME { get; set; }
        public string JOB_GROUP { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual IList<JobLog> Logs { get; set; }
        public virtual IList<JobTrigger> Triggers { get; set; }
    }
}
