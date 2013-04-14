using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Model
{
    public class CGControlPanelInitializer : DropCreateDatabaseIfModelChanges<CGControlPanelContext>
    {
        protected override void Seed(CGControlPanelContext context)
        {
            try
            {

                var jobs = new List<SqlJob>
                                {
                                    new SqlJob { DatabaseName="TestDB", ExecProcedure="Procedure", UserName="cvazquez", Password="clave", ServerName = "server", JobStatus = JobStatus.Success, CreatedBy = "", CreatedDate = DateTime.Now, Deleted = false, Description = "", ExecutionDays = 1, JobStatusEnum = 1, JobType = JobType.Manual, Name = "", Group="", JobTypeEnum = 1, JOB_GROUP = "", JOB_NAME="", SCHED_NAME = "", LastExecutionStatus = LastExecutionStatus.Success}
                                };

                jobs.ForEach(s => context.Jobs.Add(s));

                context.SaveChanges();

                var job = context.Jobs.SingleOrDefault(x => x.JobId == 1);

                var a = job.JobType == JobType.Automatico;

                var jobTriggers = new List<JobTrigger>
                                 {
                                     new SqlJobTrigger
                                         {
                                             RecordsProcessed = 10,
                                             CreatedBy = "",
                                             Job = job,
                                             CreatedDate = DateTime.Now,
                                             JobTriggerStatus = JobTriggerStatus.Ejecutado,
                                             Enabled = true
                                         }
                                 };

                jobTriggers.ForEach(s => context.JobTriggers.Add(s));
                context.SaveChanges();

                var jobTrigger = context.JobTriggers.SingleOrDefault(x => x.JobTriggerId == 1);

                var jobLog = new List<JobLog>
                                {
                                    new JobLog { JobTrigger = jobTrigger, Job  = job, ExecutionDate = DateTime.Now, InputValue = "", JobLogStatus = JobLogStatus.Success }
                                };

                jobLog.ForEach(s => context.JobLogs.Add(s));
                context.SaveChanges();

            }
            catch (Exception exception)
            {

                throw;
            }

        }
    }
}
