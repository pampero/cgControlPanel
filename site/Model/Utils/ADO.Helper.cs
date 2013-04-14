using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using Model;
using log4net;
using CG.Cryptography.Interface;
using System.Configuration;
using Services.Cryptography.impl;

namespace Utils.ADO
{
    public class Helper : IHelper
    {
        private static readonly ILog log = LogManager.GetLogger("LogFileAppender");
//        public IEncryptionService encryptionService { get; set;}
        private IEncryptionService encryptionService = new DefaultEncryptionService();
        private static readonly ManualResetEvent _reset = new ManualResetEvent(false);

        private int _triggerId;

        public UnitOfWork UnitOfWork { get; set; }

        public Helper()
        {
            UnitOfWork = new UnitOfWork();
        }

        public void KillProcess(SqlJobTrigger jobTrigger)
        {
            var sqlJob = (SqlJob)jobTrigger.Job;
            
            var connectionString = @"data source=" + sqlJob.ServerName + ";Integrated Security=false;user id=" +
                                    sqlJob.UserName +
                                    ";password=" + encryptionService.Decrypt(sqlJob.Password, encryptionService.EncryptionKey) + ";User Instance=false;Initial Catalog=" +
                                    sqlJob.DatabaseName;

            using (var _conn = new SqlConnection(connectionString))
            {
                using(var sqlCommand = _conn.CreateCommand())
                {
                    sqlCommand.CommandText = "KILL " + jobTrigger.SPID;
                    sqlCommand.CommandType = CommandType.Text;
                    _conn.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }

            var jobTriggerAux = UnitOfWork.JobTriggerRepository.GetByID(jobTrigger.JobTriggerId);
            jobTriggerAux.JobTriggerStatus = JobTriggerStatus.Error;
            jobTriggerAux.OutputExecutionLog += "Error: Proceso finalizado por el usuario";

            UnitOfWork.JobTriggerRepository.Update(jobTriggerAux);
            UnitOfWork.Save();

            if (log.IsErrorEnabled)
                log.Error("Info en TriggerID: " + jobTrigger.JobTriggerId.ToString() + " - Proceso finalizado por el usuario");
        }

        // Retorna los parametros de configuración para el formulario dinámico.
        public string GetInputFormSchema(string commandText)
        {
            using (var dbConnection = new SqlConnection(UnitOfWork.GetConnection().ConnectionString))
            {
                using (DbCommand command = new SqlCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandText;
                    command.Connection = dbConnection;
                    dbConnection.Open();
                    var dbReader = command.ExecuteReader();

                    if (dbReader.HasRows)
                    {
                        dbReader.Read();
                        return dbReader[0].ToString();
                    }
                    return "";
                }
            } 
        }
        

        private void FormatInputParameters(SqlJobTrigger trigger, ref string formattedInputFormXmlValues)
        {
            if (String.IsNullOrEmpty(trigger.InputFormXmlValues))
                trigger.InputFormXmlValues = "<CDATAFORM></CDATAFORM>";

            if (String.IsNullOrEmpty(trigger.Job.InputXmlFixedParameters))
                trigger.Job.InputXmlFixedParameters = "<INPUTXMLFIXEDPARAMETERS></INPUTXMLFIXEDPARAMETERS>";
                
            if (String.IsNullOrEmpty(trigger.InputXmlTable))
                trigger.InputXmlTable = "<INPUTXMLTABLE></INPUTXMLTABLE>";
            
            trigger.InputXmlTable = "<?xml version=\"1.0\" encoding=\"iso-8859-1\" ?>" + trigger.InputXmlTable;
            
            formattedInputFormXmlValues = "<?xml version=\"1.0\" encoding=\"iso-8859-1\" ?><CDATA><CPARAMETROSFIJOS>" + trigger.Job.InputXmlFixedParameters + "</CPARAMETROSFIJOS>" + trigger.InputFormXmlValues + "</CDATA>";
        }

        public void ExecuteAsyncNonQueryForTrigger(SqlJobTrigger trigger)
        {
            // La captura de errores se realiza en el método llamante

            _triggerId = trigger.JobTriggerId;

            var job = (SqlJob) trigger.Job;
            
            var connectionString = @"data source=" + job.ServerName + ";Integrated Security=false;user id=" +
                                    job.UserName +
                                    ";password=" + encryptionService.Decrypt(job.Password, encryptionService.EncryptionKey) + ";User Instance=false;Initial Catalog=" +
                                    job.DatabaseName + ";Asynchronous Processing=true;MultipleActiveResultSets=True";
                
                SqlConnection _conn = new SqlConnection(connectionString);
            
                if (log.IsInfoEnabled)
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - (1/7) Antes apertura ConnectionString Asinc. (Utils.ADO.Helper.ExecuteAsyncNonQueryForTrigger).");

                _conn.Open();

                if (log.IsInfoEnabled)
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - (2/7) Luego apertura ConnectionString Asinc. (Utils.ADO.Helper.ExecuteAsyncNonQueryForTrigger).");

                trigger = (SqlJobTrigger)UnitOfWork.JobTriggerRepository.GetByID(trigger.JobTriggerId);

                /* Inicio Recupero SPID */
                var sqlCommand = _conn.CreateCommand();
                sqlCommand.CommandText = "SELECT @@SPID";
                sqlCommand.CommandType = CommandType.Text;
                trigger.SPID = sqlCommand.ExecuteScalar().ToString();

                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();
                /* Fin Recupero SPID */

                SqlCommand cmd = _conn.CreateCommand();
                cmd.CommandText = job.ExecProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.Clear();
            
                cmd.Parameters.Add("@nTriggerId", SqlDbType.Int).Value = trigger.JobTriggerId;
               
                string formattedInputFormXmlValues=string.Empty;
                // Formateo los Xml de Entrada, @xParametrosInput y @xInput
                FormatInputParameters(trigger, ref formattedInputFormXmlValues);

                cmd.Parameters.Add("@xParametrosInput", SqlDbType.Xml).Value =
                    new SqlXml(new XmlTextReader(formattedInputFormXmlValues , XmlNodeType.Document, null));
                cmd.Parameters.Add("@xInput", SqlDbType.Xml).Value =
                    new SqlXml(new XmlTextReader(trigger.InputXmlTable , XmlNodeType.Document, null));
                cmd.Parameters.Add("@xOutput", SqlDbType.Xml).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@xResultado", SqlDbType.Xml).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@xLogEjecucion", SqlDbType.Xml).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@nRowsAffected", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@nRowsTotal", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@cStatus", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                cmd.Connection.InfoMessage += ConnectionInfoMessage;
                AsyncCallback result = NonQueryCallBack;
                
                if (log.IsInfoEnabled)
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - (3/7) Comienza ejecución de la llamada al Stored Asinc. (Utils.ADO.Helper.ExecuteAsyncNonQueryForTrigger).");
                cmd.BeginExecuteReader(result, cmd);
                _reset.WaitOne();
            
        }

       
        private void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            var trigger = (SqlJobTrigger)UnitOfWork.JobTriggerRepository.GetByID(Convert.ToInt32(_triggerId));
            
