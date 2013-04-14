using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using CG.Services.impl;
using Model;
using NUnit.Framework;
using Quartz;
using Quartz.Impl;
using Services.Scheduling.impl;

namespace Test.ServicesTests
{
    [TestFixture]
    public class DefaultSchedulerServiceTest
    {
        private DefaultJobSchedulerService _schedulerService { get; set; }
        private SqlJob _sqlJob { get; set; }
        private SqlJobTrigger _sqlJobTrigger = new SqlJobTrigger();
        
        [SetUp]
        public void Setup()
        {
            _schedulerService = new DefaultJobSchedulerService();
            _schedulerService.UnitOfWork = new UnitOfWork();
           
            ISchedulerFactory sf = new StdSchedulerFactory();
            ((DefaultJobSchedulerService)_schedulerService).Scheduler = sf.GetScheduler();
            _schedulerService.Start();

            _sqlJobTrigger = new SqlJobTrigger
            {
                CreatedBy = "Pepe",
                CreatedDate = DateTime.Now,
                Enabled = true,
                JobLogs = new List<JobLog>(),
                JobTriggerStatus = JobTriggerStatus.NoAgendado,
                XmlFormInputValues = "<prueba>Prueba</prueba>",
            };

            _sqlJob = new SqlJob
            {
                Comments = "blabla",
                CreatedBy = "sdsd",
                DatabaseName = "CGControlPanel3",
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
                Password = "123456",
                Logs = new List<JobLog>(),
                Triggers = new List<JobTrigger>
                               {
                                   _sqlJobTrigger
                               },
                SCHED_NAME = "asdsdsa",
                LastExecutionStatus = LastExecutionStatus.Success,
                LastExecutionStatusEnum = 1,
                ServerName = @".\SQLEXPRESS",
                UserName = "sa",
                ExecProcedure = "OP_PROCESO_EJEMPLO_EXEC",
            };

            _sqlJobTrigger.Job = _sqlJob;
        }

        [TearDown]
        public void TearDown()
        {
            _schedulerService.Stop();
        }
        
        [Test]
        public void GetJobs_Mehtod_Should_Return_A_Job_List()
        {
            var schedulerService = new DefaultJobSchedulerService();
            var jobs = schedulerService.GetJobs();
            Assert.IsTrue(jobs.Count > 0);
        }

        [Test]
        public void ManualScheduler()
        {
           //_schedulerService.AddJob(_sqlJob);
           _schedulerService.AddTrigger(_sqlJobTrigger);
           var trigger = (SqlJobTrigger) _schedulerService.GetJobTriggers().Last();
           _schedulerService.FiringManualTrigger(trigger.JobTriggerId);
           trigger = (SqlJobTrigger)_schedulerService.GetJobTriggers().Last();
           Assert.IsTrue(trigger.Job.JobStatusEnum == (int) JobStatus.Success);
           Assert.IsTrue(trigger.RecordsAffected == 10);
        }
    }
}
