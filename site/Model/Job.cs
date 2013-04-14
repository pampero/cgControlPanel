using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class Job: BusinessObject
    {
        
        public Job()
        {
            AddRule(new ValidateRequired("JobId"));
            AddRule(new ValidateRequired("Group"));
            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateRequired("CreatedBy"));
            AddRule(new ValidateRequired("CreatedDate"));

            AddRule(new ValidateLength("Group", 1, 50));
            AddRule(new ValidateLength("Name", 1, 70));
            AddRule(new ValidateLength("Description", 0, 500));
            AddRule(new ValidateLength("Comments", 0, 1000));
            AddRule(new ValidateLength("InputXmlFixedParameters", 0, 8000));
            AddRule(new ValidateLength("InputSchemaProcedure", 0, 255)); 
            AddRule(new ValidateLength("CreatedBy", 1, 50));

            AddRule(new ValidateDelete("JobId"));

            this.Triggers = new List<JobTrigger>();
        }

        public int JobId { get; set; }
        public int JobTypeEnum { get; set; }
        public JobType JobType
        {
            get { return (JobType) JobTypeEnum; }
            set { JobTypeEnum = (int) value; }
        }
        public int SecurityLevel { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsGeneral { get; set; }
        public int? ParentJobId { get; set; }
        public string Group { get; set; }
        public DateTime? AutomaticProcessTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string InputSchemaProcedure { get; set; }
        public string InputXmlFixedParameters { get; set; } 
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual IList<JobTrigger> Triggers { get; set; }
        public byte Weekdays { get; set; }
    }
}
