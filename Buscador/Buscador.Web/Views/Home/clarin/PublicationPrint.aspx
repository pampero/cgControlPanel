<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Buscador.Domain" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%@ Import Namespace="System.Linq" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
    
    <link type="text/css" rel="stylesheet" href="../../../Content/css/deautos.css" media="screen" />
    <link type="text/css" rel="stylesheet" href="../../../Content/css/comparar.css" media="screen" />  
    <link rel="Stylesheet" type="text/css" href="../../../Content/css/print.css"/>
     
        <title>DeAutos</title>
</head>
<body>
    <div class="layout fichaImprimir">
	    <div class="Botonera">
		    <ul class="clearfix">
			    <li>
				    <div class="botCont">
                        <a class="btnNarChico" href="javascript:window.print();" title="Imprimir">
                            <span class="L pngfix"></span>
                            <span class="M">Imprimir</span>
                            <span class="R pngfix"></span>
                        </a>
                    </div>
			    </li>
			    <li><a href="#" title="Volver" class="Cerrar" onclick="javascript:window.close();">Volver</a></li>
		    </ul>
	    </div>
        
	    <div class="Contenido">  
        	<h1 class="deautosLogo"><img class="pngfix" src="../../../Content/images/fd_ficha_imprimir_logo_deautos.png" alt="deautos" /></h1>
			<div class="principal">
            	<div class="tituloYPrecioCont">
                    <h3 class="first"><%=Model.VehicleDescription%></h3>
                    <div class="precio">
                        <h3><%=Model.VehiclePrice != 0 ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency)) : "A Consultar"%></h3>
                    </div>
                </div>
                <div class="contPrincipal">
                    <div class="fotocont">
                    	<img src="<%=ViewData["ImagesUrl"] %>/PublishableItemImage/390x300/<%=Model.PublishableItemId%>_1.jpg" alt="deautos" />
                    </div>
                    <ul>
                        <%if (Model.VehicleType == 1)
                          {%>
                        <li>
                        	<label>Kilometraje: </label>
                            <%=Model.VehicleKm.WithThousandsSeparator() + " km"%>
                        </li>
                        <li>
                        	<label>Año: </label>
                            <%=Model.VehicleYear.ToString()%>
                        </li>
                        <%}%>
                    	<li>
                        	<label>Combustible: </label>
                            <%=Model.VehicleFuelTypeText%>
                        </li>
                        <li>
                        	<label>Segmento: </label>
                            <%=Model.VehicleSegmentText %>
                        </li>
                        <li>
                        	<label>Precio: </label>
                            <%=Model.VehiclePrice != 0 ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency)) : "A Consultar"%>
                        </li>
                        <li>
                        	<label>Ubicación: </label>
                            <%=Html.ItemLocation(Model) %>
                        </li>
                        <li>
                        	<label>Forma de pago:  </label>
                            <%=Model.PaymentMethodText.ToProper() %>
                        </li>
                        <li>
                        	<label>Anticipo: </label>
                            <%=Model.FundingAdvance != 0 ? Html.Encode(Model.FundingAdvance.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency)) : "A Consultar"%>
                        </li>
                        <li>
                        	<label>Cuota desde: </label>
                           <%=Model.FromQuote != 0 ? Html.Encode(Model.FromQuote.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency)) : "A Consultar"%>
                        </li>
               
                    </ul>
                </div>
                

                 <%if (Model.UserViewContactData)
                 {
                    if (Model.UserType == "AgencyUser")
                    {%>
                        <div class="contactarVendedor conce"><!--AGREGAR LA CLASE "conce" PARA MOSTRAR LA CINTA -->
                    <%}else{%>
                        <div class="contactarVendedor"><!--AGREGAR LA CLASE "conce" PARA MOSTRAR LA CINTA -->
                    <%}%>
                	    <h3>Contactar al Vendedor</h3>
                        <div class="fotoyVendedor">
                    <%if (Model.UserType == "AgencyUser")
                    {%>
                    	<div class="foto">
                        	<img src="<%=ViewData["ImagesUrl"] + "/UserImage/80x60/" + Model.LogoId + "_logo.jpg"%>" alt="deautos" />
                        </div>
                    <%}%>
                        <ul>
                            <li>
                                <p><%=Model.UserDescription%></p>
                            </li>
                            <li>
                                <label>Teléfono:</label><%=Model.UserPhone%>
                            </li>
                            <li>
                                <label>Nextel ID:</label><%=Model.UserNextelId%>
                            </li>
                            <li>
                                <label>Horario de contacto:</label>Lunes a Viernes de 9hs a 18hs
                            </li>
                            <li>
                                <label>E-mail:</label><%=Model.UserEmail%>
                            </li>
                        </ul>
                        <div class="cintaConce pngfix"></div>
                            </div>
                        </div>
                <%}%>
                
                <div class="comun mod2">
                         <div class="cajaGris clearfix">
                                
                                
                                <div class="titular gris clearfix">
                                    <h4 class="avisos">Más info</h4>
                                </div>
                         </div>
                         <div class="inner masinfo">
                         	<p><%=Model.SellerComment%></p>
                            
                             <% if (Model.Features.Count > 0) { %>
                                <p class="caraEspe">Características especiales: 
                                
                                <% var features = new List<string>(); %>
                                <% foreach (var feature in Model.Features) 
                                {
                                    features.Add(feature.FeatureKey.Localize());
                                }
                                %>

                                <b><%= string.Join(", ", features.ToArray()) %></b>

                                </p>
                            <% } %>
                            
                         </div>
                         
                    </div>
                    
                    
                    <div class="comun">
                         <div class="cajaGris clearfix">
                                <div class="titular gris clearfix">
                                    <h4 class="avisos">Equipamiento</h4>
                                </div>
                         </div>
                         <div class="inner masinfo">
                         	<h4>Confort</h4>                           
                            <ul>
                                <%foreach (var spec in Model.EquipmentAttributes.Where(x => x.AttrType =="Confort").ToList())
                                {%>
                                    <li><p><%=spec.AttrValue%></p></li>                                              
                                <%}%>
                            </ul>
                         </div>
                         
                         <div class="inner masinfo">
                         	<h4>Seguridad</h4>
                            <ul>
                            	<%foreach (var spec in Model.EquipmentAttributes.Where(x => x.AttrType =="Seguridad").ToList())
                                {%>
                                    <li><p><%=spec.AttrValue%></p></li>                                              
                                <%}%>
                            </ul>
                         </div>
                         
                         <div class="inner masinfo">
                         	<h4>Exterior</h4>
                            <ul>
                            	<%foreach (var spec in Model.EquipmentAttributes.Where(x => x.AttrType =="Exterior").ToList())
                                {%>
                                    <li><p><%=spec.AttrValue%></p></li>                                              
                                <%}%>
                            </ul>
                            
                            <div class="flechadepublicacion">
                            	<label>Fecha publicación:</label><strong><%=Model.PublicationDate.ToShortDateString() %></strong><span> | </span>
                                <label>Visitas:</label><strong><%=Model.PublicationVisitorsQty %></strong>
                            </div>
                         </div>
                         
                    </div>
                    
