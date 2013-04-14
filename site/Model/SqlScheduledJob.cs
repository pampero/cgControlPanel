using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Quartz;
using Utils.ADO;
using log4net;
using System.Data.Entity.Validation;

namespace Model
{
    public class SqlScheduledJob : IJob
    {
        public UnitOfWork UnitOfWork { get; set; }
        public IHelper Helper { get; set; }

        public static readonly ILog log = LogManager.GetLogger("LogFileAppender");

        public void Execute(IJobExecutionContext context)
        {
            UnitOfWork = new UnitOfWork();
            Helper = new Helper();
            var triggerId = context.JobDetail.JobDataMap["TriggerId"];
            if (log.IsInfoEnabled)
            {
                log.Info("Info en TriggerID: " + triggerId + " - /********** INICIO DE LLAMADA AL STORED PROCEDURE *****************/");
            }
            var trigger = (SqlJobTrigger)UnitOfWork.JobTriggerRepository.GetByID(int.Parse(triggerId.ToString()));

            try
            {
                trigger.StartExecutionDate = DateTime.Now;
                trigger.JobTriggerStatus = JobTriggerStatus.Ejecutando;
                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();

                if (log.IsInfoEnabled)
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - Llamada al proceso Asinc. (Model.SqlScheduledJob.Execute).");

                Helper.ExecuteAsyncNonQueryForTrigger(trigger);
            }
            catch (SqlException ex)
            {
                var sqlErrorMessage = Helper.BuildSqlErrorMessage(ex);
                var fullError = "Error en TriggerID: " + trigger.JobTriggerId + "<br />Servidor: " + ex.Server + "<br />Procedure: " + ex.Procedure + "<br />Línea: " + ex.LineNumber + "<br />Errores Sql: " + sqlErrorMessage;

                if (log.IsErrorEnabled)
                    log.Error(fullError);

                trigger.OutputExecutionLog += fullError;
                trigger.JobTriggerStatus = JobTriggerStatus.Error;
                trigger.EndExecutionDate = DateTime.Now;
                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();
            }
            catch (DbEntityValidationException ex)
            {
                var entityValidationErrorMessage = Helper.BuildEntityValidationErrorMessage(ex);
                var fullError = "Error en TriggerID: " + context.JobDetail.JobDataMap["TriggerId"] + @"<br />Entity Framework: " + entityValidationErrorMessage;
                
                if (log.IsErrorEnabled)
                    log.Error(fullError);
                
                trigger.OutputExecutionLog += fullError;
                trigger.JobTriggerStatus = JobTriggerStatus.Error;
                trigger.EndExecutionDate = DateTime.Now;
                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();
            }
            catch (Exception ex)
            {
                var standardErrorMessage = Helper.BuildRecursiveErrorMessage(ex);
                var fullError = "Error en TriggerID: " + context.JobDetail.JobDataMap["TriggerId"] + @"<br />Standard: " + standardErrorMessage;
                
                if (log.IsErrorEnabled)
                    log.Error(fullError);
                
                trigger.OutputExecutionLog += fullError;
                trigger.JobTriggerStatus = JobTriggerStatus.Error;
                trigger.EndExecutionDate = DateTime.Now;
                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();
            }
        }
    }
}
