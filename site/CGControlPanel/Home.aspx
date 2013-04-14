<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/MainHome.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="CGControlPanel.Home" %>

<asp:Content ID="phLeftMenu" runat="server" ContentPlaceHolderID="LeftMenu">    
    <dxe:ASPxCalendar ID="calendar" ClientInstanceName="calendar" ShowClearButton="false"
        TodayButtonText="Hoy" runat="server" Columns="1" Rows="1" EnableMultiSelect="false"
        ShowWeekNumbers="false" EnableYearNavigation="false">
        <clientsideevents selectionchanged="calendar_SelectionChanged" />
    </dxe:ASPxCalendar>
</asp:Content>
<asp:Content ID="phBodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="pageheader notab">
        <h1 class="pagetitle">
            Tablero de Control</h1>
        <span class="pagedesc">Agende sus Procesos Aquí</span>
    </div>
    
    <!--/pageheader-->
    <div id="contentwrapper" class="contentwrapper widgetpage">
        <div>
            <div style="width: 50%; float: left; height: 700px">
                <div id="procesos" class="widgetbox">
                    <div class="title">
                        <h3>
                            Procesos</h3>
                    </div>
                    <div class="widgetcontent">
                        <div id="tabs">
                            <ul>
                                <li><a href="#tabs-1">Favoritos</a></li>
                                <li><a href="#tabs-2">Diarios</a></li>
                                <li><a href="#tabs-3">Generales</a></li>
                            </ul>
                            <div id="tabs-1">
                                <div class="widgetcontent padding0 statement">
                                    <div class="dxg-grid-container">
                                        <dxg:ASPxGridView runat="server" ID="grdFavorites" OnCustomJSProperties="grdGeneric_CustomJSProperties"
                                            ClientInstanceName="grdFavorites" Width="100%" KeyFieldName="JobId">
                                            <columns>
                                                <dxg:GridViewDataColumn Width="20px" FieldName="JobId" Caption="ID" VisibleIndex="0" />
                                                <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                                <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                                <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                                <dxg:GridViewDataColumn FieldName="Description" Caption="Descripción" VisibleIndex="4" />
                                                <dxg:GridViewDataColumn FieldName="InputSchemaProcedure" Caption="InputSchemaProcedure" VisibleIndex="5">
                                                    <CellStyle CssClass="HideColumn" />
                                                    <HeaderStyle CssClass="HideColumn" />
                                                    <FilterCellStyle CssClass="HideColumn" />
                                                </dxg:GridViewDataColumn>
                                                <dxg:GridViewDataHyperLinkColumn CellStyle-HorizontalAlign="Center" Width="30px" Caption=" " FieldName="JobId" ReadOnly="True" VisibleIndex="5">
                                                    <PropertiesHyperLinkEdit ImageUrl="Styles/images/book_open.png" NavigateUrlFormatString="javascript:ShowJobDetailPopup('{0}');"
                                                        Text="Datos Proceso">
                                                    </PropertiesHyperLinkEdit>
                                                    <FilterCellStyle CssClass="HideColumn" />
                                                </dxg:GridViewDataHyperLinkColumn>
                                            </columns>
                                            <settingsbehavior allowselectbyrowclick="true" />
                                            <settings showfilterrow="True" />
                                            <settingspager alwaysshowpager="true" mode="ShowPager" pagesize="8"></settingspager>
                                            <clientsideevents contextmenu="grid_ContextMenu" rowclick="ClearFocusedRows" columnsorting="ClearRelatedJobs" />
                                        </dxg:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                            <div id="tabs-2">
                                <div class="widgetcontent padding0 statement">
                                    <div class="dxg-grid-container">
                                        <dxg:ASPxGridView runat="server" ID="grdTodayJobs" OnCustomJSProperties="grdGeneric_CustomJSProperties"
                                            ClientInstanceName="grdTodayJobs" Width="100%" KeyFieldName="JobId">
                                            <columns>
                                            <dxg:GridViewDataColumn Width="20px" FieldName="JobId" Caption="ID" VisibleIndex="0" />
                                            <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                            <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                            <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                            <dxg:GridViewDataColumn FieldName="Description" Caption="Descripción" VisibleIndex="4" />
                                            <dxg:GridViewDataColumn FieldName="InputSchemaProcedure" Caption="InputSchemaProcedure" VisibleIndex="5" >
                                                <CellStyle CssClass="HideColumn"></CellStyle>
                                                <HeaderStyle CssClass="HideColumn" />
                                                <FilterCellStyle CssClass="HideColumn" />
                                            </dxg:GridViewDataColumn>         
                                             <dxg:GridViewDataHyperLinkColumn Width="30px" CellStyle-HorizontalAlign="Center" Caption=" " FieldName="JobId" ReadOnly="True" VisibleIndex="5">
                                                <PropertiesHyperLinkEdit ImageUrl="Styles/images/book_open.png" NavigateUrlFormatString="javascript:ShowJobDetailPopup('{0}');"
                                                    Text="Datos Proceso">
                                                </PropertiesHyperLinkEdit>
                                                <FilterCellStyle CssClass="HideColumn" />
                                            </dxg:GridViewDataHyperLinkColumn>     
                                        </columns>
                                            <settings showfilterrow="True" />
                                            <settingspager alwaysshowpager="true" mode="ShowPager" pagesize="8"></settingspager>
                                            <settingsbehavior allowselectbyrowclick="true" />
                                            <clientsideevents contextmenu="grid_ContextMenu" rowclick="ClearFocusedRows" columnsorting="ClearRelatedJobs" />
                                        </dxg:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                            <div id="tabs-3">
                                <div class="widgetcontent padding0 statement">
                                    <div class="dxg-grid-container">
                                        <dxg:ASPxGridView runat="server" ID="grdAllJobs" Width="100%" KeyFieldName="JobId"
                                            OnCustomJSProperties="grdGeneric_CustomJSProperties" ClientInstanceName="grdAllJobs">
                                            <columns>
                                            <dxg:GridViewDataColumn Width="30px" FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                                            <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                            <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                            <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                            <dxg:GridViewDataColumn FieldName="Description" Caption="Descripción" VisibleIndex="4" />
                                            <dxg:GridViewDataColumn FieldName="InputSchemaProcedure" Caption="InputSchemaProcedure" VisibleIndex="5">
                                                <CellStyle CssClass="HideColumn" />
                                                <HeaderStyle CssClass="HideColumn" />
                                                <FilterCellStyle CssClass="HideColumn" />
                                            </dxg:GridViewDataColumn>       
                                             <dxg:GridViewDataHyperLinkColumn CellStyle-HorizontalAlign="Center" Width="30px" Caption=" " FieldName="JobId" ReadOnly="True" VisibleIndex="5">
                                                <PropertiesHyperLinkEdit ImageUrl="Styles/images/book_open.png" NavigateUrlFormatString="javascript:ShowJobDetailPopup('{0}');"
                                                    Text="Datos Proceso">
                                                </PropertiesHyperLinkEdit>
                                                <FilterCellStyle CssClass="HideColumn" />
                                            </dxg:GridViewDataHyperLinkColumn>
                                        </columns>
                                            <settings showfilterrow="True" />
                                            <settingspager pagesize="10" visible="true" />
                                            <settingsbehavior allowselectbyrowclick="true" />
                                            <settingspager alwaysshowpager="true" mode="ShowPager" pagesize="8"></settingspager>
                                            <clientsideevents contextmenu="grid_ContextMenu" rowclick="ClearFocusedRows" columnsorting="ClearRelatedJobs" />
                                        </dxg:ASPxGridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--/#tabs-->
                    </div>
                    <!--/widgetcontent-->
                </div>
                <!--/widgetbox-->
                <div id="procesos-relacionados" class="widgetbox">
                    <div class="title">
                        <h3>
                            Procesos Relacionados</h3>
                    </div>
                    <div class="widgetcontent padding0 statement">
                        <div class="dxg-grid-container">
                            <dxg:ASPxGridView runat="server" ID="grdRelatedJobs" ClientInstanceName="grdRelatedJobs"
                                Width="100%" KeyFieldName="JobId" OnCustomJSProperties="grdGeneric_CustomJSProperties"
                                OnCustomCallback="grdRelatedJobs_CustomCallback">
                                <columns>
                                    <dxg:GridViewDataColumn Width="20px" FieldName="JobId" Caption="ID" VisibleIndex="0" />
                                    <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="0" />
                                    <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="1" />
                                    <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="2" />
                                    <dxg:GridViewDataColumn FieldName="Description" Caption="Descripción" VisibleIndex="4" />
                                    <dxg:GridViewDataColumn FieldName="InputSchemaProcedure" Caption="InputSchemaProcedure" VisibleIndex="5" >
                                        <CellStyle CssClass="HideColumn"></CellStyle>
                                        <HeaderStyle CssClass="HideColumn" />
                                    </dxg:GridViewDataColumn>       
                                </columns>
                                <clientsideevents contextmenu="grid_ContextMenu" rowclick="ClearFocusedRows" />
                                <settingsbehavior allowselectbyrowclick="True" allowsort="false" />
                            </dxg:ASPxGridView>
                        </div>
                    </div>
                    <!--/widgetcontent-->
                </div>
                <!--/widgetbox-->
            </div>
            <!--/left column -->
            <div style="width: 50%; float: right;">
                <div class="widgetbox">
                    <div class="title">
                        <h3>
                            Agendados Hoy&nbsp;
                            <div id="radiobutton-container">
                                <dxe:ASPxRadioButton runat="server" ID="radTodos" ClientInstanceName="radTodos" Checked="true"
                                    GroupName="radFiltrar" Text="Todos" Layout="Flow">
                                    <clientsideevents checkedchanged="function(s, e) {
                                        if(s.GetChecked())   grdDailyJobs.PerformCallback('0|SHOWALL');
                                    }" />
                                </dxe:ASPxRadioButton>
                                <dxe:ASPxRadioButton runat="server" ID="radManual" ClientInstanceName="radManual"
                                    GroupName="radFiltrar" Text="Man" Layout="Flow">
                                    <clientsideevents checkedchanged="function(s, e) {
                                        if(s.GetChecked())   grdDailyJobs.PerformCallback('0|SHOWMANUAL');
                                    }" />
                                </dxe:ASPxRadioButton>                        
                                <dxe:ASPxRadioButton runat="server" ID="radAutomatico" ClientInstanceName="radAutomatico"
                                    GroupName="radFiltrar" Text="Aut" Layout="Flow">
                                    <clientsideevents checkedchanged="function(s, e) {
                                        if(s.GetChecked())   grdDailyJobs.PerformCallback('0|SHOWAUTOMATIC');
                                    }" />
                                </dxe:ASPxRadioButton>
                                <dxe:ASPxRadioButton runat="server" ID="radEjecutados" ClientInstanceName="radEjecutados"
                                    GroupName="radFiltrar" Text="Ejec" Layout="Flow">
                                    <clientsideevents checkedchanged="function(s, e) {
                                        if(s.GetChecked())   grdDailyJobs.PerformCallback('0|SHOWEXECUTED');
                                    }" />
                                </dxe:ASPxRadioButton>
                                <dxe:ASPxRadioButton runat="server" ID="radError" ClientInstanceName="radEjecutados"
                                    GroupName="radFiltrar" Text="Err" Layout="Flow">
                                    <clientsideevents checkedchanged="function(s, e) {
                                if(s.GetChecked())   grdDailyJobs.PerformCallback('0|SHOWERROR');
                            }" />
                                </dxe:ASPxRadioButton>
                                <dxe:ASPxRadioButton runat="server" ID="radPendientes" ClientInstanceName="radPendientes"
                                    GroupName="radFiltrar" Text="Agen" Layout="Flow">
                                    <clientsideevents checkedchanged="function(s, e) {
                                if(s.GetChecked())   grdDailyJobs.PerformCallback('0|SHOWPENDING');
                            }" />
                                </dxe:ASPxRadioButton>
                            </div>
                        </h3>
                    </div>
                    <div class="widgetcontent padding0 statement">
                        <div class="dxg-grid-container">
                            <dxg:ASPxGridView runat="server" ID="grdDailyJobs" ClientInstanceName="grdDailyJobs"
                                KeyFieldName="JobTriggerId" OnCustomJSProperties="grdGeneric_CustomJSProperties"
                                OnCustomCallback="grdDailyJobs_CustomCallback" OnHtmlRowPrepared="grdDailyJobs_HtmlRowPrepared" Width="100%">
                                <columns>
                                    <dxg:GridViewDataColumn Width="15px" Caption=" " FieldName="CreatedBy" VisibleIndex="0" >
                                        <DataItemTemplate>
                                            <dxe:ASPxImage runat="server" ToolTip='<%# Eval("JobTriggerStatus") %>' ID="imgTemplate" ImageUrl='<%#  "/Styles/images/" + Eval("JobTriggerStatus") + ".png" %>'>
                                            </dxe:ASPxImage>
                                            </DataItemTemplate>
                                    </dxg:GridViewDataColumn>
                                    <dxg:GridViewDataColumn Width="30px" FieldName="Job.JobId" Caption="ID Proceso" VisibleIndex="1" />
                                    <dxg:GridViewDataColumn Width="30px" FieldName="JobTriggerId" Caption="ID Trigger" VisibleIndex="2">
                                     <CellStyle CssClass="HideColumn"></CellStyle>
                                        <HeaderStyle CssClass="HideColumn" />
                                    </dxg:GridViewDataColumn>        
                                    <dxg:GridViewDataColumn FieldName="Job.Group" Caption="Grupo" VisibleIndex="3" />
                                    <dxg:GridViewDataColumn FieldName="Job.Name" Caption="Proceso" VisibleIndex="4" />
                                    <dxg:GridViewDataColumn FieldName="Job.JobType" Caption="Tipo" VisibleIndex="5" />
                                    <dxg:GridViewDataDateColumn FieldName="ScheduledStartExecutionDate" Caption="Agendado" VisibleIndex="6">
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                        </PropertiesDateEdit>
                                    </dxg:GridViewDataDateColumn >
                                    <dxg:GridViewDataDateColumn FieldName="StartExecutionDate" Caption="Inicio Ejecución" VisibleIndex="7" >
                                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                        </PropertiesDateEdit>
                                    </dxg:GridViewDataDateColumn >
                                    <dxg:GridViewDataDateColumn  FieldName="EndExecutionDate" Caption="Fin Ejecución" VisibleIndex="8">
                                      <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                        </PropertiesDateEdit>
                                    </dxg:GridViewDataDateColumn >
                                    <dxg:GridViewDataColumn FieldName="JobTriggerStatus" Caption="Status" VisibleIndex="9" />
                                    <dxg:GridViewDataHyperLinkColumn  Width="30px" CellStyle-HorizontalAlign="Center" Caption=" " ToolTip="Datos Agendamiento" FieldName="JobTriggerId" ReadOnly="True" VisibleIndex="10">
                                        <PropertiesHyperLinkEdit ImageUrl="Styles/images/cog_go.png" Text="Datos de Agendamiento" NavigateUrlFormatString="javascript:ShowJobTriggerDetailPopup('{0}');">
                                        </PropertiesHyperLinkEdit>
                                    </dxg:GridViewDataHyperLinkColumn>
                                    <dxg:GridViewDataColumn FieldName="Job.InputSchemaProcedure" Caption="InputSchemaProcedure" VisibleIndex="12" >
                                        <CellStyle CssClass="HideColumn"></CellStyle>
                                        <HeaderStyle CssClass="HideColumn" />
                                    </dxg:GridViewDataColumn>    
                                </columns>
                                <settingsbehavior allowselectbyrowclick="true" />
                                <settingspager alwaysshowpager="true" mode="ShowPager" pagesize="10"></settingspager>
                                <clientsideevents contextmenu="grid_ContextMenu" rowclick="ClearFocusedRows" columnsorting="ClearRelatedJobs" />
                            </dxg:ASPxGridView>
                            <div class="stdform stdform2">
                                <p class="stdformbutton">
                                    <input type="button" onclick="ExportToHTML();" value="Exportar a HTML" />                            
                                    <dxe:ASPxButton ID="btnXlsxExport" runat="server" Text="Exportar a XLSX" UseSubmitBehavior="False"
                                        OnClick="btnXlsxExport_Click" Native="true" CssClass="stdbtn" />   
                                    <dxe:ASPxButton ID="btnRefresh" runat="server" Text="Refrescar" AutoPostBack="false"
                                        UseSubmitBehavior="false" Native="true" CssClass="stdbtn">
                                        <clientsideevents click="function(s, e) { 
                                            radTodos.SetChecked(true);

                                            scheduleCounter.PerformCallback();
                                            grdDailyJobs.PerformCallback(grdDailyJobs.GetPageIndex() +'|SHOWALL'); }" />
                                    </dxe:ASPxButton>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <!--/widgetbox-->
            </div>
            <!--/right column -->
        </div>
    </div>
    <!--/contentwrapper-->
    <!-- Popups -->
    <dxg:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="grdDailyJobs" />

    <dxp:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup"
        ShowHeader="false" HeaderText="Información" AllowDragging="True" EnableAnimation="False"
        Modal="True" PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter">
        <contentcollection>
                        <dxp:PopupControlContentControl ID="PopupControlContentControl1"  runat="server">
                        </dxp:PopupControlContentControl>
                    </contentcollection>
        <clientsideevents closeup="function(s,e) { popup.SetContentUrl('about:blank'); }"
            endcallback="function(s,e) { popup.SetContentUrl('about:blank'); }" />
    </dxp:ASPxPopupControl>

    <dxc:ASPxCallback ID="scheduleCounter" ClientInstanceName="scheduleCounter" runat="server" OnCallback="scheduleCounter_Callback">
        <ClientSideEvents CallbackComplete="function(s,e)
        {
            var scheduled = e.result.split('|')[0];
            var executed = e.result.split('|')[1];

            if  (scheduled == 'NOTIFICATION')
            {
                jQuery('#notificationsLabel').text(executed);
            }
            else
            {
                jQuery('#scheduledLabel').text(scheduled);
                jQuery('#executedLabel').text(executed);
            }
        }" />

    </dxc:ASPxCallback>
            

    <dxc:ASPxCallback ID="scheduleJob" ClientInstanceName="scheduleJob" runat="server"
        OnCallback="scheduleJob_Callback">
        <ClientSideEvents CallbackComplete="function(s,e)
        {
            switch (e.result) {
                case 'PROCESSOK':
                    jAlert('Operación realizada Correctamente','Atención', OnRefreshAllCallBack);
                    break;
                case 'ERRORPROCESSEXECUTED':
                    jAlert('Sólo puede ejecutar procesos en estado Agendado','Atención', OnRefreshAllCallBack);
                default:
                    jAlert(e.result, 'Atención', OnRefreshAllCallBack);
                    break;
            }
        }" />
    </dxc:ASPxCallback>
    <dxm:ASPxPopupMenu ID="pmRowMenu" runat="server" AutoSeparators="RootOnly" ClientInstanceName="pmRowMenu">
        <items> 
            <dxm:MenuItem Text="Agendar" Name="SCHEDULEMANUALPROCESS"/>
            <dxm:MenuItem Text="Agendar" Name="SCHEDULEAUTOMATICPROCESS" /> 
            <dxm:MenuItem Text="Ejecutar" Name="EXECUTESCHEDULEDMANUALPROCESS" />
            <dxm:MenuItem Text="Ejecutar" Name="EXECUTEAUTOMATICPROCESS" /> 
            <dxm:MenuItem Text="Cambiar Fecha" Name="CambiarFecha" /> 
            <dxm:MenuItem Text="Ejecutar" Name="EXECUTEMANUALPROCESS" /> 
            <dxm:MenuItem Text="Procesos Relacionados" Name="SHOWRELATEDPROCESSES" /> 
        </items>
       <ClientSideEvents ItemClick="function(s, e) {

            var currentRow = currentGridSelected.GetRow(globalRowIndex);
            var jobId = currentGridSelected.cpJobId[globalRowIndex];
            var jobType = currentGridSelected.cpJobType[globalRowIndex];
            var jobTriggerId = currentGridSelected.cpJobTriggerId[globalRowIndex];
            var SPName = currentGridSelected.cpSPName[globalRowIndex];
            
            switch (e.item.name) {
                case 'SHOWRELATEDPROCESSES':                    
                        grdRelatedJobs.PerformCallback(jobId);
                    break;
                case 'EXECUTESCHEDULEDMANUALPROCESS':
                    var jobTriggerId = currentGridSelected.cpJobTriggerId[globalRowIndex];

                    if ((jobType == 'Manual') && (SPName.Trim() != ''))
                        ShowInputDialog(jobId, jobTriggerId);
                    else
                    {
                        globalName = e.item.name;
                        currentGridSelectedUniqueID = currentGridSelected.uniqueID;
                        jConfirm('Seguro desea ejecutar el Proceso Manual?', 'Atención', OnCallBackConfirmExecution);
                    }
                    break;
                case 'EXECUTEMANUALPROCESS':
                    if ((jobType == 'Manual') && (SPName.Trim() != ''))
                        ShowInputDialog(jobId, -1);
                    else
                    {
                        globalName = e.item.name;
                        currentGridSelectedUniqueID = currentGridSelected.uniqueID;
                        jConfirm('Seguro desea ejecutar el Proceso Manual?', 'Atención', OnCallBackConfirmExecution);
                    }
                    break;
                case 'SCHEDULEMANUALPROCESS':
                    if (jobType == 'Manual')
                        ShowScheduleDialog(jobId, 'Manual');
                    break;
                case 'SCHEDULEAUTOMATICPROCESS':
                    if (jobType == 'Automático')
                        ShowScheduleDialog(jobId, 'Automatic');
                    break;
                // EXECUTEAUTOMATICPROCESS
                default:
                    globalName = e.item.name;
                    currentGridSelectedUniqueID = currentGridSelected.uniqueID;
                    jConfirm('Seguro desea ejecutar el Proceso Automático?', 'Atención', OnCallBackConfirmExecution);
                    break;
            }
         }" />
    </dxm:ASPxPopupMenu>
    