<%--                    <!--
                    <div class="comun mod2">
                         <div class="cajaGris clearfix">
                            <div class="titular gris clearfix">
                                <h4 class="avisos">Datos de catálogo</h4>
                            </div>
                         </div>
                         <div class="inner masinfo">
                         	<p><%=Model.CatalogDescription %></p>
                         </div>
                    </div>-->
                    
                    <!--CROQUIS -->
                     
                     	<!--<div class="croquis">
                        	<img src="<%=Model.TechnicalMeasureImage %>" alt="deautos" />
                        </div>-->
                     <!-- FIN CROQUIS -->
                     
                     <!--ESPECIFICACIONES > EQUIPAMIENTO -->
                     	<!--<div class="especificaciones">
                        	
                        	<div class="comun">
                                <div class="titular gris clearfix">
                                   <h5>Especificaciones</h5><h4><span> > </span> Equipamiento</h4>
                                </div>
                        
                                 <div class="inner masinfo">
                                    <h4>Confort y Convivencia</h4>
                                    <ul>
                                        <%foreach (var spec in Model.Specs.Where(x => x.AttrType =="Confort").ToList())
                                          {%>
                                                <li><p><%=spec.AttrValue%></p></li>                                              
                                          <%}%>
                                    </ul>
                                 </div>
                   			</div>
                            
                            <div class="comun mod3">
                                
                                 <div class="inner masinfo">
                                    <h4>Exterior</h4>
                                    <ul>
                                       <%foreach (var spec in Model.Specs.Where(x => x.AttrType =="Exterior").ToList())
                                      {%>
                                        <li><p><%=spec.AttrValue%></p></li>                                              
                                      <%}%>		
                                    </ul>
                                 </div>
                   			</div>
                            
                            <div class="comun mod3">
                                
                                 <div class="inner masinfo">
                                    <h4>Seguridad</h4>
                                    <ul>
                                        <%foreach (var spec in Model.Specs.Where(x => x.AttrType =="Seguridad").ToList())
                                        {%>
                                        <li><p><%=spec.AttrValue%></p></li>                                              
                                        <%}%>		
                                    </ul>
                                 </div>
                   			</div> 
                        <div>-->
                      <!-- FIN ESPECIFICACIONES > EQUIPAMIENTO -->
                      
                      
                      <!--EQUIPAMIENTO FICHAS TECNICAS -->
                      
                      <!--	<div class="comun">
                                <div class="titular gris clearfix">
                                   <h5>Especificaciones </h5><h4><span>></span> Ficha Técnica</h4>
                                </div>-->
                        
                                 <!--FICHAS -->
                                 
                                 <!--	<div class="fichatecnicaOpen">
							<div class="tecnica">
								<h4>Motor</h4>
								<ul>
									<li class="gris">
										Alimentación  <p>Inyección directa turbo </p>
									</li>
									<li class="">
										Motor  <p>1,8L</p>
									</li>
									<li class="gris">
										Combustible  <p>Nafta</p>
									</li>
									<li class="">
										Posición  <p>Dealntera</p>
									</li>
									<li class="gris">
										Cilindros  <p>4</p>
									</li>
									<li class="">
										Cilindrada  <p>1798 cc</p>
									</li>
									<li class="gris">
										Válvulas  <p>16</p>
									</li>
									<li class="">
										Potencia  <p>160 cv</p>
									</li>
									<li class="gris">
										Torque  <p>250/1500-4500 nm/rpm </p>
									</li>
									
								</ul>
							</div>
							
							<div class="tecnica">
								<h4>Transmisión y Chasis</h4>
								<ul>
									<li class="gris">
										Transmisión  <p>Manual</p>
									</li>
									<li class="">
										Marchas  <p>6</p>
									</li>
									<li class="gris">
										Tracción  <p>Delantera</p>
									</li>
									<li class="">
										Frenos delanteros  <p>Discos ventilados</p>
									</li>
									<li class="gris">
										Frenos traseros  <p>Discos</p>
									</li>
									<li class="">
										Suspensión delantera  <p>Independiente de 5 brazos </p>
									</li>
									<li class="gris">
										Suspensión trasera  <p>Independiente de brazos Neumáticos</p>
									</li>
									<li class="">
										Neumáticos  <p>225/55 R16</p>
									</li>
									
								</ul>
							</div>
							
							<div class="tecnica">
								<h4>Performance y Consumo</h4>
								<ul>
									<li class="gris">
										Velocidad máxima  <p>225 km/h</p>
									</li>
									<li class="">
										Aceleración 0-100 km/h  <p>8,6 seg </p>
									</li>
									<li class="gris">
										Consumo mixto <p>7,1 lts / 100 kms </p>
									</li>
								</ul>
							</div>
							
							<div class="tecnica">
								<h4>Dimensiones y Capacidades</h4>
								<ul>
									<li class="gris">
										Puertas  <p>4</p>
									</li>
									<li>
										Plazas  <p>5</p>
									</li>
									<li class="gris">
										Filas de asientos  <p>2</p>
									</li>
									<li>
										Largo / Ancho / Alto / Distancia entre ejes  <p>ejes</p>
									</li>
                                    <li class="gris">
										Peso  <p>1410 kg</p>
									</li>
                                    <li>
										Tanque de combustible  <p>65 lts</p>
									</li>
									
								</ul>
							</div>
							
						</div>-->
                                 <!--FIN FICHAS -->
                   			<!--</div>-->
                      
                      <!--FIN EQUIPAMIENTO FICHAS TECNICAS -->
                
                
                		<!--COLORES -->
                        <!--	<div class="comun">
                                <div class="titular gris clearfix">
                                   <h5>Especificaciones</h5><h4><span> > </span> Colores</h4>
                                </div>
                        
                                 <div class="coloresOpen">
                                    <ul>
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_aguamarina.png" alt="Aguamarina"  width="21" height="21" />
                                            <span>Aguamarina</span>
                                        </li>
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_amarillo.png" alt="Amarillo"  width="21" height="21" />
                                            <span>Amarillo</span>
                                        </li>
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_azul.png" alt="Azul"  width="21" height="21" />
                                            <span>Azul</span>
                                        </li>
                                       
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_berenjena.png" alt="Berenjena"  width="21" height="21" />
                                            <span>Berenjena</span>
                                        </li>
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_bicolor.png" alt="Bicolor"  width="21" height="21" />
                                            <span>Bicolor</span>
                                        </li>
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_blanco.png" alt="Blanco"  width="21" height="21" />
                                            <span>Blanco</span>
                                        </li>
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_bordo.png" alt="Bordo"  width="21" height="21" />
                                            <span>Bordo</span>
                                        </li>
                                        <li>
                                            <img class="pngfix" src="../../../Content/images/img_fichas_colores_celeste.png" alt="Celeste"  width="21" height="21" />
                                            <span>Celeste</span>
                                        </li>
                                    </ul>
							
									<p class="paleta">La paleta de colores es de caracter ilustrativo.</p>
							
								</div>
                                 
                   			</div>-->
                        <!--FIN COLORES -->
                        
                        
                        <!--REVIEW -->
                        	<!--	<div class="reviewInner">
							<div class="titulCont">
								<h3>Review</h3>
								
							</div>
							
							<div class="left">
								<div class="cajaGris">
									
									<div class="estrellotasCont clearfix">
					                     <%for (int i = 0; i < Model.AverageRanking.IntegerPart(); i++)
                                          {%>
                                	        <span class="pngfix active" title="#"></span>
                                          <%}%>
                                        <%if (Model.AverageRanking.DecimalPart() > 0)
                                          {%>
                                            <span class="pngfix mitad" title="#"></span>
                                          <%}%>
                                          <%for (int j = 0; j < 5 - Model.AverageRanking.IntegerPart() - (Model.AverageRanking.DecimalPart() > 0 ? 1 : 0); j++)
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
													<div class="relleno <%=Model.ConfortRanking.AsText() %>">
													</div>
												</div>
											</div>
											<div class="inside">
												<label>Diseño</label>
												<div class="barra">
													<div class="relleno <%=Model.DesignRanking.AsText() %>">
													</div>
												</div>
											</div>
											<div class="inside">
												<label>Seguridad</label>
												<div class="barra">
													<div class="relleno <%=Model.SecurityRanking.AsText() %>">
													</div>
												</div>
											</div>
											<div class="inside">
												<label>Precio</label>
												<div class="barra">
													<div class="relleno <%=Model.PriceRanking.AsText() %>">
													</div>
												</div>
											</div>
											
										</div>
			                        </div>
			                    </div>
							</div>
							
							<div class="right">
								<div class="blok1">
                                
                                	<div class="comentExperto">
                                    	<p>Comentario del experto</p>
                                        <div class="flechadepublicacion">
                                            <label>Fecha:</label>
                                            <label><%=Model.ExpertReviewDate.ToShortDateString() %></label>
                           				 </div>
                                    </div>
                                    
									<p><%=Model.ExpertReview %></p>
								</div>
								<div class="blok2">
									<div class="positivo">
										<h5>Positivo</h5>
										<ul>
											<%foreach (var positive in Model.Positives)
                                            {%>
                                               <li><span><%=positive%></span></li>
                                            <%} %>
										</ul>
									</div>
									
									<div class="negativo">
										<h5>Negativo</h5>
										<ul>
											 <%foreach (var negative in Model.Negatives)
                                            {%>
                                               <li><span><%=negative%></span></li>
                                            <%} %>
										</ul>
									</div>
								</div>
							</div>
						</div>    -->                    
                        <!--FIN REVIEW -->
          <!--  </div>
	    </div>-->--%>
        
        
	    <div class="Botonera">
		    <ul class="clearfix">
			    <li>
				     <div class="botCont mod">
                        <a class="btnNarChico" href="#" title="Imprimir">
                            <span class="L pngfix"></span>
                            <span class="M">Imprimir</span>
                            <span class="R pngfix"></span>
                        </a>
                    </div>
			    </li>
			    <li><a href="#" title="Cerrar" class="Cerrar" onclick="javascript:window.close();">Cerrar</a></li>
		    </ul>
	    </div>
    </div>
    </div>
    </body>
</html>

