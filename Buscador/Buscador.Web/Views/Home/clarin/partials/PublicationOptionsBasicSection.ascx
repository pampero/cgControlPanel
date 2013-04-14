<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>

<% var publication = (Publication) Model; %>

<div class="avisoadic2">
    <div class="cantfotos"><span class="txtcontad"><%=Html.Encode(publication.VehiclePicQty)%></span></div>
    <%--<div class="cantvisit"><span class="txtcontad">visitas <%=Html.Encode(publication.PublicationVisitorsQty)%></span></div>--%>
    <%--<div class="save1"><span class="txtcontad"><a href="#">Guardar aviso</a></span></div>--%>
    <div class="ver"><span class="txtcontad"></span></div>
 	<div class="addthis_toolbox addthis_default_style" id="face">
    	<!--<a class="addthis_button_facebook" id="face2"></a>
    	<a class="addthis_button_twitter" id="twi"></a>   
        <a class="addthis_button_email" id="email"></a>-->
	</div>
</div>