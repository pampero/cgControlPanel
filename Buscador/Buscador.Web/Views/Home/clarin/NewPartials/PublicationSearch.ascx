<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

 <div class="cajaNegra mod clearfix">
                            <div class="Cv Tl"></div>
                            <div class="Cv Tr"></div>
                            <div class="Cv Bl"></div>
                            <div class="Cv Br"></div>

                            <h4>Buscar otro auto</h4>
                            <div class="pngfix buscar">
                            	<form action="">
                                	<div class="checks">
                                    	<input type="radio" name="buscarOtroAuto"/><label>Nuevo</label>
                                        <input type="radio" name="buscarOtroAuto"/><label>Usado</label>
                                        <input type="radio" name="buscarOtroAuto"/><label class="last">Plan de Ahorro</label>
                                    </div>
                                    
                                    <div class="datosBuscar">
                                    	<label>Marca:</label><select><option>Seleccionar...</option><option>#option</option></select>
                                        <label>Modelo:</label><select><option>Seleccionar...</option><option>#option</option></select>
                                        <label>Versión:</label><select><option>Seleccionar...</option><option>#option</option></select>
                                        <label>Año:</label><span>Desde</span><input type="text" /><span>Hasta</span><input type="text" />
                                    </div>
                                    
                                    <div class="botCont">
                                	<a class="btnNar" href="#" title="Buscar">
                                        <span class="L"></span>
                                        <span class="M">Buscar</span>
                                        <span class="R"></span>
                              		</a>

                                </div>
                                    
                                </form>
                            </div>
                        </div>