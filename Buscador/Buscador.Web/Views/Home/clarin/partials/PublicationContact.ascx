<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>

<div class="cajaNegra">
    <div class="Cv Tl"></div>
    <div class="Cv Tr"></div>
    <div class="Cv Bl"></div>
    <div class="Cv Br"></div>
                        
    <%if (Model.UserViewContactData)
        {%>
        <div class="tipoVendedor">
        <div>
    <%}else if (Model.UserType == "AgencyUser")
        {%>
        <div class="tipoVendedor concesionaria">
        <div class="contactoConcecionariaCont"><!--!!IMPORTANTE PARA QUE APARESCAN LAS SOLAPAS DE VENDEDOR PARTICULAR el div debe quedar con las siguientes clases: class="tipoVendedor particular"-->
    <%}else
        {%>
        <div class="tipoVendedor particular">
        <div>
    <%}%>	
        <h4 class="contactarV">Contactar al Vendedor</h4>
        
            <%if (Model.UserType == "AgencyUser")
            {%>		
                        <div class="cabecera pngfix">
                        <div class="fotoyVendedor">
                              <%if ( Model.LogoId != 0)
                              {%>
                                <div class="foto">
                                   <%if (Model.UserMicrosite != "" && Model.UserMicrosite != null)
                                   {%>
                                    <a href="<%="http://www.deautos.com/concesionaria/" + Model.UserMicrosite%>" title="<%=Model.UserDescription%>"><img src="<%=ViewData["ImagesUrl"] + "/UserImage/80x60/" + Model.LogoId + "_logo.jpg"%>" alt="foto perfil" /></a>
                                   <%}else
                                    {%>
                                        <img src="<%=ViewData["ImagesUrl"] + "/UserImage/80x60/" + Model.LogoId + "_logo.jpg"%>" alt="foto perfil" />    
                                    <%}%>
                                </div> 
                              <%}%>
                            <div class="vendedor">
                                <p><%=Model.UserDescription%></p> 
                            </div>
                        </div>
                    </div>
            <%}%>
            
            <%if (Model.UserViewContactData)
              {%>
                <div class="cuerpo">
                    <ul>
                        <li><p>Teléfono:</p></li>
                        <%
                string[] phones = Regex.Split(Model.UserPhone, "//");
                foreach (var phone in phones)
                {%>
                                <li><%=phone%></li> 
                            <%} %>    
                            
                              <!-- Nuevo Catalogo 2B -->
                              <li>Nextel ID <%=Model.UserNextelId %></li>
                              <!-- FIN Nuevo Catalogo 2B -->             
                    </ul>                
                    <!--<a class="llamaGratis" href="#" title="¡Llamá Gratis ahora!">
                        <span class="pngfix L"></span>
                        <span class="M">¡Llamá Gratis ahora!</span>
                        <span class="pngfix R"></span>
                    </a>-->            
                    <ul>
                        <li><p>Direcci&oacute;n:</p></li>
                        <li><span><%=Model.UserAddress %></span></li>              
                    </ul>                
                    <ul class="email">
                        <li><p>E-mail:</p></li>
                        <li><a class="contacto" href="mailto:<%=Model.UserEmail%>" title="<%=Model.UserEmail%>"><%=Model.UserEmail%></a></li>
                    </ul>
                    <div class="botCont" id="basic-modal3">
                        <a class="btnNar basic" onclick="javascript:fShowPopUp(this);" id="ContactPopUp" title="Contactar Ahora">
                            <span class="pngfix L"></span>
                            <span class="M">Contactar Ahora</span>
                            <span class="pngfix R"></span>
                        </a>
                    </div>                    
                </div>       
            <%}%>
            
            <div id="contactIframe" style="display:<%if(Model.UserViewContactData){%>none<%}else{%>block<%}%>">
                <%--<div class="solapaYBoton" id="solapaYBoton">
                    <div class="solapaContactarse">
                        <span>Contactarse</span>
                    </div>
                    <div class="botonAzul">
                            <a class="btnDinAzul" href="#" title="¡Llamá Gratis ahora!">
                            <span class="pngfix L"></span>
                            <span class="M">¡Llamá Gratis ahora!</span>
                            <span class="pngfix R"></span>
                        </a>
                    </div>
                </div>--%>
                <%--<%=ViewData["IframeUrl"]%>/Contacts/Contact?id=<%=Model.PublicationId%>&captchaExtraName=popup" %>--%>
                <iframe src="<%=ViewData["IframeUrl"]%>/Contacts/Contact?id=<%=Model.PublicationId%>&captchaExtraName=popup" frameborder="0" scrolling="no" height="415" width="290"></iframe>
            </div>
              
              
            <%--<div class="contactarOk">
                <p>Tus datos de contacto fueron enviados al vendedor.</p>
                <p>Asimismo, hemos enviado a tu casilla de e-mail <strong>lbenitez@iconosur.com</strong> sus datos para que puedas contactarlo.</p>
                                        
                <div class="recuadro">
                    <p>Av. San Juan 1669, San Cristobal Capital Federal</p>
                    <p class="telefonos">(011) 4305-4965 <!-- <span class="pipe">|</span>  4006-6404 --></p>
                    <p class="telefonos secundario">(011) 4305-4444  <!--<span class="pipe">|</span>  4006-6404 --></p>
                    <p class="telefonos nextel">(011) 4305-4965 <span>- Nextel</span> <!--<span class="pipe">|</span>  4006-6404 --></p>
                    <a href="#" title="#">atencionclientes@forestcar.com.ar</a>
                </div>
            </div>--%>
                                    
            <%if(Model.UserType == "AgencyUser") {%>
                    <div class="links">
                    <div>
                        <%if(Model.UserMicrosite!="" && Model.UserMicrosite!=null) {%>
                        <a class="irMicrositio" href="<%="http://www.deautos.com/concesionaria/" + Model.UserMicrosite %>" title="Ir a Micrositio">Ir a Micrositio</a>
                        <a class="ubicacionMapa" id="AgencyMapUbication" href="<%="http://www.deautos.com/concesionaria/" + Model.UserMicrosite %>" title="Ubicación en el mapa">Ubicación en el mapa</a>
                        <!--<a class="ubicacionMapa" id="AgencyMapUbication" onclick="javascript:fShowPopUp(this);" title="Ubicación en el mapa">Ubicación en el mapa</a>-->
                        <%}%>                                   
                        <a class="otrosAvisosVend" href="http://www.deautos.com/autos/UIYY<%=Model.UserUid%>" title="Ver otros avisos del vendedor">Ver otros avisos del vendedor</a>
                                   
                    </div>
                </div>
            <%}%>
        </div>
        <!--FIN CONTRATAR CONCESIONARIA -->
    </div>
</div>
