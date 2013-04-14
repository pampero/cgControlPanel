<%@ Page Title="" Language="C#" MasterPageFile="~/Error.Master" AutoEventWireup="true" CodeBehind="QuartzError.aspx.cs" Inherits="CGControlPanel.QuartzError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <div class="contentwrapper padding10">
    	<div class="errorwrapper error403">
        	<div class="errorcontent">
                <h1>500 Internal Server Error</h1>
                <h3>El servidor ha encontrado un error interno y le es imposible completar su requerimiento.</h3>
                <p>Por favor contacte al administrador <strong>cmaldonado@consulgroup.com.ar</strong> he informele en qué momento ha ocurrido el error.<br />Mas información sobre este error puede estar disponible en el archivo de log del servidor.</p>
                
                <%--<button class="stdbtn btn_black" onclick="history.back()">Go Back to Previous Page</button> &nbsp; --%>
                <button onclick="location.href='/account/login.aspx'" class="stdbtn btn_orange">Salir de la Aplicación</button>
            </div><!--errorcontent-->
        </div><!--errorwrapper-->
    </div>    

</asp:Content>
