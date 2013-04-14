<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyJobsInfo.aspx.cs"
    Inherits="CGControlPanel.Reports.DailyJobsInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CG.ControlPanel - Reportes</title>
    <link rel="stylesheet" href="/css/style.default.css" type="text/css" />
</head>
<body style="border: 1px">
    <div class="pageheader notab">
        <h1 class="pagetitle">
            Reporte Diario de Ejecución de Procesos
            <asp:Literal ID="ltrlProcessType" runat="server" /></h1>
    </div>
    <form id="Form1" class="stdform stdform2" runat="server">
    <!--pageheader-->
    <div class="stdform stdform2">
        <div id="basicform" class="subcontent">
            <table style="width: 100%; padding: 5px; border: thick; border-color: red;">
                <tr>
                    <td colspan="2">
                        <h4 style="font-size: 16px; padding-top: 10px; padding-bottom: 10px;">
                            Fecha de Ejecución:
                            <asp:Literal runat="server" ID="ltrlDate"></asp:Literal></h4>
                    </td>
                    <td colspan="2">
                        <h4 style="font-size: 16px; padding-top: 10px; padding-bottom: 10px; text-align: right">
                            Usuario:
                            <asp:Literal runat="server" ID="ltrlUser"></asp:Literal></h4>
                    </td>
                </tr>
               
                <tr>
                    <dxg:ASPxGridView runat="server" ID="grdExecutedJobsTrigger" OnCustomColumnDisplayText="grdJobsTrigger_CustomColumnDisplayText"
                        ClientInstanceName="grdExecutedJobsTrigger" Width="100%" KeyFieldName="JobTriggerId">
                        <Columns>
                            <dxg:GridViewDataColumn Width="30px" FieldName="JobTriggerId" Caption="ID Proc" VisibleIndex="0" />
                            <dxg:GridViewDataColumn FieldName="Job.Name" Caption="Nombre" VisibleIndex="1" />
                            <dxg:GridViewDataColumn FieldName="Job.Group" Caption="Grupo" VisibleIndex="2" />
                            <dxg:GridViewDataColumn FieldName="RecordsProcessed" Caption="#Procesados" VisibleIndex="3" />
                            <dxg:GridViewDataColumn FieldName="RecordsAffected" Caption="#Afectados" VisibleIndex="4" />
                            <dxg:GridViewDataColumn FieldName="Job.Weekdays" Caption="Días de Ejecución" VisibleIndex="5" />
                            <dxg:GridViewDataColumn FieldName="CreatedBy" Caption="Agendado Por" VisibleIndex="5" />
                            <dxg:GridViewDataDateColumn FieldName="StartExecutionDate" Caption="Inicio Ejecución"
                                VisibleIndex="6">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                </PropertiesDateEdit>
                            </dxg:GridViewDataDateColumn>
                            <dxg:GridViewDataDateColumn FieldName="EndExecutionDate" Caption="Fin Ejecución"
                                VisibleIndex="7">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                </PropertiesDateEdit>
                            </dxg:GridViewDataDateColumn>
                        </Columns>
                        <Settings ShowFilterRow="False" ShowFilterBar="Hidden" ShowTitlePanel="True" />
                        <SettingsText Title="-- Procesos Ejecutados --"></SettingsText>
                        <SettingsPager AlwaysShowPager="false">
                        </SettingsPager>
                    </dxg:ASPxGridView>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <dxg:ASPxGridView runat="server" ID="grdScheduledJobsTrigger" OnCustomColumnDisplayText="grdJobsTrigger_CustomColumnDisplayText"
                        ClientInstanceName="grdScheduledJobsTrigger" Width="100%" KeyFieldName="JobTriggerId">
                        <Columns>
                            <dxg:GridViewDataColumn Width="30px" FieldName="JobTriggerId" Caption="ID Proc" VisibleIndex="0" />
                            <dxg:GridViewDataColumn FieldName="Job.Name" Caption="Nombre" VisibleIndex="1" />
                            <dxg:GridViewDataColumn FieldName="Job.Group" Caption="Grupo" VisibleIndex="2" />
                            <dxg:GridViewDataColumn FieldName="Job.Weekdays" Caption="Días de Ejecución" VisibleIndex="5" />
                            <dxg:GridViewDataColumn FieldName="CreatedBy" Caption="Agendado Por" VisibleIndex="5" />
                            <dxg:GridViewDataDateColumn FieldName="ScheduledStartExecutionDate" Caption="Inicio Agendado de Ejecución"
                                VisibleIndex="6">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                </PropertiesDateEdit>
                            </dxg:GridViewDataDateColumn>
                        </Columns>
                        <Settings ShowFilterRow="False" ShowFilterBar="Hidden" ShowTitlePanel="True" />
                        <SettingsText Title="-- Procesos Agendados --"></SettingsText>
                        <SettingsPager AlwaysShowPager="false">
                        </SettingsPager>
                    </dxg:ASPxGridView>
                </tr>
                 <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <dxg:ASPxGridView runat="server" ID="grdErrorJobsTrigger" OnCustomColumnDisplayText="grdJobsTrigger_CustomColumnDisplayText"
                        ClientInstanceName="grdErrorJobsTrigger" Width="100%" KeyFieldName="JobTriggerId">
                        <Columns>
                            <dxg:GridViewDataColumn Width="30px" FieldName="JobTriggerId" Caption="ID Proc" VisibleIndex="0" />
                            <dxg:GridViewDataColumn FieldName="Job.Name" Caption="Nombre" VisibleIndex="1" />
                            <dxg:GridViewDataColumn FieldName="Job.Group" Caption="Grupo" VisibleIndex="2" />
                            <dxg:GridViewDataColumn FieldName="RecordsProcessed" Caption="#Procesados" VisibleIndex="3" />
                            <dxg:GridViewDataColumn FieldName="RecordsAffected" Caption="#Afectados" VisibleIndex="4" />
                            <dxg:GridViewDataColumn FieldName="Job.Weekdays" Caption="Días de Ejecución" VisibleIndex="5" />
                            <dxg:GridViewDataColumn FieldName="CreatedBy" Caption="Agendado Por" VisibleIndex="5" />
                            <dxg:GridViewDataDateColumn FieldName="StartExecutionDate" Caption="Inicio Ejecución"
                                VisibleIndex="6">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                </PropertiesDateEdit>
                            </dxg:GridViewDataDateColumn>
                            <dxg:GridViewDataDateColumn FieldName="EndExecutionDate" Caption="Fin Ejecución"
                                VisibleIndex="7">
                                <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy HH:mm">
                                </PropertiesDateEdit>
                            </dxg:GridViewDataDateColumn>
                        </Columns>
                        <Settings ShowFilterRow="False" ShowFilterBar="Hidden" ShowTitlePanel="True" />
                        <SettingsText Title="-- Procesos Ejecutados con Error --"></SettingsText>
                        <SettingsPager AlwaysShowPager="false">
                        </SettingsPager>
                    </dxg:ASPxGridView>
                </tr>
            </table>
            <div class="stdformbutton">
                <button class="stdbtn btn_black" onclick="javascript: return window.close();">
                    Cerrar</button>
                <button class="stdbtn btn_blue" onclick="javascript: return window.print();">
                    Imprimir</button>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
