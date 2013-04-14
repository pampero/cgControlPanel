using System;
using System.Linq;
using System.Web;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Model;
using Quartz;
using System.Web.UI;
using CG.Services.interfaces;
//using JobType = CG.Model.Enums.JobType;

namespace CGControlPanel
{
    public partial class Home : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }
        public INotificationService notificationService { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                calendar.SelectedDate = DateTime.Now;

            // FAVORITOS
            grdFavorites.DataSource = jobSchedulerService.GetJobsByFavorites();
            grdFavorites.DataBind();
            
            // GENERALES
            grdAllJobs.DataSource = jobSchedulerService.GetJobsByGeneral();
            grdAllJobs.DataBind();

            // DIARIOS
            grdTodayJobs.DataSource = jobSchedulerService.GetJobsByDaily(calendar.SelectedDate);
            grdTodayJobs.DataBind();
         
            // EJECUCION
            grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(calendar.SelectedDate);
            grdDailyJobs.PageIndex = 0;
            grdDailyJobs.DataBind();
       
            grdDailyJobs.PreRender += genericGrid_PreRender;
            grdTodayJobs.PreRender += genericGrid_PreRender;
            grdAllJobs.PreRender += genericGrid_PreRender;
            grdFavorites.PreRender += genericGrid_PreRender;
        }


        protected void genericGrid_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ((ASPxGridView)sender).FocusedRowIndex = -1;
        }

        protected void grdRelatedJobs_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {

            var masterJobId = Convert.ToInt32(e.Parameters);
            
            if (masterJobId == 0) return;

            grdFavorites.FocusedRowIndex = -1;
            grdRelatedJobs.DataSource = jobSchedulerService.GetRelatedJobs(masterJobId);
            grdRelatedJobs.PageIndex = 0;
            grdRelatedJobs.DataBind();
        }

        protected void btnXlsxExport_Click(object sender, EventArgs e)
        {
            grdDailyJobs.Columns[0].Visible = false;
            grdDailyJobs.Columns["Job.JobId"].Visible = false;
            grdDailyJobs.Columns[grdDailyJobs.Columns.Count-3].Visible = false;
            grdDailyJobs.Columns[grdDailyJobs.Columns.Count-2].Visible = false;
            grdDailyJobs.Columns[grdDailyJobs.Columns.Count-1].Visible = false;
            gridExport.WriteXlsxToResponse();
        }

        protected void grdGeneric_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            int startIndex = ((ASPxGridView)sender).PageIndex * ((ASPxGridView)sender).SettingsPager.PageSize;
            int end = Math.Min(((ASPxGridView)sender).VisibleRowCount, startIndex + ((ASPxGridView)sender).SettingsPager.PageSize);
            object[] jobId = new object[end - startIndex], jobType = new object[end - startIndex], jobTriggerId = new object[end - startIndex], inputSchemaProcedure = new object[end - startIndex], jobTriggerStatus = new object[end - startIndex];
            for(int n = startIndex; n < end; n++) {
                if (((ASPxGridView)sender).ClientInstanceName == "grdDailyJobs")
                {
                    jobTriggerStatus[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "JobTriggerStatus");
                    jobId[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "Job.JobId");
                    jobType[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "Job.JobType");
                    jobTriggerId[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "JobTriggerId");
                    if (((ASPxGridView)sender).GetRowValues(n, "Job.InputSchemaProcedure") == null){
                        inputSchemaProcedure[n - startIndex] = "";
                    }
                    else
                    {
                        inputSchemaProcedure[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "Job.InputSchemaProcedure"); 
                    }
                }
                else
                {
                    jobType[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "JobType");
                    jobId[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "JobId");    
                    if (((ASPxGridView)sender).GetRowValues(n, "InputSchemaProcedure") == null)
                    {
                        inputSchemaProcedure[n - startIndex] = "";
                    }
                    else
                    {
                        inputSchemaProcedure[n - startIndex] = ((ASPxGridView)sender).GetRowValues(n, "InputSchemaProcedure");
                    }
                }
            }
            e.Properties["cpJobId"] = jobId;
            e.Properties["cpJobType"] = jobType;
            e.Properties["cpJobTriggerId"] = jobTriggerId;
            if (((ASPxGridView)sender).ClientInstanceName == "grdDailyJobs")
                e.Properties["cpJobTriggerStatus"] = jobTriggerStatus;
            e.Properties["cpSPName"] = inputSchemaProcedure;
        }

        protected void grdDailyJobs_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) 
        {
            var command = e.Parameters.Split('|')[1];
            var pageIndex = Convert.ToInt32(e.Parameters.Split('|')[0]);

            var selectedDate = calendar.SelectedDate;

            switch (command)
            {
                case "SHOWALL":
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate);
                    break;
                case "SHOWPENDING":
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate, JobTriggerStatus.Agendado);
                    break;
                case "SHOWEXECUTED":
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate, JobTriggerStatus.Ejecutado);
                    break;
                case "SHOWERROR":
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate, JobTriggerStatus.Error);
                    break;
                case "SHOWAUTOMATIC":
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate, JobType.Automático);
                    break;
                case "SHOWMANUAL":
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate, JobType.Manual);
                    break;
            }
         
            grdDailyJobs.DataBind();
            grdDailyJobs.PageIndex = pageIndex;
        }

        private static Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                var controlToReturn =
                    FindControlRecursive(controlToSearch, controlID);
                if (controlToReturn != null) return controlToReturn;
            }
            return null;
        }

        private ASPxGridView GetServerSideGridView(string clienSideGridView)
        {
            int index = clienSideGridView.Split('$').GetUpperBound(0);
            string gridName = clienSideGridView.Split('$')[index];
            return (ASPxGridView)FindControlRecursive(this.Form, gridName);
        }

        protected void grdDailyJobs_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            var jobType = (JobType)Convert.ToInt32(e.GetValue("Job.JobType"));
            if (jobType == JobType.Manual && e.Row.Cells.Count> 1)
            {
                var scheduledStartExecutionDate = Convert.ToDateTime(e.GetValue("ScheduledStartExecutionDate"));
                e.Row.Cells[6].Text = scheduledStartExecutionDate.ToString("dd/MM/yyyy");
            }
        }

        protected void scheduleCounter_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            if (e.Parameter == "MESSAGES")
            {
                // Chequea los primeros 5
                notificationService.CheckAll(User.Identity.Name);
                
                e.Result = "NOTIFICATION|" + notificationService.GetAllNotifications(User.Identity.Name);
            }
            else
            {
                var executedToday = jobSchedulerService.GetJobTriggersByExecutionDay(DateTime.Now.Date).Where(x => x.JobTriggerStatus == JobTriggerStatus.Ejecutado).Count();
                var scheduledToday = jobSchedulerService.GetJobTriggersByExecutionDay(DateTime.Now.Date).Where(x => x.JobTriggerStatus == JobTriggerStatus.Agendado).Count();

                e.Result = scheduledToday + "|" + executedToday;
            }
        }

        protected void scheduleJob_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            int jobTriggerId = 0;

            //TODO: Agregar el job como un posible job para ejecución en el día actual. SIN AGENDA, o agendar si es Automático? VERIFICAR
            var currentGridSelected = e.Parameter.Split('|')[2];
            var currentGrid = GetServerSideGridView(currentGridSelected);
 
            var jobId = Convert.ToInt32(currentGrid.GetRowValues(Convert.ToInt32(e.Parameter.Split('|')[1]), "JobId"));

            try
            {
                var sqlJob = jobSchedulerService.GetJobById(jobId);
                    
                switch (e.Parameter.Split('|')[0])
                {
                    // PROCESO AGENDADO PREVIAMENTE. SE EJECUTA DESDE LA GRILLA DE EJECUCIÓN 
                    case "EXECUTESCHEDULEDMANUALPROCESS":
                        jobTriggerId = Convert.ToInt32(currentGrid.GetRowValues(Convert.ToInt32(e.Parameter.Split('|')[1]), "JobTriggerId"));
                        var sqlJobTrigger = jobSchedulerService.GetJobTriggerById(jobTriggerId);
                        if (sqlJobTrigger.JobTriggerStatus != JobTriggerStatus.Agendado)
                        {
                            e.Result = "ERRORPROCESSEXECUTED";
                            break;
                        }
                        jobSchedulerService.ExecuteManualJob(sqlJobTrigger);
                        e.Result = "PROCESSOK";
                        break;
                    // PROCESO MANUAL SIN AGENDAMIENTO PREVIO
                    case "EXECUTEMANUALPROCESS":
                        var sqlManualJobTrigger = new SqlJobTrigger
                                                {
                                                    CreatedBy = User.Identity.Name,
                                                    CreatedDate = DateTime.Now,
                                                    Enabled = true,
                                                    StartExecutionDate = DateTime.Now,
                                                    JobTriggerStatus = JobTriggerStatus.Ejecutando
                                                };

                        jobSchedulerService.ExecuteManualJob(sqlJob, sqlManualJobTrigger);
                        e.Result = "PROCESSOK";
                        break;
                    // PROCESO AUTOMATICO SIN AGENDAMIENTO PREVIO
                    case "EXECUTEAUTOMATICPROCESS":
                        var sqlNewJobTrigger = new SqlJobTrigger
                                                {
                                                    CreatedBy = User.Identity.Name,
                                                    CreatedDate = DateTime.Now,
                                                    Enabled = true,
                                                    ScheduledStartExecutionDate = DateTime.Now,
                                                    JobTriggerStatus = JobTriggerStatus.Ejecutando
                                                };

                        jobSchedulerService.AddTrigger(sqlJob, sqlNewJobTrigger);
                        e.Result = "PROCESSOK";
                        break;
                    default:
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
