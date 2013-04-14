using System;
using System.Collections.Generic;

namespace Model
{
    public class JobLog
    {
        public int JobLogId { get; set; }
        public int JobTriggerId { get; set; }
        public int JobId { get; set; }
        public string InputValue { get; set; }
        public string OutputValue { get; set; }
        public System.DateTime ExecutionDate { get; set; }
        
        public int JobLogStatusEnum { get; set; }

        public JobLogStatus JobLogStatus
        {
            get { return (JobLogStatus) JobLogStatusEnum; }
            set { JobLogStatusEnum = (int) value; }
        }

        public virtual Job Job { get; set; }
        
        public virtual JobTrigger JobTrigger { get; set; }
    }
}
