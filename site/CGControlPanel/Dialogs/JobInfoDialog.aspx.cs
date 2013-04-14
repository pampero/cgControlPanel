using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using CG.Services.interfaces;

namespace CGControlPanel.Dialogs
{
    public partial class JobInfoDialog : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected void FillUI(Job job)
        {
            var sqlJob = (SqlJob)job;

            ltrlProcessType.Text = sqlJob.JobType.ToString();

            lblProcessName.Text = "ID: " + job.JobId + " - Proceso: " + job.Name + " - Grupo: " + job.Group;
            lblDescription.Text = "Descripción: " + job.Description;
            lblComments.Text = "Comentarios: " + sqlJob.Comments;
            lblProcessOwner.Text = "Creado Por: " + job.CreatedBy;
            if (sqlJob.JobType == JobType.Automático)
            {
                divInputSchemaProcedure.Visible = false;
                if (sqlJob.AutomaticProcessTime.HasValue && sqlJob.Weekdays != 0)
                {
                    lblAutomaticProcessTime.Text = "Hora Ejecución: " + sqlJob.AutomaticProcessTime.Value.ToString("HH:mm:ss");
                }
                else
                    lblAutomaticProcessTime.Text = "Hora Ejecución: --:-- --";
            }
            else
            {
                divInputSchemaProcedure.Visible = true;
                divAutomaticProcessTime.Visible = false;
            }
            lblProcessType.Text = "Tipo de Proceso: " + sqlJob.JobType;
            lblServerName.Text = "Nombre Servidor: " + sqlJob.ServerName;
            lblDataBaseName.Text = "Nombre BD: " + sqlJob.DatabaseName;
            lblStoredProcedure.Text = "Stored de Ejecución: " + sqlJob.ExecProcedure;
            lblDataBaseUser.Text = "Usuario DB: " + sqlJob.UserName;
            lblInputXmlFixedParameters.Text = "Valores Fijos: " + sqlJob.InputXmlFixedParameters;
            
            if (sqlJob.JobType == JobType.Automático)
                divInputSchemaProcedure.Visible = false;
            else
                lblInputSchemaProcedure.Text = "Stored de Config: " + sqlJob.InputSchemaProcedure;

            Weekdays weekdays = new Weekdays();
            weekdays.AllDays = Convert.ToByte(sqlJob.Weekdays);
            
            if (weekdays.AllDays == 0)
                lblWeekDays.Text = "Frecuencia: No Diaria";
            else
                lblWeekDays.Text = "Frecuencia: " + Utils.UI.Helper.BuildPopulateDaysLegend(weekdays);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var sqlJob = (SqlJob)jobSchedulerService.GetJobById(Convert.ToInt32(Request["jobId"]));
                FillUI(sqlJob);
            }
        }
    }
}