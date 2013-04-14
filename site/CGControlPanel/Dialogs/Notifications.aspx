<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs"
    Inherits="CGControlPanel.Dialogs.Notifications" %>

<div>
    <ul class='notitab'>
        <li class='current'><a href='#messages'>Mensajes</a></li>
    </ul>
    <div id='messages'>
        <ul class='msglist'>
            <asp:literal runat="server" id="ltrlMessages"></asp:literal>
        </ul>
        <div class='msgbutton'>
            <a onclick="scheduleCounter.PerformCallback('MESSAGES');" href='#'><asp:literal id="ltrlBtnLegend" runat="server"></asp:literal></a>
        </div>
    </div>
</div>
