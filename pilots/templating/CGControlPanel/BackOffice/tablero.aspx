<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="tablero.aspx.cs" Inherits="CGControlPanel.BackOffice.tablero" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <form id="Form1" class="stdform stdform2" runat="server">
    <div class="centercontent">
        <div class="pageheader notab">
            <h1 class="pagetitle">
                Tablero de Control</h1>
            <span class="pagedesc">Agende sus Procesos Aquí</span>
        </div>
        <!--pageheader-->
        <div id="contentwrapper" class="contentwrapper widgetpage">
            <div>
                <div style="width: 50%; float: left; height: 700px">
                    <div class="widgetbox">
                        <div class="title">
                            <h3>
                                Procesos</h3>
                        </div>
                        <div class="widgetcontent">
                            <dxg:ASPxGridView runat="server" ID="grdJobs" CssClass="allwidthgrid" ClientInstanceName="grdJobs"
                                KeyFieldName="JobId">
                                <Columns>
                                    <dxg:GridViewDataColumn Caption=" " FieldName="ExecutionDays" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <dxe:ASPxImage runat="server" ToolTip='<%# Eval("LastExecutionStatus") %>' ID="imgTemplate"
                                                ImageUrl='<%#  "/Styles/images/" + Eval("LastExecutionStatus") + ".png" %>'>
                                            </dxe:ASPxImage>
                                        </DataItemTemplate>
                                    </dxg:GridViewDataColumn>
                                    <dxg:GridViewDataColumn  FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                                    <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                    <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                    <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
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
                        <!--widgetcontent-->
                    </div>
                    <!--widgetbox-->
                    <div class="widgetbox">
                        <div class="title">
                            <h3>
                                Procesos Relacionados</h3>
                        </div>
                        <div class="widgetcontent padding0 statement">
                            <dxg:ASPxGridView runat="server" ID="ASPxGridView1" CssClass="allwidthgrid" ClientInstanceName="grdJobs"
                                KeyFieldName="JobId">
                                <Columns>
                                    <dxg:GridViewDataColumn Caption=" " FieldName="ExecutionDays" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <dxe:ASPxImage runat="server" ToolTip='<%# Eval("LastExecutionStatus") %>' ID="imgTemplate"
                                                ImageUrl='<%#  "/Styles/images/" + Eval("LastExecutionStatus") + ".png" %>'>
                                            </dxe:ASPxImage>
                                        </DataItemTemplate>
                                    </dxg:GridViewDataColumn>
                                    <dxg:GridViewDataColumn  FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                                    <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                    <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                    <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                    <dxg:GridViewDataHyperLinkColumn Width="30px" Caption="Acción" FieldName="JobId"
                                        ReadOnly="True" VisibleIndex="6">
                                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/BackOffice/JobDelete.aspx?jobId={0}"
                                            Text="Eliminar">
                                        </PropertiesHyperLinkEdit>
                                    </dxg:GridViewDataHyperLinkColumn>
                                </Columns>
                                <Settings ShowFilterRow="True" ShowFilterBar="Visible" />
                            </dxg:ASPxGridView>
                            <dxe:ASPxButton runat="server" ID="ASPxButton1" PostBackUrl="JobAM.aspx" Text="Agregar">
                            </dxe:ASPxButton>
                        </div>
                        <!--widgetcontent-->
                    </div>
                    <!--widgetbox-->
                </div>
                <div style="width: 50%; float: right;">
                    <div class="widgetbox">
                        <div class="title">
                            <h3>
                                Agendados para Hoy&nbsp;</h3>
                        </div>
                        <div class="widgetcontent padding0 statement">
                            <dxg:ASPxGridView runat="server" ID="ASPxGridView2" CssClass="allwidthgrid" ClientInstanceName="grdJobs"
                                KeyFieldName="JobId">
                                <Columns>
                                    <dxg:GridViewDataColumn Caption=" " FieldName="ExecutionDays" VisibleIndex="0">
                                        <DataItemTemplate>
                                            <dxe:ASPxImage runat="server" ToolTip='<%# Eval("LastExecutionStatus") %>' ID="imgTemplate"
                                                ImageUrl='<%#  "/Styles/images/" + Eval("LastExecutionStatus") + ".png" %>'>
                                            </dxe:ASPxImage>
                                        </DataItemTemplate>
                                    </dxg:GridViewDataColumn>
                                    <dxg:GridViewDataColumn  FieldName="JobId" Caption="ID Proc" VisibleIndex="0" />
                                    <dxg:GridViewDataColumn FieldName="Group" Caption="Grupo" VisibleIndex="1" />
                                    <dxg:GridViewDataColumn FieldName="Name" Caption="Nombre Proceso" VisibleIndex="2" />
                                    <dxg:GridViewDataColumn FieldName="JobType" Caption="Tipo" VisibleIndex="3" />
                                    <dxg:GridViewDataHyperLinkColumn Width="30px" Caption="Acción" FieldName="JobId"
                                        ReadOnly="True" VisibleIndex="6">
                                        <PropertiesHyperLinkEdit NavigateUrlFormatString="/BackOffice/JobDelete.aspx?jobId={0}"
                                            Text="Eliminar">
                                        </PropertiesHyperLinkEdit>
                                    </dxg:GridViewDataHyperLinkColumn>
                                </Columns>
                                <Settings ShowFilterRow="True" ShowFilterBar="Visible" />
                            </dxg:ASPxGridView>
                            <dxe:ASPxButton runat="server" ID="ASPxButton2" PostBackUrl="JobAM.aspx" Text="Agregar">
                            </dxe:ASPxButton>
                        </div>
                        <!--widgetcontent-->
                    </div>
                    <!--widgetbox-->
                </div>
            </div>
        </div>
        <!--contentwrapper-->
    </form>
</asp:Content>
