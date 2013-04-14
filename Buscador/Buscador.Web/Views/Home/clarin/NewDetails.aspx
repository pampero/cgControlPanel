<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Details.Master" Inherits="System.Web.Mvc.ViewPage<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link type="text/css" rel="stylesheet" href="../../../Content/css/deautos.css" media="screen" />
<link type="text/css" rel="stylesheet" href="../../../Content/css/fichas.css" media="screen" />
<%--<link type="text/css" rel="Stylesheet" href="../../../Content/css/print.css" media="screen" />--%>
<script type="text/javascript" src="../../../Scripts/genericfunctions.js"></script>
<script type="text/javascript" src="../../../Scripts/jquery.js"></script>
<script type="text/javascript" src="../../../Scripts/sliderFichas.js"></script>
<script type="text/javascript" src="../../../Scripts/search.js"></script>
<script type="text/javascript" src="../../../Scripts/googlemap.js"></script>
<script type="text/javascript" src="../../../Scripts/json2.js"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

<!-- Agregado de diseño para el modal    --->    
<script type='text/javascript' src="../../../Scripts/jquery.simplemodal.js"></script>
<script type='text/javascript' src="../../../Scripts/basic.js"></script>   
<!-- Contact Form CSS files -->
<link  type="text/css" rel="stylesheet" href="../../../Content/css/basic.css" media="screen" />
<!-- -->
<script type="text/javascript">
    $(document).ready(function () {   
        //initialize();
        //initializeSearch('<%=Url.Action("GetVehiclesBrands","Autos") %>', '<%=Url.Action("GetVehiclesModels","Autos") %>', '<%=Url.Action("GetVehiclesVersions","Autos") %>');
        initializeSearch('/autos/GetVehiclesBrands', '/autos/GetVehiclesModels', '/autos/GetVehiclesVersions');
        $("#AgencyMapUbication").click(function () {
            $("#PopUps").attr("style", "display:''");
            $("#PopUps").attr("class", "contMatterPopups contactoMapa");
        });

        $("#DenunciatePublication").click(function () {
            $("#PopUps").attr("style", "display:''");
            $("#PopUps").attr("class", "contMatterPopups denunciarAv");
        });
    });

    function fShowPopUp(obj) {
        switch (obj.id) 
        {
            case "DenunciatePublication":
                $("#PopUps").attr("style", "display:''");
                $("#PopUps").attr("class", "contMatterPopups denunciarAv");
                break;
            case "SendToAFriend":
                $("#PopUps").attr("style", "display:''");
                $("#PopUps").attr("class", "contMatterPopups enviarmail");
                break;
            case "AgencyMapUbication":
                $("#PopUps").attr("style", "display:''");
                $("#PopUps").attr("class", "contMatterPopups contactoMapa");
                break;
            case "ContactPopUp":
                $("#PopUps").attr("style", "display:''");
                $("#PopUps").attr("class", "contMatterPopups contact");
                break;
            case "consejos":
                $("#PopUps").attr("style", "display:''");
                $("#PopUps").attr("class", "contMatterPopups cons");
                break;
        }
    }

    function fClose() 
    {
        $("#PopUps").attr("style", "display:none;");
    }

    function fShowContactForm() 
    {
        //$("#contactButton").hide();
        $("#contactIframePopUp").show();
    }
    
</script>

