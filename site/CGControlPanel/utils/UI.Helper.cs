  using System.Data;
  using System.Web;
  using System.Xml;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
  using Excel;
  using Services.ControlRendering;
using Services.ControlRendering.Mappers;
using Services.Helpers;
using Model;
using System.IO;
using CG.Services.interfaces;
using System.Web.UI.HtmlControls;

namespace Utils.UI
{
    public static class Helper
    {
        public static string GetFormValues(string xmlForm, NameValueCollection formCollection)
        {
            XmlDocument doc = new XmlDocument();
            string formValues = "<CDATAFORM>";

            
            var xmlReader = XmlTextReader.Create(new StringReader(xmlForm));
            doc.Load(xmlReader);

            foreach (XmlNode xmlNode in doc.ChildNodes.Item(1).ChildNodes)
            {
                var controlType = xmlNode.GetAttribute("CTIPO");

                if (controlType != "SEPARADOR")
                {
                    var formValue = RendereableControlFactory.GetControl(controlType).GetValue("ctl00$MainContent$", formCollection, xmlNode);

                    if (!String.IsNullOrEmpty(formValue))
                        formValues += formValue;
                }
            }

            return formValues + "</CDATAFORM>"  ;
        }

        public static string GetValuesFromExcelFile(string filePath, XmlDocument xml)
        {
            var claves = new Dictionary<string, string>
                             {
                                 {"COMENTARIOS", "CCOMENTARIO"},
                                 {"PRODUCTO_A_PROCESAR", "CPRODUCTO"},
                                 {"PRODUCTOS_A_PROCESAR", "CPRODUCTOCHECK"},
                                 {"CONCEPTO_A_PROCESAR", "CCONCEPTO"},
                                 {"MONTO_MINIMO_DE_INTERES", "NMONTOMINIMO"},
                                 {"PERIODOS_A_PROCESAR", "NPERIODOS"},
                                 {"FECHA_DESDE", "DFECHADESDE"},
                                 {"FECHA_HASTA", "DFECHAHASTA"},
                                 {"HORA", "HORA"}
                             };


            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();
            var rows = result.Tables[0].Rows;

            XmlDocument doc = new XmlDocument();
            string formValues = "<CDATAFORM>";

            var validatedFields = new List<string>();

            for (var i = 0; i < rows.Count; i++)
            {
                var field = rows[i][0];
                var key = claves[field.ToString()];
                var value = rows[i][1];
                switch (key)
                {
                    case "CCOMENTARIO":
                        validatedFields.Add(key);
                        formValues += "<" + key + ">" + value + "</" + key + ">";
                        break;
                    case "CPRODUCTO":
                    case "CPRODUCTOCHECK":
                    //case "CCONCEPTO":
                    //    if (XmlHelper.GetValueFromKey(xml.ChildNodes.Item(1).ChildNodes, key, value.ToString()) != null)
                    //    {
                    //        formValues += "<" + key + ">" + value + "</" + key + ">";
                    //        validatedFields.Add(key);
                    //    }
                    //    else
                    //    {
                    //        return string.Empty;
                    //    }
                    //    break;
                    case "NMONTOMINIMO":
                    //case "NPERIODOS":
                    //    if (XmlHelper.IsRangeValid(xml.ChildNodes.Item(1).ChildNodes, key, value.ToString()) != null)
                    //    {

                    //        formValues += "<" + key + ">" + value + "</" + key + ">";
                    //        validatedFields.Add(key);
                    //    }
                    //    else
                    //    {
                    //        return string.Empty;
                    //    }
                    //    break;
                    case "DFECHADESDE":
                    case "DFECHAHASTA":
                    case "HORA":
                        DateTime date;
                        if (DateTime.TryParse(value.ToString(), out date))
                        {
                            formValues += "<" + key + ">" + value + "</" + key + ">";
                        }
                        else
                        {
                            return string.Empty;
                        }
                        break;
                }
            }

            return validatedFields.Count == 6 ? formValues + "</CDATAFORM>" : string.Empty;
        }

