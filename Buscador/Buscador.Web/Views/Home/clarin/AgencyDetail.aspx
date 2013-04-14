<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Buscador.Domain.com.clarin.entities.Agency>" %>
<%@ Import Namespace="Buscador.Domain" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Linq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="/Scripts/googlemap.js"></script>
<link rel="stylesheet" type="text/css" href="/Content/css/jquery.ad-gallery2.css" />
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
 <script type="text/javascript" src="/Scripts/jquery.ad-gallery.js"></script>

<script type="text/javascript" src="../../Scripts/certifica.js"></script>
<%--<script type="text/javascript">
    hitCertifica('200150', '/concesionaria/<%=Model.Id%>', '/concesionaria/<%=Model.Id%>');</script>--%>

<script type="text/javascript">
    $("link[href*='home.css']").remove();
</script>


<script type="text/javascript">

    $(document).ready(function(){
        initialize(); 
    })
    
</script>


  <script type="text/javascript">
  $(function() {
    $('img.image1').data('ad-desc', '');
    $('img.image1').data('ad-title', '');
    $('img.image4').data('ad-desc', '');
    $('img.image5').data('ad-desc', '');
    var galleries = $('.ad-gallery').adGallery();
    $('#switch-effect').change(
      function() {
        galleries[0].settings.effect = $(this).val();
        return false;
      }
    );
    $('#toggle-slideshow').click(
      function() {
        galleries[0].slideshow.toggle();
        return false;
      }
    );
    $('#toggle-description').click(
      function() {
        if(!galleries[0].settings.description_wrapper) {
          galleries[0].settings.description_wrapper = $('#descriptions');
        } else {
          galleries[0].settings.description_wrapper = false;
        }
        return false;
      }
    );
  });
  </script>



