using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using CG.Services.interfaces;

namespace CGControlPanel
{
    public partial class JobInfo : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            txtGroup.ReadOnly = true;
            txtName.ReadOnly = true;
            txtDescription.ReadOnly = true;
            cmbJobType.ReadOnly = true;
            chkFavorite.ReadOnly = true;
            chkDaily.ReadOnly = true;
            txtInputSchemaServerName.ReadOnly = true;
            txtInputSchemaDataBaseName.ReadOnly = true;
            txtInputSchemaUserName.ReadOnly = true;
            txtInputSchemaProcedure.ReadOnly = true;
            txtExecProcedure.ReadOnly = true;
            txtFixedParametersProcedure.ReadOnly = true;
        }

        protected void FillUI(SqlJob sqlJob)
        {
            lblProcessOwner.Text = "Proceso creado por: " + sqlJob.CreatedBy;
            txtGroup.Text = sqlJob.Group;
            txtName.Text = sqlJob.Name;
            txtDescription.Text= sqlJob.Description;
            cmbJobType.SelectedIndex = (int)sqlJob.JobType;
            chkFavorite.Value = sqlJob.IsFavorite;
            chkDaily.Value = sqlJob.IsDaily;
            txtInputSchemaServerName.Text = sqlJob.ServerName;
            txtInputSchemaDataBaseName.Text = sqlJob.DatabaseName;
            txtInputSchemaUserName.Text = sqlJob.UserName;
            txtInputSchemaProcedure.Text = sqlJob.InputSchemaProcedure;
            txtExecProcedure.Text = sqlJob.ExecProcedure;
            txtFixedParametersProcedure.Text = sqlJob.FixedParametersProcedure;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request["JobId"]))
                {
                    var job = jobSchedulerService.GetJobById(Convert.ToInt32(Request["JobId"]));

                    FillUI((SqlJob)job);
                }
            }
        }
    }
}