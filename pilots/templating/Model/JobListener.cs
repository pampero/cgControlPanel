using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;

namespace Model
{
    public class JobListener : IJobListener
    {
        public string Name
        {
            get { return GetType().Name; }
        }
        
        public void JobToBeExecuted(IJobExecutionContext context)
        {
            //TODO:loguar lo que hay que hacer despues que se ejecute el job
        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            throw new NotImplementedException();
        }
    }
}
