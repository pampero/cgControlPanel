<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JobInfo.aspx.cs" Inherits="CGControlPanel.JobInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <table width="100%">
            <tr>
                <td colspan="4"><dxe:ASPxLabel runat="server" ID="lblProcessOwner" /></td>
            </tr>
            <tr>
                <td Width="10%"><dxe:ASPxLabel runat="server" Text="Grupo" /></td>
                <td Width="65%"><dxe:ASPxTextBox runat="server" ID="txtGroup" MaxLength="50" Width="50%">
                         <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                            <RequiredField IsRequired="True" ErrorText="Requerido" />
                        </ValidationSettings>
                    </dxe:ASPxTextBox> </td>
                <td Width="10%"></td>
                <td Width="25%"></td>
            </tr>
            
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Nombre" /></td>
                <td><dxe:ASPxTextBox runat="server" ID="txtName" MaxLength="50" Width="50%">
                         <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                            <RequiredField IsRequired="True" ErrorText="Requerido" />
                        </ValidationSettings>
                    </dxe:ASPxTextBox> </td>
                <td></td>
                <td></td>
            </tr>
            
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Descripción" /></td>
                <td><dxe:ASPxMemo runat="server" ID="txtDescription" Rows="5" MaxLength="200" Width="50%"/></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Tipo de Proceso" /></td>
                <td>
                    <dxe:ASPxComboBox ID="cmbJobType" runat="server" SelectedIndex="0" Width="25%">
                        <Items>
                            <dxe:ListEditItem Value="1" Text="Automático" />
                            <dxe:ListEditItem Value="2" Text="Manual" />
                        </Items>
                    </dxe:ASPxComboBox>
                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td><dxe:ASPxCheckBox runat="server" ID="chkFavorite" Text="Es Favorito?" ></dxe:ASPxCheckBox></td>
                <td></td>
                <td></td>
            </tr>
             <tr>
                <td></td>
                <td><dxe:ASPxCheckBox runat="server" ID="chkDaily" Text="Es Diario?" ></dxe:ASPxCheckBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Procedimiento de Entrada de Datos (Local)" /></td>
                <td><dxe:ASPxTextBox runat="server" Password="True" ID="txtInputSchemaProcedure" MaxLength="50" Width="40%">
                    </dxe:ASPxTextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Parametros Fijos" /></td>
                <td><dxe:ASPxMemo runat="server" Password="True" ID="txtFixedParametersProcedure" Rows="5" Width="40%">
                    </dxe:ASPxMemo></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2"><hr/></td><td></td><td></td>
            </tr>
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Servidor" /></td>
                <td><dxe:ASPxTextBox runat="server" ID="txtInputSchemaServerName" MaxLength="40" Width="40%">
                         <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                            <RequiredField IsRequired="True" ErrorText="Requerido" />
                        </ValidationSettings>
                    </dxe:ASPxTextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Base de Datos" /></td>
                <td><dxe:ASPxTextBox runat="server" ID="txtInputSchemaDataBaseName" MaxLength="40" Width="40%">
                         <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                            <RequiredField IsRequired="True" ErrorText="Requerido" />
                        </ValidationSettings>
                    </dxe:ASPxTextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td><dxe:ASPxLabel runat="server" Text="Usuario" /></td>
                <td><dxe:ASPxTextBox runat="server" ID="txtInputSchemaUserName" MaxLength="15" Width="40%">
                         <ValidationSettings SetFocusOnError="True" ValidationGroup="Accept">
                            <RequiredField IsRequired="True" ErrorText="Requerido" />
                        </ValidationSettings>
                    </dxe:ASPxTextBox></td>
                <td></td>
                <td></td>
            </tr>
             <tr>
                <td><dxe:ASPxLabel runat="server" Text="Procedimiento a Ejecutar" /></td>
                <td><dxe:ASPxTextBox runat="server" Password="True" ID="txtExecProcedure" MaxLength="50" Width="40%">
                    </dxe:ASPxTextBox></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="4">
                    <dxe:ASPxButton AutoPostBack="False" style="float:right;" runat="server" ID="btnClose" Text="Cerrar">
                        <ClientSideEvents Click="function(s, e) { var parentWindow = window.parent;
                                            parentWindow.popup.Hide(); }" />
                    </dxe:ASPxButton>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
