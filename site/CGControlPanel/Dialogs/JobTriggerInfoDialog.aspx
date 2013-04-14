<%@ Page Title="" Language="C#" MasterPageFile="~/MainDialog.master" AutoEventWireup="true"
    CodeBehind="JobTriggerInfoDialog.aspx.cs" Inherits="CGControlPanel.Dialogs.JobTriggerInfoDialog" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="centercontent">
        <script type="text/javascript" src="../../js/custom/formatXml.js"></script>
        <script type="text/javascript">

            jQuery(document).ready(function () {

                jQuery('#scroll1').slimscroll({
                    color: '#666',
                    size: '10px',
                    width: 'auto',
                    height: '430px'
                });

                jQuery('#scroll2').slimscroll({
                    color: '#666',
                    size: '10px',
                    width: 'auto',
                    height: '430px'
                });

                jQuery('#tabs').tabs();
               
            });
           
            window.onload = function () {
                document.getElementById("MainContent_lnkPrint").onclick = OpenReport;
            }

            function OpenReport(e) {
	            if(!e) var e = window.event;
	            var url = this.href;
	            window.open(url, "popup_id", "menubar=1,scrollbars=1,resizable,width=900,height=800");
	
	            //e.cancelBubble is supported by IE - this will kill the bubbling process.
	            e.cancelBubble = true;
	            e.returnValue = false;

	            //e.stopPropagation works only in Firefox.
	            if (e.stopPropagation) {
		            e.stopPropagation();
		            e.preventDefault();
	            }
            }


            function OnCallbackComplete(s, e) {
                HideLoadingPanel();

                switch (e.result) {
                    case "DELETEDOK":
                        window.parent.ShowDelete();
                        break;
                    case "PROCESSKILLED":
                        window.parent.ShowKilled();
                        break;
                    default:
                        alert(e.result);
                }

                jQuery("#MainContent_btnAccept").attr("disabled", false);
                jQuery("#MainContent_btnKillProcess").attr("disabled", false);
            }

            function OnCallbackError(s, e) {
                HideLoadingPanel();
                jQuery("#MainContent_btnAccept").attr("disabled", false);
            };

            function OnClick() {

                ShowLoadingPanel();
                jQuery("#MainContent_btnAccept").attr("disabled", true);
                aspxCallBack.PerformCallback('DELETE');
            }

            function OnKillProcessClick() {

                if (confirm('Seguro desea eliminar la ejecución del Proceso?\r\nATENCION: Los datos pueden quedar en estado inconsistente.')) {

                    ShowLoadingPanel();
                    jQuery("#MainContent_btnKillProcess").attr("disabled", true);
                    aspxCallBack.PerformCallback('KILLPROCESS');
                }
            }

        </script>
        <form id="Form1" class="stdform stdform2" runat="server">
        <div class="pageheader notab">
            <h1 class="pagetitle">
                Resultado de ejecución del Proceso
                <asp:Literal ID="ltrlProcessType" runat="server" /></h1>
            <span class="pagedesc">Descripción detallada del resultado de ejecución</span>
        </div>
        <!--pageheader-->
        <div id="contentwrapper" class="contentwrapper">
            <div id="basicform" class="subcontent">
                <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
                    OnCallback="aspxCallback_Callback">
                    <clientsideevents callbackcomplete="OnCallbackComplete" callbackerror="OnCallbackError"></clientsideevents>
                </dxc:ASPxCallback>
                <div class="widgetcontent">
                    <div id="tabs">
                        <ul>
                            <li><a href="#tabs-1">Datos</a></li>
                            <li><a href="#tabs-2">Entrada</a></li>
                            <li><a runat="server" id="tabOutput" href="#tabs-3">Salida</a></li>
                        </ul>
                        <div id="tabs-1">
                            <div class="widgetcontent padding0 statement">
                                <div class="dxg-grid-container">
                                    <p>
                                        <asp:Label runat="server" CssClass="label" ID="lblProcessName" Text="Proceso:" />
                                    </p>
                                    <p>
                                        <asp:Label runat="server" CssClass="label" ID="lblDescription" />
                                    </p>
                                    <p>
                                        <asp:Label runat="server" CssClass="label" ID="lblComments" />
                                    </p>
                                    <p>
                                        <asp:Label runat="server" CssClass="label" ID="lblInputXmlFixedParameters" />
                                    </p>

                                    <br clear="all" />

                                    <div style="width: 50%; float: left" class="leftCol">
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblWeekDays" />
                                        </div>
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblServerName" />
                                        </div>
                                        <div class="par" runat="server" id="divInputSchemaProcedure">
                                            <asp:Label runat="server" CssClass="label" ID="lblInputSchemaProcedure" />
                                        </div>
                                    </div>

                                    <div style="width: 50%; float: right">
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblDataBaseName" />
                                        </div>
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblStoredProcedure" />
                                        </div>
                                          <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblProcessType" />
                                        </div>
                                        <div class="par" runat="server" id="divAutomaticProcessTime">
                                            <asp:Label runat="server" CssClass="label" ID="lblAutomaticProcessTime" />
                                        </div>
                                    </div>

                                    <br clear="all" />
                                    <br/>
                                    <div style="width: 50%; float: left" class="leftCol">
                                        <p>
                                            <asp:Label runat="server" CssClass="label" ID="lblProcessOwner" />
                                        </p>
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblTrigger" />
                                        </div>
                                      
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblJobTriggerStatus" />
                                        </div>
                                        
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblOutputStatus" Text="Estado de Salida:" />
                                        </div>
                                    </div>
                                    <div style="width: 50%; float: right">
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblRecords" />
                                        </div>
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblScheduledStartExecutionDate" />
                                        </div>
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblStartExecutionDate" />
                                        </div>
                                        <div class="par">
                                            <asp:Label runat="server" CssClass="label" ID="lblEndExecutionDate" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tabs-2">
                        <div class="widgetcontent padding0 statement">
                                <div class="widgetbox">
                                    <div class="widgetcontent">
                                        <div id="scroll1" class="mousescroll">
                                                <ul class="entrylist">
                                                        <li>
                                                        <div class="entry_wrap">
                                                            <div class="entry_content">
                                                                <h4><a href="#">Formulario de Entrada</a></h4>
                                                                <small>Datos fijos enviados al proceso (y variables en el caso MANUAL)</small>
                                                                <p></p>
                                                                <div><asp:Literal runat="server" ID="txtInputValues"></asp:Literal></div>
                                                            </div>
                                                        </div>
                                                        </li>
                                                        <li class="even">
                                                        <div class="entry_wrap">
                                                            <div class="entry_content">
                                                                <h4><a href="#">Datos Tabulados</a></h4>
                                                                <small>Tabla cargada desde el formulario de entrada (solo MANUAL)</small>
                                                                <p></p>
                                                                <div><asp:Label runat="server" style="display:none" ID="txtXmlInputTable"></asp:Label><a href="\Xls\Demo1.xlsx" class="localhref">Archivo Excel de entrada de datos tabulados</a></div>
                                                            </div>
                                                        </div>
                                                        </li>
                                                    </ul>                        
                                        </div><!--#scroll1-->
                                    </div><!--widgetcontent-->
                                </div>
                            </div>
                        </div>
                        <div id="tabs-3">
                            <div class="widgetcontent padding0 statement">
                                <div class="widgetbox">
                                    <div class="widgetcontent">
                                        <div id="scroll2" class="mousescroll">
                                                <ul class="entrylist">
                                                        <li>
                                                        <div class="entry_wrap">
                                                            <div class="entry_content">
                                                                <h4><a href="#">Datos Tabulados</a></h4>
                                                                <small>Tabla de salida como resultado del ingreso de tabla al proceso (solo MANUAL)</small>
                                                                <p></p>
                                                                <div><asp:Label runat="server" style="display:none" ID="txtXmlOutputTable"></asp:Label><a href="\Xls\Demo1.xlsx" class="localhref">Archivo Excel de resultado de ejecución de datos tabulados</a></div>
                                                            </div>
                                                        </div>
                                                        </li>
                                                        <li class="even">
                                                        <div class="entry_wrap">
                                                            <div class="entry_content">
                                                                <h4><a href="#">Resultado de la Ejecución</a></h4>
                                                                <small>Información sobre el resultado de la ejecución</small>
                                                                <p></p>
                                                                <div><asp:Label runat="server" ID="ltrlOutputResult"></asp:Label></div>
                                                            </div>
                                                        </div>
                                                        </li>
                                                        <li class="even">
                                                        <div class="entry_wrap">
                                                            <div class="entry_content">
                                                                <h4><a href="#">Log de Ejecución</a></h4>
                                                                <small>Datos recibidos luego de haber ejecutado completamente el proceso</small>
                                                                <p></p>
                                                                <div><asp:Label runat="server" ID="ltrlOuputExecutionLog"></asp:Label></div>
                                                            </div>
                                                        </div>
                                                        </li>
                                                        <li class="even">
                                                        <div class="entry_wrap">
                                                            <div class="entry_content">
                                                                <h4><a href="#">Trace de Ejecución</a></h4>
                                                                <small>Datos parciales recibidos desde el proceso</small>
                                                                <p></p>
                                                                <div><asp:Label runat="server" ID="ltrlOutputExecutionTrace"></asp:Label></div>
                                                            </div>
                                                        </div>
                                                        </li>
                                                    </ul>
                                        </div><!--#scroll2-->
                                    </div><!--widgetcontent-->
                                </div>
                        </div>
                    </div>
                </div>
                <div class="par stdformbutton">
                    <span id="lp" style="display: none"><small>Procesando&hellip; </small>
                        <img src="/Styles/Images/loader2.gif" alt="loading" style="vertical-align: middle" /></span>
                    <button type="button" id="btnCancel" class="stdbtn btn_black" onclick="window.parent.ClosePopup();"
                        style="float: right;">
                        Cerrar</button>
                    <button type="button" id="btnDelete" runat="server" visible="False" class="stdbtn btn_red"
                        onclick="return OnClick();">
                        Eliminar Agendamiento</button>
                    <button type="button" id="btnKillProcess" runat="server" visible="False" class="stdbtn btn_red"
                        onclick="return OnKillProcessClick();">
                        Eliminar Proceso</button>
                    <a runat="server" title="Imprimir" id="lnkPrint" class="smallButton" style="position: absolute; float: right; top: -67px; right: 3px; margin: 5px;" onclick="return OpenReport();">
                        <img src="/images/icons/blue-document-pdf-text.png" alt="">
                    </a>
                </div>
            </div>
        </div>
    </div>
    </form> 
    </div>
</asp:Content>
