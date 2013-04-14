using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NUnit.Framework;

namespace Test.ModelTests
{
    [TestFixture]
    public class JobMappingTest
    {
        [Test]
        public void SQLMappingTest()
        {
            var sqlJob = new SqlJob
                             {
                                 Comments = "blabla",
                                 CreatedBy = "sdsd",
                                 DatabaseName = "CGControlPanel",
                                 CreatedDate = DateTime.Now,
                                 Deleted = false,
                                 DeletedBy = string.Empty,
                                 Description = "Descripcion",
                                 IsFavorite = true,
                                 ExecutionDays = 1,
                                 Group = "Replicación",
                                 Name = "Job Replicación 1",
                                 JobType = JobType.Automatico,
                                 InputSchemaProcedure = "wdwdsadsa",
                                 JOB_GROUP = "wwww",
                                 JOB_NAME = "adasas",
                                 JobStatus = JobStatus.Scheduled,
                                 JobStatusEnum = 1,
                                 JobTypeEnum = 1,
                                 Password = "PASSWORD",
                                 Logs = new List<JobLog>(),
                                 Triggers = new List<JobTrigger>(),
                                 SCHED_NAME = "asdsdsa",
                                 LastExecutionStatus = LastExecutionStatus.Success,
                                 LastExecutionStatusEnum = 1,
                                 ServerName = "SQL",
                                 UserName = "PEPE",
                                 ExecProcedure = "sarlanga"
                             };
            var unitOfWork = new UnitOfWork();
            unitOfWork.JobsRepository.Insert(sqlJob);
            unitOfWork.Save();
        }
    }
}
