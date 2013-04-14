<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="System.Linq" %>

<% var publication = (Publication) Model; %>

<!-- avisos super premium-->
<div class="avisosp">
    
    <% Html.RenderPartial("PublicationCarPhotoSection", publication); %>

    <% Html.RenderPartial("PublicationDetailsSection", publication); %>
            
    <% Html.RenderPartial("PublicationUserLogoSection", publication); %>

    <% Html.RenderPartial("PublicationOptionsSection", publication); %>
</div>
