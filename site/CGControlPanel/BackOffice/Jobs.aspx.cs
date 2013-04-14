using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CG.Services.interfaces;
using DevExpress.Web.ASPxGridView;
using Model;

namespace CGControlPanel.BackOffice
{
    public partial class Jobs : BasePage
    {
        public IJobSchedulerService jobSchedulerService { get; set; }

        protected override void OnInit(EventArgs e)
        {
            if (!User.IsInRole("Administrador"))
            {
                Response.Redirect(@"\Account\DeniedAccess.aspx");
            }

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            grdJobs.DataSource = jobSchedulerService.GetSqlJobs();
            grdJobs.PageIndex = 0;
            grdJobs.DataBind();
        }

        protected void grdJobs_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "Weekdays") return;
            Weekdays weekDays = new Weekdays();

            weekDays.AllDays = Convert.ToByte(e.Value);

            if (weekDays.AllDays == 0)
                e.DisplayText = "No Diario";
            else
                e.DisplayText = Utils.UI.Helper.BuildPopulateDaysLegend(weekDays);
        }

        public IList<string> NotFilterableColumnFieldNames {
            get { return new string[]{ "JobId" }; }
        }

        protected void grdJobs_AutoFilterCellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (NotFilterableColumnFieldNames.Contains(e.Column.FieldName))
            {
                e.Editor.Parent.Controls.Add(new LiteralControl("&nbsp;"));
                e.Editor.Parent.Controls.Remove(e.Editor);
            }
        }
    }
}