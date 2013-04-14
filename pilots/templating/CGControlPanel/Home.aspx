<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CGControlPanel.Home" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<script src="Scripts/ContextMenuFunctions.js" type="text/javascript"></script>
<script type="text/javascript">
    var globalRowIndex;
    var currentGridSelected;
    var justRelated = false; // TODO: ARREGLAR

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

    function calendar_SelectionChanged(s, e) {
         
        e.processOnServer = false;
        radTodos.SetChecked(true);
        grdDailyJobs.PerformCallback('SHOWALL');
    }

    function RefreshGrdDailyJobs() {
        radTodos.SetChecked(true);
        grdDailyJobs.PerformCallback('SHOWALL');
        alert('Operación realizada correctamente!');
    }

    function ShowManualDialog(jobId) {

        popup.SetContentUrl('/Dialogs/ManualJobInputDialog.aspx?jobid=' + jobId);
        popup.Show();
    }

    function ShowScheduleDialog(jobId) {
        popup.SetContentUrl('/Dialogs/ScheduleJobDialog.aspx?jobid=' + jobId);
        popup.Show();
    }

    function ShowJobDetailPopup(jobTriggerId) {
         
        popup.SetContentUrl('/BackOffice/JobTriggerInfo.aspx?jobid=' + jobTriggerId);
        popup.Show();

    }
    
    function DeleteTriggerPopup(jobTriggerId) {

        popup.SetContentUrl('/BackOffice/JobTriggerInfo.aspx?jobid=' + jobTriggerId + '&delete=1');
        popup.Show();
    }

  
 </script>
 
    <dxc:ASPxCallback ID="scheduleJob" ClientInstanceName="scheduleJob" runat="server" OnCallback="scheduleJob_Callback">
        <ClientSideEvents EndCallback="function(s,e)
        {
            alert('Operación realizada correctamente!');
                        
            radTodos.SetChecked(true);
            grdDailyJobs.PerformCallback('SHOWALL');
        }" />
    </dxc:ASPxCallback>

 
    <dxm:ASPxPopupMenu ID="pmRowMenu" runat="server" AutoSeparators=RootOnly ClientInstanceName="pmRowMenu">
        <Items>
            <dxm:MenuItem Text="Agendar" Name="SCHEDULEMANUALPROCESS" />
            <dxm:MenuItem Text="Agendar" Name="SCHEDULEAUTOMATICPROCESS" />
            <dxm:MenuItem Text="Ejecutar" Name="EXECUTESCHEDULEDMANUALPROCESS" />
            <dxm:MenuItem Text="Ejecutar" Name="EXECUTEAUTOMATICPROCESS" />
            <dxm:MenuItem Text="Cambiar Fecha" Name="CambiarFecha" />
            <dxm:MenuItem Text="Ejecutar" Name="EXECUTEMANUALPROCESS" />
            
            <dxm:MenuItem Text="Procesos Relacionados"  Name="SHOWRELATEDPROCESSES" />
        </Items>
        <ClientSideEvents ItemClick="function(s, e) {

            var currentRow = currentGridSelected.GetRow(globalRowIndex);

            switch (e.item.name) {
                case 'SHOWRELATEDPROCESSES':
                    grdRelatedJobs.PerformCallback(globalRowIndex);
                    break;
                case 'EXECUTESCHEDULEDMANUALPROCESS':
                    if (currentRow.cells[5].innerHTML == 'Manual')
                        ShowManualDialog(currentRow.cells[0].innerHTML);
                    break;
                case 'EXECUTEMANUALPROCESS':
                    if (currentRow.cells[3].innerHTML == 'Manual')
                        ShowManualDialog(currentRow.cells[0].innerHTML);
                    break;
                case 'SCHEDULEMANUALPROCESS':
                    if (currentRow.cells[3].innerHTML == 'Manual')
                        ShowScheduleDialog(currentRow.cells[0].innerHTML);
                    break;
                case 'SCHEDULEAUTOMATICPROCESS':
                    if (currentRow.cells[3].innerHTML == 'Automatico')
                        ShowScheduleDialog(currentRow.cells[0].innerHTML);
                    break;
                // EXECUTEAUTOMATICPROCESS
                default:
                    scheduleJob.PerformCallback('' + e.item.name + '|' + globalRowIndex + '|' + currentGridSelected.uniqueID);
                    break;
            }
         }" />
    </dxm:ASPxPopupMenu>
 
    <table >

        <tr>
            <td valign="top">
                <dxe:ASPxCalendar ID="calendar" ClientInstanceName="calendar" ShowClearButton="false" TodayButtonText="Hoy" runat="server" Columns="1" Rows="1" EnableMultiSelect="false">
                    <ClientSideEvents SelectionChanged="calendar_SelectionChanged" />
                </dxe:ASPxCalendar>
                <dxp:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup" Width="800px" Height="600px" PopupHorizontalAlign="OutsideRight" PopupVerticalAlign="Below"
                    HeaderText="Información" AllowDragging="True" EnableAnimation="True" Modal="True">
                    <ContentCollection>
                        <dxp:PopupControlContentControl ID="PopupControlContentControl1"  runat="server">
                        </dxp:PopupControlContentControl>
                    </ContentCollection>
                    <ClientSideEvents />
                </dxp:ASPxPopupControl>
            </td>
            <td valign="top">
                
                <dxt:ASPxPageControl ID="ASPxPageControl1" runat="server" Width="100%" Height="350px" TabAlign="Justify" ActiveTabIndex="0" EnableTabScrolling="true">
                <TabStyle Paddings-PaddingLeft="10px" Paddings-PaddingRight="10px"/>
                <ContentStyle>
                    <Paddings PaddingLeft="40px"/>
                </ContentStyle>
                <TabPages>
                    <dxt:TabPage Text="Favoritos">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl1" runat="server">
                               <dxg:ASPxGridView runat="server" ID="grdFavorites" ClientInstanceName="grdFavorites" Width="100%" KeyFieldName="JobId" >
                                    <Columns>
                                        <dxg:GridViewDataColumn Width="30px" FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                                        <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                        <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                        <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                        <dxg:GridViewDataColumn FieldName="ExecutionDays" Caption="Fecha Ejecución" VisibleIndex="4" />              
                                    </Columns>
                                    <SettingsBehavior AllowSelectByRowClick="true" />
                                    <SettingsPager AlwaysShowPager="true" Mode=ShowPager PageSize="8" ></SettingsPager>
                                    <ClientSideEvents ContextMenu="grid_ContextMenu" RowClick="ClearFocusedRows" ColumnSorting="ClearRelatedJobs" />
                                </dxg:ASPxGridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dxt:TabPage>
                    <dxt:TabPage Text="Diarios">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl2" runat="server">
                                 <dxg:ASPxGridView runat="server" ID="grdTodayJobs" ClientInstanceName="grdTodayJobs" Width="100%" KeyFieldName="JobId">
                                    <Columns>
                                        <dxg:GridViewDataColumn Width="30px" FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                                        <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                        <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                        <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                        <dxg:GridViewDataColumn FieldName="ExecutionDays" Caption="Fecha Ejecución" VisibleIndex="4" />
                                    </Columns>
                                    <SettingsPager AlwaysShowPager="true" Mode=ShowPager PageSize="8"></SettingsPager>
                                    <SettingsBehavior AllowSelectByRowClick="true" />
                                    <ClientSideEvents ContextMenu="grid_ContextMenu" RowClick="ClearFocusedRows" ColumnSorting="ClearRelatedJobs" />
                                </dxg:ASPxGridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dxt:TabPage>
                    <dxt:TabPage Text="Generales">
                        <ContentCollection>
                            <dx:ContentControl ID="ContentControl3" runat="server">      
                                 <dxg:ASPxGridView runat="server" ID="grdAllJobs" Width="100%" KeyFieldName="JobId" ClientInstanceName="grdAllJobs">
                                    <Columns>
                                        <dxg:GridViewDataColumn Width="30px" FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                                        <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                        <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                        <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                        <dxg:GridViewDataColumn FieldName="ExecutionDays" Caption="Fecha Ejecución" VisibleIndex="4" />
                                    </Columns>
                                    <SettingsPager PageSize="10" Visible="true" />
                                    <SettingsBehavior AllowSelectByRowClick="true" />
                                    <SettingsPager AlwaysShowPager="true" Mode=ShowPager PageSize="8"></SettingsPager>
                                    <Settings ShowFilterRow="True"/>
                                    <ClientSideEvents ContextMenu="grid_ContextMenu" RowClick="ClearFocusedRows" ColumnSorting="ClearRelatedJobs" />
                                </dxg:ASPxGridView>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dxt:TabPage>
                </TabPages>
            </dxt:ASPxPageControl>
     RELACIONADOS
     <dxg:ASPxGridView runat="server" ID="grdRelatedJobs" ClientInstanceName="grdRelatedJobs" Width="100%" KeyFieldName="JobId" OnCustomCallback="grdRelatedJobs_CustomCallback">
        <Columns>
            <dxg:GridViewDataColumn Width="30px" FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
            <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="0" />
            <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="1" />
            <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="2" />
            <dxg:GridViewDataColumn FieldName="ExecutionDays" Caption="Fecha Ejecución" VisibleIndex="3" />
        </Columns>
        <ClientSideEvents ContextMenu="grid_ContextMenu" RowClick="ClearFocusedRows" />
        <SettingsBehavior AllowSelectByRowClick="True" AllowSort="false" />
    </dxg:ASPxGridView>
    </td>
   <td valign="top">
    <table>
        <tr>
            <td>
                <dxe:ASPxRadioButton runat="server" ID="radTodos" ClientInstanceName="radTodos" Checked="true" GroupName="radFiltrar" Text="Todos">
                    <ClientSideEvents CheckedChanged="function(s, e) {
                            if(s.GetChecked())   grdDailyJobs.PerformCallback('SHOWALL');
                        }" />
                </dxe:ASPxRadioButton>    
            </td>
            <td>
                <dxe:ASPxRadioButton runat="server" ID="radManual" ClientInstanceName="radManual" GroupName="radFiltrar" Text="Manual">
                   <ClientSideEvents CheckedChanged="function(s, e) {
                        if(s.GetChecked())   grdDailyJobs.PerformCallback('SHOWMANUAL');
                    }" />
                </dxe:ASPxRadioButton></td>
            <td>
                <dxe:ASPxRadioButton runat="server" ID="radAutomatico" ClientInstanceName="radAutomatico" GroupName="radFiltrar" Text="Automatico">
                    <ClientSideEvents CheckedChanged="function(s, e) {
                            if(s.GetChecked())   grdDailyJobs.PerformCallback('SHOWAUTOMATIC');
                        }" />
                </dxe:ASPxRadioButton>
            </td>
            <td>
                <dxe:ASPxRadioButton runat="server" ID="radEjecutados" ClientInstanceName="radEjecutados" GroupName="radFiltrar" Text="Ejecutados">
                    <ClientSideEvents CheckedChanged="function(s, e) {
                            if(s.GetChecked())   grdDailyJobs.PerformCallback('SHOWEXECUTED');
                        }" />
                </dxe:ASPxRadioButton>
            </td>
            <td>
                <dxe:ASPxRadioButton runat="server" ID="radError" ClientInstanceName="radEjecutados" GroupName="radFiltrar" Text="Error">
                    <ClientSideEvents CheckedChanged="function(s, e) {
                            if(s.GetChecked())   grdDailyJobs.PerformCallback('SHOWERROR');
                        }" />
                </dxe:ASPxRadioButton>
            </td>
            <td>
                <dxe:ASPxRadioButton runat="server" ID="radPendientes" ClientInstanceName="radPendientes" GroupName="radFiltrar" Text="Pendientes">
                    <ClientSideEvents CheckedChanged="function(s, e) {
                            if(s.GetChecked())   grdDailyJobs.PerformCallback('SHOWPENDING');
                        }" />
                </dxe:ASPxRadioButton>
            </td>
        </tr>
    </table>
    DIARIOS MANUALES
    <dxg:ASPxGridView runat="server" ID="grdDailyJobs" ClientInstanceName="grdDailyJobs"  KeyFieldName="JobTriggerId"
     OnCustomCallback="grdDailyJobs_CustomCallback" >
        <Columns>
            <dxg:GridViewDataColumn Width="15px" Caption=" " FieldName="ExecutionDays" VisibleIndex="0" >
                <DataItemTemplate>
                    <dxe:ASPxImage runat="server" ToolTip='<%# Eval("JobTriggerStatus") %>' ID="imgTemplate" ImageUrl='<%#  "/Styles/images/" + Eval("JobTriggerStatus") + ".png" %>'>
                    </dxe:ASPxImage>
                    </DataItemTemplate>
            </dxg:GridViewDataColumn>
            <dxg:GridViewDataColumn Width="30px" FieldName="Job.JobId" Caption="ID Proceco" VisibleIndex="0" />
            <dxg:GridViewDataColumn Width="30px" FieldName="JobTriggerId" Caption="ID Trigger" VisibleIndex="0" />
            <dxg:GridViewDataColumn FieldName="Job.Group" Caption="Grupo" VisibleIndex="0" />
            <dxg:GridViewDataColumn FieldName="Job.Name" Caption="Nombre Proceso" VisibleIndex="1" />
            <dxg:GridViewDataColumn FieldName="Job.JobType" Caption="Tipo" VisibleIndex="2" />
            <dxg:GridViewDataColumn FieldName="StartExecutionDate" Caption="Fecha Ejecución" VisibleIndex="3" />
            <dxg:GridViewDataColumn FieldName="JobTriggerStatus" Caption="Status" VisibleIndex="4" />
            <dxg:GridViewDataHyperLinkColumn Width="30px" Caption=" " FieldName="JobTriggerId" ReadOnly="True" VisibleIndex="5">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="javascript:ShowJobDetailPopup('{0}');"
                    Text="Detalle...">
                </PropertiesHyperLinkEdit>
            </dxg:GridViewDataHyperLinkColumn>
             <dxg:GridViewDataHyperLinkColumn Width="30px" Caption=" " FieldName="JobTriggerId" ReadOnly="True" VisibleIndex="6">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="javascript:DeleteTriggerPopup('{0}');"
                    Text="Eliminar...">
                </PropertiesHyperLinkEdit>
            </dxg:GridViewDataHyperLinkColumn>
        </Columns>
        <SettingsBehavior AllowSelectByRowClick="true"  />
        <SettingsPager AlwaysShowPager="true" Mode=ShowPager PageSize="10"></SettingsPager>                            
        <ClientSideEvents ContextMenu="grid_ContextMenu" RowClick="ClearFocusedRows" ColumnSorting="ClearRelatedJobs" />
    </dxg:ASPxGridView>
                
                

            </td>

        </tr>
    </table>
    

</asp:Content>
