using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CG.Services.interfaces;
using Model;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System.Configuration;
using Services.Exceptions;
using Utils.ADO;

namespace Services.Scheduling.impl
{
    public class DefaultJobSchedulerService : IJobSchedulerService
    {
        public IScheduler Scheduler { get; set; }
        public UnitOfWork UnitOfWork { get; set; }
        public IHelper Helper { get; set; }

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

        public SchedulerStatus Status()
        {
            try
            {
                if (Scheduler.IsStarted)
                    return SchedulerStatus.Iniciado;
                if (Scheduler.InStandbyMode)
                    return SchedulerStatus.Esperando;

                return SchedulerStatus.Apagado;
            }
            catch (Exception)
            {
                return SchedulerStatus.Apagado;
            }
        }

        public List<SqlJob> GetSqlJobs()
        {
            return UnitOfWork.SqlJobsRepository.GetAll();
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

           public List<Job> GetJobsByGeneral()
        {
            return UnitOfWork.JobsRepository.GetJobsByGeneral();
        }

        public List<Job> GetRelatedJobs(int jobId)
        {
            return UnitOfWork.JobsRepository.GetRelatedJobs(jobId);
        }

        public Job GetJobById(int jobId)
        {
            return UnitOfWork.JobsRepository.GetByID(jobId);
        }

       
        public Job GetJobByName(string name, string groupName)
        {
            return UnitOfWork.JobsRepository.GetJobByName(name);
        }

        public void AddQuartzJob(Job job, JobTrigger jobTrigger)
        {
            var jobDetail = JobBuilder.Create<SqlScheduledJob>()
              .WithIdentity(job.JobId.ToString(), jobTrigger.JobTriggerId.ToString())
              .Build();

            jobDetail.JobDataMap.Put("TriggerId", jobTrigger.JobTriggerId.ToString());

            DateTimeOffset runDate = DateBuilder.TodayAt((jobTrigger.ScheduledStartExecutionDate).Hour, (jobTrigger.ScheduledStartExecutionDate).Minute, (jobTrigger.ScheduledStartExecutionDate).Second);

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity(jobTrigger.JobTriggerId.ToString())
                .ForJob(jobDetail)
                .StartAt(runDate)
                .Build();

            if (Status() == SchedulerStatus.Apagado)
                throw new QuartzException("El servicio scheduler se encuentra apagado");
            Scheduler.ScheduleJob(jobDetail, trigger);
        }

        public void AddJob(Job job)
        {
            UnitOfWork.JobsRepository.Insert(job);
            UnitOfWork.Save();
        }
        

        public void GetNewJob(JobType jobType)
        {
            UnitOfWork.JobsRepository.GetJobByType(jobType);
        }

        public void DeleteTrigger(JobTrigger trigger)
        {
            if(trigger.JobTriggerStatus != JobTriggerStatus.Ejecutado)
            {
                trigger.Deleted = true;
                trigger.DeletedDate = DateTime.Now;

                if (Status() == SchedulerStatus.Apagado)
                    throw new QuartzException("El servicio scheduler se encuentra apagado");

                if (trigger.Validate())
                {
                    UnitOfWork.JobTriggerRepository.Update(trigger);
                    UnitOfWork.Save();
                    Scheduler.UnscheduleJob(new TriggerKey(trigger.JobTriggerId.ToString()));
                    return;
                }
                UnitOfWork.Save();
                Utils.Validation.Helper.BuildValidationErrors(trigger.ValidationErrors);
                Scheduler.UnscheduleJob(new TriggerKey(trigger.JobTriggerId.ToString()));
                return;
            }
            throw new Exception("Procesos ya ejecutados no pueden ser eliminados.");
        }

        public List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime)
        {
            throw new NotImplementedException();
        }

        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime dateTime)
        {
            return UnitOfWork.JobTriggerRepository.GetTriggerByExecutionDay(dateTime);
        }

      
        public List<Job> GetJobsByDaily(DateTime selectedDate)
        {
            return UnitOfWork.JobsRepository.GetJobsByDaily(selectedDate);
        }


