<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="UserDelete.aspx.cs"
    Inherits="CGControlPanel.BackOffice.UserDelete" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<script type="text/javascript">

    function OnCallbackComplete(s, e) {

        HideLoadingPanel();

        switch (e.result) {
            case "DELETEDOK":
                jAlert('El usuario ha sido eliminado correctamente', 'Atención', OnAlertCallBack);
                break;
            default:
                alert(e.result);
                jQuery("#MainContent_btnAccept").attr("disabled", false);
                return;
        }

        jQuery("#MainContent_btnAccept").attr("disabled", true);
    }

    function OnAlertCallBack() {
        window.location.href = "/BackOffice/Users.aspx";
    }

    function OnCallbackError(s, e) {

        HideLoadingPanel();
        jQuery("#MainContent_btnAccept").attr("disabled", true);
    };


    function OnCallBackConfirm(result) {
        if (result) {
            ShowLoadingPanel();

            jQuery("#MainContent_btnAccept").attr("disabled", true);
            aspxCallBack.PerformCallback('DELETE');
        }
    }

    function OnClick() {
        jConfirm('Está seguro de eliminar el usuario?', 'Confirmación', OnCallBackConfirm);
    }

    </script>
    <div class="pageheader notab">
        <h1 class="pagetitle">
            Eliminar Usuario</h1>
        <span class="pagedesc">Configure los datos del usuario</span>
    </div>
    
    <div id="contentwrapper" class="contentwrapper">
    
    <form id="Form" name="Form" runat="server" class="stdform stdform2">

    <div class="stdform stdform2">
            <div id="validation" class="subcontent">
                <!--contenttitle-->
                <p>
                    <label>
                        Usuario</label>
                    <span class="field">
                        <input runat="server" ID="txtUserName" maxlength="20" type="text" name="txtUserName" class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        EMail</label>
                    <span class="field">
                        <input runat="server" ID="txtEMail" maxlength="20" type="text" name="txtEMail" class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        Rol</label>
                    <span class="field">
                        <input runat="server" ID="txtRole" maxlength="20" type="text" name="txtRole" class="smallinput" />
                    </span>
                </p>
                <div class="par stdformbutton">
                    <span id="lp" style="display: none;"><small>Procesando&hellip; </small>
                        <img src="/Styles/Images/loader2.gif" alt="loading" style="vertical-align: middle" />
                    </span>
                    <button type="button" id="btnDelete" class="stdbtn btn_red" onclick="return OnClick();">Eliminar</button>
                    <button type="button" class="stdbtn btn_black" onclick="location.href='/BackOffice/Users.aspx';">Cancelar</button>
                </div>
            </div>
            <!--subcontent-->
        </div>
        <!--contentwrapper-->
        <asp:HiddenField runat="server" ID="hdnUserId" />
        <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
        OnCallback="aspxCallback_Callback">
        <clientsideevents callbackcomplete="OnCallbackComplete" callbackerror="OnCallbackError"></clientsideevents>
    </dxc:ASPxCallback>
    
    </form>
    </div>

        
</asp:Content>
