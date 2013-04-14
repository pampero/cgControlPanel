using System;
using System.Collections.Generic;
using System.Threading;
using CG.Services.interfaces;
using Model;
using Quartz;
using Quartz.Impl.Matchers;
//using Utils.ADO;
using System.Configuration;
using Utils.ADO;

namespace Services.Scheduling.impl
{
    public class DefaultJobSchedulerService : IJobSchedulerService
    {
        public IScheduler Scheduler { get; set; }
        public UnitOfWork UnitOfWork { get; set; }

        public void Start()
        {
            Scheduler.Start();
        }

        public void Stop()
        {
            Scheduler.Standby();
        }

        public void Pause()
        {
            Scheduler.PauseAll();
        }

        public void Resume()
        {
            Scheduler.ResumeAll();
        }

        public List<Job> GetJobs()
        {
           return UnitOfWork.JobsRepository.GetAll();
        }

        public List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime, JobType jobType)
        {
            return UnitOfWork.JobsRepository.GetJobsByExecutionDay((DateTime) dateTime);
        }

        public List<Job> GetJobsByGroupName(string groupName)
        {
            return UnitOfWork.JobsRepository.GetJobsByGroupName(groupName);
        }

        public List<Job> GetJobsByFavorites()
        {
            return UnitOfWork.JobsRepository.GetJobsByFavorites();
        }

        public List<Job> GetRelatedJobs(int jobId)
        {
            throw new NotImplementedException();
        }

        public Job GetJobById(int jobId)
        {
            return UnitOfWork.JobsRepository.GetByID(jobId);
        }

        public IList<JobLog> GetJobLog(int jobId)
        {
            return UnitOfWork.JobsRepository.GetByID(jobId).Logs;
        }

        public Job GetJobByName(string name, string groupName)
        {
            return UnitOfWork.JobsRepository.GetJobByName(name);
        }

        public void AddJob(Job job, JobTrigger jobTrigger)
        {
            IJobDetail jobDetail = JobBuilder.Create<SqlScheduledJob>()
                .WithIdentity(job.JOB_NAME, job.JOB_GROUP)
                .Build();

            jobDetail.JobDataMap.Put("TriggerId",job.JobId);  
            
            DateTimeOffset runDate = DateBuilder.TodayAt(((DateTime)jobTrigger.StartExecutionDate).Hour, ((DateTime)jobTrigger.StartExecutionDate).Minute, ((DateTime)jobTrigger.StartExecutionDate).Second);
            
            ITrigger trigger = TriggerBuilder.Create()
                .StartAt(runDate) 
                .Build();

            Scheduler.ScheduleJob(jobDetail, trigger);
        }

        public void AddJob(Job job)
        {
            UnitOfWork.JobsRepository.Insert(job);
            UnitOfWork.Save();
            //IJobDetail jobDetail = JobBuilder.Create<SqlScheduledJob>()
            //   .WithIdentity(job.JOB_NAME, job.JOB_GROUP)
            //   .Build();

            //jobDetail.JobDataMap.Put("JobId", job.JobId);

            //Scheduler.AddJob(jobDetail, false);
        }

        public void AddTrigger(JobTrigger trigger)
        {
            UnitOfWork.JobTriggerRepository.Insert(trigger);
            UnitOfWork.Save();
            //DateTimeOffset runDate = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);
            //DateTimeOffset runDate = DateBuilder.TodayAt(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            //var jobkey = new JobKey(trigger.Job.JOB_NAME, trigger.Job.JOB_GROUP);
            //ITrigger triggerBuilder = TriggerBuilder.Create()
            //    .StartAt(runDate) 
            //    .ForJob(jobkey)
            //    .Build();
            //Scheduler.ScheduleJob(triggerBuilder);
        }

        public void FiringManualTrigger(int triggerId)
        {
            var jobTrigger = UnitOfWork.JobTriggerRepository.GetByID(triggerId);
            if(jobTrigger == null)
                return;
            var job = jobTrigger.Job;
            jobTrigger.StartExecutionDate = DateTime.Now;
            AddJob(job, jobTrigger);
        }

        public void FiringAutomaticTrigger(int triggerId)
        {
            var jobTrigger = UnitOfWork.JobTriggerRepository.GetByID(triggerId);
            if (jobTrigger == null)
                return;
            var job = jobTrigger.Job;
            AddJob(job, jobTrigger);
        }

        public void GetNewJob(JobType jobType)
        {
            UnitOfWork.JobsRepository.GetJobByType(jobType);
        }

        public void DeleteTrigger(JobTrigger trigger)
        {
            UnitOfWork.JobTriggerRepository.Delete(trigger);
        }

        #region IJobSchedulerService Members


        public List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IJobSchedulerService Members


        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime? dateTime)
        {
            return UnitOfWork.JobTriggerRepository.GetTriggerByExecutionDate((DateTime)dateTime);
        }

        #endregion

        #region IJobSchedulerService Members


        public List<Job> GetJobsByDaily()
        {
            return UnitOfWork.JobsRepository.GetJobsByDaily();
        }

        #endregion


        public JobTrigger GetJobTriggerById(int jobTriggerId)
        {
            return UnitOfWork.JobTriggerRepository.GetByID(jobTriggerId);
        }


        //JobTrigger IJobSchedulerService.GetJobTriggerById(int jobTriggerId)
        //{
        //    throw new NotImplementedException();
        //}
    

        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime? dateTime, JobType jobType)
        {
 	        throw new NotImplementedException();
        }

        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime? dateTime, JobTriggerStatus jobTriggerStatus)
        {
 	        throw new NotImplementedException();
        }

        public List<JobTrigger> GetJobTriggers()
        {
            return UnitOfWork.JobTriggerRepository.GetAll();
        }

        // TODO: Testear
        public string GetInputFormSchema(Job job)
        {
            var dbReader = Helper.ExecuteReader(ConfigurationManager.AppSettings["CGControlPanelContext"], job.InputSchemaProcedure);

            if (dbReader.HasRows)
            {
                return dbReader[0].ToString();
            }

            throw new Exception("No se pudo ejecutar el Stored Procedure:" + job.InputSchemaProcedure);
        }


        public void UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }

        #region IJobSchedulerService Members


        public void DeleteJob(Job job)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
