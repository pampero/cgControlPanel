using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxUploadControl;
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

            try
            {
                var job = jobSchedulerService.GetJobById(Convert.ToInt32(Request["jobId"]));
                var xmlForm = jobSchedulerService.GetInputFormSchema(job);
                Utils.UI.Helper.CreateDynamicForm(tblControls, xmlForm);
            }
            catch (Exception ex)
            {
                Response.Write("ERROR DE CONFIGURACION:<br/>" + ex.Message);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsCallback)
            {
                if (Request["JobId"] == null)
                {
                    //TODO: Que muestre mensaje de fallo
                    return;
                }
                hdnJobId.Value = Request["JobId"];
                hdnJobTriggerId.Value = Request["JobTriggerId"];
                Session["JobId"] = Request["JobId"];

                if (hdnJobTriggerId.Value == "-2")
                    btnAccept.InnerText = "Chequear";
            }
        }

        protected void aspxCallback_Callback(object sender, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
           
            try
            {
                var job = jobSchedulerService.GetJobById(Convert.ToInt32(hdnJobId.Value));
                string xmlForm;
                string formValues;
                SqlJobTrigger sqlJobTrigger;

                switch (e.Parameter)
                {
                    // TODO: VERIFICAR SI NO ES UN JOB YA AGENDADO POR LO QUE HAY QUE UTILIZAR EL METODO CON EL SQLJOBTRIGGER COMO ARGUMENTO.
                    case "EXECUTEMANUALJOBTRIGGER":
                        var jobTrigger = (SqlJobTrigger)jobSchedulerService.GetJobTriggerById(Convert.ToInt32(hdnJobTriggerId.Value));
                        xmlForm = jobSchedulerService.GetInputFormSchema(job);
                        formValues = Utils.UI.Helper.GetFormValues(xmlForm, Request.Form);
                        
                        // Al crear el trigger se lo debe inicializar obligatoriamente con los siguientes datos
                        // JobTriggerStatus = JobTriggerStatus.Agendado;
                        // CreatedBy = User.Identity.Name;
                        // ScheduledStartExecutionDate = DateTime.Now;
                        // CreatedDate = DateTime.Now;
                        // Opcional Enabled = true;
                        jobTrigger.InputFormXmlValues = formValues;
                        jobTrigger.CreatedDate = DateTime.Now;
                        jobTrigger.ScheduledStartExecutionDate = DateTime.Now;
                        jobTrigger.CreatedBy = User.Identity.Name;
                        jobTrigger.Enabled = true;
                        jobTrigger.JobTriggerStatus = JobTriggerStatus.Agendado;

                        // Actualizar el JobTrigger con los nuevos datos.
                        jobSchedulerService.ExecuteManualJob(jobTrigger);
                        e.Result = "MANUALJOBEXECUTED";
                        break;
                    case "EXECUTEMANUALJOB":
                        
                        xmlForm = jobSchedulerService.GetInputFormSchema(job);
                        formValues = Utils.UI.Helper.GetFormValues(xmlForm, Request.Form);
                        
                        // Al crear el trigger se lo debe inicializar obligatoriamente con los siguientes datos
                        // JobTriggerStatus = JobTriggerStatus.Agendado;
                        // CreatedBy = User.Identity.Name;
                        // ScheduledStartExecutionDate = DateTime.Now;
                        // CreatedDate = DateTime.Now;
                        // Opcional Enabled = true;
                        sqlJobTrigger = new SqlJobTrigger
                                        {
                                            InputFormXmlValues = formValues,
                                            CreatedDate = DateTime.Now,
                                            ScheduledStartExecutionDate = DateTime.Now,
                                            CreatedBy = User.Identity.Name,
                                            Enabled = true,
                                            JobTriggerStatus = JobTriggerStatus.Agendado
                                        };

                        jobSchedulerService.ExecuteManualJob(job, sqlJobTrigger);
                        e.Result = "MANUALJOBEXECUTED";
                        break;
                    case "EXECUTECHECK":
                        xmlForm = jobSchedulerService.GetInputFormSchema(job);
                        formValues = Utils.UI.Helper.GetFormValues(xmlForm, Request.Form);
                        e.Result = Utils.UI.Helper.FormatXml(formValues);
                        break;
                }
            }
            catch (Exception ex)
            {
                e.Result = "ERROR: " + ex.Message;
            }
        }

        protected void uplImage_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            var file = UpFile.UploadedFiles.First();
            if (file.FileName.Contains(".xls") && file.IsValid)
            {
                file.SaveAs((@"C:\Excel\Entrada\" + file.FileName));
                var job = jobSchedulerService.GetJobById(Convert.ToInt32(Request["jobId"]));
                var xmlForm = jobSchedulerService.GetInputFormSchema(job);
                var xml = new XmlDocument();
                xml.LoadXml(xmlForm);
                var formValues = Utils.UI.Helper.GetValuesFromExcelFile(@"C:\Excel\Entrada\" + file.FileName, xml);
                if (!string.IsNullOrEmpty(formValues))
                {
                    var sqlJobTrigger = new SqlJobTrigger
                                            {
                                                InputFormXmlValues = formValues,
                                                CreatedDate = DateTime.Now,
                                                ScheduledStartExecutionDate = DateTime.Now,
                                                CreatedBy = User.Identity.Name,
                                                Enabled = true,
                                                JobTriggerStatus = JobTriggerStatus.Agendado
                                            };
                    jobSchedulerService.ExecuteManualJob(job, sqlJobTrigger);
                    return;
                }
                e.IsValid = false;
                e.ErrorText = "Los datos del archivo no son correctos";
            }
            e.IsValid = false;
            e.ErrorText = "El formato de archivo no es correcto";    
        }
    }
 }