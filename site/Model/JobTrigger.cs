using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class JobTrigger : BusinessObject
    {
       
        public JobTrigger()
        {
            AddRule(new ValidateRequired("ScheduledStartExecutionDate"));
            AddRule(new ValidateRequired("JobId"));
            AddRule(new ValidateRequired("JobTriggerId"));
            AddRule(new ValidateRequired("CreatedBy"));
            AddRule(new ValidateRequired("CreatedDate"));

            AddRule(new ValidateLength("CreatedBy", 1,50));
            AddRule(new ValidateDelete("JobTriggerId"));

            // Valida:
            //  Si es job manual y la fecha de ScheduledStartExecutionDate  < hoy =>> ERROR
            //  Si es job automatico y la fecha y hora de ScheduledStartExecutionDate < ahora =>> ERROR 
            AddRule(new ValidateSchedule("ScheduledStartExecutionDate", "JobId"));
        }

        public int JobTriggerId { get; set; }
        public int JobId { get; set; }

        public int JobTriggerStatusEnum { get; set; }

        public JobTriggerStatus JobTriggerStatus
        {
            get { return (JobTriggerStatus) JobTriggerStatusEnum; }
            set { JobTriggerStatusEnum = (int) value; }
        }

        public DateTime ScheduledStartExecutionDate { get; set; }
        public DateTime? StartExecutionDate { get; set; }
        public DateTime? EndExecutionDate { get; set; }
        public string OutputExecutionLog { get; set; }
        public string SerializedJob { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Enabled { get; set; }
        public virtual Job Job { get; set; }
    }
}
