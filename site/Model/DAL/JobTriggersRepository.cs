using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAL
{
    public class JobTriggersRepository : GenericRepository<JobTrigger>
    {
        public JobTriggersRepository(CGControlPanelContext context) : base(context)
        {
            
        }

        public List<JobTrigger> GetTriggerByExecutionDay(DateTime date)
        {
            return context.JobTriggers.Where(t => t.ScheduledStartExecutionDate.Day == date.Day && t.ScheduledStartExecutionDate.Month == date.Month && t.ScheduledStartExecutionDate.Year == date.Year && !t.Deleted).OrderBy(t => t.StartExecutionDate).ToList();
        }

        public List<JobTrigger> GetTriggerByExecutionDay(DateTime date, JobTriggerStatus jobTriggerStatus)
        {
            return context.JobTriggers.Where(t => t.ScheduledStartExecutionDate.Day == date.Day && t.ScheduledStartExecutionDate.Month == date.Month && t.ScheduledStartExecutionDate.Year == date.Year && t.JobTriggerStatusEnum == (int)jobTriggerStatus && !t.Deleted).OrderBy(t => t.StartExecutionDate).ToList();
        }

        public List<SqlJobTrigger> GetSqlTriggerByExecutionDay(DateTime date, JobTriggerStatus jobTriggerStatus)
        {
            return context.SqlJobTriggers.Where(t => t.ScheduledStartExecutionDate.Day == date.Day && t.ScheduledStartExecutionDate.Month == date.Month && t.ScheduledStartExecutionDate.Year == date.Year && t.JobTriggerStatusEnum == (int)jobTriggerStatus && !t.Deleted).OrderBy(t => t.StartExecutionDate).ToList();
        }

        public List<JobTrigger> GetTriggerByExecutionDay(DateTime date, JobType jobType)
        {
            return context.JobTriggers.Where(t => t.ScheduledStartExecutionDate.Day == date.Day && t.ScheduledStartExecutionDate.Month == date.Month && t.ScheduledStartExecutionDate.Year == date.Year && t.Job.JobTypeEnum == (int)jobType && !t.Deleted).OrderBy(t => t.StartExecutionDate).ToList();
        }

        public List<JobTrigger> GetAll()
        {
            return context.JobTriggers.Where(t => !t.Deleted).OrderByDescending(t => t.ScheduledStartExecutionDate).ToList();
        }
    }
}
