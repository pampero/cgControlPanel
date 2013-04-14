  using System.Xml;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using Services.ControlRendering;
using Services.ControlRendering.Mappers;
using Services.Helpers;
using Model;
using System.IO;

namespace Utils.UI
{
    public static class Helper
    {
        public static string GetFormValues(NameValueCollection formCollection)
        {
            XmlDocument doc = new XmlDocument();
            string formValues = "<CDATAFORM>";

            //Load the the document with the last book node.
            XmlTextReader reader = new XmlTextReader(@"C:\cgcontrolpanel\site\CGControlPanel\App_Data\Dialog.xml");
            doc.Load(reader);

            foreach (XmlNode xmlNode in doc.ChildNodes.Item(1).ChildNodes)
            {
                var controlType = xmlNode.GetAttribute("CTIPO");

                if (controlType != "SEPARADOR")
                {
                    var formValue = RendereableControlFactory.GetControl(controlType).GetValue(formCollection, xmlNode);

                    if (!String.IsNullOrEmpty(formValue))
                        formValues += formValue;
                }
            }

            return formValues + "</CDATAFORM>"  ;
        }


        public static Table BuildASPTable(string xmlTable, Table tblResult)
        {
            XmlDocument doc = new XmlDocument();

            //Load the the document with the last book node.
            XmlTextReader reader = new XmlTextReader(@"C:\cgcontrolpanel\site\CGControlPanel\App_Data\Table.xml");
            doc.Load(reader);
            bool firstPass = true;


            foreach (XmlNode xmlNode in doc.ChildNodes.Item(1).ChildNodes)
            {
                if (firstPass)
                {
                    firstPass = false;
                    var tableHeaderRow = new TableHeaderRow();

                    foreach (XmlNode xmlCell in xmlNode.ChildNodes)
                    {
                        var tableHeaderCell = new TableHeaderCell();
                        tableHeaderCell.Text = xmlCell.InnerText;
                        tableHeaderRow.Cells.Add(tableHeaderCell);
                    }
                    tblResult.Rows.Add(tableHeaderRow);
                }
                else
                {
                    var tableRow = new TableRow();
                    foreach (XmlNode xmlCell in xmlNode.ChildNodes)
                    {
                        var tableCell = new TableCell();
                        tableCell.Text = xmlCell.InnerText;
                        tableRow.Cells.Add(tableCell);
                    }

                    tblResult.Rows.Add(tableRow);
                }
            }

            return tblResult;
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

                if (controlType != "SEPARADOR")
                {
                    IRendereable control = RendereableControlFactory.GetControl(controlType);

                    List<WebControl> webControls = control.RenderControl(xmlNode);

                    cellLabel.Controls.Add(webControls[0]);

                    bool firstPass = true;

                    foreach (var webControl in webControls)
                    {
                        if (firstPass)
                            firstPass = false;
                        else
                        {
                            cellControl.Controls.Add(webControl);
                            // TODO: Agregar un <BR>
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

            ASPxButton aspxButton = new ASPxButton();
            aspxButton.ID = "btnAccept";
            aspxButton.Text = "Aceptar";
            aspxButton.ValidationGroup = "InputValidation";
            TableRow tableRowInput = new TableRow();

            TableCell tableCell = new TableCell { HorizontalAlign = HorizontalAlign.Right };

            tableCell.Controls.Add(aspxButton);

            tableRowInput.Cells.Add(new TableCell());
            tableRowInput.Cells.Add(tableCell);
            tblControls.CellPadding = 3;
            tblControls.Rows.Add(tableRowInput);
        }
    }
}