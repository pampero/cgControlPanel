<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%@ Import Namespace="System.Collections.Generic" %>

<!--Para utilizar esta partial se debe incluir el archivo search.js en la pagina y agregar en el document.ready la funcion initializeSearch() incluida en dicho js-->
 <div class="cajaNegra mod clearfix">
    <div class="Cv Tl"></div>
    <div class="Cv Tr"></div>
    <div class="Cv Bl"></div>
    <div class="Cv Br"></div>

    <h4>Buscar otro auto</h4>
    <div class="pngfix buscar">
        <div class="checks">
            <input type="radio" id="Radio1" vehicletype="1" value="usados" name="buscarOtroAuto"/><label>Usado</label>
            <input type="radio" id="buscarOtroAuto" vehicletype="2" value="nuevos" name="buscarOtroAuto"/><label>Nuevo</label>
            <%--<input type="radio" id="buscarOtroAuto" vehicletype="3" value="planahorro" name="buscarOtroAuto"/><label class="last">Plan de Ahorro</label>--%>
        </div>
                                    
        <div class="datosBuscar">
            <div class="marginL"><label>Marca:</label><%= Html.DropDownList("VehicleBrands", new SelectList("",""))%></div>
            <div class="marginL"><label>Modelo:</label><%= Html.DropDownList("VehicleModels", new SelectList("", ""))%></div>
            <div class="marginL"><label>Versión:</label><%= Html.DropDownList("VehicleVersions", new SelectList("", ""))%></div>
            <div class="marginL"><label>Año:</label><span>Desde</span><input type="text" id="sincedate" onkeypress = "return isNumberKey(event)"  /><span>Hasta</span><input type="text" id="todate" onkeypress = "return isNumberKey(event)" /></div>
        </div>
        <div class="botCont">
            <a class="btnNar" id="btnSearch" title="Buscar">
                <span class="L"></span>
                <span class="M">Buscar</span>
                <span class="R"></span>
            </a>
        </div>
    </div>
</div>