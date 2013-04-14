using System;
using System.Collections.Generic;
using Model;


namespace CG.Services.interfaces
{
    public interface IJobSchedulerService
    {
        void Start();
        void Stop();
        void Pause();
        void Resume();
        SchedulerStatus Status();
        //Debe traer todos los jobs que tienen triggers, activos o no que se ejectuan ese dia
        List<Job> GetJobs();
        List<SqlJob> GetSqlJobs();
        List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime, JobType jobType);
        List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime);
        List<Job> GetJobsByGroupName(string groupName);
        List<JobTrigger> GetJobTriggersByExecutionDay(DateTime dateTime);
        List<JobTrigger> GetJobTriggersByExecutionDay(DateTime dateTime, JobType jobType);
        List<JobTrigger> GetJobTriggersByExecutionDay(DateTime dateTime, JobTriggerStatus jobTriggerStatus);
        List<SqlJobTrigger> GetSqlJobTriggersByExecutionDay(DateTime dateTime, JobTriggerStatus jobTriggerStatus);
        List<Job> GetJobsByFavorites();
        List<Job> GetJobsByGeneral();
        List<Job> GetJobsByDaily(DateTime dateSelected);
        List<Job> GetRelatedJobs(int jobId);
        Job GetJobById(int jobId);
        JobTrigger GetJobTriggerById(int jobTriggerId);
        Job GetJobByName(string name, string groupName);
        void AddQuartzJob(Job job, JobTrigger trigger);
        void DeleteJob(Job job);
        void AddJob(Job job);
        void UpdateJob(Job job);
        void ExecuteManualJob(JobTrigger trigger);
        void ExecuteManualJob(Job job, JobTrigger trigger); 
        void AddTrigger(Job job, JobTrigger trigger);
        void GetNewJob(JobType jobType);
        void DeleteTrigger(JobTrigger trigger); //borrar siempre y cuando no se haya ejecutado
        // Retorna el formulario XML resultado de la ejecución del SP almacenado en la propiedad job.InputSchemaProcedure
        string GetInputFormSchema(Job job);
        void KillProcess(JobTrigger jobTrigger);
        List<JobTrigger> GetJobTriggers();
        void ProcessDailyJobs();
    }
}