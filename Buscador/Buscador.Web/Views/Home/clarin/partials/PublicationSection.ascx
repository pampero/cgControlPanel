<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="System.Linq" %>

<% var publication = (Publication) Model; %>
<!-- avisos super premium-->
<div class="avisosp">
    <div class="fotocar">
        <div class="pic">
            <a href="<%=publication.UrlDetails %>"><img src="<%="http://static1.deautos.com/images/fotosplaya/" + publication.PublicationId + ".jpg" %>" /></a></div>
    </div>

    <div class="avisotabs">
        <div class="tabs_txt2"><%=publication.VehicleMakeText%></div>
        <div class="tabs_txt"><%=publication.VehicleKm%></div>
        <div class="tabs_txt"><%=publication.VehicleYear%></div>
        <div class="tabs_txt"><%=publication.VehicleFuelTypeText%></div>
	<div class="tabs_txt"><%=publication.VehiclePrice%></div>
		
        <div class="avisodet">
            <div class="tabs_txt1"><%=publication.VehicleMakeText%> <%=publication.VehicleModelText%> <%=publication.VehicleVersionText%></div>
            <span class="txtcontad">
                <%= string.Join(", ",publication.EquipmentAttributes.Select(x=>x.AttrValue).ToArray()) %>
            </span>
        </div>
    </div>
            
    <div class="pic2">
        <img src="<%="http://static1.deautos.com/images/directorio/" + publication.UserUid + "_logo.jpg"%>" /></div>

    <div class="avisoadic">
        <div class="cantfotos"><span class="txtcontad"><%=publication.VehiclePicQty%></span></div>
        <div class="cantvisit"><span class="txtcontad"><%=publication.PublicationVisitorsQty%></span></div>
        <div class="save1"><span class="txtcontad"><a href="#">Guardar aviso</a></span></div>
        <div class="ver"><span class="txtcontad" id="avi2"><a href="#">Ver aviso</a></span></div>
    </div>
</div>
<!-- avisos super premium-->