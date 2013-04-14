using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using CG.Services.interfaces;

namespace CGControlPanel
{
    public partial class JobTriggerInfo : BasePage
    {
         public IJobSchedulerService jobSchedulerService { get; set; }

        protected void FillUI(JobTrigger jobTrigger)
        {
            var sqlJobTrigger =  (SqlJobTrigger)jobTrigger;

            lblProcessName.Text = "Proceso: " + jobTrigger.Job.JobId + " - " + jobTrigger.Job.Name;    
            lblProcessOwner.Text =  "Usuario: " + jobTrigger.Job.CreatedBy;
            lblDescription.Text =  "Descripción: " + jobTrigger.Job.Description;
            txtInputValues.Text = sqlJobTrigger.Job.FixedParametersProcedure + sqlJobTrigger.XmlFormInputValues; 

            lblTrigger.Text =  "Trigger: " + jobTrigger.JobTriggerId;
            lblRecords.Text = "Registros: " + sqlJobTrigger.RecordsAffected.ToString() + "/" + sqlJobTrigger.RecordsProcessed.ToString();
            lblDaily.Text = "Frecuencia: " + (sqlJobTrigger.Job.IsDaily ? "DIARIA" : "");
            
            lblComments.Text = "Comentarios: " + sqlJobTrigger.Job.Comments;
            lblProcessType.Text = "Tipo de Proceso: " + sqlJobTrigger.Job.JobType;
            
            // AREA DE INFORMACION DE EJECUCION
            if (!sqlJobTrigger.StartExecutionDate.HasValue)
            {       
                tabControl.ActiveTabPage.Visible = false;
                tabControl.ActiveTabIndex = 0;
                
                if (Request.QueryString["delete"] != "1")
                {
                    btnDeleteTrigger.Visible = false;
                }
            }
            
            // TODO: Poner un tag en el xmlResultado para mostrar datos luego de que arme la tabla.
            // InputValues es el resultado de la ejecución del stored de Configuración que arma el Form Dinámico
            txtXmlTableInputParameters.Text= sqlJobTrigger.XmlTableInput;
            txtXmlTableOutput.Text = sqlJobTrigger.XmlTableOutput;
            txtExecutionLog.Text = sqlJobTrigger.XmlTableExecutionLog;
            Utils.UI.Helper.BuildASPTable(sqlJobTrigger.XmlResult, tblResult);
            
            lblStartExecutionDate.Text = "Ejecución: " + ((sqlJobTrigger.StartExecutionDate.HasValue) ? sqlJobTrigger.StartExecutionDate.Value.ToString("dd/MM/yyyy hh:mm:ss") : "");
            lblEndExecutionDate.Text = ((sqlJobTrigger.EndExecutionDate.HasValue) ? sqlJobTrigger.EndExecutionDate.Value.ToString("dd/MM/yyyy hh:mm:ss") : "");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var job = new SqlJob
                               {
                                   DatabaseName = "TestDB",
                                   ExecProcedure = "Procedure",
                                   UserName = "cvazquez",
                                   Password = "clave",
                                   ServerName = "server",
                                   JobStatus = JobStatus.Success,
                                   CreatedBy = "",
                                   CreatedDate = DateTime.Now,
                                   Deleted = false,
                                   Description = "",
                                   ExecutionDays = 1,
                                   JobStatusEnum = 1,
                                   JobType = JobType.Manual,
                                   Name = "Nombre",
                                   Group = "Grupo",
                                   JobTypeEnum = 1,
                                   JOB_GROUP = "Grupo",
                                   JOB_NAME = "Nombre",
                                   SCHED_NAME = "Sched",
                                   LastExecutionStatus = LastExecutionStatus.Success
                               };

                //jobSchedulerService.AddJob(job);
                var sqlJobTrigger = jobSchedulerService.GetJobTriggerById(Convert.ToInt32(Request.Form["jobid"]));
                
                FillUI(sqlJobTrigger);
            }
        }

    }
}