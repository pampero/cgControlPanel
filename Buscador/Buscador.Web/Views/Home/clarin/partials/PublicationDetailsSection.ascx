<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="Buscador.Web" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<% var publication = (Publication)Model; %>

<div class="avisotabs">
    <div class="tabs_txt2"><%=Html.Encode(publication.VehicleLocLocText)%></div>
    <div class="tabs_txt"><%=Html.Encode(publication.VehicleKm.WithThousandsSeparator() + " km")%></div>
    <div class="tabs_txt"><%=Html.Encode(publication.VehicleYear)%></div>    
    <div class="tabs_txt"><%=Html.Encode(publication.VehicleFuelTypeText)%></div>
    <div class="tab_price"><%=publication.VehiclePrice!=0?Html.Encode(publication.VehiclePrice.WithThousandsSeparator().AsPrice(publication.CVehiclePriceCurrency)):"A Consultar"%></div>
    
    <div class="avisodet">
        <div class="tabs_txt1">
          <h2><a href="<%=publication.UrlDetails %>">  <%=Html.Encode(publication.VehicleMakeText)%>
            <%=Html.Encode(publication.VehicleModelText)%>
            <%=Html.Encode(publication.VehicleVersionText)%></a></h2>
        </div>

        <span class="txtcontad">
            <%= Html.Encode(string.Join(", ",publication.EquipmentAttributes.Select(x=>x.AttrValue).ToArray()).LimitTo(295)) %> 
        </span>
    </div>

</div>
