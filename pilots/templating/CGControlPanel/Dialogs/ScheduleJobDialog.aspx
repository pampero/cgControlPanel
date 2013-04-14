<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScheduleJobDialog.aspx.cs" Inherits="CGControlPanel.Dialogs.ScheduleJobDialog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">

     function OnCallbackComplete(s, e) {

         var loadingPanel = document.getElementById("lp");
         loadingPanel.style.display = "none";
         switch (e.result) {
            case "SCHEDULEDMANUALOK":
                alert("Agendado Manual realizado Correctamete");
                break;
            case "SCHEDULEDAUTOMATICOK":
                alert("Agendado Automatico realizado Correctamete");
                break;
            default:
         }
        // TODO: Cerrar Form
     }

     function OnCallbackError(s, e) {
         var loadingPanel = document.getElementById("lp");
         loadingPanel.style.display = "none";
     };

     function OnClick() {
         var isFormValid = ASPxClientEdit.ValidateGroup("Accept");
         if (isFormValid) {
             var loadingPanel = document.getElementById("lp");
             loadingPanel.style.display = "";
             
             btnAccept.SetEnabled(false);
             
             aspxCallBack.PerformCallback('SCHEDULEAUTOMATIC');

             //aspxCallBack.PerformCallback('SCHEDULEMANUAL');

             // TODO: HACER PARA MANUAL
         }
     }
</script>

<body>
    <form id="form1" runat="server">
 
  <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack" OnCallback="aspxCallback_Callback">
        <ClientSideEvents CallbackComplete="OnCallbackComplete" CallbackError="OnCallbackError"></ClientSideEvents>
    </dxc:ASPxCallback>
      
    <div id="contentwrapper" class="contentwrapper">
        	
        	<div id="basicform" class="subcontent">

					<div class="contenttitle2">
                        <h3>Agendado de Proceso</h3>
                    </div><!--contenttitle-->

        <p>
        <label>Nombre del Proceso a Agendar</label>
        <dxe:ASPxTextBox runat="server" ClientInstanceName="txtNombre" ID="txtNombre" >
            <ValidationSettings ValidationGroup="Accept" />
        </dxe:ASPxTextBox>
        </p>
        <p>
        <label>Fecha en la que desea ejecutar el Proceso</label>
        <dxe:ASPxDateEdit runat="server" ClientInstanceName="dtDate" ID="dtDate">
            <ValidationSettings ValidationGroup="Accept" />
        </dxe:ASPxDateEdit>
        </p>
        <p>
        <label>Hora en la que desea ejecutar el Proceso</label>
        <dxe:ASPxTimeEdit runat="server" ClientInstanceName="dtTime" ID="dtTime">
            <ValidationSettings ValidationGroup="Accept" />
        </dxe:ASPxTimeEdit>
        </p>

        <p>
            <div id="lp" class="loadingPanel" style="display: none;">
                <img src="/Styles/Images/loader2.gif" alt="loading" style="float: left" />
                <div class="loadingTxt">
                    Loading&hellip;</div>
                <b class="clear"></b>
            </div>

            <dxc:ASPxCallback runat="server" ID="aspxCallBack1" ClientInstanceName="aspxCallBack" OnCallback="aspxCallback_Callback">
                <ClientSideEvents CallbackComplete="OnCallbackComplete" CallbackError="OnCallbackError"></ClientSideEvents>
            </dxc:ASPxCallback>
    
        </p>

            <asp:HiddenField runat="server" ID="hdnJobId" />
    
                    </div><!--subcontent-->
            
        </div><!--contentwrapper-->

        </form>
</body>
</html>
