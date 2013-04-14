<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Domain" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="Buscador.Web.Views.Home.Helpers" %>

<!--CONTENEDOR DE DESPLEGADOS -->
<div class="desplegadosContenedor fotos" id="Tabsdiv"><!--IMPORTANTE AGREGAR LOS SIGUIENTES MODIFICADORES A "desplegadosContenedor" PARA HABILITAR LA CORRESPONDIENTE CAJA: PARA LA CAJA FOTOS: AGREGAR EL MOD "fotos" ,PARA VIDEOS  EL MOD"videos", PARA ESPECIFICACIONES "especific", PARA 360 "trecientos60" PARA REVIEW "review"-->
                    <%if(Model.VehiclePicQty>0)
                    {%>
                    <div class="Desplegado fotosCont">
                        <div class="slidesCont">
                        	<div class="imgageCont">
                            	<div class="sliderImage">
											<ul id="exepcion">
                                                <%for (var i = 1; i <= Model.VehiclePicQty; i++)%>
                                                <%{%>
												    <li>
                                                        <table width="520px" height="390px">
                                                            <tr>
                                                                <td align="center" valign="middle">
                                                                   <img  src="<%=ViewData["ImagesUrl"] %>/PublishableItemImage/520x390/<%=Model.PublishableItemId%>_<%=i%>.jpg" alt="<%=Model.VehicleDescription %>" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </li>
                                                <%}%>
											</ul>
										</div>
                            	<div class="btnL active"><span class="pngfix btnSlideL" title="Anterior"></span></div>
                                <div class="btnR active"><span class="pngfix btnSlideR active" title="Siguiente"></span></div><!--AGREGAR LA CALSE "active" AL "A" PARA ACTIVAR LA FLECHA A CELESTE -->
                               
                                	<div class="enumerar">
                                        <div class="L"></div>
                                    	<span>1</span><p></p>
                                        <div class="R"></div>
                                    </div>

                                <div class="slideImg">
                                		<!--AGREGAR LA CLASE"active" AL DIV CONTENEDOR DE LA IMAGEN PARA GENERARLE UN BORDE -->
                                		<ul>
                                            <%for (var i = 1; i <= Model.VehiclePicQty; i++)%>
                                            <%{
                                                if(i == 1)
                                                {%>
                                                    <li class="first">
                                                <%}else if(i == Model.VehiclePicQty)
                                                {%>
                                                    <li class="last">
                                                <%}else
                                                {%>
                                                    <li>
                                                <%}%>
                                                <img src="<%=ViewData["ImagesUrl"] %>/PublishableItemImage/102x76/<%=Model.PublishableItemId%>_<%=i%>.jpg" alt="#" /><span class="borde"></span></li>
                                             <%}%>   
                                		</ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%}
                    else{%>
                    <div class="Desplegado fotosCont">
                        <div class="slidesCont">
                        	<div class="imgageCont">
                        		<div class="sliderImage2">
											<ul id="Ul1">                                                
												    <li class=""><img style="height:390px" width="520px" src="<%=ViewData["ImagesUrl"] %>/PublishableItemImage/390x300/980155_1.jpg" alt="#title"></li>                                                
											</ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%}%>
                    
                     <div class="Desplegado videosCont">
                    	<div class="video">
                        	<!--REEMPLAZAR ESTA IMAGEN CON EL PLAYER DE VIDEO CORRESPONDIENTE -->
							<%--<img src="<%=Model.SegmentCatalogInfo != null ? Model.SegmentCatalogInfo.LinkToVideo : "" %>" width="512" height="312" alt="video" />--%>
                            
                            <%= Model.SegmentCatalogInfo != null ? 
                                Html.Video(Model.SegmentCatalogInfo.LinkToVideo, "512", "312", 
                                                            Model.FirstImageExists ? 
                                                                                        string.Concat(ViewData["ImagesUrl"],"/PublishableItemImage/390x300/",Model.PublishableItemId,"_1.jpg") :
                                                                                                                        "http://prepro.staticn.deautos.com/images/negra.jpg") : string.Empty %>
						</div>
                    </div>
                    
                     <div class="Desplegado EspecificacionesCont equip" id="Subtabsdiv"><!--****IMPORTANTE **** AGREGARLE A ESTE DIV LA CLASE "equip" o "ficha" o "colores" SEGUN CORRESPONDA PARA MOSTRAR EL CONTENIDO DE LAS SOLAPITAS "EQUIPAMIENTO", "FICHA TECNICA" O "COLORES" -->
                    	<div class="innerSolapas">
							<ul>
                              <% if (Model.VersionCatalogInfo != null && Model.VersionCatalogInfo.EquipmentAttributes.Count > 0) {%>
								<li class="first active" onclick="javascript:ChangeSubTab('equip')" id="equip"> <a href="#" title="Equipamiento">Equipamiento</a><!-- AGREGAR LA CLASE "active" AL LI PARA UNDIR LA SOLAPITA-->
										<p class="btnNarChico"  title="Equipamiento">
				                            <span class="L pngfix"></span>
				                            <span class="M">Equipamiento</span>
				                            <span class="R pngfix"></span>
				                        </p>
                                </li><!-- AGREGAR LA CLASE "active" AL LI PARA UNDIR LA SOLAPITA-->
                                <span class="pipe">|</span>
                               <% } %>  
                               <% if (Model.VersionCatalogInfo != null){%>                               
								<li class="center" onclick="javascript:ChangeSubTab('ficha')" id="ficha"> <a href="#" title="Ficha Técnica">Ficha Técnica</a> 
										<p class="btnNarChico"  title="Ficha Técnica">
				                            <span class="L pngfix"></span>
				                            <span class="M">Ficha Técnica</span>
				                            <span class="R pngfix"></span>
										</p>
								</li>
                                <span class="pipe">|</span>            
                                <% } %>                    
                                <% if (Model.SegmentCatalogInfo != null && Model.SegmentCatalogInfo.Colours.Count > 0 && Model.VehicleType == 2) {%>
								<li class="last" onclick="javascript:ChangeSubTab('colores')" id="colores"> <a href="#" title="Colores">Colores</a> <!-- AGREGAR LA CLASE "active" AL LI PARA UNDIR LA SOLAPITA-->
										<p class="btnNarChico" title="Colores">
				                            <span class="L pngfix"></span>
				                            <span class="M">Colores</span>
				                            <span class="R pngfix"></span>
										</p>
								</li>
                                <% } %>
							</ul>
						</div>
						<!--EQUIPAMIENTO CATALOGO-->
						<div class="equipamientoOpen">							
                                   <%if (Model.VersionCatalogInfo != null && Model.VersionCatalogInfo.EquipmentAttributes.Where(x => x.AttrType == "Confort").ToList().Count() > 0) {%>
                                   <div class="listado">
									<h4>Confort y Convivencia</h4>
									<ul>
                                       
                                            <%foreach (var spec in Model.VersionCatalogInfo.EquipmentAttributes.Where(x => x.AttrType == "Confort").ToList())
                                              {%>
                                                <li><p><%=spec.AttrValue%></p></li>                                              
                                            <%}%>				                               
									</ul>									
                                    </div>								
                                    <%} %>                    						    
							   <%if (Model.VersionCatalogInfo != null && Model.VersionCatalogInfo.EquipmentAttributes.Where(x => x.AttrType == "Exterior").ToList().Count() > 0){%>
                               <div class="listado">
								<h4>Exterior</h4>
								<ul>
                                
									 <%foreach (var spec in Model.VersionCatalogInfo.EquipmentAttributes.Where(x => x.AttrType == "Exterior").ToList())
                                        {%>
                                         <li><p><%=spec.AttrValue%></p></li>                                              
                                        <%}%>											                                    
								</ul>
                                </div>                           
                                <% } %>																					
                             <%if (Model.VersionCatalogInfo != null && Model.VersionCatalogInfo.EquipmentAttributes.Where(x => x.AttrType == "Seguridad").ToList().Count() > 0) {%>
                             <div class="listado">
								<h4>Seguridad</h4>
								<ul>                                  
									<%foreach (var spec in Model.VersionCatalogInfo.EquipmentAttributes.Where(x => x.AttrType == "Seguridad").ToList()){%>
                                            <li><p><%=spec.AttrValue%></p></li>                                              
                                       <%}%>								                                 
								</ul>
                             </div>                   
                            <% } %>    	
                       </div>
						
                        <%Model.ActualFeatureIndexCounter = 0; %>

						<div class="fichatecnicaOpen">
                          	<div class="tecnica" <%=Model.HideFeatureCategory("Motor")%>>
								<h4>Motor</h4>
								<ul>
                                    <%if (Model.VersionCatalogInfo != null) {%>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Alimentation,"gris")%>>
										<span>Alimentación</span>  <p><%=Model.VersionCatalogInfo.Alimentation%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Engine,"gris")%> >
										<span>Motor</span>  <p><%=Model.VersionCatalogInfo.Engine%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Fuel,"gris")%>>
										<span>Combustible</span>  <p><%=Model.VersionCatalogInfo.Fuel%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Position,"gris")%>>
										<span>Posición</span>  <p><%=Model.VersionCatalogInfo.Position%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Cylinder,"gris")%>>
										<span>Cilindros/válvulas </span>  <p><%=Model.VersionCatalogInfo.Cylinder%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Displacement,"gris")%>>
										<span>Cilindrada</span>  <p><%=Model.VersionCatalogInfo.Displacement%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Power,"gris")%>>
										<span>Potencia</span>  <p><%=Model.VersionCatalogInfo.Power%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Torque,"gris")%>>
										<span>Torque</span>  <p><%=Model.VersionCatalogInfo.Torque%></p>
									</li>
									<% } %>
								</ul>
							</div>
                             <%Model.ActualFeatureIndexCounter = 0; %>
							 <div class="tecnica" <%=Model.HideFeatureCategory("Transmission")%>>
								<h4>Transmisión y Chasis</h4>
								<ul>
                                    <%if (Model.VersionCatalogInfo != null) {%>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Gearbox,"gris")%>>
										<span>Caja</span>  <p><%=Model.VersionCatalogInfo.Gearbox %></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Marches,"gris")%>>
										<span>Marchas</span>  <p><%=Model.VersionCatalogInfo.Marches%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Traction,"gris")%>>
										<span>Traccion </span>  <p><%=Model.VersionCatalogInfo.Traction%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.FrontBrakes,"gris")%>>
										<span>Frenos delanteros </span>  <p><%=Model.VersionCatalogInfo.FrontBrakes%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.BackBrakes,"gris")%>>
										<span>Frenos traseros</span>  <p><%=Model.VersionCatalogInfo.BackBrakes%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.FrontSuspension,"gris")%>>
										<span>Suspension delantera </span>  <p><%=Model.VersionCatalogInfo.FrontSuspension%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.BackSuspension,"gris")%>>
										<span>Suspension trasera</span>  <p><%=Model.VersionCatalogInfo.BackSuspension%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Tires,"gris")%>>
										<span>Neumaticos</span>  <p><%=Model.VersionCatalogInfo.Tires%></p>
									</li>
                                    <% } %>
								</ul>
							</div>
                             <%Model.ActualFeatureIndexCounter = 0; %>
							<div class="tecnica" <%=Model.HideFeatureCategory("Performance")%> >
								<h4>Performance y Consumo</h4>
								<ul>
                                     <%if (Model.VersionCatalogInfo != null) {%>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.MaximumSpeed,"gris")%>>
										<span>Velocidad max (km/h) </span>  <p><%=Model.VersionCatalogInfo.MaximumSpeed%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Acceleration,"gris")%>>
										<span>Aceleracion 0 a 100</span>  <p><%=Model.VersionCatalogInfo.Acceleration%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.ZeroKmH,"gris")%>>
										<span>0 km/h</span>  <p><%=Model.VersionCatalogInfo.ZeroKmH%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.ConsumptionCity,"gris")%>>
										<span>Consumo en cuidad</span>  <p><%=Model.VersionCatalogInfo.ConsumptionCity%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.ConsumptionRoad,"gris")%>>
										<span>Consumo en ruta  </span>  <p><%=Model.VersionCatalogInfo.ConsumptionRoad%></p>
									</li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.ConsumptionCombined,"gris")%>>
                                    	<span>Consumo combinado </span> <p><%=Model.VersionCatalogInfo.ConsumptionCombined%></p>
                                    </li>
                                    <% } %>									
								</ul>
							</div>
							
                            <%Model.ActualFeatureIndexCounter = 0; %>
							
							 <div class="tecnica" <%=Model.HideFeatureCategory("Dimensiones")%> >
								<h4>Dimensiones y Capacidades</h4>
								<ul>
                                    <%if (Model.VersionCatalogInfo != null) {%>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Doors,"gris")%>>
										<span>Puertas</span>  <p><%=Model.VersionCatalogInfo.Doors %></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Squares,"gris")%>>
										<span>Plazas</span>  <p><%=Model.VersionCatalogInfo.Squares%></p>
									</li>
									<li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.RowSeats,"gris")%>>
										<span>filas de asientos</span>  <p><%=Model.VersionCatalogInfo.RowSeats%></p>
									</li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Long,"gris")%>>
                                    	<span>Largo (mm)</span>  <p><%=Model.VersionCatalogInfo.Long%></p>
                                    </li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Width,"gris")%>>
                                    	<span>Ancho (mm) </span>  <p><%=Model.VersionCatalogInfo.Width%></p>
                                    </li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Height,"gris")%>>
                                    	<span>Alto (mm) </span>  <p><%=Model.VersionCatalogInfo.Height%></p>
                                    </li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Wheelbase,"gris")%>>
                                    	<span>Distancia entre ejes (mm) </span>  <p><%=Model.VersionCatalogInfo.Wheelbase%></p>
                                    </li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.UnladenWeight,"gris")%>>
                                    	<span>Peso en vacio (kg) </span>  <p><%=Model.VersionCatalogInfo.UnladenWeight%></p>
                                    </li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.Trunk,"gris")%>>
                                    	<span>Baul</span>  <p><%=Model.VersionCatalogInfo.Trunk%></p>
                                    </li>
                                    <li <%=Model.LineFeatureValues(Model.VersionCatalogInfo.FuelTank,"gris")%>>
                                    	<span>Tanque de combustible </span>  <p><%=Model.VersionCatalogInfo.FuelTank%></p>
                                    </li>
                                    <li>
                                    	<span></span>
                                    </li>
									 <% } %>											
								</ul>
							</div>
						
						 </div>


						<div class="coloresOpen">
                            <%if (Model.SegmentCatalogInfo != null && Model.VehicleType == 2) {%>    
							<ul>                                
                                    <% foreach (var colour in Model.SegmentCatalogInfo.Colours)
                                       {%> 
								    <li>
                                        <img src="<%=Url.Content("~/Content/images/img_fichas_colores_" + HelperExtensionMethods.RemoveWhiteSpace(colour) + ".png")%>" alt="<%=colour%>"  width="21" height="21" />
									    <span><%=colour%></span>
								    </li>					
                                    <% } %>			                               
							</ul>							
							<p class="paleta">La paleta de colores es de caracter ilustrativo.</p>
                             <%} %>
							
						</div>					
                    </div>
                   
                    <div class="Desplegado reviewCont">
                    	<div class="reviewInner">
							<div class="titulCont">
								<h3>Comentario del experto</h3>						
							</div>
                              <% if (Model.SegmentCatalogInfo != null)
                                 {%>
							  <% if (Model.SegmentCatalogInfo.AverageRanking.IntegerPart() > 0 || Model.SegmentCatalogInfo.AverageRanking.DecimalPart() > 0)
            { %>
							  <div class="left">                          
								<div class="cajaGris">
									<div class="Cv Tl"></div>
									<div class="Cv Tr"></div>
									<div class="Cv Bl"></div>
									<div class="Cv Br"></div>
                                    
									    <div class="estrellotasCont clearfix">
                                            <%for (int i = 0; i < Model.SegmentCatalogInfo.AverageRanking.IntegerPart(); i++)
                                              {%>
                                	            <span class="pngfix active" title="#"></span>
                                              <%}%>
                                            <%if (Model.SegmentCatalogInfo.AverageRanking.DecimalPart() > 0)
                                              {%>
                                                <span class="pngfix mitad" title="#"></span>
                                              <%}%>
                                              <%for (int j = 0; j < 5 - Model.SegmentCatalogInfo.AverageRanking.IntegerPart() - (Model.SegmentCatalogInfo.AverageRanking.DecimalPart() > 0 ? 1 : 0); j++)
                                                {%>
                                                <span class="pngfix" title="#"></span>
                                              <%}%>
			                            </div>                                   
			                        
			                        <div class="puntaje clearfix">
			                        	<h5>Puntaje:</h5>
										<div class="porcentaje">
											<div class="inside">
												<label>Confort</label>
												<div class="barra">
													<div class="relleno <%=Model.SegmentCatalogInfo.RankingConfort.AsText() %>">
													</div>
												</div>
											</div>
											<div class="inside">
												<label>Diseño</label>
												<div class="barra">
													<div class="relleno <%=Model.SegmentCatalogInfo.RankingDesign.AsText() %>">
													</div>
												</div>
											</div>
											<div class="inside">
												<label>Seguridad</label>
												<div class="barra">
													<div class="relleno <%=Model.SegmentCatalogInfo.RankingSecurity.AsText() %>">
													</div>
												</div>
											</div>
											<div class="inside">
												<label>Precio</label>
												<div class="barra">
													<div class="relleno <%=Model.SegmentCatalogInfo.RankingPrice.AsText() %>">
													</div>
												</div>
											</div>
											
										</div>
			                        </div>
			                    </div>                            
							</div>
                            <% } %>
                            <% } %>
							<% if (Model.SegmentCatalogInfo!= null && !string.IsNullOrEmpty(Model.SegmentCatalogInfo.ExpertReview)){%>	
							<div class="right">
								<div class="blok1">
                                    <p><%=Model.SegmentCatalogInfo.ExpertReview%></p>
								</div>
								<div class="blok2">
									<div class="positivo">
										<h5>Positivo</h5>
										<ul>
                                            <%foreach (var positive in Model.SegmentCatalogInfo.Positives)
                                              {%>
                                               <li><span><%=positive%></span></li>
                                            <%} %>
										</ul>
									</div>
									
									<div class="negativo">
										<h5>Negativo</h5>
										<ul>
											 <%foreach (var negative in Model.SegmentCatalogInfo.Negatives){%>
                                               <li><span><%=negative%></span></li>
                                            <%} %>
										</ul>
									</div>
								</div>
							</div>
                           <%} %> 
						</div>
                    </div>
 </div>                              
                 
<!--FIN DE CONTENEDOR DE DESPLEGADOS -->