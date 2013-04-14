<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="UserAM.aspx.cs"
    Inherits="CGControlPanel.BackOffice.UserAM" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>

<asp:Content ID="phBodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="pageheader notab">
        <h1 class="pagetitle">
            <asp:Literal ID="ltrlLegend" runat="server"></asp:Literal>
            de Usuario</h1>
        <span class="pagedesc">Configure el usuario aquí</span>
    </div>
    <!--pageheader-->    
    <div id="contentwrapper" class="contentwrapper">

        <div class="notibar msginfo" style="display: none">
            <a class="close"></a>
            <p>
                This is an information message.</p>
        </div>
        <!-- notification msginfo -->
        <div id="divSuccess" class="notibar msgsuccess" style="display: none">
            <a class="close"></a>
            <p>
                Usuario modificado correctamente.</p>
        </div>
        <!-- notification msgsuccess -->
        <div class="notibar msgalert" style="display: none">
            <a class="close"></a>
            <p>
                No se modificó el procesos ya que tiene ejecuciones agendadas.</p>
        </div>
        <!-- notification msgalert -->
        <div class="notibar msgerror" style="display: none;">
            <a class="close"></a>
            <p>
                This is an error message.</p>
        </div>
        <!-- notification msgerror -->    

        <form id="Form" name="Form" runat="server" class="stdform stdform2">
        
        <div class="stdform stdform2">
            <div id="validation" class="subcontent">
                <p>
                    <label>
                        Usuario</label>
                    <span class="field">
                        <input runat="server" id="txtUserName" maxlength="30" type="text" name="txtUserName"
                            class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        Clave</label>
                    <span class="field">
                        <input runat="server" id="txtOldPassword" maxlength="20" type="password" name="txtOldPassword"
                            class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        Nueva Clave</label>
                    <span class="field">
                        <input runat="server" id="txtPassword" maxlength="20" type="password" name="txtPassword"
                            class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        EMail</label>
                    <span class="field">
                        <input runat="server" id="txtEMail" maxlength="50" type="text" name="txtEMail" class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        Rol</label>
                    <span class="field">
                        <select runat="server" name="cmbRoles" id="cmbRoles" />
                    </span>
                </p>
                <div class="par stdformbutton">
                    <span id="lp" style="display: none;"><small>Procesando&hellip; </small>
                        <img src="/Styles/Images/loader2.gif" alt="loading" style="vertical-align: middle" /></span>
                    <button type="button" id="btnReset" runat="server" class="stdbtn btn_red" onclick="return OnResetPassword();">
                        Resetear Clave</button>
                    <button type="submit" id="btnAccept" class="stdbtn btn_yellow">
                        Aceptar</button>
                    <button type="button" id="btnCancel" class="stdbtn btn_black" onclick="window.location.href='/BackOffice/Users.aspx';">
                        Cancelar</button>
                </div>
            </div>
        </div>
        
        <asp:HiddenField runat="server" ID="hdnUserId" />
        <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
            OnCallback="aspxCallback_Callback">
            <clientsideevents callbackcomplete="OnCallbackComplete" callbackerror="OnCallbackError"></clientsideevents>
        </dxc:ASPxCallback>
        
        </form>
        <!--subcontent-->
    </div>
    <!--contentwrapper-->
    
</asp:Content>
<asp:Content ID="phHeadContent" runat="server" ContentPlaceHolderID="HeadContent">
    
    <script type="text/javascript">

        function OnCallbackComplete(s, e) {

            HideLoadingPanel();

            switch (e.result) {
                case "UPDATEDOK":
                    jQuery("#divSuccess").css({ display: "block" });
                    jQuery("#btnCancel").html("Volver");
                    jQuery("#btnAccept").attr("disabled", false);
                    break;
                case "NEWOK":
                    jAlert('El usuario ha sido creado correctamente', 'Atención', OnAlertCallBack);
                    break;
                default:
                    jAlert(e.result, 'Atención');
                    jQuery("#btnAccept").attr("disabled", false);
                    break;
            }
        }

        function OnAlertCallBack() {
            window.location.href = "/BackOffice/Users.aspx";
        }

        function OnCallbackError(s, e) {

            HideLoadingPanel();
            jQuery("#btnAccept").attr("disabled", true);
        }

        function OnResetPassword() {

            ShowLoadingPanel();
            jQuery("#btnAccept").attr("disabled", true);
            aspxCallBack.PerformCallback('RESETPASSWORD');
        }

        jQuery(document).ready(function () {

            jQuery("#Form").validate({
                rules: {
                    ctl00$MainContent$txtEMail: {
                        required: true,
                        email: true
                    },
                    ctl00$MainContent$txtUserName: {
                        required: true
                    }
                },
                messages: {
                    ctl00$MainContent$txtEMail: "Ingrese correo válido",
                    ctl00$MainContent$txtUserName: "Ingrese nombre usuario"
                },
                submitHandler: function (form) {
                    ShowLoadingPanel();

                    jQuery("#btnAccept").attr("disabled", true);

                    if (jQuery("#MainContent_hdnUserId").val() == "")
                        aspxCallBack.PerformCallback('NEW');
                    else
                        aspxCallBack.PerformCallback('UPDATE');
                }
            });
        });

    </script>

</asp:Content>