using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using CG.Services.impl;
using Excel;
using log4net.Config;
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
        private SqlJob _sqlJob2 { get; set; }
        private SqlJob _sqlJob3 { get; set; }
        private SqlJob _sqlJob4 { get; set; }
        private SqlJob _sqlJob5 { get; set; }
        private SqlJob _sqlJob6 { get; set; }
        private SqlJobTrigger _sqlJobTrigger2 = new SqlJobTrigger();
        private SqlJobTrigger _sqlJobTrigger3 = new SqlJobTrigger();
        private SqlJobTrigger _sqlJobTrigger4 = new SqlJobTrigger();
        private SqlJobTrigger _sqlJobTrigger5 = new SqlJobTrigger();
        private SqlJobTrigger _sqlJobTrigger6 = new SqlJobTrigger();
        private UnitOfWork _unitOfWork { get; set; }
        private FileStream stream { get; set; }
        
        [SetUp]
        public void Setup()
        {
            stream = new FileStream(@"C:\test.xlsx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            
            ISchedulerFactory sf = new StdSchedulerFactory();
            if (_schedulerService == null)
            {
                _schedulerService = new DefaultJobSchedulerService();
                ((DefaultJobSchedulerService)_schedulerService).Scheduler = sf.GetScheduler();
            }
            _unitOfWork = new UnitOfWork();
            _schedulerService.UnitOfWork = _unitOfWork;
            //_schedulerService.Resume();
            
            _sqlJobTrigger = new SqlJobTrigger
            {
                CreatedBy = "Pepe",
                CreatedDate = DateTime.Now,
                Enabled = true,
                JobTriggerStatus = JobTriggerStatus.NoAgendado,
                InputFormXmlValues = "<prueba>Prueba</prueba>",
                ScheduledStartExecutionDate = DateTime.Now
            };

            _sqlJob = new SqlJob
            {
                Comments = "blabla",
                CreatedBy = "sdsd",
                DatabaseName = "cgQuartz",
                CreatedDate = DateTime.Now,
                Deleted = false,
                DeletedBy = string.Empty,
                Description = "Descripcion",
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 1",
                JobType = JobType.Automático,
                InputSchemaProcedure = "wdwdsadsa",
                JobTypeEnum = 1,
                Password = "pgsql",
                ServerName = @".\SQLEXPRESS",
                UserName = "sa",
                ExecProcedure = "OP_PROCESO_QUARTZ_EXEC",
            };

           
            _sqlJobTrigger2 = new SqlJobTrigger
            {
                CreatedBy = "Pepe",
                CreatedDate = DateTime.Now,
                Enabled = true,
                JobTriggerStatus = JobTriggerStatus.NoAgendado,
                InputFormXmlValues = "<prueba>Prueba2</prueba>",
                ScheduledStartExecutionDate = DateTime.Now
            };

            _sqlJobTrigger3 = new SqlJobTrigger
            {
                CreatedBy = "Pepe",
                CreatedDate = DateTime.Now,
                Enabled = true,
                JobTriggerStatus = JobTriggerStatus.NoAgendado,
                InputFormXmlValues = "<prueba>Prueba2</prueba>",
                ScheduledStartExecutionDate = DateTime.Now
            };

            _sqlJobTrigger4 = new SqlJobTrigger
            {
                CreatedBy = "Pepe",
                CreatedDate = DateTime.Now,
                Enabled = true,
                JobTriggerStatus = JobTriggerStatus.NoAgendado,
                InputFormXmlValues = "<prueba>Prueba2</prueba>",
                ScheduledStartExecutionDate = DateTime.Now
            };

            _sqlJobTrigger5 = new SqlJobTrigger
            {
                CreatedBy = "Pepe",
                CreatedDate = DateTime.Now,
                Enabled = true,
                JobTriggerStatus = JobTriggerStatus.NoAgendado,
                InputFormXmlValues = "<prueba>Prueba2</prueba>",
                ScheduledStartExecutionDate = DateTime.Now
            };

            _sqlJobTrigger6 = new SqlJobTrigger
            {
                CreatedBy = "Pepe",
               CreatedDate = DateTime.Now,
                Enabled = true,
                JobTriggerStatus = JobTriggerStatus.NoAgendado,
                InputFormXmlValues = "<prueba>Prueba2</prueba>",
                ScheduledStartExecutionDate = DateTime.Now
            };

            _sqlJob2 = new SqlJob
            {
                Comments = "blabla2",
                CreatedBy = "sdsd2",
                DatabaseName = "cgQuartz",
                CreatedDate = DateTime.Now,
                Deleted = false,
                DeletedBy = string.Empty,
                Description = "Descripcion",
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 2",
                JobType = JobType.Automático,
                InputSchemaProcedure = "wdwdsadsa2",
                JobTypeEnum = 1,
                Password = "pgsql",
                ServerName = @".\SQLEXPRESS",
                UserName = "sa",
                ExecProcedure = "OP_PROCESO_QUARTZ_EXEC2",
            };

            _sqlJob3 = new SqlJob
            {
                Comments = "blabla3",
                CreatedBy = "sdsd3",
                DatabaseName = "cgQuartz",
                CreatedDate = DateTime.Now,
                Deleted = false,
                DeletedBy = string.Empty,
                Description = "Descripcion",
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 3",
                JobType = JobType.Automático,
                InputSchemaProcedure = "wdwdsadsa3",
                JobTypeEnum = 1,
                Password = "pgsql",
                ServerName = @".\SQLEXPRESS",
                UserName = "sa",
                ExecProcedure = "OP_PROCESO_QUARTZ_EXEC3",
            };

            _sqlJob4 = new SqlJob
            {
                Comments = "blabla4",
                CreatedBy = "sdsd4",
                DatabaseName = "cgQuartz",
                CreatedDate = DateTime.Now,
                Deleted = false,
                DeletedBy = string.Empty,
                Description = "Descripcion",
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 4",
                JobType = JobType.Automático,
                InputSchemaProcedure = "wdwdsadsa4",
                JobTypeEnum = 1,
                Password = "pgsql",
                ServerName = @".\SQLEXPRESS",
                UserName = "sa",
                ExecProcedure = "OP_PROCESO_QUARTZ_EXEC4",
            };

            _sqlJob4 = new SqlJob
            {
                Comments = "blabla5",
                CreatedBy = "sdsd5",
                DatabaseName = "cgQuartz",
                CreatedDate = DateTime.Now,
                Deleted = false,
                DeletedBy = string.Empty,
                Description = "Descripcion",
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 5",
                JobType = JobType.Automático,
                InputSchemaProcedure = "wdwdsadsa5",
                JobTypeEnum = 1,
                Password = "pgsql",
                ServerName = @".\SQLEXPRESS",
                UserName = "sa",
                ExecProcedure = "OP_PROCESO_QUARTZ_EXEC5",
            };

            _sqlJob5 = new SqlJob
            {
                Comments = "blabla6",
                CreatedBy = "sdsd6",
                DatabaseName = "cgQuartz",
                CreatedDate = DateTime.Now,
                Deleted = false,
                DeletedBy = string.Empty,
                Description = "Descripcion",
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 6",
                JobType = JobType.Automático,
                InputSchemaProcedure = "wdwdsadsa6",
                JobTypeEnum = 1,
                Password = "pgsql",
                ServerName = @".\SQLEXPRESS",
                UserName = "sa",
                ExecProcedure = "OP_PROCESO_QUARTZ_EXEC6",
            };
        }

        [TearDown]
        public void TearDown()
        {
            //_schedulerService.Stop();
        }
        
        [Test]
        public void Add_Manual_Trigger_to_Scheduler()
        {
            _schedulerService.AddJob(_sqlJob);
            _sqlJobTrigger.Job = _sqlJob;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger);
            Thread.Sleep(60000*3);
            var uw = new UnitOfWork();
            var tr = uw.JobTriggerRepository.GetAll().First();
            Assert.IsTrue(tr.JobTriggerStatus == JobTriggerStatus.Ejecutado);
        }

        [Test]
        public void Add_Automatic_Trigger_to_Scheduler()
        {
            _schedulerService.AddJob(_sqlJob);
            _sqlJobTrigger.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now.AddSeconds(20);
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger);
            Thread.Sleep(65000*3);
            var uw = new UnitOfWork();
            var tr = uw.JobTriggerRepository.GetAll().First();
            Assert.IsTrue(tr.JobTriggerStatus == JobTriggerStatus.Ejecutado);
        }

        [Test]
        public void Manual_Fire_Trigger_Without_Scheduling()
        {
           _schedulerService.AddJob(_sqlJob);
           _sqlJobTrigger.Job = _sqlJob;
           _schedulerService.ExecuteManualJob(_sqlJob, _sqlJobTrigger);
           Thread.Sleep(65000*3);
           var uw = new UnitOfWork();
           var tr = uw.JobTriggerRepository.GetAll().First();
           Assert.IsTrue(tr.JobTriggerStatus == JobTriggerStatus.Ejecutado);
        }

        [Test]
        public void Manual_Fire_Trigger_With_Scheduling()
        {
            _sqlJobTrigger.Job = _sqlJob;
            _sqlJob.Triggers.Add(_sqlJobTrigger);
            var uw = new UnitOfWork();
            uw.JobsRepository.Insert(_sqlJob);
            uw.Save();
            _schedulerService.ExecuteManualJob(_sqlJobTrigger);
            Thread.Sleep(65000*3);
            var uw2 = new UnitOfWork();
            var tr = uw2.JobTriggerRepository.GetAll().First();
            Assert.IsTrue(tr.JobTriggerStatus == JobTriggerStatus.Ejecutado);
        }

        [Test]
        public void Delete_A_Trigger_Sould_Return_The_Trigger_Deleted()
        {
            _schedulerService.AddJob(_sqlJob);
            _sqlJobTrigger.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger);
            _sqlJobTrigger.DeletedBy = "Pepe";
             _schedulerService.DeleteTrigger(_sqlJobTrigger);
            Thread.Sleep(65000*3);
            var uw2 = new UnitOfWork();
            var triggers = uw2.JobTriggerRepository.GetAll();
            Assert.IsTrue(!triggers.Contains(_sqlJobTrigger));
        }


        [Test]
        public void Delete_A_Job_Sould_The_Return_The_Job_Deleted()
        {
            _schedulerService.AddJob(_sqlJob);
            _sqlJobTrigger.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now.AddMinutes(5);
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger);
            _sqlJobTrigger2.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now.AddMinutes(5);
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger2);
            _sqlJob.DeletedBy = "Pepe";
            _sqlJob.InputXmlFixedParameters = "<test>probando</test>";
            _schedulerService.DeleteJob(_sqlJob);
            Thread.Sleep(40000);
            var uw2 = new UnitOfWork();
            var jobs = uw2.JobsRepository.GetAll();
            Assert.IsTrue(!jobs.Contains(_sqlJob));
        }

        [Test]
        public void TestMultipleTriggers()
        {
            _schedulerService.AddJob(_sqlJob);
            _sqlJobTrigger.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger);
            _sqlJobTrigger2.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now.AddSeconds(10);
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger2);
            _sqlJobTrigger3.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger3);
            _sqlJobTrigger4.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger4);
            _sqlJobTrigger5.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger5);
            _sqlJobTrigger6.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger6);
            Thread.Sleep(65000*6);
        }

        [Test]
        public void TestMultipleTriggersWithoutThread()
        {
            _schedulerService.AddJob(_sqlJob);
            _sqlJobTrigger.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger);
            _sqlJobTrigger2.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger2);
            _sqlJobTrigger3.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger3);
            _sqlJobTrigger4.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger4);
            _sqlJobTrigger5.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger5);
            _sqlJobTrigger6.Job = _sqlJob;
            _sqlJobTrigger.ScheduledStartExecutionDate = DateTime.Now;
            _schedulerService.AddTrigger(_sqlJob, _sqlJobTrigger6);
            Thread.Sleep(65000*6);
            var uw2 = new UnitOfWork();
            var tr = uw2.JobTriggerRepository.GetAll().First();
            Assert.IsTrue(tr.JobTriggerStatus == JobTriggerStatus.Ejecutado);
        }

        [Test]
        public void Process_Daily_Automatic_Triggers_Should_Return_Quartz_Scheduled()
        {
            _sqlJob.JobType = JobType.Automático;
            _sqlJob.Weekdays = 127;
            _schedulerService.AddJob(_sqlJob);
            _schedulerService.ProcessDailyJobs();
            Thread.Sleep(65000 * 2);
            var uw = new UnitOfWork();
            var tr = uw.JobTriggerRepository.GetAll().First();
            Assert.IsTrue(tr.JobTriggerStatus == JobTriggerStatus.Ejecutado);
        }
    }
}
