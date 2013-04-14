using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using Services.Helpers;
using CG.Services.interfaces;
using Model;
using Utils.ADO;
using System.Configuration;

namespace CGControlPanel.Dialogs
{
    public partial class ManualJobInputDialog : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            var job = jobSchedulerService.GetJobById(Convert.ToInt32(Request["jobId"]));
            var xmlForm = jobSchedulerService.GetInputFormSchema(job);

            Utils.UI.Helper.CreateDynamicForm(tblControls, xmlForm);
            
            ASPxButton btnAccept = (ASPxButton)FindControl("btnAccept");
            btnAccept.Click += new EventHandler(aspxButton_Click);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void aspxButton_Click(object sender, EventArgs e)
        {
            string formValues = Utils.UI.Helper.GetFormValues(Request.Form);
        }
    }
}