<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<!--Cont Head -->
		        <div class="ContHead">
        	<div class="path">
            	<%=Html.BreadcrumbFor(Model)%>
               
            </div>
            
            <div class="volverAlResultado">[ <a href="#" title="volver al resultado"> « volver al resultado</a> ]
            </div>
            
            <div class="facebookConteiner "><!--AGREGAR EL MODIFICADOR "bigResolution" AL DIV CLASS="facebookConteiner" PARA OCULTAR LOS ICONOS CHICOS DE FACEBOOK Y MOSTRAR LOS ICONOS DE FACEBOOK VERTICALES QUE APARECEN DEL LADO IZQUIERDO DE LA PANTALLA-->
                <div class="iconosFacebook">
                   <img style="float:left;" src="<%=Url.Content("~/Content/images/fd_facebook_links_meGusta.gif") %>" alt="facebook megusta" />
                   <img  style="float:left;" src="<%=Url.Content("~/Content/images/fd_facebook_links_votos.gif")%>" alt="facebook votos" />
                   <span class="pipe2">|</span>
                   <a class="share" href="#" title="Compartir"></a>
                      <!--REEMPLAZAR ESTA IMAGEN DE FACEBOOK, POR EL CODIGO DE LA CAJA CORRESPONDIENTE -->
                </div>
                 <div class="facebookVertical pngfix">
                        <div class="Cont">
                            <div class="bordes">
                            	<div class="separador">
                                	<img src="<%=Url.Content("~/Content/images/fd_fichas_facebook_vertical1.gif")%>" alt="facebook" />
                                </div>
                            	<div class="separador">
                                	<img src="<%=Url.Content("~/Content/images/fd_fichas_facebook_vertical2.gif")%>" alt="facebook" />
                                </div>
                                <div class="separador last">
                                	<a class="compartir" href="#" title="Compartir"></a>
                                </div>
                                
                               
                               
                            </div>
                        </div>
                  </div>
            </div>
            
            
        </div>
        		<!--fin Cont Head -->