<div class="layout microConcesionaria">
	<!-- CONTENIDO -->
    <div id="div1"></div>
    <div id="div2" style="background-color:green;"></div>


	<div class="Cont clearfix ">
        <%Html.RenderPartial("PublicationHeader");%>
        <div class="bn728x90">&nbsp;
				<%if (Model.State != PublicationOrderState.FinishedByFraud.ToString())
				{%>
		            <%=ViewData["bannerBottomHtml"]%>
		      <%}%>
	    </div>
                
    <!--CONTEINER -->
    <div class="conteiner colMargen clearfix"><!--segin el modificador que tenga "conteiner", cambiará la columna left -->
    	<div class="colLeft" >
            <div class="bn728x90">
               <%-- <div style="background-color:#333333;text-align:center;width:728px; height:90px; float:left;">
                    <p style="color:#FFFFFF"><br />728 x 90</p>
                </div>--%>
                <%=ViewData["bannerBottomHtml"]%>
            </div>
            <%if (Model.State == PublicationOrderState.FinishedByFraud.ToString())
              {%>
                <div class="finalizado">
                	<div class="cajaError"><!--CAMBIAR LA CLASE "cajaOK" PARA MOSTRAR LA CAJA VERDE, O "cajaError" PARA MOSTRAR LA CAJA ROJA.  -->
                        <div class="textCont">
                            <span class="first">El aviso que esta buscando ya no se encuentra disponible.</span>
                            <a href="http://www.deautos.com/autos" title="clic aquí">Realizar una Nueva búsqueda</a>
                        </div>
                    </div>
                </div>
            <%}else 
                {
                    if (Model.State != PublicationOrderState.Active.ToString() && Model.State != PublicationOrderState.ActivatedByClienting.ToString())
                    {%>
                         <!--Finalizado -->
                            <div class="finalizado">
                	            <div class="cajaError"><!--CAMBIAR LA CLASE "cajaOK" PARA MOSTRAR LA CAJA VERDE, O "cajaError" PARA MOSTRAR LA CAJA ROJA.  -->
                                    <div class="textCont">
                                        <span class="first">La publicación correspondiente a este aviso, se encuentra finalizada.  </span>
                                        <a href="<%=ViewData["SimilarByModelSearchUrl"] %>" title="clic aquí">Nueva Búsqueda</a>
                                    </div>
                                </div>
                            </div>
                            <!--fin Finalizado -->                
                     <%}%>
                    <div class="blockeTitular">
                        <% Html.RenderPartial("PublicationInfo");%>        	
                        <!-- !! MUY IMPORTANTE PARA PROGRAMAR !!  TENER EN CUENTA QUE CADA SOLAPA DENTRO DEL CONTENEDOR "solapasCont" GUARDA RELACION CON LOS DIVS DENTRO DE "columnaLeft" -->
                        <%
                                Html.RenderPartial("PublicationTabs", Model);
                            %>    	
                        <div class="bordeBottom"></div>
                    </div> 
               <%} %>
               <div class="columnaLeft">
                  <%if (Model.State != PublicationOrderState.FinishedByFraud.ToString())
                    {%>             
                        <%/*if (Model.ConfigShowCatalogInfo && Model.ShowCatalogInfo) 
                         {*/
                            Html.RenderPartial("PublicationTabsInfo", Model);
                         /*}*/ %>

                         <%/*if (Model.ConfigShowCatalogInfo && Model.ShowCatalogInfo)
                         {*/
                           Html.RenderPartial("PublicationDetails", Model);
                         /*}*/%>

                        <div class="banner_300x50">
                            <%=ViewData["bannerIzquierda1"]%>
                        </div> 
                        <div class="banner_300x50">
                            <%=ViewData["bannerIzquierda2"]%>
                        </div>

                        <%
                        Html.RenderPartial("PublicationMoreInfo");%>
                        <% if (Model.ConfigShowCatalogInfo && Model.ShowCatalogInfo){
                            Html.RenderPartial("PublicationCatalog", Model);        
                        } %>
                        <%Html.RenderPartial("PublicationCompareInfo");%>       
                    <%}%>
                <%--<div class="bannersCont">
                    <div class="bn300x100">
                        <div style="background-color:#333333;text-align:center;width:300px; height:100px; float:left;">
                       		<p style="color:#FFFFFF; padding-top:28px;"><br />300 X 100</p>
                   	    </div>
                        <%=ViewData["bannerDerecha4"]%>
                	</div>	 
					<div class="bn300x100">
                        <div style="background-color:#333333;text-align:center;width:300px; height:100px; float:left;">
                       		<p style="color:#FFFFFF; padding-top:28px;"><br />300 X 100</p>
                   	    </div>
                        <%=ViewData["bannerDerecha5"]%>
                	</div>
                </div>--%>
                
	            
            </div>  
        
            <%if (Model.State != PublicationOrderState.FinishedByFraud.ToString())
              {%>
                <div class="columnaRight">
                
                     <%
                      if (Model.State == PublicationOrderState.Active.ToString() ||
                          Model.State == PublicationOrderState.ActivatedByClienting.ToString())
                      {
                          Html.RenderPartial("PublicationContact", Model);
                      }%>      
                    
                     <div class="bn300x250">
                        <%=ViewData["bannerDerecha2"]%>
                     </div>
                         
                     <%
                      Html.RenderPartial("PublicationSearch");%>     
                               
                     <div class="bn300x100">
                        <%=ViewData["bannerDerecha1"]%>
                     </div>
                             
                     <div class="bn300x200">
                        <%=ViewData["bannerDerecha3"]%>
                     </div>
                </div>
            <%}%>
            <!--<div class="colRight">
              col right
            </div> -->
        </div>
        </div>        <!--FIN CONTEINER -->
	</div>
	<!-- fin CONTENIDO -->
		
