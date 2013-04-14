using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAL
{
    public class SqlJobsRepository : GenericRepository<SqlJob>
    {
        public SqlJobsRepository(CGControlPanelContext context)
            : base(context)
        {
            
        }

        public List<SqlJob> GetAll()
        {
            return context.SqlJobs.Where(x => !x.Deleted).OrderByDescending(x =>x.CreatedDate).ToList();
        }
    }
    public class JobsRepository : GenericRepository<Job>
    {
        public JobsRepository(CGControlPanelContext context) : base(context)
        {
            
        }

        public List<Job> GetAll()
        {
            return context.Jobs.Where(x => !x.Deleted).OrderByDescending(x => x.CreatedDate).ToList();
        }

        public List<Job> GetJobsByExecutionDay(DateTime dateTime)
        {
            var jobs = new List<Job>();
            foreach (var job in context.Jobs)
            {
                foreach(var trigger in job.Triggers)
                {
                    if (trigger.StartExecutionDate.Equals(dateTime)) 
                        jobs.Add(job);
                }

            }
            return jobs;
        }

        public List<Job> GetJobsByGroupName(string groupName)
        {
            return context.Jobs.Where(j => j.Group == groupName && !j.Deleted).ToList();
        }

        public Job GetJobByName(string name)
        {
            return context.Jobs.Single(j => j.Name == name && !j.Deleted);
        }

        public List<Job> GetJobsByFavorites()
        {
            return context.Jobs.Where(j => j.IsFavorite && !j.Deleted).ToList();
        }

        public List<Job> GetJobsByGeneral()
        {
            return context.Jobs.Where(j => j.IsGeneral && !j.Deleted).ToList();
        }

        public List<Job> GetRelatedJobs(int jobId)
        {
            return context.Jobs.Where(j => j.ParentJobId != null && j.ParentJobId == jobId && !j.Deleted).ToList();
        }

        public List<Job> GetJobByType(JobType jobType)
        {
            return context.Jobs.Where(j => j.JobType == jobType && !j.Deleted).ToList();
        }

        private string TranslateDayOfWeek(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Friday:
                    return "FRI";
                case DayOfWeek.Monday:
                    return "MON";
                case DayOfWeek.Saturday:
                    return "SAT";
                case DayOfWeek.Sunday:
                    return "SUN";
                case DayOfWeek.Thursday:
                    return "THU";
                case DayOfWeek.Tuesday:
                    return "TUE";
                case DayOfWeek.Wednesday:
                    return "WED";
            }
            return "";
        }

        private string BuildDays(Weekdays weekdays)
        {
            string legend = (weekdays.Sunday) ? "SUN" : "";
            legend = (weekdays.Monday) ? legend + "MON" : legend;
            legend = (weekdays.Tuesday) ? legend + "TUE" : legend;
            legend = (weekdays.Wednesday) ? legend + "WED" : legend;
            legend = (weekdays.Thursday) ? legend + "THU" : legend;
            legend = (weekdays.Friday) ? legend + "FRI" : legend;
            legend = (weekdays.Saturday) ? legend + "SAT" : legend;
            return legend;
        }

        public List<Job> GetJobsByDaily(DateTime selectedDate)
        {
            DayOfWeek dayOfWeek = selectedDate.Date.DayOfWeek;
            var dayTranslated = TranslateDayOfWeek(dayOfWeek);

            var jobs = context.Jobs.Where(j => !j.Deleted).ToList();
            var newJobsList = new List<Job>();

            foreach (var job in jobs)
            { 
                Weekdays weekDays = new Weekdays();

                weekDays.AllDays = job.Weekdays;

                var executionDays = BuildDays(weekDays);

                if (executionDays.IndexOf(dayTranslated, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    newJobsList.Add(job);
                }
            }

            return newJobsList;
        }
    }
}
