using System;
using System.Web.UI;
using Model;
using CG.Services.interfaces;
using System.Globalization;

namespace CGControlPanel.Dialogs
{
    public partial class ScheduleJobDialog : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
           // dtDate.MinDate = DateTime.Now.AddDays(-1);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
             //   dtDate.Date = DateTime.Now;

                hdnJobId.Value = Request["JobId"];

                // Si es manual solo se debe agendar el día ya que es el usuario el que lo ejecuta cuando lo desea
                if (Request["JobType"] != null)
                {
                    var job = jobSchedulerService.GetJobById(Convert.ToInt32(Request["JobId"]));
                    txtNombre.Value = "ID: " + job.JobId + " - Proceso: " + job.Name + " - Grupo: " + job.Group;

                    if (Request["JobType"].ToUpper() == "MANUAL")
                    {
                        ltrlProcessType.Text = "Manual";
                        divAutomaticProcess.Visible = false;
                        //dtTime.Visible = false;
                        //lblHour.Style.Add("Display", "none");
                    }
                    else 
                    {
                        ltrlProcessType.Text = "Automático";
                    }
                }
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            var sqlJob = jobSchedulerService.GetJobById(Convert.ToInt32(hdnJobId.Value));

            try
            {
                IFormatProvider culture = new CultureInfo("es-AR", true);
                var date = DateTime.Parse(dtDate.Value,
                           culture,
                           DateTimeStyles.NoCurrentDateDefault);
                var selectedDateTime = date; //new DateTime(date.Year, date.Month, date.Day);

                switch (e.Parameter)
                {
                    case "SCHEDULEMANUAL":
                        // Se agrega el trigger pero deshabilitado, para que pueda ser ejecutado desde la grilla de ejecución cuando se corra el comando Ejecutar desde el menú contextual.
                        // No se agrega en Quartz, solo en CGControlPanel.
                        e.Result = "SCHEDULEDMANUALOK";
                        var sqlManualJobTrigger = new SqlJobTrigger
                        {
                            CreatedBy = User.Identity.Name,
                            CreatedDate = DateTime.Now,
                            Enabled = false, // DESHABILITADO
                            ScheduledStartExecutionDate = selectedDateTime.AddMinutes(59).AddHours(11),
                            JobTriggerStatus = JobTriggerStatus.Agendado
                        };

                        jobSchedulerService.AddTrigger(sqlJob, sqlManualJobTrigger);
                        break;
                    case "SCHEDULEAUTOMATIC":
                        var time = DateTime.Parse(dtTime.Value,
                           culture,
                           DateTimeStyles.NoCurrentDateDefault);
                        selectedDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                        
                        // Al crear el trigger se lo debe inicializar obligatoriamente con los siguientes datos.
                        // De todas maneras hay un método Validate que valida el objeto dentro de AddTrigger.
                        // JobTriggerStatus = JobTriggerStatus.Agendado;
                        // CreatedBy = User.Identity.Name;
                        // ScheduledStartExecutionDate = DateTime.Now;
                        // CreatedDate = DateTime.Now;
                        // Opcional Enabled = true;
                        var sqlJobTrigger = new SqlJobTrigger
                                                {
                                                    CreatedBy = User.Identity.Name,
                                                    CreatedDate = DateTime.Now,
                                                    Enabled = true,
                                                    ScheduledStartExecutionDate = selectedDateTime,
                                                    JobTriggerStatus = JobTriggerStatus.Agendado
                                                };

                        jobSchedulerService.AddTrigger(sqlJob, sqlJobTrigger);
                        e.Result = "SCHEDULEDAUTOMATICOK";
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