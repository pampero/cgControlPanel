<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Users.aspx.cs"
    Inherits="CGControlPanel.BackOffice.Users" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="pageheader notab">
        <h1 class="pagetitle">
            Listado de Usuarios</h1>
        <span class="pagedesc">Todos los usuarios disponibles en el sistema</span>
    </div>

    <div id="contentwrapper" class="contentwrapper">
        
        <form id="Form" name="Form" runat="server" class="stdform stdform2">

        <div class="dxg-grid-container">
            <dxg:ASPxGridView runat="server" ID="grdUsers" ClientInstanceName="grdJobs" Width="100%" OnAutoFilterCellEditorInitialize="grdUsers_AutoFilterCellEditorInitialize"
                KeyFieldName="UserName">
                <columns>
                            <dxg:GridViewDataColumn FieldName="UserName" Caption="Usuario" VisibleIndex="0" />
                            <dxg:GridViewDataColumn FieldName="Email" Caption="EMail" VisibleIndex="1" />
                            <dxg:GridViewDataHyperLinkColumn Width="30px" Caption=" " FieldName="UserName" ReadOnly="True" VisibleIndex="2">
                                <PropertiesHyperLinkEdit ImageUrl="/Styles/images/book_open.png" NavigateUrlFormatString="/BackOffice/UserAM.aspx?UserName={0}" Text="Editar">
                                </PropertiesHyperLinkEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"/> 
                            </dxg:GridViewDataHyperLinkColumn>
                            <dxg:GridViewDataHyperLinkColumn Width="30px" Caption=" " FieldName="UserName" ReadOnly="True" VisibleIndex="4">
                                <PropertiesHyperLinkEdit ImageUrl="/Styles/images/cross.png" NavigateUrlFormatString="/BackOffice/UserDelete.aspx?UserName={0}" Text="Eliminar">
                                </PropertiesHyperLinkEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"/> 
                            </dxg:GridViewDataHyperLinkColumn>
                        </columns>
                <settings showfilterrow="True" showfilterbar="Visible" />
                <SettingsPager AlwaysShowPager="true" PageSize="15"></SettingsPager>
            </dxg:ASPxGridView>
        </div>
        <div class="stdform stdform2">
            <p class="par stdformbutton">
                <button type="button" class="stdbtn btn_blue" onclick="window.location.href='/BackOffice/UserAM.aspx';">
                    Nuevo</button>
            </p>
        </div>
        
        </form>

    </div>
    <!--contentwrapper-->
</asp:Content>
