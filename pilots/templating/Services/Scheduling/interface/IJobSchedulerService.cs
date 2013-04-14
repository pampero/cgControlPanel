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
        //Debe traer todos los jobs que tienen triggers, activos o no que se ejectuan ese dia
        List<Job> GetJobs();
        List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime, JobType jobType);
        List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime);
        List<Job> GetJobsByGroupName(string groupName);
        List<JobTrigger> GetJobTriggersByExecutionDay(DateTime? dateTime);
        List<JobTrigger> GetJobTriggersByExecutionDay(DateTime? dateTime, JobType jobType);
        List<JobTrigger> GetJobTriggersByExecutionDay(DateTime? dateTime, JobTriggerStatus jobTriggerStatus);
        List<Job> GetJobsByFavorites();
        List<Job> GetJobsByDaily();
        List<Job> GetRelatedJobs(int jobId);
        Job GetJobById(int jobId);
        JobTrigger GetJobTriggerById(int jobTriggerId);
        IList<JobLog> GetJobLog(int jobId);
        Job GetJobByName(string name, string groupName);
        void AddJob(Job job, JobTrigger trigger);
        void DeleteJob(Job job);
        void AddJob(Job job);
        void UpdateJob(Job job);
        void AddTrigger(JobTrigger trigger);
        void GetNewJob(JobType jobType);
        void DeleteTrigger(JobTrigger trigger); //borrar siempre y cuando no se haya ejecutado
        // Retorna el formulario XML resultado de la ejecución del SP almacenado en la propiedad job.InputSchemaProcedure
        string GetInputFormSchema(Job job);

        void FiringManualTrigger(int triggerId);
        List<JobTrigger> GetJobTriggers();
    }
}