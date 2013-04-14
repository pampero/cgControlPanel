using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxGridView;
using Model;
using CG.Services.interfaces;

namespace CGControlPanel.Reports
{
    /// <summary>
    /// FALTA:
    ///     1.  Ocultar y mostrar la hora cuando es automático diario
    /// </summary>
    public partial class DailyJobsInfo : System.Web.UI.Page
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected void FillReport(DateTime dateTime)
        {
            ltrlDate.Text = dateTime.ToString("dd/MM/yyyy");
            ltrlUser.Text = User.Identity.Name;

            var scheduledJobTriggers = jobSchedulerService.GetSqlJobTriggersByExecutionDay(dateTime, JobTriggerStatus.Agendado);
            var errorJobTriggers = jobSchedulerService.GetSqlJobTriggersByExecutionDay(dateTime, JobTriggerStatus.Error);
            var executedJobTriggers = jobSchedulerService.GetSqlJobTriggersByExecutionDay(dateTime, JobTriggerStatus.Ejecutado);

            grdExecutedJobsTrigger.DataSource = executedJobTriggers;
            grdExecutedJobsTrigger.DataBind();

            grdScheduledJobsTrigger.DataSource = scheduledJobTriggers;
            grdScheduledJobsTrigger.DataBind();

            if (errorJobTriggers.Count == 0)
                grdErrorJobsTrigger.Visible = false;

            grdErrorJobsTrigger.DataSource = errorJobTriggers;
            grdErrorJobsTrigger.DataBind();
        }

        protected void grdJobsTrigger_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "Job.Weekdays") return;
            Weekdays weekDays = new Weekdays {AllDays = Convert.ToByte(e.Value)};

            if (weekDays.AllDays == 0)
                e.DisplayText = "No Diario";
            else
                e.DisplayText = Utils.UI.Helper.BuildPopulateDaysLegend(weekDays);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var selectedDate = Convert.ToDateTime(Request.QueryString["selectedDate"], new CultureInfo("en-US"));

            FillReport(selectedDate);
         }
    }
}