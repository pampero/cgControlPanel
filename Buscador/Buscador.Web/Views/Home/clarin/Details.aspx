<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Details.Master" Inherits="System.Web.Mvc.ViewPage<Publication>" %>

<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- muestra y oculta div de cuotas -->
    <script type="text/javascript" language="JavaScript"><!--
        function HideContent(d) {
            document.getElementById(d).style.display = "none";
        }
        function ShowContent(d) {
            document.getElementById(d).style.display = "block";
        }
        function ReverseDisplay(d) {
            if (document.getElementById(d).style.display == "none") { document.getElementById(d).style.display = "block"; }
            else { document.getElementById(d).style.display = "none"; }
        }
    //-->
    </script>
    
    <!-- muestra y oculta div de cuotas -->
    <div id="contenedor">
        
        <div id="two-box-top">
            <div id="navtrail">
                <span class="txt-001"><%=Html.BreadcrumbFor(Model)%></span></div>
            <!--<div id="redes">
                <ul>
                    <li><a href="#">
                        <img src="<%=Url.Content("~/Content/images/myspace.jpg")%>" border="0" /></a></li>
                    <li><a href="#">
                        <img src="<%=Url.Content("~/Content/images/fb.jpg")%>" border="0" /></a></li>
                    <li><a href="#">
                        <img src="<%=Url.Content("~/Content/images/send.jpg")%>" border="0" /></a></li>
                </ul>
            </div>-->
        </div>
        <div id="colum-left">
            <div class="h1-title">
                <h1><%=Model.VehicleDescription%></h1>
            </div>
            <div class="box-pic-auto">

                <div class="galeria-01">
                    <div id="gallery" class="ad-gallery">
                      <div class="ad-image-wrapper" style="width: 388px; height: 300px; top: 19px; left: 19px;">
                      </div>
                      <div class="ad-nav">
                        <div class="ad-thumbs">
                          <ul class="ad-thumb-list">
                            
                            <%for (var i = 1; i <= Model.VehiclePicQty; i++)%>
                            <%{%>
                                    <li>
                                        <a href="http://imagenes.deautos.com/PublishableItemImage/390x300/<%=Model.PublishableItemId%>_<%=i%>.jpg">
                                             <img src="http://imagenes.deautos.com/PublishableItemImage/102x76/<%=Model.PublishableItemId%>_<%=i%>.jpg" class="image<%=i%>" title=""/>
                                        </a>
                                    </li>
                            <%}%>
                          </ul>
                        </div>
                      </div>
                    </div>
                </div>

                <div class="galeria-02">
                    <!-- se pueden ocultar o agragrar items -->
                    <ul>
                    <%--<li><h1><%=Model.VehicleYear%></h1></li>--%>

                        <% if (Model.VehicleType == 1)
                           {%>
                            <li><span class="caracteristica"><%=Model.VehicleYear%></span></li>
                        <% }%>
                        <li><span class="caracteristica"><%=Model.VehicleFuelTypeText%></span></li>
                        <% if (Model.VehicleType == 1)
                           {%>
                            <li><span class="caracteristica"><%=Model.VehicleKm.WithThousandsSeparator() + " km"%></span></li>
                        <% }%>
                        <li><span class="caracteristica"><%=Model.VehiclePrice != 0
                          ? Html.Encode(Model.VehiclePrice.WithThousandsSeparator().AsPrice(Model.CVehiclePriceCurrency))
                          : "A Consultar"%></span></li>
                    </ul>
                    <!-- se pueden ocultar o agragrar items -->

                    <%--<% if(Model.UserType=="AgencyUser")
                       { %>
                        <div class="galeria-04">
                            <h1>
                                <a href="#">
                                    <img src="http://imagenes.deautos.com/UserImage/80x60/<%=Model.LogoId %>_logo.jpg" border="0" /></a></h1>
                        </div>
                    <%} %>--%>

                    <% ViewData.Add("showLinkToMircrosite",true); %>

                    <div style="margin-left:30px;">
                        <% Html.RenderPartial("PublicationUserLogoSection", Model); %>
                    </div>
                    <br />
                    <div class="dataline-03ver">
                        <a href="http://www.deautos.com/autos/UIYY<%=Model.UserUid%>">ver mas vehículos</a>
                    </div>
                    
                    <%--<div class="dataline-02ver"><a href="#">ver microsite</a></div> <br />--%>


                    <%--<div class="dataline-03ver"><a href="#">ver mas vehículos</a></div> --%>
                </div>

            </div>
            <div class="box-data-auto">
                <!-- datos auto -->
                <div class="datosauto">
                    <div class="titulos">
                        <h2>Datos del auto</h2>
                    </div>
                    <div class="dataline-auto">
                        <span class="txt-004">Vendedor:</span> <span class="txt-001"><%=Model.UserDescription%></span></div>
                    <div class="dataline-auto">
                        <div class="into-info">
                            <span class="txt-004">Marca:</span> <span class="txt-001"><%=Model.VehicleMakeText %></span>
                        </div>
                        <div class="into-info">
                            <span class="txt-004">Modelo:</span> <span class="txt-001"><%=Model.VehicleModelText %></span>
                        </div>
                        <div class="into-info">
                            <span class="txt-004">Versión:</span> <span class="txt-001"><%=Model.VehicleVersionText %></span>
                        </div>
                    </div>
                    <div class="dataline-auto">
                        <div class="into-info">
                            <span class="txt-004">Segmento:</span> <span class="txt-001"><%=Model.VehicleSegmentText %></span>
                        </div>
                        <div class="into-info">
                            <span class="txt-004">Color:</span> <span class="txt-001"><%=Model.VehicleColorText == "0" ? "-" : Model.VehicleColorText%></span>
                        </div>
                        <div class="into-info">
                            <span class="txt-004">Forma de pago:</span> <span class="txt-001"><%=Model.PaymentMethodText.ToProper() %></span>
                        </div>
                        
                    </div>
                    <div class="dataline-auto">
                        <span class="txt-004">Ubicación:</span> <span class="txt-001"><%=Html.ItemLocation(Model) %></span>
                        </div>
                </div>
                <!-- datos auto -->
                <% if (Model.UserType == "AgencyUser")
                {%>                   
                    <div class="dataline-02"><a href="http://www.deautos.com/autos/UIYY<%=Model.UserUid%>">Ver más publicaciones del vendedor</a></div>
                <%
                }%>
                <!-- datos plan -->
                <%--<div class="datosplan">
                    <div class="plan-left">
                        <div class="dataline-plan">
                            <span class="txt-004">Tipo de plan</span> <span class="txt-001"><%=Model.PlanType %></span></div>
                        <div class="dataline-plan">
                            <span class="txt-004">Valor cuota</span> <span class="txt-001"><%=Model.QuoteValue %></span></div>
                        <div class="dataline-plan">
                            <span class="txt-004">Valor cuota promedio</span> <span class="txt-001"><%=Model.AverageQuoteValue %></span></div>
                        <div class="dataline-plan">
                            <span class="txt-004">Valor venta plan</span> <span class="txt-001"><%=Model.PlanSaleValue %></span></div>
                    </div>
                    <div class="plan-right">
                        <div class="dataline-plan">
                            <span class="txt-004">Valor suscripción</span> <span class="txt-001"><%=Model.SuscriptionValue %></span></div>
                        <div class="dataline-plan">
                            <span class="txt-004">Financiación:</span> <span class="txt-001"><%=Model.Funding%></span></div>
                        <div class="dataline-plan">
                            <span class="txt-004">Entrega pactada cuota:</span> <span class="txt-001"><%=Model.DeliveryQuote %></span></div>
                        <div class="dataline-plan">
                            <span class="txt-004">Cuotas restantes:</span> <span class="txt-001"><%=Model.RemainingQuotes %></span></div>
                        
                        <% if (Model.HasQuotesDetails)
                           {%>
                            <div class="dataline-cuotas">
                                <a href="javascript:ShowContent('cuotas')">Ver avance de las cuotas</a>
                            </div>
                            <div id="cuotas" class="cajacuotas" style="display: none;">
                            
                                <% foreach (var quoteDetail in Model.QuoteDetails)
                                   {%>
                                        <div class="dataline-auto2">
                                            <span class="txt-001">De cuota</span><span class="txt-004"><%=quoteDetail.FromQuote%></span><span class="txt-001">a cuota</span><span class="txt-004"><%=quoteDetail.ToQuote%></span><span class="txt-001">:</span><span class="txt-002"><%=quoteDetail.QuoteValue%></span>
                                        </div>
                                <% }%>

                                <div class="dataline-cerrar">
                                    <a href="javascript:HideContent('cuotas')">Cerrar</a></div>
                            </div>
                        <%}%>
                    </div>
                </div>--%>
                <!-- datos plan -->
                <!-- financiación -->
                <%if (Model.FundingAdvance != 0 && Model.FromQuote != 0){%>
                    <div class="datosfinanc">
                         <div class="titulos">
                            <h2>Financiaci&oacute;n</h2>
                         </div>
                        <%--<div class="dataline-auto">
                            <span class="txt-004">Otros conceptos:</span> <span class="txt-001">Patentamiento $1.000</span></div>--%>
                        <div class="dataline-auto">
                            <span class="txt-004">Anticipo:</span> <span class="txt-001"><%=Model.FundingAdvance%></span></div>
                        <div class="dataline-auto">
                            <span class="txt-004">Cuota desde:</span> <span class="txt-001"><%=Model.FromQuote%></span></div>
                    </div>
                <%}%>
                <!-- financiación -->
                <div class="dataline">
                    <span class="txt-004">Comentario del vendedor:</span> <span class="txt-001"><%=Model.SellerComment %></span>
                </div>
                <div class="dataline-01">
                    <span class="txt-004">Equipamiento:</span> 
                    <span class="txt-001"><%= Html.Encode(string.Join(", ",Model.EquipmentAttributes.Select(x=>x.AttrValue).ToArray())) %></span>
                </div>
            </div>
            <%--<div class="banner315x50">
                <%=ViewData["bannerDerecha3"]%>
                </script>
            </div>--%>
            <div class="boxavisos">
                <div class="titlebox">
                    <%--<p class="txt-002">Avisos vigentes comparables</p>--%>
                    <h3>Autos similares a <%=Model.VehicleMakeText + " " + Model.VehicleModelText %></h3>
                </div>

                <div style="margin-top: 40px;">
                <div class="year-ficha" style="text-decoration:underline">Año</div>
                <div class="model-ficha" style="text-decoration:underline">Modelo</div>
                <div class="color-ficha" style="text-decoration:underline">Color</div>
                <div class="price-ficha" style="text-decoration:underline">Precio</div>
                <div class="km-ficha" style="text-decoration:underline">Km</div>
                </div>

                <% var similarByModel = (List<Publication>)ViewData["SimilarByModel"]; %>

                <% foreach (var publication in similarByModel)
                   {%>
                    <a href="<%=publication.UrlDetails %>">
                        <div class="avisos01" onmouseover="this.className='background-02'" onmouseout="this.className='background-01'">
                        
                            <div class="year-ficha"><%= publication.VehicleYear.ToString() == "0" ? "-" : publication.VehicleYear.ToString()%></div>
                            <div class="model-ficha"><%=publication.VehicleMakeText + publication.VehicleModelText + publication.VehicleVersionText %></div>
                            <div class="color-ficha"><%=publication.VehicleColorText == "0" ? "-" : publication.VehicleColorText%></div>
                            <div class="price-ficha"><%=publication.VehiclePrice != 0 ? Html.Encode(publication.VehiclePrice.WithThousandsSeparator().AsPrice(publication.CVehiclePriceCurrency)) : "A Consultar"%></div>
                            <div class="km-ficha"><%=publication.VehicleKm.WithThousandsSeparator() + " km"%></div>
                        
                        </div>
                    </a>
                 <%} %>

                <div class="sombra">
                    <img src="<%=Url.Content("~/Content/images/sombra.jpg") %>" /></div>
            </div>
         
        </div>
        <div id="colum-right">
            <!-- ocultable -->
            <%if (Model.UserType == "AgencyUser")
              {%>
                <div class="caja-form">

                <div class="datos-line-auto"><span class="txt-001"><B>Vendedor:</B> <%=Model.UserDescription%></span></div>

                <div class="datos-line-auto"><span class="txt-001"><B>E-mail:</B> <%=Model.UserEmail%></span></div>

                <div class="datos-line-auto"><span class="txt-001"><B>Teléfono:</B> <%=Model.UserPhone%></span></div>

                <div class="datos-line-auto"><span class="txt-001"><B>Dirección:</B><%=Model.UserAddress%></span></div>
                

                <!-- base semi-transparente -->
                <div id="fade" class="overlay" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                </div>
                <div class="datos-line-auto">
                    <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='block';document.getElementById('fade').style.display='block'">
                        <input type="button" class="send" style="margin-left:50px;"/>
                    </a>
                </div>

                
                <div id="light" class="modal" style="display:none;width:auto;height:auto;margin-left:100px;">
                    <div class="closemodal">
                        <a href="javascript:void(0)" onclick="document.getElementById('light').style.display='none';document.getElementById('fade').style.display='none'">
                            Cerrar
                        </a>
                    </div>
                    <div>
                        <iframe src="http://localhost:42618/Contacts/Contact/<%=Model.PublicationId%>" frameborder="0" scrolling="no" height="550" width="320">
                        </iframe>
                    </div>
                </div>
                </div>
                
            <%}
              else
              {%>
                  <iframe src="http://localhost:42618/Contacts/Contact/<%=Model.PublicationId%>" frameborder="0" scrolling="no" height="550" width="320">
                  </iframe>
            <%}%>
            <div class="topform"><img src="<%=Url.Content("~/Content/images/bottom-img-form.jpg") %>" /></div>
            <div class="banner214x120">
                <%=ViewData["bannerDerecha3"]%>
                </script>
            </div>
           <%-- <div class="caja-form">
                <form>
                <span class="campform"><span class="ast">*</span><span class="txt-001">Apellido y Nombre</span><br />
                    <input class="imput01" type="text" name="nombre" />
                    <div class="validation">
                        <span class="txt-006">(*) Este campo es obligatorio</span></div>
                </span><span class="campform"><span class="ast">*</span><span class="txt-001">E-mail</span><br />
                    <input class="imput01" type="text" name="mail" />
                    <div class="validation">
                        <span class="txt-006">(*) Este campo es obligatorio</span></div>
                </span><span class="campform"><span class="txt-001">Teléfono (ej. 011 15 6666 5555)</span><br />
                    <input class="cod15" type="text" name="numero" />
                    <input class="cod15" type="text" name="numero" />
                    <input class="numero" type="text" name="numero" />
                    <div class="validation">
                        <span class="txt-006">(*) Este campo está incompleto</span></div>
                </span><span class="campform"><span class="txt-001">Comentarios</span><br />
                    <textarea class="imput02" cols="20" rows="10" name="Texto"></textarea>
                    <div class="validation">
                        <span class="txt-006"></span>
                    </div>
                </span>
                <div class="align-center">
                    <span class="campform">
                        <p>
                            <img src="img/captcha.jpg" border="0" />
                            <a href="#">
                                <img src="<%=Url.Content("~/Content/images/refresh.jpg") %>" border="0" /></a></p>
                        <p class="txt-001">
                            Ingrese los caracteres que visualiza</p>
                        <p>
                            <input class="numero" type="text" name="captcha" /></p>
                        <div class="validation">
                            <span class="txt-006">(*) Este campo es obligatorio</span></div>
                    </span><span class="check">
                        <input type="checkbox" value="1" checked="" id="chkNews" name="chkNews">
                        <span class="txt-001">Acepto recibir Newsletter</span> </span>
                    <input class="send" type="submit" value="" />
                </div>
                </form>
            </div>
            <div class="topform">
                <img src="<%=Url.Content("~/Content/images/bottom-img-form.jpg") %>" /></div>--%>
            <!-- ocultable -->
            <div class="banner214x120">
                <%=ViewData["bannerDerecha1"]%>
                </script>
            </div>
            <div class="banner214x120">
                <%=ViewData["bannerDerecha2"]%>
                </script>
            </div>

                <div class="banner214x120">
                    <%=ViewData["bannerDerecha4"]%>
                </script>
            </div>
            <!-- <div class="banner315x50"><img src="img/315x50.gif" /></div>
<div class="banner315x50"><img src="img/315x50.gif" /></div> -->
            <div class="banner-iAvisos-230x300">
                <%=ViewData["bannerDerecha5"]%>
                </script>
            </div>
        </div>
        <div class="banner-footer">
            <%=ViewData["bannerBottomHtml"] %>
            </script>
        </div>
        
    
    
</asp:Content>
