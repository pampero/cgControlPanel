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

        public List<JobTrigger> GetTriggerByExecutionDate(DateTime date)
        {
            return context.JobTriggers.Where(t => t.StartExecutionDate == date).ToList();
        }

        public List<JobTrigger> GetAll()
        {
            return context.JobTriggers.ToList();
        }
    }
}
