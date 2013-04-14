<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<% var publication = (Publication) Model;
   var vehiclePrice = publication.VehiclePrice != 0
                          ? Html.Encode(
                              publication.VehiclePrice.WithThousandsSeparator().AsPrice(
                                  publication.CVehiclePriceCurrency))
                          : "Consultar";
%>

<div class="avisoslineales">
    <div class="avisotablineales">
        <%--<div class="tabs_txt_lineales"><b><%=Html.Encode(publication.VehicleMakeText + " " + publication.VehicleModelText)%></b><br /> <%=Html.Encode(publication.VehicleYear==0?"0Km":string.Format("{0:0000}",publication.VehicleYear).Remove(0,2))%> <%=Html.Encode(publication.VehicleFuelTypeText + " " + vehiclePrice + " " + publication.SellerComment + " " + publication.UserPhone)%></div>--%>
        <div class="tabs_txt_lineales">
            <b><%=Html.Encode(publication.VehicleMakeText + " " + publication.VehicleModelText)%></b>
        <br />
         <%=Html.Encode(publication.SellerComment + " " + publication.UserPhone)%></div>
         <div class=""><span class="txtcontad" id="avi1"></span></div> 
        <div class="addthis_toolbox addthis_default_style" id="face_nor">
	
    	<!-- <a class="addthis_button_facebook" id="face2"></a>
    	<a class="addthis_button_twitter" id="twi"></a>   
        <a class="addthis_button_email" id="email"></a> -->
	</div>
    </div>
</div>
