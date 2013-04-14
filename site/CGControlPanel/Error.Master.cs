using System;
using System.Linq;
using System.Web.UI;
using CG.Services.interfaces;
using Model;
using System.Web;
using Services.Security.Interface;

namespace CGControlPanel
{
    public partial class ErrorMaster : MasterPage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }
        public IMembershipService membershipService { get; set; }
        public INotificationService notificationService { get; set; }


        protected void notificationCounter_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {    // Chequea los primeros 5
                notificationService.CheckAll(Page.User.Identity.Name);

                e.Result = "NOTIFICATION|" + notificationService.GetAllNotifications(Page.User.Identity.Name);
         }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsPostBack)
            {
                ltrlNotificationsCount.Text = notificationService.GetAllNotifications(Page.User.Identity.Name).ToString();

                var executedToday = jobSchedulerService.GetJobTriggersByExecutionDay(DateTime.Now.Date).Where(x => x.JobTriggerStatus == JobTriggerStatus.Ejecutado).Count();
                var scheduledToday = jobSchedulerService.GetJobTriggersByExecutionDay(DateTime.Now.Date).Where(x => x.JobTriggerStatus == JobTriggerStatus.Agendado).Count();
               
                ltrlScheduledJobs.Text = scheduledToday.ToString();
                ltrlExecutedJobs.Text = executedToday.ToString();
                ltrlUserName.Text = HttpContext.Current.User.Identity.Name;

                var membershipUser = membershipService.GetUser(HttpContext.Current.User.Identity.Name);
                ltrlMail.Text = membershipUser.Email;
            }
        }

    }
}
