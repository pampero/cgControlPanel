<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<% var publication = (Publication) Model; %>

<div class="avisosimple">
    <div class="fotocar2">
        <div class="picsimple"><img src="../../../../Content/images/ico_foto.png" border="0"></div>
    </div>

    <div class="avisotabsimple">
        <div class="tabs_txt1_simple"><a href="<%=publication.UrlDetails %>"><%=Html.Encode(publication.VehicleMakeText + " " + publication.VehicleModelText)%></a></div>
        <div class="tabs_txt"><%=Html.Encode(publication.VehicleKm.WithThousandsSeparator() + " km")%></div>
        <div class="tabs_txt"><%=Html.Encode(publication.VehicleYear)%></div>        
        <div class="tabs_txt"><%=Html.Encode(publication.VehicleFuelTypeText)%></div>
        <div class="tab_price"><%=publication.VehiclePrice!=0?Html.Encode(publication.VehiclePrice.WithThousandsSeparator().AsPrice(publication.CVehiclePriceCurrency)):"A Consultar"%></div>
         <div class="ver2"><span class="txtcontad" id="avi1"></span></div> 
        <div class="addthis_toolbox addthis_default_style" id="face_nor">
	
    	<!-- <a class="addthis_button_facebook" id="face2"></a>
    	<a class="addthis_button_twitter" id="twi"></a>   
        <a class="addthis_button_email" id="email"></a> -->
	</div>
    </div>
</div>
