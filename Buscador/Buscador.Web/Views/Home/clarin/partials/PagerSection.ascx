<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Services.com.clarin.services" %>
<%@ Import Namespace="Buscador.Services.com.clarin" %>
<%@ Import Namespace="System.Linq" %>

<%
    var result = (IResults<Publication>)Model;
    
    if(result.Pages.Count!=0)
    {
    %>
        <%if((result.ActualPage - 2)>=0)
        { %>
            <a href="<%=result.Pages.Skip(result.ActualPage - 2).ToList()[0].Url %>">Anterior</a>
        <%}
          else
          {%>
             Anterior
        <%} %>

        <%
        foreach (var pageInfo in result.Pages.Skip(result.ActualPage - 5).Take(10))
        {
            if(pageInfo.Number==result.ActualPage)
            {%>
                <span><%=pageInfo.Number%></span>
            <%}
        %>
        
            <%else {%>

                <a href="<%=pageInfo.Url %>"><%= pageInfo.Number %> </a>
            <%  } %>    
<%      } %>
        
        <%if (result.ActualPage == 0 && result.Pages.Count>2)
          {%>
            <a href="<%=result.Pages.Where(x=>x.Number==2).First().Url %>">Siguiente</a>
        <%}
          else
          {
              if (result.Pages.Where(x => x.Number == result.ActualPage + 1).FirstOrDefault()!=null){%>
                    <a href="<%=result.Pages.Where(x=>x.Number==result.ActualPage+1).First().Url %>">Siguiente</a>
            <%} else
              {%>
                    Siguiente
              <%} %>
        <%} %>
<%  } %>