</asp:Content>
<asp:Content ID="phHeadContent" runat="server" ContentPlaceHolderID="HeadContent">
     <script type="text/javascript">

         jQuery(function () {
             // Proxy created on the fly
             var chat = jQuery.connection.notification;

             // Declare a function on the chat hub so the server can invoke it
             chat.newNotification = function (message) {
                 OnRefreshAllCallBack();
             };

             // Start the connection
             jQuery.connection.hub.start();
         });
    </script>
    <script src="Scripts/ContextMenuFunctions.js" type="text/javascript"></script>
    <script type="text/javascript">

        jQuery(document).ready(function () {

            jQuery('.togglemenu').click();

            jQuery('#tabs').tabs();

            ///// SLIM SCROLL /////
            jQuery('#scroll1').slimscroll({
                color: '#666',
                size: '10px',
                width: 'auto',
                height: '175px'
            });
        });

        function OnCallBackConfirmExecution(result) {
            if (result) {
                scheduleJob.PerformCallback('' + globalName + '|' + globalRowIndex + '|' + currentGridSelectedUniqueID);
                scheduleCounter.PerformCallback();
            }
        }

        function ShowAlert() {
            jAlert('El proceso ha sido agendado correctamente', 'Atención', OnDialogCallBack);
        }

        function ShowKilled() {
            jAlert('El proceso ha sido cancelado correctamente', 'Atención', OnDialogCallBack);
        }

        function ShowDelete() {
            jAlert('El proceso ha sido eliminado correctamente', 'Atención', OnDialogCallBack);
        }

        function OnDialogCallBack() {
            ClosePopupAndRefreshDaily();
        }

        function OnRefreshAllCallBack() {
            radTodos.SetChecked(true);
            grdDailyJobs.PerformCallback(grdDailyJobs.GetPageIndex() + '|SHOWALL');
            scheduleCounter.PerformCallback();
        }

        var globalRowIndex;
        var globalName;
        var currentGridSelected;
        var isEnabledDateSelected = true;

        function ClearRelatedJobs(s, e) {
            grdRelatedJobs.PerformCallback('-1');
            s._selectAllRowsOnPage(false);
        }

        // En todo momento hay UNA SOLA FILA seleccionada
        function ClearFocusedRows(s, e) {

            currentGridSelected = s;

            switch (currentGridSelected.name) {
            case "MainContent_grdDailyJobs":
                grdRelatedJobs._selectAllRowsOnPage(false);
                grdFavorites._selectAllRowsOnPage(false);
                grdTodayJobs._selectAllRowsOnPage(false);
                grdAllJobs._selectAllRowsOnPage(false);
                break;
            case "MainContent_ASPxPageControl1_grdFavorites":
                grdRelatedJobs._selectAllRowsOnPage(false);
                grdTodayJobs._selectAllRowsOnPage(false);
                grdAllJobs._selectAllRowsOnPage(false);
                grdDailyJobs._selectAllRowsOnPage(false);
                grdRelatedJobs._selectAllRowsOnPage(false);
                break;
            case "MainContent_ASPxPageControl1_grdAllJobs":
                grdRelatedJobs._selectAllRowsOnPage(false);
                grdTodayJobs._selectAllRowsOnPage(false);
                grdFavorites._selectAllRowsOnPage(false);
                grdDailyJobs._selectAllRowsOnPage(false);
                grdRelatedJobs._selectAllRowsOnPage(false);
                break;
            case "MainContent_ASPxPageControl1_grdDailyJobs":
                grdRelatedJobs._selectAllRowsOnPage(false);
                grdTodayJobs._selectAllRowsOnPage(false);
                grdFavorites._selectAllRowsOnPage(false);
                grdAllJobs._selectAllRowsOnPage(false);
                grdRelatedJobs._selectAllRowsOnPage(false);
                break;
            case "MainContent_ASPxPageControl1_grdTodayJobs":
                grdRelatedJobs._selectAllRowsOnPage(false);
                grdDailyJobs._selectAllRowsOnPage(false);
                grdFavorites._selectAllRowsOnPage(false);
                grdAllJobs._selectAllRowsOnPage(false);
                grdRelatedJobs._selectAllRowsOnPage(false);
                break;
            case "MainContent_grdRelatedJobs":
                grdTodayJobs._selectAllRowsOnPage(false);
                grdDailyJobs._selectAllRowsOnPage(false);
                grdFavorites._selectAllRowsOnPage(false);
                grdAllJobs._selectAllRowsOnPage(false);
                break;
            }
        }

        function ExportToHTML() {
            
            window.open('Reports/DailyJobsInfo.aspx?selectedDate=' + formatDate(calendar.GetSelectedDate(), 'MM/dd/yyyy'));
        }
        
        function calendar_SelectionChanged(s, e) {
            
            var today = new Date();
            today.setDate(today.getDate() - 1);
            isEnabledDateSelected = (calendar.GetSelectedDate() >= today);

            e.processOnServer = false;
            radTodos.SetChecked(true);
            grdRelatedJobs.PerformCallback('-1');
            grdDailyJobs.PerformCallback(grdDailyJobs.GetPageIndex() + '|SHOWALL');
        }

        function RefreshGrdDailyJobs() {
            radTodos.SetChecked(true);
            grdDailyJobs.PerformCallback(grdDailyJobs.GetPageIndex() + '|SHOWALL');
            scheduleCounter.PerformCallback();
            jAlert('Operación realizada correctamente!', 'Atención');
        }
        
        function ClosePopup() {
            popup.Hide();
        }

        function ClosePopupAndRefreshDaily() {
            popup.Hide();
            grdDailyJobs.PerformCallback(grdDailyJobs.GetPageIndex() + '|SHOWALL');
            scheduleCounter.PerformCallback();
        }

        function ShowInputDialog(jobId, jobTriggerId) {

            popup.SetSize(800, 680);
            popup.SetContentUrl('/Dialogs/ManualJobInputDialog.aspx?jobid=' + jobId + "&jobTriggerId=" + jobTriggerId);
            popup.Show();
        }

        // Manual es solo día, Automático es día y hora de ejecución.
        function ShowScheduleDialog(jobId, jobType) {

            if (jobType == 'Manual')
                popup.SetSize(850, 300);
            else
                popup.SetSize(850, 350);

            popup.SetContentUrl('/Dialogs/ScheduleJobDialog.aspx?jobid=' + jobId + '&jobType=' + jobType);
            popup.Show();
        }

        function ShowJobTriggerDetailPopup(jobTriggerId) {
            popup.SetSize(900, 700);

            popup.SetContentUrl('/Dialogs/JobTriggerInfoDialog.aspx?jobTriggerId=' + jobTriggerId);
            popup.Show();
        }

        function ShowJobDetailPopup(jobId) {
            popup.SetSize(800, 600);

            popup.SetContentUrl('/Dialogs/JobInfoDialog.aspx?jobId=' + jobId);
            popup.Show();
        }
     
    </script>
</asp:Content>
