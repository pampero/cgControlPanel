<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeBehind="JobDelete.aspx.cs" Inherits="CGControlPanel.JobDelete" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <style>
        /* css for timepicker */
        .ui-timepicker-div .ui-widget-header
        {
            margin-bottom: 8px;
        }
        .ui-timepicker-div dl
        {
            text-align: left;
        }
        .ui-timepicker-div dl dt
        {
            height: 25px;
            margin-bottom: -25px;
        }
        .ui-timepicker-div dl dd
        {
            margin: 0 10px 10px 65px;
        }
        .ui-timepicker-div td
        {
            font-size: 90%;
        }
        .ui-tpicker-grid-label
        {
            background: none;
            border: none;
            margin: 0;
            padding: 0;
        }
    </style>
    <script type="text/javascript" src="../js/plugins/jquery-ui-timepicker-addon.js"></script>
    <script type="text/javascript">

        function OnCallbackComplete(s, e) {

            HideLoadingPanel();

            switch (e.result) {
                case "DELETEDOK":
                    jAlert('El proceso ha sido eliminado correctamente', 'Atención', OnAlertCallBack);
                    break;
                default:
                    jAlert(e.result, 'Atención');
                    jQuery("#btnDelete").attr("disabled", false);
                    break;
            }
        }

        function OnAlertCallBack() {
            window.location.href = "/BackOffice/Jobs.aspx";
        }

        function OnCallBackConfirm(result) {
            if (result) {
                ShowLoadingPanel();

                aspxCallBack.PerformCallback('DELETE');
            }
            else {

                jQuery("#btnDelete").attr("disabled", false);
            }
        }

        function OnCallbackError(s, e) {
            HideLoadingPanel();
            jQuery("#btnDelete").attr("disabled", false);
        };

        function OnClick() {

            jQuery("#btnDelete").attr("disabled", true);
            jConfirm('Está seguro de eliminar el proceso?', 'Confirmación', OnCallBackConfirm);
        }


        jQuery(document).ready(function () {

            jQuery('#MainContent_dtAutomaticProcessTime').timepicker({});
        });

    </script>
    <div class="pageheader notab">
        <h1 class="pagetitle">
            Eliminar Proceso</h1>
        <span class="pagedesc">Configure los datos del proceso</span>
    </div>
    <form id="Form" name="Form" runat="server" class="stdform stdform2">
    <div class="stdform stdform2">
        <div id="contentwrapper" class="contentwrapper">
            <div id="basicform" class="subcontent">
            <p>
                <label>
                    Grupo</label>
                <span class="field">
                    <input runat="server" id="txtGroup" maxlength="50" type="text" name="txtGroup" class="longinput" />
                </span>
            </p>
            <p>
                <label>
                    Nombre</label>
                <span class="field">
                    <input runat="server" id="txtName" maxlength="50" type="text" name="txtName" class="longinput" />
                </span>
            </p>
            <p>
                <label>
                    Descripción</label>
                <span class="field">
                    <textarea cols="80" runat="server" rows="5" name="txtDescription" id="txtDescription"
                        class="longinput" />
                </span>
            </p>
            <p>
                <label>
                    Comentarios</label>
                <span class="field">
                    <textarea cols="80" runat="server" rows="5" name="txtComments" id="txtComments" class="longinput" />
                </span>
            </p>
            <p>
                <label>
                    Tipo de Agendamiento</label>
                <span class="field">
                    <select runat="server" name="cmbJobType" id="cmbJobType" disabled="True">
                        <option value="1">Manual</option>
                        <option value="2">Automático</option>
                    </select>
                </span>
            </p>
            <p>
                <label>
                    Proceso Padre</label>
                <span class="field">
                    <select runat="server" name="cmbRelatedProcess" id="cmbRelatedProcess" />
                </span>
            </p>
              <p>
                <label>
                    Días</label>
                <span class="field">
                    <input runat="server" type="checkbox" name="chkSunday" id="chkSunday" />Domingo<br />
                    <input runat="server" type="checkbox" name="chkMonday" id="chkMonday" />Lunes<br />
                    <input runat="server" type="checkbox" name="chkTuesday" id="chkTuesday" />Martes<br />
                    <input runat="server" type="checkbox" name="chkWednesday" id="chkWednesday" />Miércoles<br />
                    <input runat="server" type="checkbox" name="chkThursday" id="chkThursday" />Jueves<br />
                    <input runat="server" type="checkbox" name="chkFriday" id="chkFriday" />Viernes<br />
                    <input runat="server" type="checkbox" name="chkSaturday" id="chkSaturday" />Sábado
                </span>
            </p>
            <p runat="server" id="lblAutomaticProcessTime">
                <label>
                    Hora Ejecución</label>
                 <span class="field">
                        <input runat="server" id="dtAutomaticProcessTime" name="dtAutomaticProcessTime" maxlength="5" class="smallinput" />
                    </span>
            </p>
            <p runat="server" id="lblInputSchemaProcedure">
                <label>
                    Proceso Configuración</label>
                <span class="field">
                    <input runat="server" id="txtInputSchemaProcedure" maxlength="50" type="text" name="txtInputSchemaProcedure"
                        class="longinput" />
                </span>
            </p>
            <p>
                <label>
                    Datos Fijos</label>
                <span class="field">
                    <textarea cols="80" runat="server" rows="5" name="txtComments" id="Textarea1" class="longinput" />
                </span>
            </p>
            <p>
                <label>
                    Servidor</label>
                <span class="field">
                    <input runat="server" id="txtProcedureServerName" maxlength="50" type="text" name="txtProcedureServerName"
                        class="smallinput" />
                </span>
            </p>
            <p>
                <label>
                    Base de Datos</label>
                <span class="field">
                    <input runat="server" id="txtProcedureDataBaseName" maxlength="50" type="text"
                        name="txtProcedureDataBaseName" class="smallinput" />
                </span>
            </p>
            <p>
                <label>
                    Usuario</label>
                <span class="field">
                    <input runat="server" id="txtProcedureUserName" maxlength="50" type="text" name="txtProcedureUserName"
                        class="smallinput" />
                </span>
            </p>
            <p>
                <label>
                    Procedimiento a Ejecutar</label>
                <span class="field">
                    <input runat="server" id="txtExecProcedure" maxlength="50" type="text" name="txtExecProcedure"
                        class="smallinput" />
                </span>
            </p>
             <p>
                <label>
                    Es General</label>
                <span class="field">
                    <input type="checkbox" runat="server" id="chkGeneral" name="chkGeneral" />
                </span>
            </p>
            <p>
                <label>
                    Es Favorito</label>
                <span class="field">
                    <input type="checkbox" runat="server" id="chkFavorite" name="chkFavorite"  />
                </span>
            </p>
            <p>
                <label>
                    Procesos Pendientes de Ejecución
                </label>
                <span class="field">
                    <asp:Label runat="server" ID="lblCanDelete" />
                </span>
            </p>
            <p class="par stdformbutton">
                <span id="lp" style="display: none"><small>Procesando&hellip; </small>
                    <img src="/Styles/Images/loader2.gif" alt="loading" style="vertical-align: middle" />
                </span>
                <button type="button" id="btnDelete" class="stdbtn btn_red" onclick="return OnClick();">
                    Eliminar</button>
                <button type="button" class="stdbtn btn_black" onclick="window.location.href='/BackOffice/Jobs.aspx';">
                    Cancelar</button>
            </p>
        </div>
        <!--subcontent-->
    </div>
    <!--contentwrapper-->
    <asp:HiddenField runat="server" ID="hdnJobId" />
    <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
        OnCallback="aspxCallback_Callback">
        <clientsideevents callbackcomplete="OnCallbackComplete" callbackerror="OnCallbackError"></clientsideevents>
    </dxc:ASPxCallback>
    </div>

    </form>
</asp:Content>
