<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="System.Linq" %>

<div class="comun">
        <div class="cajaGris clearfix">
            <div class="Cv Tl"></div>
            <div class="Cv Tr"></div>
            <div class="Cv Bl"></div>
            <div class="Cv Br"></div>
            <div class="titular gris clearfix">
                <h4 class="avisos">Más info</h4>
            </div>
        </div>
        <div class="inner masinfo">
        <p><%=Model.SellerComment%></p>
        </div>
</div>
			
<div class="comun">
                         <div class="cajaGris equi clearfix">
                                <div class="Cv Tl"></div>
                                <div class="Cv Tr"></div>
                                <div class="Cv Bl"></div>
                                <div class="Cv Br"></div>
                                
                                <div class="titular gris clearfix">
                                    <h4 class="avisos">Equipamiento</h4>
                                </div>
                         </div>
                         <div class="inner">
                         	
                            <div class="CONFORT open" id="divConfortSpecs"><!--AGREGAR LA CLASE "open" PARA DESPLEGAR EL CONTENIDO -->
								<div class="titul">
									<a href="javascript:OpenSpecs('divConfortSpecs')" title="Abrir"></a>
									<h4>Confort</h4>
								</div>
								<div class="listado">
									<ul>
                                         <%foreach (var spec in Model.EquipmentAttributes.Where(x => x.AttrType =="Confort").ToList())
                                          {%>
                                                <li><p><%=spec.AttrValue%></p></li>                                              
                                          <%}%>
									</ul>
									
								</div>
							</div>
							
							 <div class="CONFORT open" id="divSecuritySpecs"><!--AGREGAR LA CLASE "open" PARA DESPLEGAR EL CONTENIDO -->
								<div class="titul">
									<a href="javascript:OpenSpecs('divSecuritySpecs')" title="Cerrar"></a>
									<h4>Seguridad</h4>
								</div>
								<div class="listado">
									<ul>
                                        <%foreach (var spec in Model.EquipmentAttributes.Where(x => x.AttrType =="Seguridad").ToList())
                                          {%>
                                                <li><p><%=spec.AttrValue%></p></li>                                              
                                          <%}%>
									</ul>
									
								</div>
							</div>
							
							
							 <div class="CONFORT last open" id="divExteriorSpecs"><!--AGREGAR LA CLASE "open" PARA DESPLEGAR EL CONTENIDO -->
								<div class="titul">
									<a href="javascript:OpenSpecs('divExteriorSpecs')" title="Abrir"></a>
									<h4>Exterior</h4>
								</div>
								<div class="listado">
									<ul>
                                        <%foreach (var spec in Model.EquipmentAttributes.Where(x => x.AttrType =="Exterior").ToList())
                                          {%>
                                                <li><p><%=spec.AttrValue%></p></li>                                              
                                          <%}%>
									</ul>
									
								</div>
							</div>
							
							
                            <div class="flechadepublicacion">
                            	<label>Fecha publicación:</label><strong>12/12/2010 </strong><span> | </span>
                                <label>Visitas:</label><strong>20</strong>
                            </div>
                            
                         </div>
                         
                    </div>  