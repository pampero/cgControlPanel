using System;
using System.Linq;
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
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            log.Error("Error");
            log.Info("Info");

            // TAB Grids
            grdFavorites.DataSource = jobSchedulerService.GetJobsByFavorites();
            grdFavorites.DataBind();
            
            grdAllJobs.DataSource = jobSchedulerService.GetJobsByGroupName("");
            grdAllJobs.DataBind();

            grdTodayJobs.DataSource = jobSchedulerService.GetJobsByDaily();
            grdTodayJobs.DataBind();
         
            // TODAY JOBS GRID
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


        protected void grdDailyJobs_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) 
        {
            var command = e.Parameters.Split('|')[0];
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
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate, JobType.Automatico);
                    break;
                case "SHOWMANUAL":
                    grdDailyJobs.DataSource = jobSchedulerService.GetJobTriggersByExecutionDay(selectedDate, JobType.Manual);
                    break;
            }
         
            grdDailyJobs.PageIndex = 0;
            grdDailyJobs.DataBind();
        }

        private Control FindControlRecursive(Control rootControl, string controlID)
        {
            if (rootControl.ID == controlID) return rootControl;

            foreach (Control controlToSearch in rootControl.Controls)
            {
                Control controlToReturn =
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

        protected void scheduleJob_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            //TODO: Agregar el job como un posible job para ejecución en el día actual. SIN AGENDA, o agendar si es automatico? VERIFICAR
            var currentGridSelected = e.Parameter.Split('|')[2];
            var currentGrid = GetServerSideGridView(currentGridSelected);
 
            // Favorito, Diario, General o ya agendado Manual (No tiene trigger asociado, se crea cuando se ejecuta manualmente)
            Int32 jobId = Convert.ToInt32(currentGrid.GetRowValues(Convert.ToInt32(e.Parameter.Split('|')[1]), "JobId"));

            // Si es 0 es un proceso automatico ya agendado para correr hoy, por lo que tiene trigger asociado.
            if (jobId == 0)
            {
                jobId = Convert.ToInt32(currentGrid.GetRowValues(Convert.ToInt32(e.Parameter.Split('|')[1]), "Job.JobId"));
            }
        }

    }
}
