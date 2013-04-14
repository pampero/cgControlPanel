<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeBehind="JobAM.aspx.cs" Inherits="CGControlPanel.JobAM" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>
<asp:Content ID="phBodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
    <div class="pageheader notab">
        <h1 class="pagetitle">
            <asp:Literal ID="ltrlLegend" runat="server"></asp:Literal>
            de Proceso</h1>
        <span class="pagedesc">Configure los datos del proceso</span>
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
                Proceso modificado correctamente.</p>
        </div>
        <!-- notification msgsuccess -->
        <div class="notibar msgalert" style="display: none">
            <a class="close"></a>
            <p>
                No se modificó el procesos ya que tiene ejecuciones agendadas.</p>
        </div>
        <!-- notification msgalert -->
        <div id="divError" class="notibar msgerror" style="display: none">
            <a class="close"></a>
            <p>
                Ha ocurrido un error al actualizar el proceso. Contácte al administrador.</p>
        </div>
        <form id="Form" name="Form" runat="server" class="stdform stdform2">
        <!-- notification msgerror -->
        <div class="stdform stdform2">
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
                        <input runat="server" id="txtDescription" maxlength="200" type="text" name="txtDescription"
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
                        <select runat="server" name="cmbJobType" id="cmbJobType" onchange="return cmbJobType_OnSelectedIndexChanged();">
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
                <p id="lblProcessTime" runat="server">
                    <label>
                        Hora Ejecución</label>
                    <span class="field">
                        <input runat="server" id="dtAutomaticProcessTime" name="dtAutomaticProcessTime" maxlength="5"
                            class="smallinput" />
                    </span>
                </p>
                <p id="lblInputSchemaProcedure" runat="server">
                    <label>
                        Proceso Configuración</label>
                    <span class="field">
                        <input runat="server" id="txtInputSchemaProcedure" maxlength="50" type="text" name="txtInputSchemaProcedure"
                            class="longinput" />
                        <button type="button" id="btnCheckInputDialog" runat="server" class="stdbtn btn_lime"
                            onclick="return ShowInputDialog();">
                            Validar</button>
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
                <p>
                    <label>
                        Datos Fijos</label>
                    <span class="field">
                        <textarea runat="server" cols="80" rows="5" name="txtInputXmlFixedParameters" id="txtInputXmlFixedParameters"
                            class="longinput" />
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
                        <input runat="server" id="txtProcedureDataBaseName" maxlength="50" type="text" name="txtProcedureDataBaseName"
                            class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        Usuario</label>
                    <span class="field">
                        <input runat="server" id="txtProcedureUserName" maxlength="15" type="text" name="txtProcedureUserName"
                            class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        Password</label>
                    <span class="field">
                        <input runat="server" id="txtProcedurePassword" maxlength="15" type="password" name="txtProcedurePassword"
                            class="smallinput" />
                    </span>
                </p>
                <p>
                    <label>
                        Procedimiento a Ejecutar</label>
                    <span class="field">
                        <input runat="server" type="text" name="txtExecProcedure" id="txtExecProcedure" class="smallinput"
                            maxlength="50" />
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
                        <input type="checkbox" runat="server" id="chkFavorite" name="chkFavorite" />
                    </span>
                </p>
                <p>
                    <label>
                        Plantilla Excel</label>
                    <span class="field">
                        <input type="file" id="file" name="file" />                    </span>
                </p>
                <p class="par stdformbutton">
                    <span id="lp" style="display: none"><small>Procesando&hellip; </small>
                        <img src="/Styles/Images/loader2.gif" alt="loading" style="vertical-align: middle" />
                    </span>
                    <button type="submit" id="btnAccept" class="stdbtn btn_yellow">
                        Aceptar</button>
                    <button type="button" id="btnCancel" class="stdbtn btn_black" onclick="window.location.href='/BackOffice/Jobs.aspx';">
                        Cancelar</button>
                </p>
            </div>
        </div>
        <!--contentwrapper-->
        <asp:HiddenField runat="server" ID="hdnJobId" />
        <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
            OnCallback="aspxCallback_Callback">
            <clientsideevents callbackcomplete="OnCallbackComplete" callbackerror="OnCallbackError">
        </clientsideevents>
        </dxc:ASPxCallback>
        <dxp:ASPxPopupControl ID="popup" runat="server" ClientInstanceName="popup" HeaderText="Información"
            AllowDragging="True" EnableAnimation="False" Modal="True" PopupVerticalAlign="WindowCenter"
            PopupHorizontalAlign="WindowCenter">
            <contentcollection>
            <dxp:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
            </dxp:PopupControlContentControl>
        </contentcollection>
            <clientsideevents closeup="function(s,e) { popup.SetContentUrl('about:blank'); }"
                endcallback="function(s,e) { popup.SetContentUrl('about:blank'); }" />
        </dxp:ASPxPopupControl>

        </form>
    </div>
