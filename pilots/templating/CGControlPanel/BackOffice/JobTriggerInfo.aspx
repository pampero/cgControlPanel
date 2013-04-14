<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobTriggerInfo.aspx.cs" Inherits="CGControlPanel.JobTriggerInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
<script type="text/javascript">

     function ShowJobDetailPopup() {
         
        popup.SetContentUrl('/BackOffice/JobInfo.aspx?jobid=');
        popup.Show();
    }

 </script>

    <form id="form1" runat="server">
         <dxp:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup" Width="800px" Height="600px" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
            HeaderText="Proceso" AllowDragging="True" EnableAnimation="False" Modal="True">
                    <ContentCollection>
                        <dxp:PopupControlContentControl ID="PopupControlContentControl1"  runat="server">
                        </dxp:PopupControlContentControl>
                    </ContentCollection>
        </dxp:ASPxPopupControl>

        <table width="100%">
            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblProcessName" Text="Proceso:" /></td>
            </tr>
            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblTrigger" /></td>
            </tr>
            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblProcessOwner" /></td>
            </tr>
             <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblDescription" /></td>
            </tr>

            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblRecords"/></td>
            </tr>
            
            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblDaily" /></td>
            </tr>
            
            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblComments" /></td>
            </tr>
            
            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblProcessType" /></td>
            </tr>

            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblStatus" /></td>
            </tr>

            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblStartExecutionDate" /></td>
            </tr>

            <tr>
                <td colspan="2"><dxe:ASPxLabel runat="server" ID="lblEndExecutionDate" /></td>
            </tr>

             <dxt:ASPxPageControl ID="tabControl" runat="server" Width="100%" Height="350px"
        TabAlign="Justify" ActiveTabIndex="1" EnableTabScrolling="true">
        <TabStyle Paddings-PaddingLeft="10px" Paddings-PaddingRight="10px"/>
        <ContentStyle>
            <Paddings PaddingLeft="40px"/>
        </ContentStyle>
        <TabPages>
            <dxt:TabPage Text="Entrada">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl1" runat="server">

                        <table>
                            
                            <tr>
                                <td><dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="Valores de Entrada" /></td>
                                <td><dxe:ASPxMemo runat="server" ID="txtInputValues" Rows="7" /></td>
                            </tr>
            
                            <tr>
                                <td><dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Datos Tabulados de Entrada " /></td>
                                <td><dxe:ASPxMemo runat="server" ID="txtXmlTableInputParameters" Rows="7" /></td>
                            </tr>
                       </table>           
                    </dx:ContentControl>
                </ContentCollection>
            </dxt:TabPage>
            <dxt:TabPage Text="Salida">
                <ContentCollection>
                    <dx:ContentControl ID="ContentControl2" runat="server">
                        <table>
                            <tr>
                                <td><dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Log de Ejecución" /></td>
                                <td><dxe:ASPxMemo runat="server" ID="txtExecutionLog" Rows="7" /></td>
                            </tr>
                            <tr>
                                <td><dxe:ASPxLabel ID="ASPxLabel4" runat="server" Text="Datos Tabulados de Salida" /></td>
                                <td><dxe:ASPxMemo runat="server" ID="txtXmlTableOutput" Rows="7" /></td>
                            </tr>
            
                             <tr>
                                <td colspan="2">
                                <asp:Table runat="server" Id="tblResult"></asp:Table>
                                </td>
                            </tr>
                        </table>          
                    </dx:ContentControl>
                </ContentCollection>
            </dxt:TabPage>
           
        </TabPages>
    </dxt:ASPxPageControl>
 
            <tr>
                <td colspan="2">
                    
                    <dxe:ASPxButton AutoPostBack="False" style="float:right;" runat="server" ID="btnClose" Text="Cerrar">
                        <ClientSideEvents Click="function(s, e) { var parentWindow = window.parent;
                                            parentWindow.popup.Hide(); }" />
                    </dxe:ASPxButton>
                    
                    <dxe:ASPxButton Visible="False" runat="server" AutoPostBack="False" style="float:right; padding-right: 10px;" runat="server" ID="btnDeleteTrigger" Text="Eliminar">
                    </dxe:ASPxButton>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
