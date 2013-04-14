<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="cajaNegra">
                    	<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                        
                        
                        <div class="tipoVendedor concesionaria"><!--!!IMPORTANTE PARA QUE APARESCAN LAS SOLAPAS DE VENDEDOR PARTICULAR el div debe quedar con las siguientes clases: class="tipoVendedor particular"-->
                        								<!--A"tipoVendedor" APARTE DEL MOD"particular", TAMBIEN AGREGAR EL MODIFICADOR "ok" PARA MOSTRAR LA CAJA DE "CONTACTO OK" Y OCULTAR LAS DEMAS, !!IMPORTANTE POR OTRO LADO, PARA VER LAS OPCIONES DE "CONTACTO CONCESIONARIA" el div debe quedar con las siguientes clases: class="tipoVendedor concesionaria", SI SE QUIERE VER LA CAJA "CONTACTO CONCESIONARIA OK" el div debe quedar con las siguientes clases: class="tipoVendedor concesionaria ok"-->
                        	<h4 class="contactarV">Contactar al Vendedor</h4>
                            
                            
                            
                            <!--CONTRATAR CONCESIONARIA -->
                            	<div class="contactoConcecionariaCont">
                                		
                                     <div class="cabecera pngfix">
                                        <div class="fotoyVendedor">
                                            <div class="foto">
                                                <img src="<%=Url.Content("~/Content/images/img_fichas_reemplazable1.gif")%>" alt="foto perfil" />
                                            </div>
                                            <div class="vendedor">
                                                <p>Pestelli</p> <p>Suc. San Martín</p> 
                                            </div>
                                        </div>
                                    </div>
                                        
                                        
                                     <div class="solapasParti">
                                        <div class="solapaYBoton">
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
                                            
                                        </div>
                                        <form action="">
                                            <span>Los campos con</span><span class="requerido">*</span><span>son obligatorios.</span>
                                            <div class="instancias"><!--AGREGAR LA CLASE "error" A ESTE DIV PARA MOSTRAR LOS CAMPOS ROJOS -->
                                                <input class="nombre" type="text" value="Apellido y Nombre:" />
                                                <input type="text" class="error"/>
                                                <p class="error">Debe ingresar Nombre y Apellido</p>
                                            </div>  
                                                <span class="requerido mod">*</span>
                                           <div class="instancias"><!--AGREGAR LA CLASE "error" A ESTE DIV PARA MOSTRAR LOS CAMPOS ROJOS -->
                                                <input class="nombre" type="text" value="E-mail:" />
                                                <input type="text" class="error"/>
                                                <p class="error">Debe ingresar su e-mail</p>
                                           </div>
                                           
                                            <span class="requerido mod">*</span>
                                            <input type="text" value="Ej: 011" class="inp1" /><input type="text" value="Ej:43332222" class="inp2" />
                                            <textarea rows="" cols="">Escriba aquí su mensaje</textarea>
                                            
                                            <div class="captchaCont">
                                                <div class="captcha">
                                                    <img src="<%=Url.Content("~/Content/images/img_captcha.jpg")%>" alt="captcha" />
                                                </div>
                                                
                                                <div class="ingresaCodigo">
                                                    <input /><a class="pngfix ingresa" href="#" title="Ingresar los caracteres"></a>
                                                    <span class="ingresa">Ingrese los caracteres que visualiza</span>
                                                    
                                                    <div class="recibNewsletters">
                                                    	<input type="checkbox" name="newsletter" /><span>Acepto recibir Newsletters</span>
                                                    </div>
                                                    
                                                    
                                                    <div class="botCont">
                                                        <a class="btnNar" href="#" title="Enviar">
                                                            <span class="L"></span>
                                                            <span class="M">Enviar</span>
                                                            <span class="R"></span>
                                                        </a>
        
                                                     </div>
        
        
                                                    
                                                </div>
                                                
                                            </div>
                                            
                                        </form>
                                    </div>
                                    
                                    <div class="contactarOk">
                                        <p>Tus datos de contacto fueron enviados al vendedor.</p>
                                        <p>Asimismo, hemos enviado a tu casilla de e-mail <strong>lbenitez@iconosur.com</strong> sus datos para que puedas contactarlo.</p>
                                        
                                        <div class="recuadro">
                                            <p>Av. San Juan 1669, San Cristobal Capital Federal</p>
                                            <p class="telefonos">(011) 4305-4965 <!-- <span class="pipe">|</span>  4006-6404 --></p>
                                            <p class="telefonos secundario">(011) 4305-4444  <!--<span class="pipe">|</span>  4006-6404 --></p>
                                            <p class="telefonos nextel">(011) 4305-4965 <span>- Nextel</span> <!--<span class="pipe">|</span>  4006-6404 --></p>
                                            <a href="#" title="#">atencionclientes@forestcar.com.ar</a>
                                        </div>
                                        
                                    </div>
                                    
                                    
                                    <div class="links">
                                        <div>
                                            <a class="irMicrositio" href="#" title="Ir a Micrositio">Ir a Micrositio</a>
                                            <a class="ubicacionMapa" href="#" title="Ubicación en el mapa">Ubicación en el mapa</a>
                                            <a class="otrosAvisosVend" href="#" title="Ver otros avisos del vendedor">Ver otros avisos del vendedor</a>
                                        </div>
                                    </div>
                                    
                                </div>
                            <!--FIN CONTRATAR CONCESIONARIA -->
                            
                            
                        	<div class="cabecera pngfix">
                            	<div class="fotoyVendedor">
                                	<div class="foto">
                                    	<img src="<%=Url.Content("~/Content/images/img_fichas_reemplazable1.gif")%>" alt="foto perfil" />
                                    </div>
                                    <div class="vendedor">
                                    	<p>Pestelli</p> <p>Suc. San Martín</p> 
                                    </div>
                                </div>
                            </div>
                            
                            <div class="cuerpo">
                            	<ul>
                                	<li><p>Teléfono:</p></li>
                                    <li>(011) 154-305-4965</li>
                                    <li>(011) 154-305-4965</li>
                                </ul>
                                
                                <a class="llamaGratis" href="#" title="¡Llamá Gratis ahora!">
                                	<span class="pngfix L"></span>
                                    <span class="M">¡Llamá Gratis ahora!</span>
                                    <span class="pngfix R"></span>
                                </a>
                                
                                <ul>
                                	<li><p>Horario de contacto:</p></li>
                                    <li><span>Lunes a Viernes de 9hs a 18hs</span></li>
                                
                                </ul>
                                
                                <ul class="email">
                                	<li><p>E-mail:</p></li>
                                    <li><a class="contacto" href="mailto:#contacto" title="#">contacto@nombreconcesionaria.com.ar</a></li>
                                </ul>
                                
                                <div class="botCont">
                                	<a class="btnNar" href="#" title="Contactar Ahora">
                                        <span class="pngfix L"></span>
                                        <span class="M">Contactar Ahora</span>
                                        <span class="pngfix R"></span>
                              		</a>

                                </div>


                                
                            </div>
                            
                            <div class="solapasParti">
                            	<div class="solapaYBoton">
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
                                    
                                </div>
                                <form action="">
                                	<span>Los campos con</span><span class="requerido">*</span><span>son obligatorios.</span>
                                	<div class="instancias"><!--AGREGAR LA CLASE "error" A ESTE DIV PARA MOSTRAR LOS CAMPOS ROJOS -->
                                        <input class="nombre" type="text" value="Apellido y Nombre:" />
                                        <input type="text" class="error"/>
                                        <p class="error">Debe ingresar Nombre y Apellido</p>
                                    </div>  
                                        <span class="requerido mod">*</span>
                                   <div class="instancias"><!--AGREGAR LA CLASE "error" A ESTE DIV PARA MOSTRAR LOS CAMPOS ROJOS -->
                                   		<input class="nombre" type="text" value="E-mail:" />
                                        <input type="text" class="error"/>
                                        <p class="error">Debe ingresar su e-mail</p>
                                   </div>
                                   
                                    <span class="requerido mod">*</span>
                                    <input type="text" value="Ej: 011" class="inp1" /><input type="text" value="Ej:43332222" class="inp2" />
                                    <textarea rows="" cols="">Escriba aquí su mensaje</textarea>
                                    
                                    <div class="captchaCont">
                                		<div class="captcha">
                                        	<img src="<%=Url.Content("~/Content/images/img_captcha.jpg")%>" alt="captcha" />
                                        </div>
                                        
                                        <div class="ingresaCodigo">
                                        	<input /><a class="pngfix ingresa" href="#" title="Ingresar los caracteres"></a>
                                            <span class="ingresa">Ingrese los caracteres que visualiza</span>
                                            <div class="recibNewsletters">
                                               	<input type="checkbox" name="newsletter" /><span>Acepto recibir Newsletters</span>
                                            </div>
                                            
                                            
                                            
                                            
                                            
                                            <div class="botCont">
                                                <a class="btnNar" href="#" title="Enviar">
                                                    <span class="L"></span>
                                                    <span class="M">Enviar</span>
                                                    <span class="R"></span>
                                                </a>

                               				 </div>


                                            
                                        </div>
                                        
                                	</div>
                                    
                                </form>
                                
                                
                                
                            </div>
                            
                            
                            <div class="contactarOk">
                            	<p>Tus datos de contacto fueron enviados al vendedor.</p>
                                <p>Asimismo, hemos enviado a tu casilla de e-mail <strong>lbenitez@iconosur.com</strong> sus datos para que puedas contactarlo.</p>
                            	
                                <div class="recuadro">
                                	<p>Av. San Juan 1669, San Cristobal Capital Federal</p>
                                    <p class="telefonos">(011) 4305-4965  <span class="pipe">|</span>  4006-6404</p>
                                    <a href="#" title="#">atencionclientes@forestcar.com.ar</a>
                                </div>
                                
                            </div>
                            
                            <div class="links">
                            	<div>
                                	<a class="irMicrositio" href="#" title="Ir a Micrositio">Ir a Micrositio</a>
                                    <a class="ubicacionMapa" href="#" title="Ubicación en el mapa">Ubicación en el mapa</a>
                                    <a class="otrosAvisosVend" href="#" title="Ver otros avisos del vendedor">Ver otros avisos del vendedor</a>
                                </div>
                            </div>
                            
                        </div>
                        
                    </div>