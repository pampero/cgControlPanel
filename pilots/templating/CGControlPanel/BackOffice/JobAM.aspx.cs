using System;
using Model;
using CG.Services.interfaces;

namespace CGControlPanel
{
    public partial class JobAM : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected void FillUI(SqlJob sqlJob)
        {
            txtGroup.Text = sqlJob.Group;
            txtName.Text = sqlJob.Name;
            txtDescription.Text = sqlJob.Description;
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

        protected void FillEntity(SqlJob sqlJob)
        {
            if (!String.IsNullOrEmpty(hdnJobId.Value))
                sqlJob.JobId = Convert.ToInt32(hdnJobId.Value);

            sqlJob.Group = txtGroup.Text;
            sqlJob.Name = txtName.Text;
            sqlJob.Description = txtDescription.Text;
            sqlJob.JobType =(JobType)cmbJobType.SelectedIndex;
            sqlJob.IsFavorite = Convert.ToBoolean(chkFavorite.Value);
            sqlJob.IsDaily = Convert.ToBoolean(chkDaily.Value);
            sqlJob.ServerName = txtInputSchemaServerName.Text;
            sqlJob.DatabaseName =  txtInputSchemaDataBaseName.Text;
            sqlJob.UserName = txtInputSchemaUserName.Text;
            sqlJob.InputSchemaProcedure = txtInputSchemaProcedure.Text;
            sqlJob.ExecProcedure = txtExecProcedure.Text;
            sqlJob.FixedParametersProcedure = txtFixedParametersProcedure.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request["JobId"]))
                {
                 //   ltrlLegend.Text = "Modificación";
                    var job = jobSchedulerService.GetJobById(Convert.ToInt32(Request["JobId"]));

                    FillUI((SqlJob)job);
                }
                else
                {
                   // ltrlLegend.Text = "Alta";
                }
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            SqlJob sqlJob = new SqlJob();
            System.Threading.Thread.Sleep(2000);
            try
            {
                e.Result = "UPDATEDOK";
                
            }
            catch (Exception ex)
            {
                if (e.Parameter == "UPDATE")
                {
                    throw new Exception("No se ha podido actualizar el proceso debido al siguiente error: " + ex.Message);
                }

                if (e.Parameter == "NEW")
                {
                    throw new Exception("No se ha podido crear el proceso debido al siguiente error: " + ex.Message);
                }
            }
        }
    }
}