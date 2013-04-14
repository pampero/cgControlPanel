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
    public partial class JobTriggerInfoDialog : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected void FillUI(JobTrigger jobTrigger)
        {
            var sqlJobTrigger = (SqlJobTrigger)jobTrigger;

            ltrlProcessType.Text = sqlJobTrigger.Job.JobType.ToString();
            
            /* DATOS JOB */
            lblProcessName.Text = "ID: " + jobTrigger.Job.JobId + " - Proceso: " + jobTrigger.Job.Name + " - Grupo: " + jobTrigger.Job.Group;
            lblProcessOwner.Text = "Usuario: " + jobTrigger.Job.CreatedBy;
            lblDescription.Text = "Descripción: " + jobTrigger.Job.Description;

            // Formatea los datos con el estilo XML que muestra Internet Explorer
            txtInputValues.Text = Utils.UI.Helper.FormatXml(sqlJobTrigger.Job.InputXmlFixedParameters + sqlJobTrigger.InputFormXmlValues);

            lblComments.Text = "Comentarios: " + sqlJobTrigger.Job.Comments;
            lblProcessType.Text = "Tipo de Proceso: " + sqlJobTrigger.Job.JobType;

            Weekdays weekdays = new Weekdays();
            weekdays.AllDays = Convert.ToByte(((SqlJob)sqlJobTrigger.Job).Weekdays);
            
            if (weekdays.AllDays == 0)
                lblWeekDays.Text = "Frecuencia: No Diaria";
            else
                lblWeekDays.Text = "Frecuencia: " + Utils.UI.Helper.BuildPopulateDaysLegend(weekdays);

            lblServerName.Text = "Nombre Servidor: " + ((SqlJob)sqlJobTrigger.Job).ServerName;
            lblDataBaseName.Text = "Nombre BD: " + ((SqlJob)sqlJobTrigger.Job).DatabaseName;
            lblStoredProcedure.Text = "Stored de Ejecución: " + ((SqlJob)sqlJobTrigger.Job).ExecProcedure;
            lblInputXmlFixedParameters.Text = "Valores Fijos: " + sqlJobTrigger.Job.InputXmlFixedParameters;

            if (sqlJobTrigger.Job.JobType == JobType.Automático)
            {
                lblScheduledStartExecutionDate.Text = "Agendado el: " + sqlJobTrigger.ScheduledStartExecutionDate.ToString("dd/MM/yyyy HH:mm");
                lblInputSchemaProcedure.Text = "Stored de Config: -";

                if (sqlJobTrigger.Job.AutomaticProcessTime.HasValue && sqlJobTrigger.Job.Weekdays != 0)
                {
                    lblAutomaticProcessTime.Text = "Hora Ejecución: " + sqlJobTrigger.Job.AutomaticProcessTime.Value.ToString("HH:mm:ss");
                }
                else
                    divAutomaticProcessTime.Visible = false;
            }
            else
            {
                lblScheduledStartExecutionDate.Text = "Agendado el: " + sqlJobTrigger.ScheduledStartExecutionDate.ToString("dd/MM/yyyy");
                lblInputSchemaProcedure.Text = "Stored de Config: " + sqlJobTrigger.Job.InputSchemaProcedure;
                divInputSchemaProcedure.Visible = true;
                divAutomaticProcessTime.Visible = false;
            }
            
            /* FIN DATOS JOB */

            /* DATOS JOBTRIGGER */
            if (String.IsNullOrEmpty(sqlJobTrigger.OutputExecutionStatus))
                lblOutputStatus.Text = "Estado de la Salida: NO Ejecutado";
            else
                lblOutputStatus.Text = "Estado de la Salida: " + sqlJobTrigger.OutputExecutionStatus;
            
            lblTrigger.Text = "Trigger: " + jobTrigger.JobTriggerId;

            if ((sqlJobTrigger.RecordsAffected == 0) && (sqlJobTrigger.RecordsProcessed == 0))
                lblRecords.Text = "Registros: - / -";
            else
                lblRecords.Text = "Registros: " + sqlJobTrigger.RecordsAffected.ToString() + "/" + sqlJobTrigger.RecordsProcessed.ToString();
         

            switch (jobTrigger.JobTriggerStatus)
	        {
                case JobTriggerStatus.Agendado:
                    btnDelete.Visible = true;
                    btnKillProcess.Visible = false;
                    break;
                case JobTriggerStatus.Ejecutando:
                    btnDelete.Visible = false;
                    btnKillProcess.Visible = true;
                break;
                default:
                    btnDelete.Visible = false;
                    btnKillProcess.Visible = false;
                    break;
        	}

            // TODO: Poner un tag en el xmlResultado para mostrar datos luego de que arme la tabla.
            // InputValues es el resultado de la ejecución del stored de Configuración que arma el Form Dinámico
            txtXmlInputTable.Text= sqlJobTrigger.InputXmlTable;
            txtXmlOutputTable.Text = sqlJobTrigger.OutputXmlTable;

            ltrlOuputExecutionLog.Text = string.IsNullOrEmpty(sqlJobTrigger.OutputExecutionLog) ? "SIN DATOS PARA MOSTRAR" : sqlJobTrigger.OutputExecutionLog;

            ltrlOutputResult.Text = string.IsNullOrEmpty(sqlJobTrigger.OutputExecutionResult) ? "SIN DATOS PARA MOSTRAR" : sqlJobTrigger.OutputExecutionResult;
            ltrlOutputExecutionTrace.Text = string.IsNullOrEmpty(sqlJobTrigger.OutputExecutionTrace) ? "SIN DATOS PARA MOSTRAR" : sqlJobTrigger.OutputExecutionTrace;

            lblJobTriggerStatus.Text = "Estado del Proceso: " + sqlJobTrigger.JobTriggerStatus.ToString().ToUpper();
            lblStartExecutionDate.Text = "Inicio Ejecución: " + ((sqlJobTrigger.StartExecutionDate.HasValue) ? sqlJobTrigger.StartExecutionDate.Value.ToString("dd/MM/yyyy hh:mm:ss") : "");
            lblEndExecutionDate.Text = "Fin Ejecución: " + ((sqlJobTrigger.EndExecutionDate.HasValue) ? sqlJobTrigger.EndExecutionDate.Value.ToString("dd/MM/yyyy hh:mm:ss") : "");

            /* FIN DATOS JOBTRIGGER */

            lnkPrint.HRef = "/Reports/JobTriggerInfo.aspx?triggerId=" + jobTrigger.JobTriggerId;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var sqlJobTrigger = (SqlJobTrigger)jobSchedulerService.GetJobTriggerById(Convert.ToInt32(Request["jobTriggerId"]));
                FillUI(sqlJobTrigger);
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            var sqlJobTrigger = (SqlJobTrigger)jobSchedulerService.GetJobTriggerById(Convert.ToInt32(Request["jobTriggerId"]));

            try
            {
                switch (e.Parameter)
                {
                    // SOLO BORRAR SI EL TRIGGER ESTA AGENDADO
                    case "DELETE":                        
                        if (sqlJobTrigger.JobTriggerStatus == JobTriggerStatus.Agendado)
                        {
                            sqlJobTrigger.DeletedBy = User.Identity.Name;
                            jobSchedulerService.DeleteTrigger(sqlJobTrigger);
                            e.Result = "DELETEDOK";
                        }
                        else
                        {
                            e.Result = "No se puede eliminar el agendamiento porque no está en estado Agendado";
                        }
                        break;
                    case "KILLPROCESS":
                        if (sqlJobTrigger.JobTriggerStatus == JobTriggerStatus.Ejecutando)
                            jobSchedulerService.KillProcess(sqlJobTrigger);
                        e.Result = "PROCESSKILLED";
                        break;
                }
            }
            catch (Exception ex)
            {
                if (log.IsErrorEnabled)
                    log.Error(Utils.UI.Helper.BuildRecursiveErrorMessage(ex));
                e.Result = "Error:\r\n" + Utils.UI.Helper.BuildRecursiveErrorMessage(ex);
            }
        }
    }
}