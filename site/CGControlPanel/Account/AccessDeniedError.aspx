<%@ Page Title="" Language="C#" MasterPageFile="~/Error.Master" AutoEventWireup="true" CodeBehind="AccessDeniedError.aspx.cs" Inherits="CGControlPanel.AccessDeniedError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
       <div class="contentwrapper padding10">
    	<div class="errorwrapper error403">
        	<div class="errorcontent">
                <h1>403 Acceso Denegado</h1>
                <h3>Usted no posee los permisos suficientes para acceder al módulo seleccionado.</h3>
                <p>Si cree que esto es erroneo contacte al administrador <strong>cmaldonado@consulgroup.com.ar</strong> he informele sobre lo sucedido.<br /></p>
                
                <button class="stdbtn btn_black" onclick="history.back()">Volver a la Pagina Anterior</button> &nbsp; 
                <button onclick="location.href='/account/login.aspx'" class="stdbtn btn_orange">Salir de la Aplicación</button>
            </div><!--errorcontent-->
        </div><!--errorwrapper-->
    </div>    

</asp:Content>
