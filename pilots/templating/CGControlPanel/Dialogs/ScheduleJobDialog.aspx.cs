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
    public partial class ScheduleJobDialog : System.Web.UI.Page
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            dtDate.MinDate = DateTime.Now;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["JobId"] == null)
                {
                    //TODO: Que muestre mensaje de fallo
                    return;
                }

                hdnJobId.Value = Request["JobId"];

                // Si es manual solo se debe agendar el día ya que es el usuario el que lo ejecuta cuando lo desea
                if (Request["JobType"].ToUpper() == "MANUAL")
                {
                    dtTime.Visible = false;
                }
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            var sqlJob = jobSchedulerService.GetJobById(Convert.ToInt32(hdnJobId.Value));

            try
            {
                // TODO: Validar
                switch (e.Parameter)
                {
                    case "SCHEDULEMANUAL":
                        // TODO: Analizar como se hace el agendamiento manual
                        e.Result = "SCHEDULEDMANUALOK";
                        break;
                    case "SCHEDULEAUTOMATIC":
                        var sqlJobTrigger = new SqlJobTrigger();
                        jobSchedulerService.AddTrigger(sqlJobTrigger);
                        e.Result = "SCHEDULEDAUTOMATICOK";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido agendar el proceso debido al siguiente error: " + ex.Message);
            }
        }
    }
}