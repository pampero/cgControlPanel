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
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public IList<JobLog> GetJobLog(int jobId)
        {
            var jobsList = new List<JobLog>();

            var jobTrigger = new SqlJobTrigger();

            if (jobId == 12)
            {
                jobsList.Add(new JobLog { JobTrigger = jobTrigger, ExecutionDate = DateTime.Now, JobLogId = 1, JobLogStatus = JobLogStatus.Success });
                jobsList.Add(new JobLog { JobTrigger = jobTrigger, ExecutionDate = DateTime.Now, JobLogId = 2, JobLogStatus = JobLogStatus.Error });
            }

            if (jobId == 23)
            {
                jobsList.Add(new JobLog
                                 {
                                     JobTrigger = jobTrigger,
                                     ExecutionDate = DateTime.Now,
                                     JobLogId = 3,
                                     JobLogStatus  = JobLogStatus.Error
                                 });
            }

            if (jobId == 34)
            {
                jobsList.Add(new JobLog
                                 {
                                     JobTrigger = jobTrigger,
                                     ExecutionDate = DateTime.Now,
                                     JobLogId = 4,
                                     JobLogStatus  = JobLogStatus.Error
                                 });
            }
            
            if (jobId == 45)
            {
                jobsList.Add(new JobLog
                                    {
                                        JobTrigger = jobTrigger,
                                        ExecutionDate = DateTime.Now,
                                        JobLogId = 5,
                                        JobLogStatus  = JobLogStatus.Error
                                    });
                jobsList.Add(new JobLog
                                    {
                                        JobTrigger = jobTrigger,
                                        ExecutionDate = DateTime.Now,
                                        JobLogId = 6,
                                        JobLogStatus  = JobLogStatus.Success
                                    });
            }
        
            return jobsList;
        }

        public List<Job> GetJobsByGroupName(string groupName)
        {
            var jobsList = new List<Job>();
            
            jobsList.Add(new SqlJob { JobId=1, IsFavorite = true, ExecutionDays = 1, Group= "Replicación", Name = "Job Replicación 1", JobType = JobType.Automatico});
            jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, ExecutionDays = 1, Group= "Replicación", Name  = "Job Replicación 2", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 34, IsFavorite = true, ExecutionDays = 1, Group= "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true, ExecutionDays = 1, Group= "Replicación", Name  = "Job Replicación 4", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 53, IsFavorite = true, ExecutionDays = 1, Group= "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 65, IsFavorite = true, ExecutionDays = 1, Group= "Replicación", Name  = "Job Replicación 4", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 74, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 82, IsFavorite = true, ExecutionDays = 1, Group= "Replicación", Name  = "Job Replicación 4", JobType = JobType.Automatico });
            
            return jobsList;
        }

        public List<Job> GetJobs()
        {
            var jobsList = new List<Job>();

            jobsList.Add(new SqlJob { JobId = 1, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob { JobId = 23, IsFavorite = true, ExecutionDays = 1, Group = "Otros", Name = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 34, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Manual});
            jobsList.Add(new SqlJob { JobId = 45, IsFavorite = true, ExecutionDays = 1, Group = "Otros", Name = "Job Replicación 4", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob { JobId = 53, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob { JobId = 65, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob { JobId = 74, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob { JobId = 82, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automatico });

            return jobsList;
        }

        public Job GetJobById(int JobId)
        {
            SqlJobTrigger sqlJobTrigger = new SqlJobTrigger
                                              {
                                                  JobTriggerId = 1,
                                                  CreatedBy = "Carlos",
                                                  XmlFormInputValues = "Input Values",
                                                  XmlTableInput = "XML Input Values",
                                                  XmlTableOutput = "XML Output",
                                                  XmlResult = "XML Result",
                                                  RecordsProcessed = 100,
                                                  RecordsAffected = 10,
                                                  JobTriggerStatus = JobTriggerStatus.Agendado
                                              };
            var triggers = new List<JobTrigger>();
            triggers.Add(sqlJobTrigger);

            return new SqlJob
                {
                    JobId = 1,
                    Triggers = triggers,
                    IsFavorite = true,
                    ExecutionDays = 1,
                    Group = "Replicación",
                    Name = "Job Replicación 1",
                    JobType = JobType.Automatico,
                    ServerName = "SQL1",
                    DatabaseName = "CGPlanos",
                    Description = "Esto es una descripción de las tareas que realiza el proceso",
                    UserName = "PEPE",
                    CreatedBy = "Carlos.Daniel.Vazquez"

                };
        }

        public JobTrigger GetJobTriggerById(int JobId)
        {
            var sqlJob = new SqlJob
            {
                JobId = 1,
                IsFavorite = true,
                ExecutionDays = 1,
                Group = "Replicación",
                Name = "Job Replicación 1",
                Comments = "Comentarios",
                JobType = JobType.Automatico,
                ServerName = "SQL1",
                DatabaseName = "CGPlanos",
                Description = "Esto es una descripción de las tareas que realiza el proceso",
                UserName = "PEPE",
                CreatedBy = "Carlos.Daniel.Vazquez",
                
            };

            return new SqlJobTrigger
            {
                JobTriggerId = 1,
                CreatedBy = "Carlos",
                XmlFormInputValues = "Input Values",
                XmlTableInput = "XML Input Values",
                XmlTableOutput = "XML Output",
                RecordsProcessed = 100,
                RecordsAffected = 10,
                Job =sqlJob,
                JobTriggerStatus = JobTriggerStatus.Agendado,
                XmlTableExecutionLog = "Execution Log",
                XmlResult = @"<?xml version=""1.0"" encoding=""iso-8859-1"" ?>
<CTABLARESULTADO>
  <CCABECERA>
    <CVALOR>CABECERA 1</CVALOR>
    <CVALOR>CABECERA 2</CVALOR>
    <CVALOR>CABECERA 3</CVALOR>
    <CVALOR>CABECERA 4</CVALOR>
  </CCABECERA>
  <CFILA>
    <CVALOR>CTITULO1</CVALOR>
    <CVALOR>TITULO</CVALOR>
    <CVALOR>0111- PROCESOS DE CUENTAS BANCARIAS</CVALOR>
    <CVALOR>1</CVALOR>
  </CFILA>
  <CFILA>
    <CVALOR>CTITULO2</CVALOR>
    <CVALOR>TITULO2</CVALOR>
    <CVALOR>0112- PROCESOS DE CUENTAS BANCARIAS</CVALOR>
    <CVALOR>2</CVALOR>
  </CFILA>
  <CFILA>
    <CVALOR>CTITULO3</CVALOR>
    <CVALOR>TITULO3</CVALOR>
    <CVALOR>0113- PROCESOS DE CUENTAS BANCARIAS</CVALOR>
    <CVALOR>3</CVALOR>
  </CFILA>
  <CFILA>
    <CVALOR>CTITULO4</CVALOR>
    <CVALOR>TITULO4</CVALOR>
    <CVALOR>0114- PROCESOS DE CUENTAS BANCARIAS</CVALOR>
    <CVALOR>4</CVALOR>
  </CFILA>
</CTABLARESULTADO>"
            };
            
        }

        public Job GetJobByName(string name, string groupName)
        {
            throw new NotImplementedException();
        }

        public void AddJob(Job job, JobTrigger trigger)
        {
            throw new NotImplementedException();
        }

        public void AddJob(Job job)
        {
           
        }

        public void AddTrigger(JobTrigger trigger)
        {
            throw new NotImplementedException();
        }

        public void GetNewJob(JobType jobType)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrigger(JobTrigger trigger)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetJobsByFavorites()
        {
            var jobsList = new List<Job>();

            jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, ExecutionDays = 2, Group  = "Replicación", Name  = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 44, IsFavorite = true, ExecutionDays = 3, Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true, ExecutionDays = 4, Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 52, IsFavorite = true, ExecutionDays =4, Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 53, IsFavorite = true, ExecutionDays = 4, Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 78, IsFavorite = true, ExecutionDays = 5, Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 89, IsFavorite = true, ExecutionDays = 8, Group  = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 152, IsFavorite = true, ExecutionDays = 4, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob { JobId = 153, IsFavorite = true, ExecutionDays = 4, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
            jobsList.Add(new SqlJob { JobId = 178, IsFavorite = true, ExecutionDays = 5, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob { JobId = 189, IsFavorite = true, ExecutionDays = 8, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual });
           
            return jobsList;
        }

        public List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime, JobType jobType)
        {
             var jobsList = new List<Job>();

            if (jobType == JobType.Manual)
            {
                jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual, LastExecutionStatus = LastExecutionStatus.Error});
                jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, ExecutionDays = 2, Group = "Replicación", Name = "Job Replicación 2", JobType = JobType.Manual, LastExecutionStatus =LastExecutionStatus.Error });
                jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true, ExecutionDays = 8, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual, LastExecutionStatus  = LastExecutionStatus.Error });
            }
            else
            {
                jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Automatico, LastExecutionStatus = LastExecutionStatus.Error});
                jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, ExecutionDays = 2, Group = "Replicación", Name = "Job Replicación 2", JobType = JobType.Automatico, LastExecutionStatus =LastExecutionStatus.Error });
                jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true, ExecutionDays = 8, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Automatico, LastExecutionStatus  = LastExecutionStatus.Error });
            }
            
            return jobsList;
        }

        public List<Job> GetJobsByExecutionDay(string groupName, DateTime? dateTime)
        {
             var jobsList = new List<Job>();

             jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual, LastExecutionStatus = LastExecutionStatus.Error});
             jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, ExecutionDays = 2, Group = "Replicación", Name = "Job Replicación 2", JobType = JobType.Manual, LastExecutionStatus =LastExecutionStatus.Error });
             jobsList.Add(new SqlJob  { JobId = 34, IsFavorite = true, ExecutionDays = 2, Group = "Replicación", Name = "Job Replicación 3", JobType = JobType.Automatico, LastExecutionStatus  = LastExecutionStatus.Error });
             jobsList.Add(new SqlJob  { JobId = 45, IsFavorite = true, ExecutionDays = 8, Group = "Replicación", Name = "Job Replicación 4", JobType = JobType.Manual, LastExecutionStatus  = LastExecutionStatus.Error });
            
            return jobsList;
        }

        public List<Job> GetRelatedJobs(int jobId)
        {
            
            var jobsList = new List<Job>();

            if (jobId == -1) return jobsList;

            if((jobId % 2) == 0)
            {
                jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual });
                jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, ExecutionDays = 2, Group = "Replicación", Name  = "Job Replicación 2", JobType = JobType.Manual });
            }

            jobsList.Add(new SqlJob  { JobId = 31, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
            jobsList.Add(new SqlJob  { JobId = 42, IsFavorite = true, ExecutionDays = 2, Group = "Replicación", Name  = "Job Replicación 4", JobType = JobType.Manual });
            
            return jobsList;
        }


        #region IJobSchedulerService Members


        public List<JobTrigger> GetJobTriggersByExecutionDay(DateTime? dateTime)
        {
            var jobsTriggerList = new List<JobTrigger>();

            var sqlJob = new SqlJob
                {
                    JobId = 12,
                    IsFavorite = true,
                    ExecutionDays = 1,
                    Group = "Replicación",
                    Name = "Job Replicación 1",
                    JobType = JobType.Manual
                };

            var sqlJob2 = new SqlJob
            {
                JobId = 13,
                IsFavorite = true,
                ExecutionDays = 1,
                Group = "Replicación Automática",
                Name = "Job Replicación 1",
                JobType = JobType.Automatico
            };

            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 1, Job = sqlJob, RecordsAffected = 1, RecordsProcessed = 100, JobTriggerStatus = JobTriggerStatus.Agendado });
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 2, Job = sqlJob2, RecordsAffected = 2, RecordsProcessed = 200, JobTriggerStatus = JobTriggerStatus.Agendado });
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 3, Job = sqlJob, RecordsAffected = 33, RecordsProcessed = 250, JobTriggerStatus = JobTriggerStatus.Ejecutado });
            
            return jobsTriggerList;
        }

        #endregion

        #region IJobSchedulerService Members


        public List<Job> GetJobsByDaily()
        {
            var jobsList = new List<Job>();

            jobsList.Add(new SqlJob  { JobId = 12, IsFavorite = true, ExecutionDays = 1, Group = "Replicación", Name = "Job Replicación 1", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 23, IsFavorite = true, ExecutionDays = 2, Group  = "Replicación", Name  = "Job Replicación 2", JobType = JobType.Manual });
            jobsList.Add(new SqlJob  { JobId = 44, IsFavorite = true, ExecutionDays = 3, Group  = "Replicación", Name  = "Job Replicación 3", JobType = JobType.Automatico });
           
            return jobsList;
        }

        #endregion
    

        public List<JobTrigger>  GetJobTriggersByExecutionDay(DateTime? dateTime, JobType jobType)
        {
            var jobsTriggerList = new List<JobTrigger>();

            var sqlJob = new SqlJob
            {
                JobId = 12,
                IsFavorite = true,
                ExecutionDays = 1,
                Group = "Replicación",
                Name = "Job Replicación 1",
                JobType = jobType
            };

            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 1, Job = sqlJob, RecordsAffected = 1, RecordsProcessed = 100, JobTriggerStatus = JobTriggerStatus.Agendado });
            jobsTriggerList.Add(new SqlJobTrigger { JobTriggerId = 2, Job = sqlJob, RecordsAffected = 2, RecordsProcessed = 200, JobTriggerStatus = JobTriggerStatus.Agendado });
            
            return jobsTriggerList;
        }

        public List<JobTrigger>  GetJobTriggersByExecutionDay(DateTime? dateTime, JobTriggerStatus jobTriggerStatus)
        {
            var jobsTriggerList = new List<JobTrigger>();

            var sqlJob = new SqlJob
            {
                JobId = 12,
                IsFavorite = true,
                ExecutionDays = 1,
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
    <DMAXDATE>2012/06/30</DMAXDATE>
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

        public void FiringManualTrigger(int triggerId)
        {
            throw new NotImplementedException();
        }

        public List<JobTrigger> GetJobTriggers()
        {
            throw new NotImplementedException();
        }


        public void UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }

        #region IJobSchedulerService Members


        public void DeleteJob(Job job)
        {
            
        }

        #endregion
    }
}
