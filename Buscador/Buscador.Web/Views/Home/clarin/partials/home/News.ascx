<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.Collections.Generic.IList<Buscador.Domain.com.clarin.entities.News>>" %>
<script type="text/javascript">
    $(document).ready(function () {
        var news = <%=Model.Count %> ;
        if (news == 3) {
            $('#LoadingNews').hide();
            $('#NewsContent').show();     
        }
    });
</script>
<div id="NewsContent" style="display:none">
<section id="newsnotice" class="Noticias active ContSec"><!--AGREGARLE EL MODIFICADOR "active" PARA MOSTRAR EL CONTENIDO -->
  
                                	<h4 class="copete">
                                      Enterate de las últimas novedades del mercado. 
                                    </h4>
                                    
                                    <section class="left">
                                    <% foreach (var newse in Model)
                                       {%>
                                        <figure class="imContent">
                                        	<%--<a href="<%=newse.Link %>" title="<%=newse.Title %>">--%>
                                            	<img width="444" height="306" src="<%=newse.Picture %>" alt="deautos"/>
                                            <%--</a>--%>
                                        </figure>
                                        <% } %>
                                    </section>
                                    
                                    <div class="right">
                                        <ul class="clearfix">
                                        <% foreach (var newse in Model)
                                           {%>
                                            <li class="first"><!--AGREGAR LA CLASE "act" A LOS LI PARA MOSTRAR EL DESTACADO -->
                                                <a href="<%=newse.Link %>" title="<%=newse.Title %>"><%=newse.Title %></a>
                                                <p><%=newse.Description %></p>
                                            </li>
                                         <%}%>
                                        </ul>
                                    </div>
</section>
</div>
<div id="LoadingNews">
    Cargando...
</div>