</asp:Content>
<asp:Content ID="phHeadContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">

        function OnCallbackComplete(s, e) {

            HideLoadingPanel();

            switch (e.result) {
                case "UPDATEDOK":
                    jQuery("#divSuccess").css({ display: "block" });
                    jQuery("#btnCancel").html("Volver");
                    jQuery('html, body').animate({ scrollTop: 0 }, 'slow');
                    jQuery("#btnAccept").attr("disabled", false);
                    break;
                case "NEWOK":
                    jAlert('El proceso ha sido creado correctamente', 'Atención', OnAlertCallBack);
                    break;
                default:
                    jQuery("#divError").css({ display: "block" });
                    jQuery('html, body').animate({ scrollTop: 0 }, 'slow');
                    jQuery("#btnAccept").attr("disabled", false);
                    break;
            }
        }

        function OnCallbackError(s, e) {

            HideLoadingPanel();
            jQuery("#btnAccept").attr("disabled", false);
        };

        function OnAlertCallBack() {
            window.location.href = "/BackOffice/Jobs.aspx";
        }

        function cmbJobType_OnSelectedIndexChanged(s, e) {
            // Automático
            if (jQuery("#MainContent_cmbJobType").val() == "2") {
                jQuery("#MainContent_lblProcessTime").show();
                jQuery("#MainContent_lblInputSchemaProcedure").hide();
            } else {
                jQuery("#MainContent_lblProcessTime").hide();
                jQuery("#MainContent_lblInputSchemaProcedure").show();
            }
        }

        function ClosePopup()
        {
            popup.Hide();
        }

        function ShowInputDialog() {
            popup.SetSize(700, 580);
            popup.SetContentUrl('/Dialogs/ManualJobInputDialog.aspx?jobid=' + jQuery("#MainContent_hdnJobId").val() + "&jobTriggerId=-2");
            popup.Show();
        }

        function multiLineHtmlEncode(value) {
            var lines = value.split(/\r\n|\r|\n/);
            for (var i = 0; i < lines.length; i++) {
                lines[i] = htmlEncode(lines[i]);
            }
            return lines.join('\r\n');
        }

        function htmlEncode(value) {
            if (value) {
                return jQuery('<div/>').text(value).html();
            } else {
                return '';
            }
        }

        function htmlDecode(value) {
            return jQuery('<div/>').html(value).text();
        }

        jQuery(document).ready(function () {

            cmbJobType_OnSelectedIndexChanged(null, null);

            jQuery.validator.addMethod("time", function (value, element) {
                return this.optional(element) || /^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$/i.test(value);
            }, "Ingrese hora");

            jQuery('#MainContent_dtAutomaticProcessTime').timepicker({});

            jQuery("#MainContent_txtComments").charCount({
                allowed: 1000,
                warning: 800,
                counterText: 'Caracteres restantes: '
            });

            jQuery("#MainContent_txtInputXmlFixedParameters").charCount({
                allowed: 1000,
                warning: 900,
                counterText: 'Caracteres restantes: '
            });

            jQuery("#Form").validate({
                rules: {
                    ctl00$MainContent$txtGroup: {
                        required: true
                    },
                    ctl00$MainContent$txtName: {
                        required: true
                    },
                    ctl00$MainContent$txtProcedureServerName: {
                        required: true
                    },
                    ctl00$MainContent$txtProcedureDataBaseName: {
                        required: true
                    },
                    ctl00$MainContent$txtExecProcedure: {
                        required: true
                    },
                    ctl00$MainContent$txtComments: {
                        maxlength: 1000
                    },
                    ctl00$MainContent$txtInputXmlFixedParameters: {
                        maxlength: 3000
                    },
                    ctl00$MainContent$dtAutomaticProcessTime: {
                        time: true,
                        required: true
                    }
                },
                messages: {
                    ctl00$MainContent$txtGroup: "Ingrese grupo",
                    ctl00$MainContent$txtName: "Ingrese nombre",
                    ctl00$MainContent$txtProcedureServerName: "Ingrese servidor",
                    ctl00$MainContent$txtProcedureDataBaseName: "Ingrese base de datos",
                    ctl00$MainContent$txtExecProcedure: "Ingrese procedimiento",
                    ctl00$MainContent$txtComments: "Tamaño máximo de 1000 caracteres",
                    ctl00$MainContent$txtInputXmlFixedParameters: "Tamaño máximo de 255 caracteres",
                    ctl00$MainContent$dtAutomaticProcessTime: "Ingrese hora"
                },
                submitHandler: function (form) {
                    ShowLoadingPanel();
                    var original = jQuery("#MainContent_txtInputXmlFixedParameters").val()
                    var encodedHtml = multiLineHtmlEncode(original);
                    jQuery("#MainContent_txtInputXmlFixedParameters").val(encodedHtml);

                    jQuery("#btnAccept").attr("disabled", true);

                    if (jQuery("#MainContent_hdnJobId").val() == "")
                        aspxCallBack.PerformCallback('NEW');
                    else
                        aspxCallBack.PerformCallback('UPDATE');

                    jQuery("#MainContent_txtInputXmlFixedParameters").val(original);
                }
            });
        });
    </script>
</asp:Content>
