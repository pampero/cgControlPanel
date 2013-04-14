using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Model;
using CG.Services.interfaces;

namespace CGControlPanel
{
    public partial class JobDelete : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            txtGroup.ReadOnly = true;
            txtName.ReadOnly = true;
            txtDescription.ReadOnly = true;
            cmbJobType.ReadOnly = true;
            chkFavorite.ReadOnly = true;
            txtInputSchemaServerName.ReadOnly = true;
            txtInputSchemaDataBaseName.ReadOnly = true;
            txtInputSchemaUserName.ReadOnly = true;
            txtInputSchemaPassword.ReadOnly = true;
            txtInputSchemaProcedure.ReadOnly = true;
        }

        protected void FillUI(SqlJob sqlJob)
        {
            hdnJobId.Value = sqlJob.JobId.ToString();
            txtGroup.Text = sqlJob.Group;
            txtName.Text = sqlJob.Name;
            txtDescription.Text = sqlJob.Description;
            cmbJobType.SelectedIndex = (int)sqlJob.JobType;
            chkFavorite.Value = sqlJob.IsFavorite;
            txtInputSchemaServerName.Text = sqlJob.ServerName;
            txtInputSchemaDataBaseName.Text = sqlJob.DatabaseName;
            txtInputSchemaUserName.Text = sqlJob.UserName;
            txtInputSchemaProcedure.Text = sqlJob.InputSchemaProcedure;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (String.IsNullOrEmpty(Request["JobId"]))
                {
                    return;
                }

                var sqlJob = jobSchedulerService.GetJobById(Convert.ToInt32(Request["JobId"]));
                var sqlJobTrigger = sqlJob.Triggers.SingleOrDefault(x => x.JobTriggerStatus == JobTriggerStatus.Agendado);
                
                FillUI((SqlJob)sqlJob);

                if (sqlJobTrigger == null)
                {
                    lblCanDelete.Text = "No puede borrar el proceso ya que tiene ejecuciones agendadas.";
                    btnDelete.Visible = false;
                    btnDelete.Text = "Volver";
                }

                IList<SqlJobTrigger> list= new List<SqlJobTrigger>();

                foreach (SqlJobTrigger sqlTempJobTrigger in sqlJob.Triggers.Where(x=>x.JobTriggerStatus == JobTriggerStatus.Agendado).OrderBy(x=>x.CreatedDate).ToList())
                {
                    list.Add(sqlTempJobTrigger);
                }

                // No tiene el Enabled=TRUE porque puede que no se haya creado el trigger aún en Quartz
                grdJobTriggers.DataSource = list;
                grdJobTriggers.DataBind();
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            SqlJob sqlJob = new SqlJob();
            System.Threading.Thread.Sleep(2000);
            try
            {
                // TODO: Validar que se pueda eliminar el proceso.
                switch (e.Parameter)
                {
                    case "DELETE":
                        try
                        {
                            jobSchedulerService.DeleteJob(sqlJob);
                            e.Result = "DELETEOK";
                            throw new Exception();
                        }
                        catch (Exception ex)
                        {
                            e.Result = "DELETENOOK";
                        }
                        
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                if (e.Parameter == "DELETE")
                {
                    throw new Exception("No se ha podido eliminar el proceso debido al siguiente error: " + ex.Message);
                }
            }
        }

    }
}