using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.DAL
{
    public class JobsRepository : GenericRepository<Job>
    {
        public JobsRepository(CGControlPanelContext context) : base(context)
        {
            
        }

        public List<Job> GetAll()
        {
            return context.Jobs.ToList();
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
            return context.Jobs.Where(j => j.Group == groupName).ToList();
        }

        public Job GetJobByName(string name)
        {
            return context.Jobs.Single(j => j.Name == name);
        }

        public List<Job> GetJobsByFavorites()
        {
            return context.Jobs.Where(j => j.IsFavorite).ToList();
        }

        public List<Job> GetJobByType(JobType jobType)
        {
            return context.Jobs.Where(j => j.JobType == jobType).ToList();
        }

        public List<Job> GetJobsByDaily()
        {
            return context.Jobs.Where(j => j.IsDaily).ToList();
        }
    }
}