        public JobTrigger GetJobTriggerById(int jobTriggerId)
        {
            return UnitOfWork.JobTriggerRepository.GetByID(jobTriggerId);
        }

        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime dateTime, JobType jobType)
        {
            return UnitOfWork.JobTriggerRepository.GetTriggerByExecutionDay(dateTime, jobType);
        }

        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime dateTime, JobTriggerStatus jobTriggerStatus)
        {
            return UnitOfWork.JobTriggerRepository.GetTriggerByExecutionDay(dateTime, jobTriggerStatus);
        }

        public List<SqlJobTrigger> GetSqlJobTriggersByExecutionDay(DateTime dateTime, JobTriggerStatus jobTriggerStatus)
        {
            return UnitOfWork.JobTriggerRepository.GetSqlTriggerByExecutionDay(dateTime, jobTriggerStatus);
        }

        public List<JobTrigger> GetJobTriggers()
        {
            return UnitOfWork.JobTriggerRepository.GetAll();
        }

        public string GetInputFormSchema(Job job)
        {
            var inputSchema = Helper.GetInputFormSchema(job.InputSchemaProcedure);
            
           if (String.IsNullOrEmpty(inputSchema))
               throw new Exception("No se pudo ejecutar el Stored Procedure:" + job.InputSchemaProcedure);

           return inputSchema;
        }

        public void UpdateJob(Job job)
        {
            UnitOfWork.JobsRepository.Update(job);
            UnitOfWork.Save();
        }

        // Borrar los triggers de Quartz y del sistema (baja lógica)
        public void DeleteJob(Job job)
        {
            foreach (var trigger in job.Triggers)
            {
                trigger.DeletedBy = job.DeletedBy;
                DeleteTrigger(trigger);
            }
            
            job.Deleted = true;
            job.DeletedDate = DateTime.Now;
            //job.DeletedBy = "PENDIENTE";

            if (job.Validate())
            {
                UnitOfWork.JobsRepository.Update(job);
                UnitOfWork.Save();
            }
        }

        /// <summary>
        /// Si el job es de tipo Automático crea un trigger en CGControlPanel y en Quartz. Se ejecuta automáticamente.
        /// Si el job es de tipo manual se crea un trigger DESHABILITADO en CGControlPanel. Se ejecutará luego manualmente desde el menú contextual correspondiente -que disparará ExecuteManualJob-.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="trigger"></param>
        public void AddTrigger(Job job, JobTrigger trigger)
        {
            // OJO: Si el trigger viene deshabilitado NO se lo debe agregar al Quartz, es el caso de agendamiento de un job manual
            job.Triggers.Add(trigger);
            trigger.Job = job;
            trigger.JobId = job.JobId;

            if (trigger.Validate())
            {
                UnitOfWork.JobTriggerRepository.Insert(trigger);
                UnitOfWork.JobsRepository.Update(job);
                UnitOfWork.Save();
                if (trigger.Enabled)
                {
                    AddQuartzJob(job, trigger);
                }
            }
            else {
                Utils.Validation.Helper.BuildValidationErrors(trigger.ValidationErrors);
            }
        }


        /// <summary>
        /// Utilizado para proceso manual agendado previamente (mediante Windows Service o desde las grillas usando el método Agendar -que disparó el método AddTrigger- sobre procesos Manuales). 
        /// El método hace un UPDATE del trigger de deshabilitado a habilitado mas otros datos, actualmente ya viene cambiado, y lo crea en Quartz para que se ejecute inmediatamente.
        /// </summary>
        /// <param name="trigger"></param>
        public void ExecuteManualJob(JobTrigger trigger)
        {
            trigger.Enabled = true;
            trigger.ScheduledStartExecutionDate = DateTime.Now;
            var job = trigger.Job;
            UnitOfWork.JobTriggerRepository.Update(trigger);
            UnitOfWork.Save();
            AddQuartzJob(job, trigger);
        }

        /// <summary>
        /// Utilizado para proceso manual que no ha sido agendado previamente, se crea el trigger en CGControlPanel y en Quartz.
        /// </summary>
        /// <param name="job">Job Manual</param>
        /// <param name="trigger"></param>
        public void ExecuteManualJob(Job job, JobTrigger trigger)
        {
            trigger.ScheduledStartExecutionDate = DateTime.Now;
            job.Triggers.Add(trigger);
            UnitOfWork.JobsRepository.Update(job);
            UnitOfWork.Save();
            AddQuartzJob(job, trigger);
        }

        public void KillProcess(JobTrigger jobTrigger)
        {
            Helper.KillProcess((SqlJobTrigger)jobTrigger);
        }

        public void ProcessDailyJobs()
        {
            var jobs = UnitOfWork.JobsRepository.GetJobsByDaily(DateTime.Now).Where(x => x.JobType == JobType.Automático);
            foreach (var job in jobs)
            {
                if (job.AutomaticProcessTime.HasValue)
                {
                    var automaticProcessTime = DateTime.Now.Date.AddHours(job.AutomaticProcessTime.Value.Hour).AddMinutes(job.AutomaticProcessTime.Value.Minute);
                    
                    var trigger = new SqlJobTrigger
                                      {
                                          CreatedBy = job.CreatedBy,
                                          CreatedDate = DateTime.Now,
                                          Enabled = true,
                                          ScheduledStartExecutionDate = automaticProcessTime ,
                                          JobTriggerStatus = JobTriggerStatus.Agendado
                                      };
                    AddTrigger(job, trigger);
                }
            }
        }
    }
}
