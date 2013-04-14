<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>

<% var publication = (Publication) Model; %>

<!-- avisos basic -->
<div class="avisop">
    
    <% Html.RenderPartial("PublicationCarPhotoSection", publication); %>

    <% Html.RenderPartial("PublicationDetailsSection", publication); %>
            
    <% Html.RenderPartial("PublicationUserLogoSection", publication); %>

    <% Html.RenderPartial("PublicationOptionsBasicSection", publication); %>
</div>


