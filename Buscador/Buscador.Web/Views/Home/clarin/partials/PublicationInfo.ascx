<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<div class="tituloYPrecioCont">
                        <div class="titular">
                            <h1> <%=Model.VehicleDescription%></h1>
                        </div>
                        <div class="precio">
                            <span class="titulo1"><%=(Model.VehiclePrice!=0)
                          ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))
                          : "A Consultar"%></span>
                        </div>
                    </div>
                    
                    <div class="contMedio <%=Model.VehicleTypeText%>"><!--AGREGAR EL MODIFICADOR A "contMedio" SEGUN CORRESPONDA, pra mostrar los datos del ul NUEVO, USADO O PLAN AHORRO,: LOS MODIFICADORES SON : "nuevo" , "usado" , "planAhorro"-->
                    	<div class="datos">
                        	<ul class="nuevo">
                            	<li>Combustible:<p><%=Model.VehicleFuelTypeText%></p></li>
                                <li>Forma de pago:<p><%=Model.PaymentMethodText.ToProper()%></p></li>
                                <li>Segmento:<p><%=Model.VehicleSegmentText%></p></li>


                                <%if (Model.FundingAdvance!=null && Model.FundingAdvance != 0)
                                  {%>
                                
                                <li>Anticipo:<p><%=Html.Encode(Model.FundingAdvance.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))%></p></li>
                                
                                <%}%>


                                <li>Precio:<p><%=(Model.VehiclePrice != 0)
                                                      ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))
                                                      : "A Consultar"%></p></li>

                          <%if(Model.FromQuote!=null && Model.FromQuote!=0){ %>
                                <li>Cuota desde:<p><%=Html.Encode(Model.FromQuote.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))%></p></li>
                          <%} %>

                                <li>Ubicación:<p><%=Html.ItemLocation(Model)%></p></li>
								<li>Color:<p><%=Model.VehicleColorText == "0" ? "-" : Model.VehicleColorText%></p></li>
                            </ul>
                            <ul class="usado">
                            	<li>Kilometraje:<p><%=Model.VehicleKm.WithThousandsSeparator() + " km"%></p></li>
                                <li>Combustible:<p><%=Model.VehicleFuelTypeText%></p></li>
                                <li>Año:<p><%=Model.VehicleYear.ToString()%></p></li>
                                <li>Segmento:<p><%=Model.VehicleSegmentText%></p></li>
                                <li>Color:<p><%=Model.VehicleColorText == "0" ? "-" : Model.VehicleColorText%></p></li>
                                <li>Forma de pago:<p><%=Model.PaymentMethodText.ToProper()%></p></li>
                                <li>Ubicación:<p><%=Html.ItemLocation(Model)%></p></li>

                                <%if (Model.FundingAdvance != null && Model.FundingAdvance != 0)
                                  {%>
								<li>Anticipo:<p><%=Html.Encode(Model.FundingAdvance.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))%></p></li>
                                <%}%>

                                <li>Precio:<p><%=(Model.VehiclePrice != 0)
                          ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))
                          : "A Consultar"%></p></li>

                          <%if (Model.FromQuote != null && Model.FromQuote != 0)
                            {%>
                                <li>Cuota desde:<p><%=Html.Encode(Model.FromQuote.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))%></p></li>
                                <%
                            }%>
                            </ul>
                            
                            <ul class="planAhorro">
                            	<li>Combustible:<p><%=Model.VehicleFuelTypeText%></p></li>
                                <li>Segmento:<p><%=Model.VehicleSegmentText%></p></li>
                                <li>Ubicación:<p><%=Html.ItemLocation(Model)%></p></li>
                            </ul>
                            
                            
                            
                            <!--<ul class="anticipoyCuotadesde">
                            	<li class="anticipo"><p>Anticipo:</p><span></span></li>
                                <li class="cuotaDesde"><p>Cuota desde:</p><span></span></li>
                            </ul> -->
                            
                        </div>
                        
                        <div class="estrellasybotonesCont nuevo"><!--AGREGAR LA CLASE "usados" PARA MOSTRAR LA SOLAPA "CON GARANTIA MECANICA" Y OCULTAR LAS ESTRELLAS O AGREGAR LA CLASE "nuevo" PARA MOSTRAR LAS ESTRELLAS -->
                       		
                        	<div class="estrellasCont">
                            <%
                                if (Model.ShowCatalogInfo && Model.ConfigShowCatalogInfo)
                                {%>
                                <%
                                    if (Model.SegmentCatalogInfo != null &&
                                        !string.IsNullOrEmpty(Model.SegmentCatalogInfo.ExpertReview))
                                    {%>
                            	<a class="aFlecha" href="javascript:ChangeTab('review')" title="Ver review">Ver review</a>
                                <%
                                    }%>
                                <%
                                if (Model.SegmentCatalogInfo != null)
                                {%>
                                <%
                                    if (Model.SegmentCatalogInfo.AverageRanking.IntegerPart() > 0 ||
                                        Model.SegmentCatalogInfo.AverageRanking.DecimalPart() > 0)
                                    {%>
                            	    <div class="estrellas">
                                    <%
                                        for (int i = 0; i < Model.SegmentCatalogInfo.AverageRanking.IntegerPart(); i++)
                                        {%>
                                	    <div class="pngfix active"></div>
                                      <%
                                        }%>
                                    <%
                                        if (Model.SegmentCatalogInfo.AverageRanking.DecimalPart() > 0)
                                        {%>
                                        <div class="pngfix mitad"></div>
                                      <%
                                        }%>
                                      <%
                                        for (int j = 0;
                                             j <
                                             5 - Model.SegmentCatalogInfo.AverageRanking.IntegerPart() -
                                             (Model.SegmentCatalogInfo.AverageRanking.DecimalPart() > 0 ? 1 : 0);
                                             j++)
                                        {%>
                                        <div class="pngfix inactive"></div>
                                      <%
                                        }%>                                
                                     </div>          
                                  <%
                                    }%>
                                <%
                                }%>                                  
                        	<% } %>
                            <!-- AGREGAR LA CLASE "quitarComparador" A ESTE DIV CUANDO EL BOTON DE COMPARAR FUÉ APRETADO, Y MUESTRA EL BOTON DE QUITARCOMPARAR -->
                            <div class="comparar ">                            
                            <!--<div class="btndinamicoCont">
                            	<a href="#" title="Comparar con otro auto" class="btnDinamicoGris">
                                	<span class="clearfix L"></span>
                                    <span class="M"><span class="autito"></span>Agregar al comparador</span>
                                    <span class="clearfix R"></span>
                               	</a>
                            </div>-->
                            
                            <!--<div class="btndinamicoCont quitar">
                            	<a href="#" title="Quitar del comparador" class="btnDinamicoGris">
                                	<span class="clearfix L"></span>
                                    <span class="M"><span class="autito"></span>Quitar del comparador</span>
                                    <span class="clearfix R"></span>
                               	</a>
                                
                                <div class="solapaScroll">
                                	<div class="pngfix irAlComparador">
                                    	<a href="#" title="ir al comparador">Ir a comparador</a>
                                        <span>(2)</span>
                                    </div>
                                </div>
                                
                            </div>-->
                            	
                            </div>
                            
                            <div class="pngfix garantiaMecanica">
                            	<span>Con Garantía Mecánica</span>
                            </div>
                        </div>
                        </div>
                        
                    </div>