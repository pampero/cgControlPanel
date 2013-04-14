using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Xml.Serialization;
using Model;
using Quartz;
using System.IO;
using System.Text;
using CG.Services.interfaces;

namespace CG.Services.impl
{
    public class FakeJobSchedulerService : IJobSchedulerService
    {

        public void Start()
        {
            
        }

        public void Stop()
        {
            
        }

        public void Pause()
        {
            
        }

        public void Resume()
        {
            
        }

        public SchedulerStatus Status()
        {
            return SchedulerStatus.Iniciado;
        }

        public List<Job> GetJobsByGroupName(string groupName)
        {
            var jobsList = new List<Job>();
            
            jobsList.Add(new SqlJob { JobId=1, IsFavorite = true, Group= "Replicación", Name = "Job Replicación 1", JobType = JobType.Automático});
            jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, Group= "Replicación", Name  = "Job Replicación 2", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 34, IsFavorite = true, Group= "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true, Group= "Replicación", Name  = "Job Replicación 4", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 53, IsFavorite = true, Group= "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 65, IsFavorite = true, Group= "Replicación", Name  = "Job Replicación 4", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 74, IsFavorite = true, Group = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 82, IsFavorite = true, Group= "Replicación", Name  = "Job Replicación 4", JobType = JobType.Automático });
            