            if (e.Errors.Count > 0)
            {
                foreach (SqlError info in e.Errors)
                {
                    trigger.OutputExecutionTrace += String.Format(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " {0}<BR/>", info.Message);
                    if (log.IsInfoEnabled)
                        log.Info("Trace en TriggerID:" + trigger.JobTriggerId + " Mensaje:" + info.Message);
                } 
            }
            UnitOfWork.JobTriggerRepository.Update(trigger);
            UnitOfWork.Save();
        }

        private void NonQueryCallBack(IAsyncResult result)
        {
            SqlCommand command = (SqlCommand)result.AsyncState;
            SqlJobTrigger trigger = null;

            try
            {
                trigger = (SqlJobTrigger)UnitOfWork.JobTriggerRepository.GetByID(Convert.ToInt32(command.Parameters["@nTriggerId"].Value));

                command.EndExecuteReader(result);

                if (log.IsInfoEnabled)
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - (4/7) Finalizó la ejecución de la  llamada al Stored Asinc. (Utils.ADO.Helper.NonQueryCallBack).");
                

                if (log.IsInfoEnabled)
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - (5/7) Comienza la recuperación de parámetros. (Utils.ADO.Helper.NonQueryCallBack).");

                trigger.OutputXmlTable = command.Parameters["@xOutput"].Value.ToString();
                trigger.OutputExecutionResult = "<table>" + command.Parameters["@xResultado"].Value + "</table>";
                trigger.OutputExecutionLog = command.Parameters["@xLogEjecucion"].Value.ToString();
                trigger.RecordsAffected = int.Parse(command.Parameters["@nRowsAffected"].Value.ToString());
                trigger.RecordsProcessed = int.Parse(command.Parameters["@nRowsTotal"].Value.ToString());
                trigger.OutputExecutionStatus = command.Parameters["@cStatus"].Value.ToString();
                trigger.JobTriggerStatus = JobTriggerStatus.Ejecutado;
                trigger.EndExecutionDate = DateTime.Now;
                trigger.SerializedJob = String.Format("<GROUP>{0}</GROUP><NAME>{1}</NAME><COMMENTS>{2}</COMMENTS><PARENTJOBID>{3}</PARENTJOBID><INPUTSCHEMAPROCEDURE>{4}</INPUTSCHEMAPROCEDURE>{5}<JOBTYPE>{6}</JOBTYPE>", trigger.Job.Group, trigger.Job.Name, trigger.Job.Comments, trigger.Job.ParentJobId, trigger.Job.InputSchemaProcedure, trigger.Job.InputXmlFixedParameters, trigger.Job.JobType);

                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();

                CGControlPanel.Notifications.NotificationHub.Send("UPDATE");

                if (log.IsInfoEnabled)
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - (6/7) Finaliza la recuperación de parámetros. (Utils.ADO.Helper.NonQueryCallBack).");
            }
            catch (SqlException ex)
            {
                var sqlErrorMessage = BuildSqlErrorMessage(ex);
                var fullError = "Error en TriggerID: " + trigger.JobTriggerId + @"<br />Servidor: " + ex.Server + "<br />Procedure: " + ex.Procedure + "<br />Línea: " + ex.LineNumber + "<br />Errores Sql: " + sqlErrorMessage;

                if (log.IsErrorEnabled)
                    log.Error(fullError.Replace("<br />", "\r\n"));

                trigger.OutputExecutionLog += fullError;
                trigger.JobTriggerStatus = JobTriggerStatus.Error;
                trigger.EndExecutionDate = DateTime.Now;
                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();
            }
            catch (Exception ex)
            {
                var standardErrorMessage = BuildRecursiveErrorMessage(ex);
                var fullError = "Error en TriggerID: " + trigger.JobTriggerId + "<br />Standard: " + standardErrorMessage ;

                if (log.IsErrorEnabled)
                    log.Error(fullError.Replace("<br />", "\r\n"));

                trigger.OutputExecutionLog += fullError;
                trigger.JobTriggerStatus = JobTriggerStatus.Error;
                trigger.EndExecutionDate = DateTime.Now;
                UnitOfWork.JobTriggerRepository.Update(trigger);
                UnitOfWork.Save();
            }
            finally
            {
                if (command.Connection.State != ConnectionState.Closed)
                    command.Connection.Close();

                if (log.IsInfoEnabled)
                {
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - (7/7) Conexión de SQL Cerrada. (Utils.ADO.Helper.NonQueryCallBack).");
                    log.Info("Info en TriggerID: " + trigger.JobTriggerId + " - /********** FIN DE LLAMADA AL STORED PROCEDURE *****************/");
                }
                _reset.Set();
            }
        }

        public string BuildRecursiveErrorMessage(Exception exception)
        {
            string message = string.Empty;

            if (exception.InnerException != null)
            {
                message = exception.Message + " - " + BuildRecursiveErrorMessage(exception.InnerException);
            }
            else
            {
                message = exception.Message;
            }

            return message;
        }

        public string BuildSqlErrorMessage(SqlException exception)
        {
            string message = string.Empty;

            foreach (var sqlError in exception.Errors)
            {
                message += sqlError + " - ";
            }

            return message;
        }

        public string BuildEntityValidationErrorMessage(DbEntityValidationException exception)
        {
            string message = string.Empty;

            foreach (var validationErrors in exception.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    message += string.Format("Propiedad: {0} Error: {1}\r\n", validationError.PropertyName, validationError.ErrorMessage);
                }
            }

            return  message;
        }
    }
}
