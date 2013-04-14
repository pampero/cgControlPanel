<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Jobs.aspx.cs" Inherits="CGControlPanel.BackOffice.Jobs" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <form id="Form1" class="stdform stdform2" runat="server">
    <div class="centercontent">
        <div class="pageheader notab">
            <h1 class="pagetitle">
                Procesos</h1>
        </div>
        <dxg:ASPxGridView runat="server" ID="grdJobs" CssClass="allwidthgrid" ClientInstanceName="grdJobs" KeyFieldName="JobId">
            <Columns>
                <dxg:GridViewDataColumn Width="15px" Caption=" " FieldName="ExecutionDays" VisibleIndex="0">
                    <DataItemTemplate>
                        <dxe:ASPxImage runat="server" ToolTip='<%# Eval("LastExecutionStatus") %>' ID="imgTemplate"
                            ImageUrl='<%#  "/Styles/images/" + Eval("LastExecutionStatus") + ".png" %>'>
                        </dxe:ASPxImage>
                    </DataItemTemplate>
                </dxg:GridViewDataColumn>
                <dxg:GridViewDataColumn Width="30px" FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                <dxg:GridViewDataColumn FieldName="ExecutionDays" Caption="Fecha Ejecución" VisibleIndex="4" />
                <dxg:GridViewDataHyperLinkColumn Width="30px" Caption="Acción" FieldName="JobId"
                    ReadOnly="True" VisibleIndex="5">
                    <PropertiesHyperLinkEdit NavigateUrlFormatString="/BackOffice/JobAM.aspx?jobId={0}"
                        Text="Editar">
                    </PropertiesHyperLinkEdit>
                </dxg:GridViewDataHyperLinkColumn>
                <dxg:GridViewDataHyperLinkColumn Width="30px" Caption="Acción" FieldName="JobId"
                    ReadOnly="True" VisibleIndex="6">
                    <PropertiesHyperLinkEdit NavigateUrlFormatString="/BackOffice/JobDelete.aspx?jobId={0}"
                        Text="Eliminar">
                    </PropertiesHyperLinkEdit>
                </dxg:GridViewDataHyperLinkColumn>
            </Columns>
            <Settings ShowFilterRow="True" ShowFilterBar="Visible" />
        </dxg:ASPxGridView>
        <dxe:ASPxButton runat="server" ID="btnNew" PostBackUrl="JobAM.aspx" Text="Agregar">
        </dxe:ASPxButton>
    </div>
    </form>
</asp:Content>
