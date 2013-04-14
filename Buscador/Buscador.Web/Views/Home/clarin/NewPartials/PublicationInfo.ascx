<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<div class="tituloYPrecioCont">
                        <div class="titular">
                            <h1> <%=Model.VehicleDescription%></h1>
                        </div>
                        <div class="precio">
                            <span class="titulo1"><%=Model.VehiclePrice != 0
                          ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))
                          : "Consultar"%></span>
                        </div>
                    </div>
                    
                    <div class="contMedio <%=Model.VehicleTypeText%>"><!--AGREGAR EL MODIFICADOR A "contMedio" SEGUN CORRESPONDA, pra mostrar los datos del ul NUEVO, USADO O PLAN AHORRO,: LOS MODIFICADORES SON : "nuevo" , "usado" , "planAhorro"-->
                    	<div class="datos">
                        	<ul class="nuevo">
                            	<li>Combustible:<p><%=Model.VehicleFuelTypeText%></p></li>
                                <li>Forma de pago:<p><%=Model.PaymentMethodText.ToProper() %></p></li>
                                <li>Segmento:<p><%=Model.VehicleSegmentText %></p></li>
                                <li>Anticipo:<p><%=Model.FundingAdvance != 0 ? Html.Encode(Model.FundingAdvance.WithThousandsSeparator().AsPrice(Model.FundingAdvanceCurrency)) : "Consultar"%></p></li>
                                <li>Precio:<p><%=Model.VehiclePrice != 0 ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency)) : "Consultar"%></p></li>
                                <li>Cuota desde:<p><%=Model.FromQuote != 0 ? Html.Encode(Model.FromQuote.WithThousandsSeparator().AsPrice(Model.FundingAdvanceCurrency)) : "Consultar"%></p></li>
                                <li>Ubicación:<p><%=Html.ItemLocation(Model) %></p></li>
								<li>Color:<p><%=Model.VehicleColorText == "0" ? "-" : Model.VehicleColorText%></p></li>
                            </ul>
                            <ul class="usado">
                            	<li>Kilometraje:<p><%=Model.VehicleKm.WithThousandsSeparator() + " km"%></p></li>
                                <li>Combustible:<p><%=Model.VehicleFuelTypeText%></p></li>
                                <li>Año:<p>2010</p></li>
                                <li>Segmento:<p><%=Model.VehicleSegmentText %></p></li>
                                <li>Color:<p><%=Model.VehicleColorText == "0" ? "-" : Model.VehicleColorText%></p></li>
                                <li>Forma de pago:<p><%=Model.PaymentMethodText.ToProper() %></p></li>
                                <li>Ubicación:<p><%=Html.ItemLocation(Model) %></p></li>
								<li>Anticipo:<p><%=Model.FundingAdvance != 0 ? Html.Encode(Model.FundingAdvance.WithThousandsSeparator().AsPrice(Model.FundingAdvanceCurrency)) : "Consultar"%></p></li>
                                <li>Cuota desde:<p><%=Model.FromQuote != 0 ? Html.Encode(Model.FromQuote.WithThousandsSeparator().AsPrice(Model.FundingAdvanceCurrency)) : "Consultar"%></p></li>
                                <li>Precio:<p><%=Model.VehiclePrice != 0 ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency)) : "Consultar"%></p></li>
                            </ul>
                            
                            <ul class="planAhorro">
                            	<li>Combustible:<p><%=Model.VehicleFuelTypeText%></p></li>
                                <li>Segmento:<p><%=Model.VehicleSegmentText %></p></li>
                                <li>Ubicación:<p><%=Html.ItemLocation(Model) %></p></li>
                            </ul>
                            
                            
                            
                            <!--<ul class="anticipoyCuotadesde">
                            	<li class="anticipo"><p>Anticipo:</p><span></span></li>
                                <li class="cuotaDesde"><p>Cuota desde:</p><span></span></li>
                            </ul> -->
                            
                        </div>
                        
                        <div class="estrellasybotonesCont nuevo"><!--AGREGAR LA CLASE "usados" PARA MOSTRAR LA SOLAPA "CON GARANTIA MECANICA" Y OCULTAR LAS ESTRELLAS O AGREGAR LA CLASE "nuevo" PARA MOSTRAR LAS ESTRELLAS -->
                       		
                        	<div class="estrellasCont">
                            	<a class="aFlecha" href="#" title="Ver review">Ver review</a>
                            	<div class="estrellas">
                                <%for (int i = 0; i < Model.AverageRanking.IntegerPart(); i++)
                                  {%>
                                	<a href="#" title="#" class="pngfix active"></a>
                                  <%}%>
                                <%if (Model.AverageRanking.DecimalPart() > 0)
                                  {%>
                                    <a href="#" title="#" class="pngfix mitad"></a>
                                  <%}%>
                                  <%for (int j = 0; j < 5 - Model.AverageRanking.IntegerPart() - (Model.AverageRanking.DecimalPart() > 0 ? 1 : 0); j++)
                                    {%>
                                    <a href="#" title="#" class="pngfix inactive"></a>
                                  <%}%>
                                </div>
                            </div>
                        	
                            <!-- AGREGAR LA CLASE "quitarComparador" A ESTE DIV CUANDO EL BOTON DE COMPARAR FUÉ APRETADO, Y MUESTRA EL BOTON DE QUITARCOMPARAR -->
                            <div class="comparar ">                            
                            <!--<div class="btndinamicoCont">
                            	<a href="#" title="Comparar con otro auto" class="btnDinamicoGris">
                                	<span class="clearfix L"></span>
                                    <span class="M"><span class="autito"></span>Agregar al comparador</span>
                                    <span class="clearfix R"></span>
                               	</a>
                            </div>-->
                            
                            <div class="btndinamicoCont quitar">
                            	<!--<a href="#" title="Quitar del comparador" class="btnDinamicoGris">
                                	<span class="clearfix L"></span>
                                    <span class="M"><span class="autito"></span>Quitar del comparador</span>
                                    <span class="clearfix R"></span>
                               	</a>-->
                                
                                <div class="solapaScroll">
                                	<div class="pngfix irAlComparador">
                                    	<a href="#" title="ir al comparador">Ir a comparador</a>
                                        <span>(2)</span>
                                    </div>
                                </div>
                                
                            </div>
                            	
                            </div>
                            
                            <div class="pngfix garantiaMecanica">
                            	<span>Con Garantía Mecánica</span>
                            </div>
                        </div>
                        
                    </div>