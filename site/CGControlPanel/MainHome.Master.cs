using System;
using System.Linq;
using System.Web.UI;
using CG.Services.interfaces;
using Model;
using System.Web;
using Services.Security.Interface;

namespace CGControlPanel
{
    public partial class MainHomeMaster : MasterPage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }
        public IMembershipService membershipService { get; set; }
        public INotificationService notificationService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.ClientScript.RegisterClientScriptInclude("Utilities", Page.ResolveUrl("~/Scripts/Utilities.js"));
            Page.ClientScript.RegisterClientScriptInclude("DateFunctions", Page.ResolveUrl("~/Scripts/DateFunctions.js"));
        }

        protected override void OnLoad(EventArgs e)
        {
            if (jobSchedulerService.Status() != SchedulerStatus.Iniciado)
            {
                Response.Redirect(@"\QuartzError.aspx");
            }

            base.OnLoad(e);

            if (!Page.IsPostBack)
            {
                ltrlNotificationsCount.Text = notificationService.GetAllNotifications(Page.User.Identity.Name).ToString();

                var executedToday = jobSchedulerService.GetJobTriggersByExecutionDay(DateTime.Now.Date).Where(x => x.JobTriggerStatus == JobTriggerStatus.Ejecutado).Count();
                var scheduledToday = jobSchedulerService.GetJobTriggersByExecutionDay(DateTime.Now.Date).Where(x => x.JobTriggerStatus == JobTriggerStatus.Agendado).Count();

                ltrlScheduledJobs.Text = scheduledToday.ToString();
                ltrlExecutedJobs.Text = executedToday.ToString();
                ltrlUserName.Text = HttpContext.Current.User.Identity.Name;
                ltrlUserNameUserData.Text = HttpContext.Current.User.Identity.Name;
                var membershipUser = membershipService.GetUser(HttpContext.Current.User.Identity.Name);
                ltrlMail.Text = membershipUser.Email;
            }
        }

    }
}
