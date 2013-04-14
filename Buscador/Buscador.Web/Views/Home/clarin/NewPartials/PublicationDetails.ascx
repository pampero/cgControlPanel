<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>

 <div class="comun detalles <%if(Model.VehicleType == 3){%> active <%}%>"><!--AGREGAR LA CLASE "active" A ESTE DIV PARA MOSTRAR "EL DETALLE DE PLAN DE AHORRO" Y EL RANGO DE CUOTAS -->
        <div class="cajaGris clearfix">
            <div class="Cv Tl"></div>
            <div class="Cv Tr"></div>
            <div class="Cv Bl"></div>
            <div class="Cv Br"></div>
                                
            <div class="titular gris clearfix">
                <h4 class="avisos">Detalles del Plan de Ahorro</h4>
            </div>
               
        </div>
        <div class="detalesPlanAhorroCont">
            <div class="first">
                <ul>
                    <li>Tipo de Plan:<p>Adjudicado</p></li>
                    <li>Valor venta del Plan: <p>$15000</p></li>
                    <li>Tipo de Financiación: <p>70/30</p></li>
                    <li>Valor cuota promedio: <p>$519</p></li>
                    <li>Valor cuota pura: <p>$425</p></li>
                    <li>Total cuotas: <p>84</p></li>
                    <li>Entrega pactada cuota: <p>10</p></li>
                    <li><p></p></li>
                </ul>
            </div>
                                
            <div class="last">
                <h3>Rango de cuotas:</h3>
                <ul>
                    <li>Cuota 1 a 10: <p>$500</p></li>
                    <li>Tipo de Financiación: <p>$500</p></li>
                    <li>Valor cuota pura: <p>$500</p></li>
                </ul>
            </div>
                                    
            </div>
                         
</div>