using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CG.Services.interfaces;

namespace CGControlPanel.BackOffice
{
    public partial class Jobs : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            grdJobs.DataSource = jobSchedulerService.GetJobs();
            grdJobs.PageIndex = 0;
            grdJobs.DataBind();
        }
    }
}