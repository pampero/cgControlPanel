<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>

<% var publication = (Publication) Model;
   var showLinkToMircrosite = bool.Parse(ViewData["showLinkToMircrosite"]!=null?ViewData["showLinkToMircrosite"].ToString():"false");
    %>

<% if(publication.UserType=="AgencyUser") {%>
    
    <% if(! string.IsNullOrEmpty(publication.UserMicrosite)) {%>
        <div class="pic2">
            <a  href="<%="http://www.deautos.com/concesionaria/" + publication.UserMicrosite %>"><img alt="Concesionaria <%=publication.UserDescription%>" border="0" style="width:96px;height:72px;" src="<%=ViewData["ImagesUrl"] + "/UserImage/80x60/" + publication.LogoId + "_logo.jpg"%>" onerror="this.onerror=null;this.parentNode.parentNode.style.display='none';" /></a>
        </div>
        <%if(showLinkToMircrosite)
          { %>
                <div class="dataline-02ver" style="margin-left:-30px;">
                   <a  href="<%="http://www.deautos.com/concesionaria/" + publication.UserMicrosite %>"><%=publication.UserDescription %></a>
                </div> 
                <br />
        <%} %>
    <%}
    else{ %>
        
            <%if (publication.LogoId!=0){ %>
                <div class="pic2">
                    <img border="0" style="width:96px;height:72px;" src="<%=ViewData["ImagesUrl"] + "/UserImage/80x60/" + publication.LogoId + "_logo.jpg"%>" onerror="this.onerror=null;this.parentNode.style.display='none';" />
                </div>
            <%} %>
    <%} %>
<%} %>

