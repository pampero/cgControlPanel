<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>

<!--AGRUPACION DE DATOS DE CATALOGO -->  
<% if(Model.SegmentCatalogInfo != null){ %>
<div class="datosCatalogoCont">            
             <% if (!string.IsNullOrEmpty(Model.SegmentCatalogInfo.ModelDescription))
                {%>       
                     <div class="comun">
                         <div class="cajaGris clearfix">
                                <div class="Cv Tl"></div>
                                <div class="Cv Tr"></div>
                                <div class="Cv Bl"></div>
                                <div class="Cv Br"></div>
                                
                                <div class="titular gris clearfix">
                                    <h4 class="avisos">Datos de catálogo</h4>
                                </div>
                         </div>
                         <div class="inner">
                         	<p><%=Model.SegmentCatalogInfo.Description%></p>
                            
                         </div>
                    </div>
            <% }%>
                    
                    
                    <div class="bn620x60">                      
                       <%=ViewData["bannerIzquierda3"]%>
                	 </div>                   
                     
                     <!--CROQUIS -->                     
                     <% if(!string.IsNullOrEmpty(Model.SegmentCatalogInfo.TechnicalMeasureImage)) {%>
                        <div class="croquis">
                        	<img src="<%=Model.SegmentCatalogInfo.TechnicalMeasureImage%>" alt="croquis" />                           
                        </div>
                    <%  } %>
                     <!-- FIN CROQUIS -->
            </div> 
<%  } %>        
<!--AGRUPACION DE DATOS DE CATALOGO FIN--> 