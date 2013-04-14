<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>

<% var publication = (Publication)Model; %>

<div class="fotocar">
    <div class="pic">
       <a href="<%=publication.UrlDetails %>">
                
                <img style="width:96px;height:72px;" border="0" 
                alt="<%=Html.Encode(publication.VehicleMakeText)%> <%=Html.Encode(publication.VehicleModelText)%> <%=Html.Encode(publication.VehicleVersionText)%>"
                src="<%=ViewData["ImagesUrl"] + "/PublishableItemImage/96x72/" + Html.Encode(publication.PublishableItemId + "_1.jpg")%>" style="height:100%;"/>
        </a>
    </div>
</div>
