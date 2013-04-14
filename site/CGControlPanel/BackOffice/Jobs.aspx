<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeBehind="Jobs.aspx.cs" Inherits="CGControlPanel.BackOffice.Jobs" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="pageheader notab">
        <h1 class="pagetitle">
            Listado de Procesos</h1>
        <span class="pagedesc">Todos los procesos disponibles en el sistema</span>
    </div>
    <div id="contentwrapper" class="contentwrapper">
        
        <form id="Form" name="Form" runat="server" class="stdform stdform2">

        <div class="dxg-grid-container">
            <dxg:ASPxGridView runat="server" ID="grdJobs" OnCustomColumnDisplayText="grdJobs_CustomColumnDisplayText" OnAutoFilterCellEditorInitialize="grdJobs_AutoFilterCellEditorInitialize"
                ClientInstanceName="grdJobs" Width="100%" KeyFieldName="JobId">
                <columns>
                            <dxg:GridViewDataColumn Width="30px" FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                            <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                            <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre" VisibleIndex="2" />
                            <dxg:GridViewDataColumn FieldName="Description" Caption="Descripción" VisibleIndex="3" />
                            <dxg:GridViewDataColumn FieldName="IsGeneral" Caption="General" VisibleIndex="4" />
                            <dxg:GridViewDataColumn FieldName="IsFavorite" Caption="Favorito" VisibleIndex="5" />
                            <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="6" />
                            <dxg:GridViewDataColumn FieldName="Weekdays" Caption="Días" VisibleIndex="7" />
                            <dxg:GridViewDataColumn FieldName="ServerName" Caption="Servidor" VisibleIndex="7" />
                            <dxg:GridViewDataColumn FieldName="DatabaseName" Caption="Base de Datos" VisibleIndex="7" />
                            <dxg:GridViewDataColumn FieldName="ExecProcedure" Caption="Procedimiento" VisibleIndex="7" />
                            <dxg:GridViewDataHyperLinkColumn Width="30px" Caption=" " FieldName="JobId" ReadOnly="True" VisibleIndex="8">
                                <PropertiesHyperLinkEdit ImageUrl="/Styles/images/book_open.png" NavigateUrlFormatString="/BackOffice/JobAM.aspx?jobId={0}" Text="Editar">
                                </PropertiesHyperLinkEdit>
                                <HeaderStyle HorizontalAlign="Center" />
                                <CellStyle HorizontalAlign="Center"/> 
                            </dxg:GridViewDataHyperLinkColumn>
                            <dxg:GridViewDataHyperLinkColumn Width="30px" Caption=" " FieldName="JobId" ReadOnly="True" VisibleIndex="9">
                                <PropertiesHyperLinkEdit ImageUrl="/Styles/images/cross.png" NavigateUrlFormatString="/BackOffice/JobDelete.aspx?jobId={0}"
                                    Text="Eliminar">
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
            <div class="par stdformbutton">
                <button type="button" class="stdbtn btn_blue" onclick="window.location.href='/BackOffice/JobAM.aspx';">
                    Nuevo</button>
            </div>
        </div>
        
        </form>

    </div>
    <!--subcontent-->
</div>
<!--contentwrapper-->
</asp:Content>
