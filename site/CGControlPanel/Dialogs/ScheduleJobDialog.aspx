<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MainDialog.master" AutoEventWireup="true"
    CodeBehind="ScheduleJobDialog.aspx.cs" Inherits="CGControlPanel.Dialogs.ScheduleJobDialog" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v12.1, Version=12.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxe" %>
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
    <script type="text/javascript" src="../js/plugins/i18n/jquery.ui.datepicker-es.js"></script>

    <div class="centercontent">
        <script type="text/javascript">

            function OnCallbackComplete(s, e) {

                HideLoadingPanel();

                switch (e.result) {
                    case "SCHEDULEDMANUALOK":
                        window.parent.ShowAlert();
                        break;
                    case "SCHEDULEDAUTOMATICOK":
                        jQuery('#alertButton').click();
                        window.parent.ClosePopupAndRefreshDaily();
                        break;
                    default:
                        jAlert(e.result);
                        jQuery("#MainContent_btnAccept").attr("disabled", false);
                        break;
                }
            }


            function OnCallbackError(s, e) {
                HideLoadingPanel();

                jQuery("#MainContent_btnAccept").attr("disabled", false);
            };


            jQuery(document).ready(function () {

                jQuery.validator.addMethod("time", function (value, element) {
                    return this.optional(element) || /^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$/i.test(value);
                }, "Ingrese hora");

                jQuery('#MainContent_dtDate').datepicker({});
                jQuery('#MainContent_dtTime').timepicker({});

                jQuery("#Form").validate({
                    rules: {
                        ctl00$MainContent$dtDate: {
                            
                            required: true
                        },
                        ctl00$MainContent$dtTime: {
                            time: true,
                            required: true
                        }
                    },
                    messages: {
                        ctl00$MainContent$dtDate: "Ingrese fecha",
                        ctl00$MainContent$dtTime: "Ingrese hora"
                    },
                    submitHandler: function (form) {
                        ShowLoadingPanel();

                        jQuery("#MainContent_btnAccept").attr("disabled", true);

                        if (jQuery("#MainContent_dtTime").val() != undefined)
                            aspxCallBack.PerformCallback('SCHEDULEAUTOMATIC');
                        else
                            aspxCallBack.PerformCallback('SCHEDULEMANUAL');
                    }
                });
            });

        </script>
        <form id="Form" name="Form" class="stdform stdform2" runat="server">
        <dxc:ASPxCallback runat="server" ID="aspxCallBack" ClientInstanceName="aspxCallBack"
            OnCallback="aspxCallback_Callback">
            <clientsideevents callbackcomplete="OnCallbackComplete" callbackerror="OnCallbackError"></clientsideevents>
        </dxc:ASPxCallback>
        <div class="pageheader notab">
            <h1 class="pagetitle">
                Agendado de Proceso
                <asp:Literal ID="ltrlProcessType" runat="server" /></h1>
            <span class="pagedesc">Ingrese los datos necesarios para adendar el proceso</span>
        </div>
        <!--pageheader-->
        <div id="contentwrapper" class="contentwrapper">
            <div id="basicform" class="subcontent">
                <p>
                    <label>
                        Proceso</label>
                    <span class="field">
                        <input runat="server" id="txtNombre" type="text" name="txtNombre" class="longinput" readonly="true" />
                    </span>
                </p>
                <p>
                    <label>
                        Fecha Ejecución</label>
                    <span class="field">
                        <input runat="server" id="dtDate" name="dtDate" maxlength="10" class="smallinput" />
                    </span>
                </p>
                <p id="divAutomaticProcess" runat="server">
                    <label>
                        Hora de ejecución del Proceso</label>
                    <span class="field">
                        <input runat="server" id="dtTime" name="dtTime" maxlength="5" class="smallinput" />
                    </span>
                </p>
                <div class="stdformbutton">
                    <span id="lp" style="display: none;"><small>Procesando&hellip; </small>
                        <img src="/Styles/Images/loader2.gif" alt="loading" style="vertical-align: middle" /></span>
                    <button type="button" id="btnCancel" class="stdbtn btn_black" onclick="window.parent.ClosePopup();"
                        style="float: right;">
                        Cerrar</button>
                    <button type="submit" id="btnAccept" class="stdbtn btn_blue">
                        Aceptar</button>
                </div>
            </div>
            <!--subcontent-->
        </div>
        <!--contentwrapper-->
        <asp:HiddenField runat="server" ID="hdnJobId" />
        <a href="" id="alertButton" class="HideColumn" >Basic Alert</a>
        </form>
    </div>
</asp:Content>
