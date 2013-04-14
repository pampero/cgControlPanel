using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Model;
using CG.Services.interfaces;
using System.Drawing;

namespace CGControlPanel
{
    public partial class JobDelete : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            if (!User.IsInRole("Administrador"))
            {
                Response.Redirect(@"\Account\DeniedAccess.aspx");
            }

            base.OnInit(e);

            txtGroup.Disabled = true;
            txtName.Disabled = true;
            txtDescription.Disabled = true;
            cmbJobType.Disabled = true;
            cmbRelatedProcess.Disabled = true;
            chkGeneral.Disabled = true;
            chkFavorite.Disabled = true;
            txtComments.Disabled = true;
            txtProcedureServerName.Disabled = true;
            txtProcedureDataBaseName.Disabled = true;
            txtProcedureUserName.Disabled = true;
            txtInputSchemaProcedure.Disabled = true;
            dtAutomaticProcessTime.Disabled = true;
        }

        protected void FillUI(SqlJob sqlJob)
        {
            hdnJobId.Value = sqlJob.JobId.ToString();
            txtGroup.Value = sqlJob.Group;
           
            if (sqlJob.JobType == JobType.Manual)
            {
                lblInputSchemaProcedure.Visible = true;
                lblAutomaticProcessTime.Visible = false;
            }
            else
            {
                if (sqlJob.AutomaticProcessTime.HasValue)
                    dtAutomaticProcessTime.Value = sqlJob.AutomaticProcessTime.Value.TimeOfDay.Hours.ToString().PadLeft(2, '0') + ":" + sqlJob.AutomaticProcessTime.Value.TimeOfDay.Minutes.ToString().PadLeft(2, '0');
                lblInputSchemaProcedure.Visible = false;
            }

            txtName.Value = sqlJob.Name;
            txtDescription.Value = sqlJob.Description;
            txtComments.Value = sqlJob.Comments;
            chkGeneral.Checked =sqlJob.IsGeneral;
            cmbJobType.Value = sqlJob.JobTypeEnum.ToString();
            if (sqlJob.ParentJobId.HasValue && sqlJob.ParentJobId.Value == 0)
            {
                cmbRelatedProcess.Value = "Ninguno";
            }
            else
            {
                if (sqlJob.ParentJobId.HasValue)
                {
                    cmbRelatedProcess.Value = jobSchedulerService.GetJobById(sqlJob.ParentJobId.Value).Name;
                }
                else
                {
                    cmbRelatedProcess.Value = "Ninguno";
                }
            }
            chkFavorite.Checked = sqlJob.IsFavorite;
            txtProcedureServerName.Value = sqlJob.ServerName;
            txtProcedureDataBaseName.Value = sqlJob.DatabaseName;
            txtProcedureUserName.Value = sqlJob.UserName;
            txtInputSchemaProcedure.Value = sqlJob.InputSchemaProcedure;

            Weekdays weekdays = new Weekdays();
            weekdays.AllDays = Convert.ToByte(sqlJob.Weekdays);

            PopulateCheckBoxes(weekdays);
        }


        private void PopulateCheckBoxes(Weekdays weekdays)
        {
            chkSunday.Checked = weekdays.Sunday;
            chkMonday.Checked = weekdays.Monday;
            chkTuesday.Checked = weekdays.Tuesday;
            chkWednesday.Checked = weekdays.Wednesday;
            chkThursday.Checked = weekdays.Thursday;
            chkFriday.Checked = weekdays.Friday;
            chkSaturday.Checked = weekdays.Saturday;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cmbRelatedProcess.DataSource = jobSchedulerService.GetJobs();
                cmbRelatedProcess.DataTextField = "Name";
                cmbRelatedProcess.DataValueField = "JobId";
                cmbRelatedProcess.DataBind();
                cmbRelatedProcess.Items.Insert(0, "Ninguno");

                if (String.IsNullOrEmpty(Request["JobId"]))
                {
                    return;
                }

                var sqlJob = jobSchedulerService.GetJobById(Convert.ToInt32(Request["JobId"]));
                var sqlJobTrigger = sqlJob.Triggers.SingleOrDefault(x => x.JobTriggerStatus == JobTriggerStatus.Agendado);
                
                FillUI((SqlJob)sqlJob);

                if (sqlJobTrigger != null)
                {
                    lblCanDelete.Text = "Actualmente tiene procesos agendados. Verifique si es conveniente borrar el proceso.";
                    lblCanDelete.ForeColor = Color.Red;
                }
                else
                {
                    lblCanDelete.Text = "Actualmente no tiene procesos agendados.";
                }
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            var sqlJob = jobSchedulerService.GetJobById(Convert.ToInt32(Request["JobId"]));

            try
            {
                switch (e.Parameter)
                {
                    case "DELETE":
                        sqlJob.DeletedBy = User.Identity.Name;
                        jobSchedulerService.DeleteJob(sqlJob);
                        e.Result = "DELETEDOK";
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