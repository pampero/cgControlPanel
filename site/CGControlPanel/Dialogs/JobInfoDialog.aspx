<%@ Page Title="" Language="C#" MasterPageFile="~/MainDialog.master" AutoEventWireup="true"
    CodeBehind="JobInfoDialog.aspx.cs" Inherits="CGControlPanel.Dialogs.JobInfoDialog" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <form id="Form1" class="stdform stdform2" runat="server">
    <div class="pageheader notab">
        <h1 class="pagetitle">
            Agendado de Proceso
            <asp:Literal ID="ltrlProcessType" runat="server" /></h1>
        <span class="pagedesc">Configure los datos del agendamiento</span>
    </div>
    <!--pageheader-->
    <div id="contentwrapper" class="contentwrapper">
        <div id="basicform" class="subcontent">
            <p>
                <asp:Label runat="server" CssClass="label" ID="lblProcessName" Text="Proceso:" />
            </p>
            <p>
                <asp:Label runat="server" CssClass="label" ID="lblDescription" />
            </p>
            <p>
                <asp:Label runat="server" CssClass="label" ID="lblComments" />
            </p>
            <p>
                <asp:Label runat="server" CssClass="label" ID="lblInputXmlFixedParameters" />
            </p>
            <br />
            <div style="width: 50%; float: left" class="leftCol">
                <div class="par">
                    <asp:Label runat="server" CssClass="label" ID="lblProcessType" />
                </div>
                <div class="par">
                    <asp:Label runat="server" CssClass="label" ID="lblWeekDays" />
                </div>
                <div class="par" runat="server" id="divAutomaticProcessTime">
                    <asp:Label runat="server" CssClass="label" ID="lblAutomaticProcessTime" />
                </div>
                <div class="par" runat="server" id="divInputSchemaProcedure">
                    <asp:Label runat="server" CssClass="label" ID="lblInputSchemaProcedure" />
                </div>
                <div class="par">
                    <asp:Label runat="server" CssClass="label" ID="lblServerName" />
                </div>
            </div>
            <div style="width: 50%; float: right">
                <div class="par">
                    <asp:Label runat="server" CssClass="label" ID="lblDataBaseName" />
                </div>
                <div class="par">
                    <asp:Label runat="server" CssClass="label" ID="lblDataBaseUser" />
                </div>
                <div class="par">
                    <asp:Label runat="server" CssClass="label" ID="lblStoredProcedure" />
                </div>
                <p>
                    <asp:Label runat="server" CssClass="label" ID="lblProcessOwner" />
                </p>
            </div>
            <div class="par stdformbutton">
                <button class="stdbtn btn_black" onclick="window.parent.ClosePopup();">
                    Cerrar</button>
            </div>
        </div>
    </div>
    </form>
</asp:Content>