<div class="layout microConcesionaria">
   <div class="conteiner colMargen clearfix"><!--segin el modificador que tenga "conteiner", cambiará la columna left -->
                        <div class="path">
	                        <ul class="breadcrum clearfix">
                                <li class="first"><a title="Inicio" href="#">Inicio</a></li>
                                <li class="last"><span> &gt;</span><%=Model.Name %></li>
                            </ul>
                        </div>
        	<div class="colLeft">

            	<div class="cajaNegra">
                	<div class="Cv Tl"></div>
                    <div class="Cv Tr"></div>
                    <div class="Cv Bl"></div> 
                    <div class="Cv Br"></div>                    
                	<div class="contHead">
                    	<div class="imgCont">
                        <table border="1" width="123" height="120">
                            <tr align="center">
                                <td valign="middle">
                                    <a href="#" title="#">
                                        <img src="<%=ViewData["ImagesUrl"] %>/UserImage/102x76/<%=Model.UserId%>_logo.jpg" alt="deautos"/>
                                    </a>
                                </td>
                            </tr>
                        </table>
                        </div>

                        <div class="insideMidleH">
                        	<h2 class="titulo1"><%=Model.Name %></h2>
                            <div class="insideMidleB">
                            	<div class="links">
                                	<ul>
                                    	<li><label>Email:</label><a href="mailto:<%=Model.EMail %>" title="<%=Model.EMail %>"><%=Model.EMail %></a></li>
                                        <%if (!string.IsNullOrEmpty(Model.Website)){ %>
                                            <li><label>Web:</label><a href="http://<%=Model.Website %>" title="<%=Model.Website %>"><%=Model.Website %></a></li>
                                        <%} %>
                                    </ul>
                                </div>
                                <%--<div class="botCont">
                                	<a class="btnNar" href="#" title="Contactanos">
                                        <span class="L"></span>
                                        <span class="M">Contactanos</span>
                                        <span class="R"></span>
                              		</a>

                                </div>--%>
                            </div>
                        </div>
                        
                        <div class="chapaVentas">
                        	<div class="ventasCont">
                            	<span>Ventas y Servicios:</span>
                                <p><%=Model.PhoneNumber %></p>
                                <!-- <p>(011) 5811-1101 //154-445-6638 // 565*3603</p> -->
                            </div>
                        </div>
                        
                    </div>
                    <div class="cajaBlanca clearfix" style="padding-bottom: 18px;">        				
                        <div class="slidesCont" style="padding-left:20px; width:333px;">                    
                            <div id="gallery" class="ad-gallery">
                                <div class="ad-image-wrapper"></div>
                                <div class="ad-controls"></div>   
	                                <div class="ad-nav">
                                        <div class="ad-thumbs explo76">
                                          <ul class="ad-thumb-list">
                                            
                                            <li>
                                                <a href="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_1"%>.jpg">
                                                <img height="57" width="76" src="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_1"%>.jpg" class="image0">
                                                </a>
                                            </li>
                                            <li>
                                                <a href="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_2"%>.jpg">
                                                <img height="57" width="76" src="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_2"%>.jpg" class="image1">
                                                </a>
                                            </li>
                                            <li>
                                                <a href="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_3"%>.jpg">
                                                <img height="57" width="76" src="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_3"%>.jpg" class="image2">
                                                </a>
                                            </li>
                                            <li>
                                                <a href="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_4"%>.jpg">
                                                <img height="57" width="76" src="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_4"%>.jpg" class="image3">
                                                </a>
                                            </li>

                                            <%--<% for(var j=0;j<=7;j++)
                                               {
                                                   int h = j + 1;
                                                   %>
                                                    <li>
                                                      <a href="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_" + h%>.jpg">
                                                        <img height="57" width="76" src="http://staticn.deautos.com/images/directorio/<%=Model.UserId + "_" + h%>.jpg" class="image<%=j%>">
                                                      </a>
                                                    </li>
                                            <% } %>--%>
                                          </ul>
                                        </div>
                                    </div>
                                </div>
                        </div>
                        
                        <!--google map-->
                        <div class="mapCont">
                        	<div class="map">
                                <%= Html.MapCenterIn(Model.LocationCoordinates, "ABQIAAAA0B1myXxg790GVj8JEg0EvBSeSlW9vW7u8j6xEORhq-WIcyI06BQiJJLQIAKiJzEKAV6jiLPP3uxwtA",570,215)%>
                            </div>
                            <div class="place"><h5><%=Model.Address %></h5></div>
                            <div class="verPublicaciones">
                            	<a href="http://www.deautos.com/autos-usados/UIYY<%=Model.UserId%>" title="Ver publicaciones del vendedor">Ver publicaciones del vendedor</a>
                                <%--<span class="spanVerPublic">Ver publicaciones del vendedor</span>--%>
                            </div>
                        </div>
                        
        			</div>
                </div>
                
                <div class="columnaLeft">
                    <%var halfServiceCount = Model.Services.Count > 0 ? Model.Services[0].SplitIntoSentencesOfSize(8).Count() / 2 : 0;
                      if (Model.Services.Count > 0)
                      {%>
                	        <div class="cajaGris">
                    	        <div class="Cv Tl"></div>
                                <div class="Cv Tr"></div>
                                <div class="Cv Bl"></div>
                                <div class="Cv Br"></div>
                    	        <div class="titular clearfix">
                        	        <h4>Servicios</h4>
                                </div>
                        
                                <div class="main grande clearfix">
                        	        <p class="servicios">Los servicios brindados antes y después de la compra:</p>
                                
                                <ul class="first">

                                <%for (var i = 0; i < halfServiceCount; i++)
                                {
                                    var service = Model.Services[0].SplitIntoSentencesOfSize(8).ToArray()[i];
                                %>
                                    <li class="first"><%=service%></li>      
                              <%} %>

                                
                                </ul> 

                                <ul class="first" id="derecha">
                                <%for (var i = halfServiceCount; i < Model.Services[0].SplitIntoSentencesOfSize(8).Count(); i++)
                                {
                                    var service = Model.Services[0].SplitIntoSentencesOfSize(8).ToArray()[i];
                                 %>
                                    <li class="first"><%=service%></li>         
                              <%} %>
                                </ul>

                                

                                <%--<ul class="first" id="derecha">
	                                <li class="first">Compra venta 0KM y usados Permutas Consignaciones Gestoria propia y documentación</li>
	                                <li class="first">garantizada Atención personalizada en toda la gestion de</li>
                                    <li class="first">transferencia Asesoramiento y cotizaciones Financiaciones bancarias y o</li>
                                    <li class="first">creditos personales</li>
                                </ul>

                                <ul class="first">
                                <%foreach (var service in Model.Services[0].SplitIntoSentencesOfSize(8))
                                  {%>
                            	      <li class="first"><%=service%></li>
                                  <%
                                  }%>
                                </ul> --%>

                                </div>
                            </div>
                    <%
                      }%>

                    <%if (!string.IsNullOrEmpty(Model.Description)) 
                    {%>
                        <div class="laEmpresa">
                            <div class="cajaNegra mod clearfix">
                                <div class="Cv Tl"></div>
                                <div class="Cv Tr"></div>
                                <div class="Cv Bl"></div>
                                <div class="Cv Br"></div>
                                <h4>La empresa</h4>
                            </div>
                        
                            <p class="parrafoFirst">
                        	    <%=Model.Description %>
                            </p>
                        </div>  
                    <% }%>  
                    
                </div>
                
                <%if (((List<Publication>)ViewData["Publications"]).Count > 0 && (!string.IsNullOrEmpty(Model.Description) || Model.Services.Count>0)) 
                {%>
                    <div class="columnaRight">
                
                	<div class="cajaGris clearfix">
                    	<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                        
                    	<div class="titular gris clearfix">
                            <h2 class="avisos">Autos destacados</h2>
                            <a class="verTodos pngfix" href="http://test.www.deautos.com/autos/UIYY<%=Model.UserId%>" title="Ver todos">Ver todos</a>
                   		</div>
                        
						<div class="main chico">
                        	<ul class="destacados">
                                
                                <%foreach (var publication in (List<Publication>)ViewData["Publications"])
                                {%>
                                    <li class="fila1 first clearfix">
                                	    <%--<div class="avisosImg"><a href="#" title="#"><img src="../../../Content/images/img_reemplazable_4.gif" alt="deautos"></a></div>--%>
                                        <% Html.RenderPartial("PublicationCarPhotoSection", publication); %>
                                        <div class="avisosCont">
                                    	    <a href="<%=publication.UrlDetails %>" title="Renault Scenic 2 RXE PRIVILEGE"><h3><%=Html.Encode(publication.VehicleMakeText)%>
                                                                <%=Html.Encode(publication.VehicleModelText)%>
                                                                <%=Html.Encode(publication.VehicleVersionText)%></h3></a>
                                            <span class="datos"><%=publication.VehicleFuelTypeText %> | <%=publication.VehicleYear %> | <%=publication.VehicleKm %> Km</span>
                                            <h5 class="precio"><%=publication.VehiclePrice!=0?Html.Encode(publication.VehiclePrice.WithThousandsSeparator().AsPrice(publication.CVehiclePriceCurrency)):"A Consultar"%></h5>
                                        </div>
                                    </li>   
                              <%} %>

                            	<%--<li class="fila1 first clearfix">
                                	<div class="avisosImg"><a href="#" title="#"><img src="../../../Content/images/img_reemplazable_4.gif" alt="deautos"></a></div>
                                    <div class="avisosCont">
                                    	<a href="#" title="Renault Scenic 2 RXE PRIVILEGE">Renault Scenic 2 RXE PRIVILEGE</a>
                                        <span class="datos">Nafta | 2005 | 88000 Km</span>
                                        <h5 class="precio">U$S 50.900</h5>
                                    </div>
                                </li>
                                
                                <li class="fila1 clearfix">
                                	<div class="avisosImg"><a href="#" title="#"><img src="../../../Content/images/img_reemplazable_4.gif" alt="deautos"></a></div>
                                    <div class="avisosCont">
                                    	<a href="#" title="Renault Scenic 2 RXE PRIVILEGE">Renault Scenic 2 RXE PRIVILEGE</a>
                                        <span class="datos">Nafta | 2005 | 88000 Km</span>
                                        <h5 class="precio">U$S 50.900</h5>
                                    </div>
                                </li>
                                
                                <li class="fila1 clearfix">
                                	<div class="avisosImg"><a href="#" title="#"><img src="../../../Content/images/img_reemplazable_4.gif" alt="deautos"></a></div>
                                    <div class="avisosCont">
                                    	<a href="#" title="Renault Scenic 2 RXE PRIVILEGE">Renault Scenic 2 RXE PRIVILEGE</a>
                                        <span class="datos">Nafta | 2005 | 88000 Km</span>
                                        <h5 class="precio">U$S 50.900</h5>
                                    </div>
                                </li>
                                
                                <li class="fila1 clearfix">
                                	<div class="avisosImg"><a href="#" title="#"><img src="../../../Content/images/img_reemplazable_4.gif" alt="deautos"></a></div>
                                    <div class="avisosCont">
                                    	<a href="#" title="Renault Scenic 2 RXE PRIVILEGE">Renault Scenic 2 RXE PRIVILEGE</a>
                                        <span class="datos">Nafta | 2005 | 88000 Km</span>
                                        <h5 class="precio">U$S 50.900</h5>
                                    </div>
                                </li>
                                
                                <li class="fila1 last clearfix">
                                	<div class="avisosImg"><a href="#" title="#"><img src="../../../Content/images/img_reemplazable_4.gif" alt="deautos"></a></div>
                                    <div class="avisosCont">
                                    	<a href="#" title="Renault Scenic 2 RXE PRIVILEGE">Renault Scenic 2 RXE PRIVILEGE</a>
                                        <span class="datos">Nafta | 2005 | 88000 Km</span>
                                        <h5 class="precio">U$S 50.900</h5>
                                    </div>
                                </li>--%>
                                
                            </ul>
                        </div>                	
                </div>
                
            </div>
                <%} %>
            <!--<div class="colRight">
              col right
            </div> -->
        </div>
                <!--FIN CONTEINER -->
	</div>
</div>
</asp:Content>
