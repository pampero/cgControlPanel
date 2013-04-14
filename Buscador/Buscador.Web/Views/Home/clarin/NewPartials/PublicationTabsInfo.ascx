<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%@ Import Namespace="System.Linq" %>

<!--CONTENEDOR DE DESPLEGADOS -->
<div class="desplegadosContenedor fotos" id="Tabsdiv"><!--IMPORTANTE AGREGAR LOS SIGUIENTES MODIFICADORES A "desplegadosContenedor" PARA HABILITAR LA CORRESPONDIENTE CAJA: PARA LA CAJA FOTOS: AGREGAR EL MOD "fotos" ,PARA VIDEOS  EL MOD"videos", PARA ESPECIFICACIONES "especific", PARA 360 "trecientos60" PARA REVIEW "review"-->
                    <div class="Desplegado fotosCont">
                        <div class="slidesCont">
                        	<div class="imgageCont">
                            	<div class="sliderImage">
											<ul>
                                                <%for (var i = 1; i <= Model.VehiclePicQty; i++)%>
                                                <%{%>
												    <li><img src="http://imagenes.deautos.com/PublishableItemImage/390x300/<%=Model.PublishableItemId%>_<%=i%>.jpg" alt="#title" /></li>
                                                <%}%>
											</ul>
										</div>
                            	<div class="btnL active"><span class="pngfix btnSlideL" title="#"></span></div>
                                <div class="btnR active"><span class="pngfix btnSlideR active" title="#"></span></div><!--AGREGAR LA CALSE "active" AL "A" PARA ACTIVAR LA FLECHA A CELESTE -->
                               
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
                                                <img src="http://imagenes.deautos.com/PublishableItemImage/102x76/<%=Model.PublishableItemId%>_<%=i%>.jpg" alt="#" /><span class="borde"></span></li>
                                             <%}%>   
                                		</ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                     <div class="Desplegado videosCont">
                    	<div class="video">
                        	<!--REEMPLAZAR ESTA IMAGEN CON EL PLAYER DE VIDEO CORRESPONDIENTE -->
							<img src="<%=Url.Content("~/Content/images/img_fichas_solapa_video_video.jpg")%>" width="512" height="312" alt="video" />
						</div>
                    </div>
                    
                     <div class="Desplegado EspecificacionesCont equip" id="Subtabsdiv"><!--****IMPORTANTE **** AGREGARLE A ESTE DIV LA CLASE "equip" o "ficha" o "colores" SEGUN CORRESPONDA PARA MOSTRAR EL CONTENIDO DE LAS SOLAPITAS "EQUIPAMIENTO", "FICHA TECNICA" O "COLORES" -->
                    	<div class="innerSolapas">
							<ul>
								<li class="first active" onclick="javascript:ChangeSubTab('equip')" id="equip"> <a href="#" title="Equipamiento">Equipamiento</a><!-- AGREGAR LA CLASE "active" AL LI PARA UNDIR LA SOLAPITA-->
										<p class="btnNarChico"  title="Equipamiento">
				                            <span class="L pngfix"></span>
				                            <span class="M">Equipamiento</span>
				                            <span class="R pngfix"></span>
				                        </p>
                                </li><!-- AGREGAR LA CLASE "active" AL LI PARA UNDIR LA SOLAPITA-->
								<li class="center" onclick="javascript:ChangeSubTab('ficha')" id="ficha"> <span class="pipe">|</span><a href="#" title="Ficha Técnica">Ficha Técnica</a> <span class="pipe">|</span>
										<p class="btnNarChico"  title="Ficha Técnica">
				                            <span class="L pngfix"></span>
				                            <span class="M">Ficha Técnica</span>
				                            <span class="R pngfix"></span>
										</p>
								</li>
								<li class="last" onclick="javascript:ChangeSubTab('colores')" id="colores"> <a href="#" title="Colores">Colores</a> <!-- AGREGAR LA CLASE "active" AL LI PARA UNDIR LA SOLAPITA-->
										<p class="btnNarChico" title="Colores">
				                            <span class="L pngfix"></span>
				                            <span class="M">Colores</span>
				                            <span class="R pngfix"></span>
										</p>
								</li>
							</ul>
						</div>
						<!--EQUIPAMIENTO CATALOGO-->
						<div class="equipamientoOpen">
							<div class="listado">
									<h4>Confort y Convivencia</h4>
									<ul>
                                        <%foreach (var spec in Model.Specs.Where(x => x.AttrType =="Confort").ToList())
                                          {%>
                                                <li><p><%=spec.AttrValue%></p></li>                                              
                                          <%}%>										
									</ul>									
						    </div>								
							<div class="listado">
								<h4>Exterior</h4>
								<ul>
									<%foreach (var spec in Model.Specs.Where(x => x.AttrType =="Exterior").ToList())
                                      {%>
                                        <li><p><%=spec.AttrValue%></p></li>                                              
                                      <%}%>											
								</ul>
									
							</div>
							<div class="listado">
								<h4>Seguridad</h4>
								<ul>
									<%foreach (var spec in Model.Specs.Where(x => x.AttrType =="Seguridad").ToList())
                                        {%>
                                        <li><p><%=spec.AttrValue%></p></li>                                              
                                        <%}%>											
								</ul>
									
							</div>
						</div>
						
						<div class="fichatecnicaOpen">
							<div class="tecnica">
								<h4>Motor</h4>
								<ul>
									<li class="gris">
										<span>Alimentación</span>  <p>Inyección directa turbo </p>
									</li>
									<li class="">
										<span>Motor</span>  <p>1,8L</p>
									</li>
									<li class="gris">
										<span>Combustible</span>  <p>Nafta</p>
									</li>
									<li class="">
										<span>Posición</span>  <p>Dealntera</p>
									</li>
									<li class="gris">
										<span>Cilindros/válvulas </span>  <p>4</p>
									</li>
									<li class="">
										<span>Cilindrada</span>  <p>1798 cc</p>
									</li>
									<li class="gris">
										<span>Válvulas</span>  <p>16</p>
									</li>
									<li class="">
										<span>Potencia</span>  <p>160 cv</p>
									</li>
									<li class="gris">
										<span>Torque</span>  <p>250/1500-4500 nm/rpm </p>
									</li>
									
								</ul>
							</div>
							
							<div class="tecnica">
								<h4>Transmisión y Chasis</h4>
								<ul>
									<li class="gris">
										<span>Caja</span>  <p>automaticas</p>
									</li>
									<li class="">
										<span>Marchas</span>  <p>7</p>
									</li>
									<li class="gris">
										<span>Traccion </span>  <p>tracera</p>
									</li>
									<li class="">
										<span>Frenos delanteros </span>  <p></p>
									</li>
									<li class="gris">
										<span>Frenos traseros</span>  <p></p>
									</li>
									<li class="">
										<span>Suspension delantera </span>  <p></p>
									</li>
									<li class="gris">
										<span>Suspension trasera</span>  <p></p>
									</li>
									<li class="">
										<span>Neumaticos</span>  <p></p>
									</li>
								</ul>
							</div>
							
							<div class="tecnica">
								<h4>Performance y Consumo</h4>
								<ul>
									<li class="gris">
										<span>Velocidad max (km/h) </span>  <p>400km/h</p>
									</li>
									<li class="">
										<span>Aceleracion 0 a 100</span>  <p>2 sec</p>
									</li>
									<li class="gris">
										<span>0 km/h</span>  <p>(s)</p>
									</li>
									<li class="">
										<span>Consumo en cuidad</span>  <p>(l/100km)</p>
									</li>
									<li class="gris">
										<span>Consumo en ruta  </span>  <p>(l/100km)</p>
									</li>
                                    <li>
                                    	<span>Consumo combinado </span> <p>(l/100km)</p>
                                    </li>
                                  
									
								</ul>
							</div>
							
							
							<div class="tecnica">
								<h4>Dimensiones y Capacidades</h4>
								<ul>
									<li class="gris">
										<span>Puertas</span>  <p>2</p>
									</li>
									<li class="">
										<span>Plazas</span>  <p></p>
									</li>
									<li class="gris">
										<span>filas de asientos</span>  <p>1</p>
									</li>
                                    <li>
                                    	<span>Largo (mm)</span>  <p>2500</p>
                                    </li>
                                    <li class="gris">
                                    	<span>Ancho (mm) </span>  <p>1800</p>
                                    </li>
                                    <li>
                                    	<span>Alto (mm) </span>  <p>1000</p>
                                    </li>
                                    <li class="gris">
                                    	<span>Distancia entre ejes (mm) </span>  <p>1000</p>
                                    </li>
                                    <li>
                                    	<span>Peso en vacio (kg) </span>  <p>800</p>
                                    </li>
                                    <li class="gris">
                                    	<span>Baul</span>  <p>no</p>
                                    </li>
                                    <li>
                                    	<span>Tanque de combustible </span>  <p>3000cc</p>
                                    </li>
                                    <li>
                                    	<span></span>
                                    </li>
									
									
								</ul>
							</div>
							
						</div>
						
						
						<div class="coloresOpen">
							<ul>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_aguamarina.png")%>" alt="Aguamarina"  width="21" height="21" />
									<span>Aguamarina</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_almendra.png")%>" alt="Almendra" width="21" height="21" />
									<span>Almendra</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_amarillo.png")%>" alt="Amarillo"  width="21" height="21" />
									<span>Amarillo</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_anis.png")%>" alt="Anis"  width="21" height="21" />
									<span>Anis</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_arena.png")%>" alt="Arena"  width="21" height="21" />
									<span>Arena</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_azul.png")%>" alt="Azul"  width="21" height="21" />
									<span>Azul</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_beige.png")%>" alt="Beige"  width="21" height="21" />
									<span>Beige</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_berenjena.png")%>" alt="Berenjena"  width="21" height="21" />
									<span>Berenjena</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_bicolor.png")%>" alt="Bicolor"  width="21" height="21" />
									<span>Bicolor</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_blanco.png")%>" alt="Blanco"  width="21" height="21" />
									<span>Blanco</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_bordo.png")%>" alt="Bordo"  width="21" height="21" />
									<span>Bordo</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_bronce.png")%>" alt="Bronce"  width="21" height="21" />
									<span>Bronce</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_celeste.png")%>" alt="Celeste"  width="21" height="21" />
									<span>Celeste</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_champagne.png")%>" alt="Champagne"  width="21" height="21" />
									<span>Champagne</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_cobre.png")%>" alt="Cobre"  width="21" height="21" />
									<span>Cobre</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_crema.png")%>" alt="Crema"  width="21" height="21" />
									<span>Crema</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_dorado.png")%>" alt="Dorado"  width="21" height="21" />
									<span>Dorado</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_gris.png")%>" alt="Gris"  width="21" height="21" />
									<span>Gris</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_grisIntermedio.png")%>" alt="Gris Intermedio"  width="21" height="21" />
									<span>Gris Intermedio</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_grisOscuro.png")%>" alt="Gris Oscuro"  width="21" height="21" />
									<span>Gris Oscuro</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_grisPlata.png")%>" alt="Gris Plata"  width="21" height="21" />
									<span>Gris Plata</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_grisVerdoso.png")%>" alt="Gris Verdoso"  width="21" height="21" />
									<span>Gris Verdoso</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_marron.png")%>" alt="Marron"  width="21" height="21" />
									<span>Marron</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_mostaza.png")%>" alt="Mostaza"  width="21" height="21" />
									<span>Mostaza</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_naranja.png")%>" alt="Naranja"  width="21" height="21" />
									<span>Naranja</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_negro.png")%>" alt="Negro"  width="21" height="21" />
									<span>Negro</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_ocre.png")%>" alt="Ocre"  width="21" height="21" />
									<span>Ocre</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_perlado.png")%>" alt="Perlado"  width="21" height="21" />
									<span>Perlado</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_rojo.png")%>" alt="Rojo"  width="21" height="21" />
									<span>Rojo</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_rosado.png")%>" alt="Rosado"  width="21" height="21" />
									<span>Rosado</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_turquesa.png")%>" alt="Turquesa"  width="21" height="21" />
									<span>Turquesa</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_verde.png")%>" alt="Verde"  width="21" height="21" />
									<span>Verde</span>
								</li>
								<li>
									<img src="<%=Url.Content("~/Content/images/img_fichas_colores_violeta.png")%>" alt="Violeta"  width="21" height="21" />
									<span>Violeta</span>
								</li>
							</ul>
							
							<p class="paleta">La paleta de colores es de caracter ilustrativo.</p>
							
						</div>
						
						
                    </div>
                   
                    <div class="Desplegado reviewCont">
                    	<div class="reviewInner">
							<div class="titulCont">
								<h3>Comentario del experto</h3>
								<div class="fecha">
									<span>Fecha: </span>  <p><%=Model.ExpertReviewDate.ToShortDateString() %></p>
								</div>
							</div>
							
							<div class="left">
								<div class="cajaGris">
									<div class="Cv Tl"></div>
									<div class="Cv Tr"></div>
									<div class="Cv Bl"></div>
									<div class="Cv Br"></div>
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
						</div>
                    </div>
                    
                  </div>
<!--FIN DE CONTENEDOR DE DESPLEGADOS -->