            return jobsList;
        }

        public List<Job> GetJobs()
        {
            var jobsList = new List<Job>();

            jobsList.Add(new SqlJob { JobId = 1, IsFavorite = true, Weekdays=3, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 23, IsFavorite = true, Weekdays=6, Group = "Otros", Name = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 34, IsFavorite = true, Weekdays = 19, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Manual});
            jobsList.Add(new SqlJob { JobId = 45, IsFavorite = true, Group = "Otros", Name = "Job Replicación 4", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 53, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 65, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 74, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 82, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automático });

            return jobsList;
        }

        public List<SqlJob> GetSqlJobs()
        {
            var jobsList = new List<SqlJob>();

            jobsList.Add(new SqlJob { JobId = 1, IsFavorite = true, Weekdays = 3, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 23, IsFavorite = true, Weekdays = 6, Group = "Otros", Name = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 34, IsFavorite = true, Weekdays = 19, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 45, IsFavorite = true, Group = "Otros", Name = "Job Replicación 4", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 53, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 65, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 74, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 82, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automático });

            return jobsList;
        }

        public List<SqlJobTrigger> GetSqlJobTriggersByExecutionDay(DateTime dateTime, JobTriggerStatus jobTriggerStatus)
        {
            throw new NotImplementedException();
        }

        public Job GetJobById(int JobId)
        {
            SqlJobTrigger sqlJobTrigger = new SqlJobTrigger
                                              {
                                                  JobTriggerId = 1,
                                                  CreatedBy = "Carlos",
                                                  InputFormXmlValues = "Input Values",
                                                  InputXmlTable = "XML Input Values",
                                                  OutputXmlTable = "XML Output",
                                                  OutputExecutionResult = "XML Result",
                                                  RecordsProcessed = 100,
                                                  RecordsAffected = 10,
                                                  ScheduledStartExecutionDate = DateTime.Now,
                                                  JobTriggerStatus = JobTriggerStatus.Agendado
                                              };
            var triggers = new List<JobTrigger>();
            triggers.Add(sqlJobTrigger);

            return new SqlJob
                {
                    JobId = 1,
                    Triggers = triggers,
                    IsFavorite = true,
                    Group = "Replicación",
                    Name = "Job Replicación 1",
                    JobType = JobType.Automático,
                    ServerName = "SQL1",
                    AutomaticProcessTime = DateTime.Now,
                    DatabaseName = "CGPlanos",
                    Description = "Esto es una descripción de las tareas que realiza el proceso",
                    UserName = "PEPE",
                    CreatedBy = "Carlos.Daniel.Vazquez",
                    Weekdays = 13, 
                    ParentJobId = 23
                };
        }

        public JobTrigger GetJobTriggerById(int JobTriggerId)
        {
            var sqlJob = new SqlJob
            {
                JobId = 1,
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 1",
                Comments = "Comentarios",
                JobType = JobType.Manual,
                AutomaticProcessTime = DateTime.Now,
                ServerName = "SQL1",
                DatabaseName = "CGPlanos",
                Description = "Esto es una descripción de las tareas que realiza el proceso",
                UserName = "PEPE",
                CreatedBy = "Carlos.Daniel.Vazquez",
                Weekdays = 21
            };

            var sqlJobTrigger = new SqlJobTrigger
            {
                JobTriggerId = JobTriggerId,
                CreatedBy = "Carlos",
                InputFormXmlValues = "Input Values",
                InputXmlTable = "XML Input Values",
                OutputXmlTable = "XML Output",
                RecordsProcessed = 100,
                RecordsAffected = 10,
                Job =sqlJob,
                JobTriggerStatus = JobTriggerStatus.Ejecutado,
                ScheduledStartExecutionDate = DateTime.Now.AddDays(-1),
                StartExecutionDate = DateTime.Now.AddDays(-1),
                EndExecutionDate = DateTime.Now,
                OutputExecutionStatus = "Ejecutado SIN Errores",
                OutputExecutionLog = "<table width='100%'><tr><td>test</td></tr></table>",
                OutputExecutionResult= @"<p>resultado 1</p><p>resultado 2</p><p>resultado 3</p>"
            };
            // Si NO se ejecutó
            if (JobTriggerId != 3)
            {
                sqlJobTrigger.StartExecutionDate = null;
                sqlJobTrigger.JobTriggerStatus = JobTriggerStatus.Agendado;
                sqlJobTrigger.OutputExecutionLog = "-";
                sqlJobTrigger.OutputExecutionResult = "-";
                sqlJobTrigger.OutputExecutionStatus = "-";
                sqlJobTrigger.InputFormXmlValues = "-";
                sqlJobTrigger.InputXmlTable = "-";
                sqlJobTrigger.OutputXmlTable = "-";
                sqlJobTrigger.RecordsProcessed = 0;
                sqlJobTrigger.RecordsAffected = 0;
                sqlJobTrigger.EndExecutionDate = null;
                sqlJobTrigger.Job.Weekdays = 0;
            }

            // En Ejecución
            if (JobTriggerId == 2)
            {
                sqlJobTrigger.StartExecutionDate = DateTime.Now;
                sqlJobTrigger.Job.Weekdays = 6;
                sqlJobTrigger.JobTriggerStatus = JobTriggerStatus.Ejecutando;
                sqlJobTrigger.Job.JobType = JobType.Automático;
            }

            return sqlJobTrigger;
        }

        public Job GetJobByName(string name, string groupName)
        {
            throw new NotImplementedException();
        }

        public void AddQuartzJob(Job job, JobTrigger trigger)
        {
           
        }

        public void AddJob(Job job)
        {
           
        }

        public void AddTrigger(JobTrigger trigger)
        {
          
        }

        public void GetNewJob(JobType jobType)
        {
           
        }

        public void DeleteTrigger(JobTrigger trigger)
        {
            
        }

        public List<Job> GetJobsByFavorites()
        {
            var jobsList = new List<Job>();

            jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 44, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { InputSchemaProcedure = "PROCEDURE", JobId = 45, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 52, IsFavorite = true, Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 53, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 78, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 89, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 152, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 153, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 178, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 189, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
           
            return jobsList;
        }

         public List<Job> GetJobsByGeneral()
        {
            var jobsList = new List<Job>();

            jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 44, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { InputSchemaProcedure = "PROCEDURE", JobId = 45, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 52, IsFavorite = true, Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 53, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 78, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 89, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 152, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 153, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 178, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob { JobId = 189, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
           
            return jobsList;
        }

        public List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime, JobType jobType)
        {
             var jobsList = new List<Job>();

            if (jobType == JobType.Manual)
            {
                jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual});
                jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 2", JobType = JobType.Manual });
                jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
            }
            else
            {
                jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Automático});
                jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 2", JobType = JobType.Automático });
                jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automático });
            }
            
            return jobsList;
        }

        public List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime)
        {
             var jobsList = new List<Job>();

             jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual});
             jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 2", JobType = JobType.Manual });
             jobsList.Add(new SqlJob  { JobId = 34, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automático });
             jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true,  Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
            
            return jobsList;
        }

        public List<Job> GetRelatedJobs(int jobId)
        {
            
            var jobsList = new List<Job>();

            if (jobId == -1) return jobsList;

            if((jobId % 2) == 0)
            {
                jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual });
                jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true,  Group = "Replicación", Name  = "Job Replicación 2", JobType = JobType.Manual });
            }

            jobsList.Add(new SqlJob  { JobId = 31, IsFavorite = true, Group = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
            jobsList.Add(new SqlJob  { JobId = 42, IsFavorite = true,  Group = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            
            return jobsList;
        }


        #region IJobSchedulerService Members


        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime dateTime)
        {
            var jobsTriggerList = new List<JobTrigger>();

            var sqlJob = new SqlJob
                {
                    JobId = 12,
                    IsFavorite = true,
                    Group = "Replicación",
                    Name = "Job Replicación 2",
                    JobType = JobType.Manual,
                    Weekdays = 6
                };

            var sqlJob2 = new SqlJob
            {
                JobId = 13,
                IsFavorite = true,
                Group = "Replicación Automática",
                Name = "Job Replicación 3",
                JobType = JobType.Automático,
                Weekdays = 0
            };

            var sqlJob3 = new SqlJob
            {
                JobId = 14,
                IsFavorite = true,
                Group = "Replicación Automática",
                Name = "Job Replicación 4",
                JobType = JobType.Manual,
                InputSchemaProcedure = "PROCEDURE",
                Weekdays = 21
            };

            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 1, Job = sqlJob, JobTriggerStatus = JobTriggerStatus.Agendado });
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 2, Job = sqlJob2, StartExecutionDate = DateTime.Now, JobTriggerStatus = JobTriggerStatus.Ejecutando });
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 3, Job = sqlJob, RecordsAffected = 33, StartExecutionDate = DateTime.Now, EndExecutionDate = DateTime.Now.AddHours(1), RecordsProcessed = 250, JobTriggerStatus = JobTriggerStatus.Ejecutado });
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 4, Job = sqlJob3, JobTriggerStatus = JobTriggerStatus.Agendado });
            
            return jobsTriggerList;
        }

        #endregion

        #region IJobSchedulerService Members


        public List<Job> GetJobsByDaily(DateTime selectedDate)
        {
            var jobsList = new List<Job>();

            jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 44, IsFavorite = true,  Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automático });
           
            return jobsList;
        }

        #endregion
    

        public List<JobTrigger>  GetJobTriggersByExecutionDay(DateTime dateTime, JobType jobType)
        {
            var jobsTriggerList = new List<JobTrigger>();

            var sqlJob = new SqlJob
            {
                JobId = 12,
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 1",
                JobType = jobType
            };

            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 1, Job = sqlJob, RecordsAffected = 1, RecordsProcessed = 100, JobTriggerStatus = JobTriggerStatus.Agendado });
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 2, Job = sqlJob, RecordsAffected = 2, RecordsProcessed = 200, JobTriggerStatus = JobTriggerStatus.Agendado });
            
            return jobsTriggerList;
        }

        public List<JobTrigger>  GetJobTriggersByExecutionDay(DateTime dateTime, JobTriggerStatus jobTriggerStatus)
        {
            var jobsTriggerList = new List<JobTrigger>();

            var sqlJob = new SqlJob
            {
                JobId = 12,
                IsFavorite = true,
                Group = "Replicación",
                Name = "Job Replicación 1",
                JobType = JobType.Manual
            };

            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 1, Job = sqlJob, RecordsAffected = 1, RecordsProcessed = 100, JobTriggerStatus = jobTriggerStatus});
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 2, Job = sqlJob, RecordsAffected = 2, RecordsProcessed = 200, JobTriggerStatus = jobTriggerStatus });

            return jobsTriggerList;
        }

        public string GetInputFormSchema(Job job)
        {
            return @"<?xml version=""1.0"" encoding=""iso-8859-1"" ?>
<CDIALOGO>
  <CAMPO>
    <CCLAVE>CTITULO1</CCLAVE>
    <CTIPO>TITULO</CTIPO>
    <CNOMBRE>0111- PROCESOS DE CUENTAS BANCARIAS</CNOMBRE>
    <LTITULO>1</LTITULO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CSEPARADOR1</CCLAVE>
    <CTIPO>SEPARADOR</CTIPO>
    <CNOMBRE>Parametros del proceso</CNOMBRE>
    <LTITULO>1</LTITULO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CCOMENTARIO</CCLAVE>
    <CTIPO>TPTEXTO</CTIPO>
    <CNOMBRE>Comentarios</CNOMBRE>
    <NLARGOMIN>1</NLARGOMIN>
    <NLARGOMAX>255</NLARGOMAX>
    <LVACIO>1</LVACIO>
    <LMODIFICABLE>1</LMODIFICABLE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CPRODUCTO</CCLAVE>
    <CTIPO>TPRADIO</CTIPO>
    <CDEFAULT>CCORR</CDEFAULT>
    <CCONTROLASOC>CCONCEPTO</CCONTROLASOC>
    <CNOMBRE>Producto a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVE>TARJETA</CCLAVE>
        <CTEXTO>Tarjetas de credito</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CCORR</CCLAVE>
        <CTEXTO>Cuenta Corriente</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CAHORRO</CCLAVE>
        <CTEXTO>Caja de Ahorro</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CPRODUCTOCHECK</CCLAVE>
    <CTIPO>TPCHECK</CTIPO>
    <CNOMBRE>Productos a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVE>TARJETACHECK</CCLAVE>
        <CTEXTO>Tarjetas de credito</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVE>CCORRCHECK</CCLAVE>
        <CTEXTO>Cuenta Corriente</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CCONCEPTO</CCLAVE>
    <CTIPO>TPCOMBO</CTIPO>
    <CNOMBRE>Concepto a procesar</CNOMBRE>
    <VALORES>
      <VALOR>
        <CCLAVEASOC>CAHORRO</CCLAVEASOC>
        <CCLAVE>INT CH</CCLAVE>
        <CTEXTO>Generar Intereses</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CAHORRO</CCLAVEASOC>
        <CCLAVE>MULTA CH</CCLAVE>
        <CTEXTO>Generar Multas</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>INT CC</CCLAVE>
        <CTEXTO>Generar Intereses</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>MULTA CC</CCLAVE>
        <CTEXTO>Generar Multas</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>CCORR</CCLAVEASOC>
        <CCLAVE>SALDOS CC</CCLAVE>
        <CTEXTO>Recalcular Saldos</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>TARJETA</CCLAVEASOC>
        <CCLAVE>REDOND TJ</CCLAVE>
        <CTEXTO>Corregir redondeos</CTEXTO>
      </VALOR>
      <VALOR>
        <CCLAVEASOC>TARJETA</CCLAVEASOC>
        <CCLAVE>PAG TJ</CCLAVE>
        <CTEXTO>Pago Minimo</CTEXTO>
      </VALOR>
    </VALORES>
  </CAMPO>
  <CAMPO>
    <CCLAVE>NMONTOMINIMO</CCLAVE>
    <CTIPO>TPREAL</CTIPO>
    <CNOMBRE>Monto minimo de interes</CNOMBRE>
    <LVACIO>1</LVACIO>
    <LMODIFICABLE>1</LMODIFICABLE>
    <NMINIMO>10.59</NMINIMO>
    <NMAXIMO>4000.53</NMAXIMO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>NPERIODOS</CCLAVE>
    <CTIPO>TPENTERO</CTIPO>
    <CNOMBRE>Periodos a Procesar</CNOMBRE>
    <NMINIMO>1</NMINIMO>
    <NMAXIMO>1000</NMAXIMO>
    <LVACIO>1</LVACIO>
  </CAMPO>
  <CAMPO>
    <CCLAVE>CSEPARADOR2</CCLAVE>
    <CTIPO>SEPARADOR</CTIPO>
    <CNOMBRE>Rango de Fechas</CNOMBRE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>DFECHADESDE</CCLAVE>
    <CTIPO>TPFECHA</CTIPO>
    <CCONTROLASOC>DFECHAHASTA</CCONTROLASOC>
    <CNOMBRE>Fecha Desde</CNOMBRE>
    <LVACIO>0</LVACIO>
    <DMINDATE>2012/01/01</DMINDATE>
    <DMAXDATE>2013/12/24</DMAXDATE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>DFECHAHASTA</CCLAVE>
    <CTIPO>TPFECHA</CTIPO>
    <CNOMBRE>Fecha Hasta</CNOMBRE>
    <LVACIO>0</LVACIO>
    <DMINDATE>2012/01/01</DMINDATE>
    <DMAXDATE>2012/12/30</DMAXDATE>
  </CAMPO>
  <CAMPO>
    <CCLAVE>HORA</CCLAVE>
    <CTIPO>TPHORA</CTIPO>
    <CNOMBRE>Hora</CNOMBRE>
    <LVACIO>0</LVACIO>
    <HMINIMO>09:00:00</HMINIMO>
    <HMAXIMO>18:00:00</HMAXIMO>
  </CAMPO>
</CDIALOGO>";
        }

        public void FireTriggerManualMode(int triggerId)
        {
         
        }

        public void FiringManualTrigger(int triggerId)
        {
         
        }

        public List<JobTrigger> GetJobTriggers()
        {
            throw new NotImplementedException();
        }

        public void ProcessDailyJobs()
        {
            throw new NotImplementedException();
        }

        public void FireTriggerAutomaticMode(int triggerId)
        {
            
        }


        public void UpdateJob(Job job)
        {
            
        }

        #region IJobSchedulerService Members


        public void DeleteJob(Job job)
        {
            
        }

        #endregion


        public void AddTrigger(Job job, JobTrigger trigger)
        {
            
        }


        public void ExecuteManualJob(JobTrigger trigger)
        {
            
        }

        public void ExecuteManualJob(Job job, JobTrigger trigger)
        {
        }

        public void KillProcess(JobTrigger jobTrigger)
        { 
        }
    }
}
