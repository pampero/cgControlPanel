<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Dialog.master" AutoEventWireup="true"
    CodeBehind="ManualJobInputDialog.aspx.cs" Inherits="CGControlPanel.Dialogs.ManualJobInputDialog" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>

<%@ Register TagPrefix="dxuc" Namespace="DevExpress.Web.ASPxUploadControl" Assembly="DevExpress.Web.V12.1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript" src="../js/custom/formatXml.js"></script>
    <script type="text/javascript">

        function OnCallbackComplete(s, e) {

            HideLoadingPanel();

            switch (e.result) {
                case "MANUALJOBEXECUTED":
                    jAlert('Operación realizada Correctamente', 'Atención', OnAlertCallBack);
                    break;
                default:
                    jAlert(e.result, 'Atención');
            }

            jQuery("#btnAccept").attr("disabled", false);

        }

        function OnAlertCallBack() {
            window.parent.ClosePopupAndRefreshDaily();

        }


        function OnCallbackError(s, e) {

            HideLoadingPanel();
            jQuery("#btnAccept").attr("disabled", true);

        };


        function OnClick() {           
          var isFormValid = ASPxClientEdit.ValidateGroup("InputValidation");
            if (isFormValid) {
                ShowLoadingPanel();

                jQuery("#btnAccept").attr("disabled", true);

                if (jQuery("#MainContent_hdnJobTriggerId").val() == -2) {
                    aspxCallBack.PerformCallback('EXECUTECHECK');
                    return false;
                }
                // Si lo saca de la grilla de ejecución debe mandarle también el trigger, por lo que cuando abre este form debería pasarselo.
                if (jQuery("#MainContent_hdnJobTriggerId").val() != -1)
                    aspxCallBack.PerformCallback('EXECUTEMANUALJOBTRIGGER');
                else
                    aspxCallBack.PerformCallback('EXECUTEMANUALJOB');
            }
            return false;
        }
        
        function CheckDifference(dateFrom, dateTo) {
            var startDate = new Date();
            var endDate = new Date();
            startDate = dateFrom.GetDate();
            if (startDate != null) {
                endDate = dateTo.GetDate();
                if (endDate < startDate) {
                    return false;
                }
            }
            return true;
        }

        function Uploader_OnFileUploadComplete(args) {
            if (args.isValid) {
                OnAlertCallBack();                
            }            
        }

        function Uploader_OnUploadStart() {
            btnUpload.SetEnabled(false);
        }
        
//        function Uploader_OnFileUploadComplete(args) {            
//             if (args.isValid) {                
//               // aspxCallBack.PerformCallback('DOWNLOADFILE');
//            }            
//        }
        function Uploader_OnFilesUploadComplete(args) {
            //UpdateUploadButton();
            alert("dadsa");
        }
//        function UpdateUploadButton() {
//            btnUpload.SetEnabled(uploader.GetText(0) != "");
//        }
//        
    </script>
    <div class="pageheader notab">
        <h1 class="pagetitle" style="font-weight:bold">
            Formulario de Entrada de Datos</h1>
        <span class="pagedesc">Configure los parametros del proceso</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        <form id="Form1" class="stdform stdform2" runat="server">
        <!--pageheader-->
        <div class="stdform stdform2">
            <div id="basicform" class="subcontent">
                <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
                    OnCallback="aspxCallback_Callback">
                    <ClientSideEvents CallbackComplete="OnCallbackComplete" CallbackError="OnCallbackError">
                    </ClientSideEvents>
                </dxc:ASPxCallback>
                <asp:HiddenField runat="server" ID="hdnJobId" />
                <asp:HiddenField runat="server" ID="hdnJobTriggerId" /> 
                <asp:HiddenField runat="server" ID="hdnFilePath" />
                <asp:Table runat="server" CellSpacing="3" ID="tblControls" Width="100%" BorderWidth="0px">
                    <asp:TableRow>
                        <asp:TableHeaderCell Width="30%"></asp:TableHeaderCell>
                        <asp:TableHeaderCell Width="80%"></asp:TableHeaderCell>
                    </asp:TableRow>
                </asp:Table>

                 <p class="par stdformbutton">
                    <span id="lp" style="display: none"><small>Procesando&hellip; </small>
                        <img src="/Styles/Images/loader2.gif" alt="loading" style="vertical-align: middle" />
                    </span>                   
                    <dxuc:ASPxUploadControl ID="UpFile" runat="server" ClientInstanceName="uploader" Size="35" OnFileUploadComplete="uplImage_FileUploadComplete">                         
                    <ClientSideEvents FileUploadComplete="function(s, e) { Uploader_OnFileUploadComplete(e); }"></ClientSideEvents>
                    </dxuc:ASPxUploadControl>                    
                    <dxe:ASPxButton ID="btnUpload" runat="server" AutoPostBack="False" Text="Upload" ClientInstanceName="btnUpload" Width="100px">
                            <ClientSideEvents Click="function(s, e) { uploader.Upload(); }" />
                    </dxe:ASPxButton>                    
                    <button runat="server" id="btnAccept" class="stdbtn btn_blue" onclick="return OnClick()">
                        Aceptar</button>                                           
                     <%--<dxe:ASPxButton style="float: right; padding-right: 10px;" runat="server" ID="btnAccept"
                ClientInstanceName="btnAccept" Text="Aceptar" CausesValidation="False" AutoPostBack="False"
                UseSubmitBehavior="False">
                <clientsideevents click="OnClick"></clientsideevents>
            </dxe:ASPxButton>--%>
                    <button type="button" id="btnCancel" class="stdbtn btn_black"  onclick="window.parent.ClosePopup();">
                        Cancelar</button>
                </p>

            </div>
        </div>
        </form>
    </div>
    <!--contentwrapper-->
    
</asp:Content>