        public static void CreateDynamicForm(Table tblControls, string xmlForm)
        {
            XmlDocument doc = new XmlDocument();
            var xmlReader = XmlTextReader.Create(new StringReader(xmlForm));

            doc.Load(xmlReader);

            foreach (XmlNode xmlNode in doc.ChildNodes.Item(1).ChildNodes)
            {
                var controlType = xmlNode.GetAttribute("CTIPO");
                TableRow tableRow = new TableRow();
                TableCell cellLabel = new TableCell();
                TableCell cellControl = new TableCell();

                cellLabel.Attributes.Add("style", "vertical-align: middle");

                if (controlType != "SEPARADOR")
                {
                    var control = RendereableControlFactory.GetControl(controlType);
                    
                    List<WebControl> webControls = control.RenderControl(xmlNode);

                    cellLabel.Controls.Add(webControls[0]);

                    bool firstPass = true;

                    foreach (var webControl in webControls)
                    {
                        if (controlType == "TITULO")
                            webControl.Attributes.Add("style", "width:500px");
                        
                        if (firstPass)
                            firstPass = false;
                        else
                        {
                            cellControl.Controls.Add(webControl);
                        }
                    }
                }
                else
                {
                    Literal literal = new Literal();
                    literal.Text = "<HR>";
                    cellLabel.Controls.Add(literal);
                }

                if ((controlType == "TITULO") || (controlType == "SEPARADOR"))
                {
                    cellLabel.ColumnSpan = 2;
                    tableRow.Cells.Add(cellLabel);
                }
                else
                {
                    tableRow.Cells.Add(cellLabel);
                    tableRow.Cells.Add(cellControl);
                }

                tblControls.Rows.Add(tableRow);
            }
        }

        public static string BuildPopulateDaysLegend(Weekdays weekdays)
        {
            string legend = (weekdays.Sunday)? "Dom-": "";
            legend = (weekdays.Monday)? legend + "Lun-": legend;
            legend = (weekdays.Tuesday)? legend + "Mar-": legend;
            legend = (weekdays.Wednesday)? legend + "Mie-": legend;
            legend = (weekdays.Thursday)? legend + "Jue-": legend;
            legend = (weekdays.Friday)? legend + "Vie-": legend;
            legend = (weekdays.Saturday)? legend + "Sab": legend;
            
            if (legend.EndsWith("-"))
            {
                legend = legend.Remove(legend.Length - 1);
            }
            return  legend;
        }

        public static string BuildRecursiveErrorMessage(Exception exception)
        {
            string message = string.Empty;

            if (exception.InnerException != null)
            {
                message = exception.Message + "\r\n" + BuildRecursiveErrorMessage(exception.InnerException);
            }
            else
            {
                message = exception.Message;
            }

            return message;
        }

        public static string FormatXml(string transactionalXml)
        {
            transactionalXml = "<ROOT>" + transactionalXml + "</ROOT>";

            XmlDocument xmlDoc = new XmlDocument();
            Stream xmlStream;
            System.Xml.Xsl.XslCompiledTransform xsl = new System.Xml.Xsl.XslCompiledTransform();
            ASCIIEncoding enc = new ASCIIEncoding();
            StringWriter writer = new System.IO.StringWriter();

            // Get Xsl
            xsl.Load(HttpContext.Current.Server.MapPath(@"\css\defaultss.xslt"));

            // Remove the utf encoding as it causes problems with the XPathDocument
            transactionalXml = transactionalXml.Replace("utf-32", "");
            transactionalXml = transactionalXml.Replace("utf-16", "");
            transactionalXml = transactionalXml.Replace("utf-8", "");
            xmlDoc.LoadXml(transactionalXml);

            // Get the bytes
            xmlStream = new MemoryStream(enc.GetBytes(xmlDoc.OuterXml), true);

            // Load Xpath document
            System.Xml.XPath.XPathDocument xp = new System.Xml.XPath.XPathDocument(xmlStream);

            // Perform Transform
            xsl.Transform(xp, null, writer);
            return writer.ToString();
        }
    }
}