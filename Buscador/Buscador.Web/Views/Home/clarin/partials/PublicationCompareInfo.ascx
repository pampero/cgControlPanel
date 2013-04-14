<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Publication>" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>


<div class="contCajasG">
    <div class="cajaGris clearfix">
                    	<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                        
                    	<div class="titular gris clearfix">
                            <h4 class="avisos">Otros <%=Model.VehicleMakeText%> similares</h4>
                           
                   		</div>
                        <% var similarByModel = (List<Publication>)ViewData["SimilarByModel"]; %>
						<div class="main chico">
                        	<ul class="destacados">
                                <% foreach (var publication in similarByModel)
                                {%>
                                    <li class="fila1 first clearfix">
                                	    <div class="avisosImg"><a href="<%=publication.UrlDetails %>" title="<%=publication.VehicleDescription%>"><img alt="" src="<%=ViewData["ImagesUrl"] %>/PublishableItemImage/102x76/<%=publication.PublishableItemId%>_1.jpg"  /></a></div>
                                        <div class="avisosCont">
                                    	    <h2><a href="<%=publication.UrlDetails %>" title="<%=publication.VehicleDescription%>"><%=publication.VehicleDescription%></a></h2>
                                            <span class="datosf"><%=publication.VehicleFuelTypeText%>  <%=publication.VehicleYear.ToString() == "0" ? " " : " | " + publication.VehicleYear.ToString() + " | " + publication.VehicleKm.WithThousandsSeparator() + " km"%></span>
                                            <h5 class="precio"><%=publication.VehiclePrice!=0? Html.Encode(publication.VehiclePrice.WithThousandsSeparator().AsPrice(publication.CVehiclePriceCurrency)) : "A Consultar"%></h5>
                                        </div>
                                    </li>
                                <%} %>
                            </ul>
                        </div>   
							<div class="verTodosCont">
								 <a class="verTodos pngfix" href="<%=ViewData["SimilarByModelSearchUrl"] %>" title="Ver todos">Ver todos</a>
							</div>
                </div>
					
	<!--SEGUNDA CAJA GRIS -->
    <div class="cajaGris last clearfix">
                    	<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                        <% var comparableByModel = (List<Publication>)ViewData["ComparableByModel"]; %>
                    	<div class="titular gris clearfix">
                            <h4 class="avisos">Comparables de este modelo</h4>
                           
                   		</div>
                        
						<div class="main chico">
                        	<ul class="destacados">
                             <% foreach (var publication in comparableByModel)
                                {%>
                            	<li class="fila1 first clearfix">
                                	    <div class="avisosImg"><a href="<%=publication.UrlDetails %>" title="<%=publication.VehicleDescription%>"><img alt="" src="<%=ViewData["ImagesUrl"] %>/PublishableItemImage/102x76/<%=publication.PublishableItemId%>_1.jpg"  /></a></div>
                                        <div class="avisosCont">
                                    	    <a href="<%=publication.UrlDetails %>" title="<%=publication.VehicleDescription%>"><%=publication.VehicleDescription%></a>
                                            <span class="datosf"><%=publication.VehicleFuelTypeText%>  <%=publication.VehicleYear.ToString() == "0" ? " " : " | " + publication.VehicleYear.ToString() + " | " + publication.VehicleKm.WithThousandsSeparator() + " km"%></span>
                                            <h5 class="precio"><%= publication.VehiclePrice!=0 ? Html.Encode(publication.VehiclePrice.WithThousandsSeparator().AsPrice(publication.CVehiclePriceCurrency)) : "A Consultar"%></h5>
                                        </div>
                                    </li>
                                 <%} %>
                            </ul>
                        </div>   

							<div class="verTodosCont">
								 <a class="verTodos pngfix" href="<%=ViewData["SimilarSearchUrl"] %>" title="Ver todos">Ver todos</a>
							</div>
                </div>
	<!--  FIN SEGUNDA CAJA GRIS-->
</div>