</div>
<!-- fin LAYOUT -->

<div id="basic-modal-content">  <!-- Todo el contenido del popUp debe estar dentro de este div -->
<div class="contMatterPopups mapa" id="PopUps" style="display:none;"><!--!!IMPORTANTE, AGREGARLE LOS SIGUIENTES MODIFICADORES A "contMatterPopups" PARA MOSTRAR EL CORRESPONDIENTE POP UP; PARA MOSTRAR "ENVIAR EMAIL" AGREGAR EL MOD:"enviarmail"; PARA MOSTRAR MAPA: AGREGAR "mapa"; PARA CONTACTO CONCESIONARIA "conce" -->

        <div class="consejos">
           <div class="PopUpCont chico">
                <div class="ContOpacExpress puliContacto">                
                    <div class="cvTop pngfix"></div>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="cv_left"></td>
                            <td>
                                <div class="popCont">
                                    <div class="contHd">
                                        <h4>Consejos de seguridad para el comprador</h4>
                                        <a class="cerrar" href="javascript:fClose();" title="Cerrar"></a>
                                    </div>
                                   <ul class="con">
                                    <li><p>No pagues con servicios de pago anónimos (como Western Union).</p></li>
                                    <li><p>Nunca envíes dinero al exterior sin primero revisar el vehículo en persona.</p></li>
                                    <li><p>Antes de comprar un vehículo, revísalo personalmente y verifica su documentación.</p></li>
                                    <li><p>Siempre habla por teléfono con el vendedor.</p></li>
                                  </ul>
                                 
                                </div>
                            </td>
                            <td class="cv_right"></td>
                        </tr>
                    </table>
                    <div class="cvBottom pngfix"></div>
                </div>	
            </div>
        </div>


        <div class="denunciar"><!--AGREGARLE LA CLASE "ok" A "enviarMail" PARA MOSTRAR QUE EL ENVIO FUE CORRECTO-->
           <div class="PopUpCont chico">
                <div class="ContOpacExpress puliContacto">                
                    <div class="cvTop pngfix"></div>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="cv_left"></td>
                            <td>
                                <div class="popCont">
                                    <div class="contHd">
                                        <h4>Denunciar este aviso</h4>
                                        <a class="cerrar" href="javascript:fClose();" title="Cerrar"></a>
                                    </div>                                    
                                    <iframe src="<%=ViewData["IframeUrl"]%>/Publication/DenunciatePublication/<%=Model.PublicationId %>" frameborder="0" scrolling="no" height="420" width="650">
                                    </iframe>  
                                    
                                </div>
                            </td>
                            <td class="cv_right"></td>
                        </tr>
                    </table>
                    <div class="cvBottom pngfix"></div>
                </div>	
            </div>
        </div>

        <div class="enviarMail "><!--AGREGARLE LA CLASE "ok" A "enviarMail" PARA MOSTRAR QUE EL ENVIO FUE CORRECTO-->
           <div class="PopUpCont chico">
                
                <div class="ContOpacExpress puliContacto">
                
                    <div class="cvTop pngfix"></div>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="cv_left"></td>
                            <td>
                                <div class="popCont">
                                    <div class="contHd">
                                        <h4>Enviar a un amigo</h4>
                                        <a class="cerrar" href="#" title="Cerrar"></a>
                                    </div>
                                    <iframe src="<%=ViewData["IframeUrl"]%>/UserInfo/SendToAFriend/<%=Model.PublicationId %>" frameborder="0" scrolling="no" height="530" width="680">
                                    </iframe>    
                                </div>
                            </td>
                            <td class="cv_right"></td>
                        </tr>
                    </table>
                    <div class="cvBottom pngfix"></div>
                
                </div>	
            </div>
        </div>
        
        <!--CONTACTO MAPA -->
        <div class="contactoMapa">
            <div class="PopUpCont chico">
                <div class="ContOpacExpress">
                    <div class="cvTop pngfix"></div>                    
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="cv_left"></td>
                            <td>
                                <div class="popCont">
                                    <div class="contHd">
                                        <h4>Ubicación en el mapa de</h4>
                                        <h3 class="naranja">Pestelli</h3>
                                        <a class="cerrar" href="javascript:fClose();" title="Cerrar"></a>
                                    </div>
                                    <div class="contForm">
                                        <!--MAPITA -->
                                        <div class="mapaCont">
                                            <div class="mapa">
                                                <%if(ViewData["AgencyLocationCoordinates"] != null) {%>
                                                    <%= Html.MapCenterIn(ViewData["AgencyLocationCoordinates"].ToString(), "ABQIAAAA0B1myXxg790GVj8JEg0EvBSeSlW9vW7u8j6xEORhq-WIcyI06BQiJJLQIAKiJzEKAV6jiLPP3uxwtA",570,215)%>
                                                <%}%>
                                                <!--REEMPLAZAR ESTA IMAGEN POR EL MAPA CORRESPONDIENTE -->
                                            </div>
                                        </div>
                                        <!--FIN MAPITA -->
                                        <div class="botonCont">
                                            <a class="btnNar" href="javascript:fClose();" title="Cerrar">
                                                <span class="L"></span>
                                                <span class="M">Cerrar</span>
                                                <span class="R"></span>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td class="cv_right"></td>
                        </tr>
                    </table>
                    <div class="cvBottom pngfix"></div>            
                </div>	
            </div>
        </div>
        <!--FIN CONTACTO MAPA -->
        
        <div class="contactoConce">
            <%--<div class="enviarMail "><!--AGREGARLE LA CLASE "ok" A "enviarMail" PARA MOSTRAR QUE EL ENVIO DE "CONTACTO CONCESIONARIA" FUE CORRECTO-->
                 <div class="PopUpCont chico">
                    
                    <div class="ContOpacExpress puliContacto">
                    
                        <div class="cvTop pngfix"></div>
                        
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="cv_left"></td>
                                <td>
                                    <div class="popCont">
                                        <div class="contHd">
                                            <h4>Contactarse con la concesionaria</h4>
                                            <a class="cerrar" href="javascript:fClose();" title="Cerrar"></a>
                                        </div>
                                        
                                        <div class="contForm">
                                            
                                            <form action="">
                                                
                                                <p class="requerido">Los campos con<span class="rojo"> * </span>son obligatorios.</p>
                                                
                                                
                                                <div class="fila1"><!--AGREGAR EN "fila1" EL MODIFICADOR "error" PARA MOSTRAR EL CAMPO DE ERROR -->
                                                    <label>E-mail:</label><input class="requiere" type="text" value=""/><div class="errorCont">
                    <input type="text" value="" /> <span class="rojo"> Debe ingresar su E-mail</span>
                </div>
                <span class="rojo asterisco">*</span>
                                                </div>
                                                
                                                
                                                
                                                
                                                <div class="fila1">
                                                    <label>Mensaje:</label><textarea rows="" cols="">Escribí acá tu mensaje...</textarea>
                                                </div>
                                                
                                                <div class="fila2">
                                                    <div class="codigoImg"><img src="../../../Content/images/img_codigo_imagen.gif" alt="codigo imagen" /></div>
                                                </div>
                                                <div class="fila2"><!--AGREGAR EN "fila2" EL MODIFICADOR "error" PARA MOSTRAR EL CAMPO DE ERROR -->
                                                    <input class=" codigo requiere" type="text" value="" /> <input class="btnCodigo" title="Ingrese los caracteres" type="submit" value="" />
                                                    
								                   <span class="textError">Debe ingresar los caracteres que visualiza</span>
                
                                                    
                                                    <span class="ingreseChar">Ingrese los caracteres que visualiza</span>
                                                </div>
                                                
                                               
                             
                                                <div class="botonesCont">
                                                    <a class="btnNar" href="#" title="Enviar">
                                                        <span class="L"></span>
                                                        <span class="M">Enviar</span>
                                                        <span class="R"></span>
                                                    </a>
                                                    <a class="cancelar" href="javascript:fClose();" title="Cancelar">Cancelar</a>
                
                                                </div>
                                                
                                                
                                            </form>
                                                </div>
                                                
                                                
                                                <!--EL OKEY -->
                                                <div class="contForm okey">
                                        
                                            <div class="cajaOk"><!--CAMBIAR LA CLASE "cajaOK" PARA MOSTRAR LA CAJA VERDE, O "cajaError" PARA MOSTRAR LA CAJA ROJA.  -->
                                                <div class="textCont">
                                                    <span>Hemos registrado tu solicitud de contacto por un vehículo </span><span><strong>Suzuki Swift 1.5 5p 2009</strong></span>
                                                </div>
                                                
                                                
                                            </div>
                                            
                                            <div class="textInner">
                                                <span>En los próximos minutos recibirás un correo electrónico con los datos del vendedor, y el vendedor recibirá también tus datos para contactarte.</span>
                                           		 <p>El número de referencia de tu solicitud es <strong class="naranjita">US/8455665</strong></p>
                                                <span>Por favor contactanos por cualquier duda que tengas.<br />
                 Gracias nuevamente por utilizar y confiar en nuestros servicios.</span>
                                            </div>
                                                
                                            <div class="botonCont">
                                                    <a class="btnNar" href="javascript:fClose();" title="Cerrar">
                                                        <span class="L"></span>
                                                        <span class="M">Cerrar</span>
                                                        <span class="R"></span>
                                                    </a>
                                                </div>
                                            
                                        </div>
                                                <!--FIN EL OKEY -->
                                                
                                            </div>
                                       
                                </td>
                                <td class="cv_right"></td>
                            </tr>
                        </table>
                        
                        <div class="cvBottom pngfix"></div>
                    
                                
                    </div>	
                </div>
            </div>--%>
        </div>


        <div class="contactar">
           <div class="PopUpCont chico">
                <div class="ContOpacExpress puliContacto">                
                    <div class="cvTop pngfix"></div>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="cv_left"></td>
                            <td>
                                <div class="popCont">
                                    <div class="contHd">
                                        <h4>Contactarse</h4>
                                        <a class="cerrar" href="javascript:fClose();" title="Cerrar"></a>
                                    </div>
                                    <iframe src="<%=ViewData["IframeUrl"]%>/Contacts/Contact/<%=Model.PublicationId%>" frameborder="0" scrolling="no" height="418" width="290"></iframe>                                    
                                </div>
                            </td>
                            <td class="cv_right"></td>
                        </tr>
                    </table>
                    <div class="cvBottom pngfix"></div>
                </div>	
            </div>
        </div>
    </div>

</div>
   

</asp:Content>
