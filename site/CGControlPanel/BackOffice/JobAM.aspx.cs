using System;
using System.Globalization;
using Model;
using CG.Services.interfaces;
using System.Configuration;
using CG.Cryptography.Interface;

namespace CGControlPanel
{
    public partial class JobAM : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }
        public IEncryptionService encryptionService { get; set;}

        protected override void OnInit(EventArgs e)
        {
            if (!User.IsInRole("Administrador"))
            {
                Response.Redirect(@"\Account\AccessDeniedError.aspx");
            }

            base.OnInit(e);
        }

        protected void FillUI(SqlJob sqlJob)
        {
            txtGroup.Value = sqlJob.Group;
            txtName.Value = sqlJob.Name;
            txtDescription.Value = sqlJob.Description;

            if (sqlJob.ParentJobId.HasValue && sqlJob.ParentJobId.Value != 0)
            {
                cmbRelatedProcess.Value = jobSchedulerService.GetJobById(sqlJob.ParentJobId.Value).JobId.ToString();
            }

            if (sqlJob.ParentJobId.HasValue && sqlJob.ParentJobId.Value == 0)
            {
                cmbRelatedProcess.Value = "Ninguno";
            }

            cmbJobType.Value = sqlJob.JobTypeEnum.ToString();
            chkFavorite.Checked = sqlJob.IsFavorite;
            chkGeneral.Checked = sqlJob.IsGeneral;
            txtComments.Value = sqlJob.Comments;
            txtProcedureServerName.Value = sqlJob.ServerName;
            txtProcedureDataBaseName.Value = sqlJob.DatabaseName;
            
            if (sqlJob.JobType == JobType.Manual)
            {
                lblProcessTime.Visible = false;
            }
            else
            {
                if (sqlJob.AutomaticProcessTime.HasValue)
                    dtAutomaticProcessTime.Value = sqlJob.AutomaticProcessTime.Value.TimeOfDay.Hours.ToString().PadLeft(2, '0') + ":" + sqlJob.AutomaticProcessTime.Value.TimeOfDay.Minutes.ToString().PadLeft(2, '0');
                lblInputSchemaProcedure.Visible = false;
            }

            if (sqlJob.InputSchemaProcedure == null || sqlJob.InputSchemaProcedure.Trim() == "")
            {
                btnCheckInputDialog.Visible = false;
            }

            txtProcedureUserName.Value = sqlJob.UserName;
            txtInputSchemaProcedure.Value = sqlJob.InputSchemaProcedure;
            txtExecProcedure.Value = sqlJob.ExecProcedure;
            
            txtInputXmlFixedParameters.Value = sqlJob.InputXmlFixedParameters.Replace("<INPUTXMLFIXEDPARAMETERS>", "").Replace("</INPUTXMLFIXEDPARAMETERS>", "");
            
            Weekdays weekdays = new Weekdays();
            weekdays.AllDays = Convert.ToByte(sqlJob.Weekdays);
                
            PopulateCheckBoxes(weekdays);
        }

        protected void FillEntity(SqlJob sqlJob)
        {
            if (!String.IsNullOrEmpty(hdnJobId.Value))
                sqlJob.JobId = Convert.ToInt32(hdnJobId.Value);

            sqlJob.Group = txtGroup.Value;
            sqlJob.Name = txtName.Value;
            sqlJob.Description = txtDescription.Value;
            sqlJob.Comments = txtComments.Value;
            sqlJob.JobTypeEnum = Convert.ToInt32(cmbJobType.Value);
            sqlJob.IsFavorite = Convert.ToBoolean(chkFavorite.Checked);
            sqlJob.ServerName = txtProcedureServerName.Value;
            sqlJob.IsGeneral = chkGeneral.Checked;
            int parentJobId; 
            if (cmbRelatedProcess.Value != null && int.TryParse(cmbRelatedProcess.Value.ToString(), out parentJobId))
                sqlJob.ParentJobId = parentJobId;
            else
                sqlJob.ParentJobId = 0;
            sqlJob.DatabaseName = txtProcedureDataBaseName.Value;
            sqlJob.UserName = txtProcedureUserName.Value;
            
            if (sqlJob.JobType == JobType.Automático)
            {
                var time = DateTime.Parse(dtAutomaticProcessTime.Value,
                                          new CultureInfo("es-AR"),
                                          DateTimeStyles.NoCurrentDateDefault);
                sqlJob.AutomaticProcessTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                           time.Hour, time.Minute, time.Second);
            }
            
            sqlJob.InputSchemaProcedure = txtInputSchemaProcedure.Value;
            sqlJob.ExecProcedure = txtExecProcedure.Value;
            if (!string.IsNullOrEmpty(txtProcedurePassword.Value))
                sqlJob.Password = encryptionService.Encrypt(txtProcedurePassword.Value, encryptionService.EncryptionKey);

            sqlJob.InputXmlFixedParameters = "<INPUTXMLFIXEDPARAMETERS>" + Server.HtmlDecode(txtInputXmlFixedParameters.Value) + "</INPUTXMLFIXEDPARAMETERS>";
                
            sqlJob.Weekdays = GetCheckBoxesSelections().AllDays;
        }
    
        private Weekdays GetCheckBoxesSelections()
        {
            Weekdays weekdays = new Weekdays
                                    {
                                        Sunday = chkSunday.Checked,
                                        Monday = chkMonday.Checked,
                                        Tuesday = chkTuesday.Checked,
                                        Wednesday = chkWednesday.Checked,
                                        Thursday = chkThursday.Checked,
                                        Friday = chkFriday.Checked,
                                        Saturday = chkSaturday.Checked
                                    };
            return weekdays;
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

                if (!String.IsNullOrEmpty(Request["JobId"]))
                {
                    ltrlLegend.Text = "Modificación";
                    cmbJobType.Disabled = true;
                    var job = jobSchedulerService.GetJobById(Convert.ToInt32(Request["JobId"]));
                    hdnJobId.Value = job.JobId.ToString();
                    FillUI((SqlJob)job);
                }
                else
                {
                    ltrlLegend.Text = "Alta";
                    btnCheckInputDialog.Visible = false;
                    cmbJobType.SelectedIndex = 0;
                    cmbRelatedProcess.SelectedIndex = 0;
                }
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            SqlJob sqlJob = new SqlJob();

            try
            {
                System.Threading.Thread.Sleep(1000);

                switch (e.Parameter)
                {
                    case "NEW":
                        sqlJob.CreatedBy = User.Identity.Name;
                        sqlJob.CreatedDate = DateTime.Now;
                        FillEntity(sqlJob);
                        jobSchedulerService.AddJob(sqlJob);
                        e.Result = "NEWOK";
                        break;
                    case "UPDATE":
                        sqlJob = (SqlJob)jobSchedulerService.GetJobById(Convert.ToInt32(hdnJobId.Value));
                        FillEntity(sqlJob);
                        jobSchedulerService.UpdateJob(sqlJob);
                        e.Result = "UPDATEDOK";
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