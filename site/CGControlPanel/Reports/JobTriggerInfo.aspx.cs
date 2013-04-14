using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using CG.Services.interfaces;

namespace CGControlPanel.Reports
{
    /// <summary>
    /// FALTA:
    ///     1.  Ocultar y mostrar la hora cuando es automático diario
    /// </summary>
    public partial class JobTriggerInfo : System.Web.UI.Page
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected void FillReport(JobTrigger jobTrigger)
        {
            var sqlJobTrigger = (SqlJobTrigger)jobTrigger;

            /* DATOS JOB */

            lblProcessName.Text = jobTrigger.Job.Name + " (" + jobTrigger.Job.Group + ") - " + jobTrigger.Job.JobId  + " -" ;
            lblProcessOwner.Text = jobTrigger.Job.CreatedBy;
            lblDescription.Text = jobTrigger.Job.Description;
            lblInputValues.Text = Utils.UI.Helper.FormatXml(sqlJobTrigger.Job.InputXmlFixedParameters + sqlJobTrigger.InputFormXmlValues);
            lblComments.Text = sqlJobTrigger.Job.Comments;
            lblProcessType.Text = sqlJobTrigger.Job.JobType.ToString();

            Weekdays weekdays = new Weekdays();
            weekdays.AllDays = Convert.ToByte(((SqlJob)sqlJobTrigger.Job).Weekdays);

            if (weekdays.AllDays == 0)
                lblWeekDays.Text = "No Diaria";
            else
                lblWeekDays.Text = Utils.UI.Helper.BuildPopulateDaysLegend(weekdays);

            lblServerName.Text = ((SqlJob)sqlJobTrigger.Job).ServerName;
            lblDataBaseName.Text = ((SqlJob)sqlJobTrigger.Job).DatabaseName;
            lblStoredProcedure.Text = ((SqlJob)sqlJobTrigger.Job).ExecProcedure;
            lblInputXmlFixedParameters.Text = Utils.UI.Helper.FormatXml(sqlJobTrigger.Job.InputXmlFixedParameters);
            lblInputXmlFixedParameters.Text = lblInputXmlFixedParameters.Text.Replace("<ROOT>", "").Replace("</ROOT>", "");

            if (sqlJobTrigger.Job.JobType == JobType.Automático)
            {
                lblScheduledStartExecutionDate.Text = sqlJobTrigger.ScheduledStartExecutionDate.ToString("dd/MM/yyyy HH:mm:ss");

                if (sqlJobTrigger.Job.AutomaticProcessTime.HasValue && sqlJobTrigger.Job.Weekdays != 0)
                {
                    lblAutomaticProcessTime.Text = "Hora Ejecución: " + sqlJobTrigger.Job.AutomaticProcessTime.Value.ToString("HH:mm:ss");
                }
                else
                    lblAutomaticProcessTime.Text = "-";
            }
            else
            {
                lblScheduledStartExecutionDate.Text = sqlJobTrigger.ScheduledStartExecutionDate.ToString("dd/MM/yyyy");
                lblInputSchemaProcedure.Text = sqlJobTrigger.Job.InputSchemaProcedure;
                lblAutomaticProcessTime.Text = "-";
            }

            /* FIN DATOS JOB */

            /* DATOS JOBTRIGGER */
            if (String.IsNullOrEmpty(sqlJobTrigger.OutputExecutionStatus))
                lblOutputStatus.Text = "NO Ejecutado";
            else
                lblOutputStatus.Text = sqlJobTrigger.OutputExecutionStatus;

            lblTrigger.Text = jobTrigger.JobTriggerId.ToString();

            if ((sqlJobTrigger.RecordsAffected == 0) && (sqlJobTrigger.RecordsProcessed == 0))
                lblRecords.Text = "- / -";
            else
                lblRecords.Text = sqlJobTrigger.RecordsAffected.ToString() + "/" + sqlJobTrigger.RecordsProcessed.ToString();

            lblOuputExecutionLog.Text = string.IsNullOrEmpty(sqlJobTrigger.OutputExecutionLog) ? "SIN DATOS PARA MOSTRAR" : sqlJobTrigger.OutputExecutionLog;
            lblOutputResult.Text = string.IsNullOrEmpty(sqlJobTrigger.OutputExecutionResult) ? "SIN DATOS PARA MOSTRAR" : sqlJobTrigger.OutputExecutionResult;
            lblOutputExecutionTrace.Text = string.IsNullOrEmpty(sqlJobTrigger.OutputExecutionTrace) ? "SIN DATOS PARA MOSTRAR" : sqlJobTrigger.OutputExecutionTrace;

            lblJobTriggerStatus.Text = sqlJobTrigger.JobTriggerStatus.ToString().ToUpper();
            lblStartExecutionDate.Text = ((sqlJobTrigger.StartExecutionDate.HasValue) ? sqlJobTrigger.StartExecutionDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : "");
            lblEndExecutionDate.Text = ((sqlJobTrigger.EndExecutionDate.HasValue) ? sqlJobTrigger.EndExecutionDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : "");

            /* FIN DATOS JOBTRIGGER */
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var sqlJobTrigger = (SqlJobTrigger)jobSchedulerService.GetJobTriggerById(Convert.ToInt32(Request["triggerId"]));
                FillReport(sqlJobTrigger);
            }
        }
    }
}