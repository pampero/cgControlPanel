<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobTriggerInfo.aspx.cs"
    Inherits="CGControlPanel.Reports.JobTriggerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CG.ControlPanel - Reporte de información de ejecución del proceso</title>
    <link rel="stylesheet" href="/css/style.default.css" type="text/css" />
</head>
<body style="border:1px">
     <div class="pageheader notab">
        <h1 class="pagetitle">
            Información de Ejecución del Proceso
            <asp:Literal ID="ltrlProcessType" runat="server" /></h1>
        <span class="pagedesc">CG.ControlPanel</span>
    </div>
    
        <form id="Form1" class="stdform stdform2" runat="server">
        <!--pageheader-->
        <div class="stdform stdform2">
            <div id="basicform" class="subcontent">
        <table style="width: 100%; padding:5px;border:thick;border-color:red;" >
            <tr>
                <td colspan="4">
                    <h4 style="font-size:16px;padding-top: 10px;padding-bottom: 10px;">Datos del Proceso: <asp:Literal runat="server" ID="lblProcessName" /></h4>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                   
                </td>
            </tr>
            <tr>
                <td>
                    Descripción:
                </td>
                <td colspan="3">
                    <asp:Literal runat="server" ID="lblDescription" />
                </td>
            </tr>
            <tr>
                <td>Comentarios:
                </td>
                <td colspan="3">
                    <asp:Literal runat="server" ID="lblComments" />
                </td>
            </tr>
            <tr>
                <td>
                    Valores Fijos:
                </td>
                <td colspan="3">
                    <asp:Literal runat="server" ID="lblInputXmlFixedParameters" />
                </td>
            </tr>
       
            <tr>
                <td style="width: 20%">
                    Frecuencia:
                </td>
                <td style="width: 30%">
                    <asp:Literal runat="server" ID="lblWeekDays" />
                </td>
                <td style="width: 15%">
                    Nombre BD:
                </td>
                <td style="width: 35%">
                    <asp:Literal runat="server" ID="lblDataBaseName" />
                </td>
            </tr>
            <tr>
                <td>
                    Nombre Servidor:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblServerName" />
                </td>
                <td>
                    Stored de Ejecución:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblStoredProcedure" />
                </td>
            </tr>
          
            <tr>
                <td>
                    Stored de Config:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblInputSchemaProcedure" />
                </td>
                <td>
                    Tipo de Proceso:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblProcessType" />
                </td>
            </tr>
      
            <tr>
                <td>
                    Usuario:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblProcessOwner" />
                </td>
                <td>
                    Registro:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblRecords" />
                </td>
            </tr>
            <tr>
                <td>
                    Trigger:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblTrigger" />
                </td>
                <td>
                    Agendado el:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblScheduledStartExecutionDate" />
                </td>
            </tr>
            <tr>
                <td>
                    Estado del Proceso:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblJobTriggerStatus" />
                </td>
                <td>
                    Inicio de Ejecución:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblStartExecutionDate" />
                </td>
            </tr>
            <tr>
                <td>
                    Estado de Salida:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblOutputStatus" Text="Estado de Salida:" />
                </td>
                <td>
                    Fin de Ejecución:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblEndExecutionDate" />
                </td>
            </tr>
             <tr>
                <td>
                    Hora Ejecución:
                </td>
                <td>
                    <asp:Literal runat="server" ID="lblAutomaticProcessTime" />
                </td>
                <td colspan="2">
                </td>
            </tr>
<%------------------------------------------------  Datos de entrada ---------------------------------------------%>
             <tr>
                <td colspan="4">
                    <h4 style="font-size:16px;padding-top: 10px;padding-bottom: 10px;">Datos de Entrada</h4>
                </td>
            </tr>
            <tr>
                <td>
                    Formulario de Entrada:
                </td>
                <td colspan="3">
                    <asp:Literal runat="server" ID="lblInputValues" />
                </td>
            </tr>
<%------------------------------------------------  Datos de salida ---------------------------------------------%>
             <tr>
                <td colspan="4">
                    <h4 style="font-size:16px;padding-top: 10px;padding-bottom: 10px;">Datos de Salida</h4>
                </td>
            </tr>
            <tr>
                <td>
                    Resultado de Ejecución:
                </td>
                <td colspan="2">
                    <asp:Literal runat="server" ID="lblOutputResult" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Log de Ejecución:
                </td>
                <td colspan="3">
                    <div><asp:Literal runat="server" ID="lblOuputExecutionLog" /></div>
                </td>
            </tr>
            <tr>
                <td>
                    Trace de Ejecución:
                </td>
                <td colspan="3">
                    <div><asp:Literal runat="server" ID="lblOutputExecutionTrace" /></div>
                </td>
            </tr>
        </table>
         <div class="stdformbutton">
                <button class="stdbtn btn_black" onclick="javascript: return window.close();">Cerrar</button>
                <button class="stdbtn btn_blue" onclick="javascript: return window.print();">Imprimir</button>
            </div>
            </div>
            </div>
            </form>

</body>
</html>
