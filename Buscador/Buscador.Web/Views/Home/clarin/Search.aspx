<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="Buscador.Domain" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.filters" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.slices" %>
<%@ Import Namespace="Buscador.Services.com.clarin.services" %>
<%@ Import Namespace="Buscador.Web" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="Buscador.Web.Controllers" %>
<%@ Import Namespace="Buscador.Web.Views.Home.Helpers" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     </div>
    <% var result = ((IResults<Publication>)ViewData["result"]); %>
    <div id="lisleft">
        <div id="tit-fil">Filtrar búsqueda</div>
        <% var i = 0; %>
        <% foreach (var filterGroup in result.FilterGroups)
           {
               if (filterGroup.Name == "vehicle_year" && result.VisibleAppliedFilters.Where(x => x.Name == "vehicle_type_id" && x.Value == "NewCar").Count() > 0) continue;
               %>
        <div class="twisty open bor">
            <div class="twistyOpen">
                <%= Html.Encode(filterGroup.Name.Localize()) %>
            </div>
            <div class="option" style="display: block;">
                
				<div class="filtres">
					<ul>
						<% foreach (var filter in filterGroup.FiltersToShow.Take(5))
						   { %>
							<li>
								<% Html.RenderPartial("FilterSection", filter); %>
							</li>
						<% } %>
					</ul>
				</div>

                <%if(filterGroup.FiltersToShow.Count>5){%>
                <div id="vermas">
                    <div id="firstpane">
                        <p id="verMasLabel" class="menu_head" onclick="this.style.display='none';">Ver más</p>
                          <div class="menu_body">
                            <ul id="navlist">
                                <% foreach (var filter in filterGroup.FiltersToShow.Take(10).Except(filterGroup.FiltersToShow.Take(5)))
                                   { %>
                                    <li>
                                        <% Html.RenderPartial("FilterSection", filter); %>
                                    </li>
                                <% } %>
                            </ul>
                            <%if (filterGroup.FiltersToShow.Count>10){ %>
                                <a href="javascript:void(0)" onclick="document.getElementById('light<%=i%>').style.display='block';document.getElementById('fade').style.display='block'">
                                    <b>Ver Mas</b>
                                </a>
                            <%} %>
                        </div>
                    </div>
                </div>
                <!-- base semi-transparente -->
                <div id="fade" class="overlay" onclick="document.getElementById('light<%=i%>').style.display='none';document.getElementById('fade').style.display='none'">
                </div>
                <!-- fin base semi-transparente -->
                <!-- ventana modal oculta -->
                <div id="light<%=i%>" class="modal">
                    <div id="modalTitle" style="background-color:Orange; width:100%; float:left;padding-left: 5px;color:White;font-weight:bold;font-size:small"><%=Html.Encode(filterGroup.Name.Localize()) %>
                        <div class="closemodal" style="width:30%; background-color:Orange;float: right;padding-right: 5px;">
                            <a href="javascript:void(0)" onclick="document.getElementById('light<%=i%>').style.display='none';document.getElementById('fade').style.display='none'">
                                Cerrar</a>
                        </div>
                    </div>
                    <div style="margin: 0 auto;float:left;overflow-y:scroll;height:95%;width:100%">
                        <%
                            int columnResult = 12;
                            int cantColumns = 3;
 
                            if((filterGroup.FiltersToShow.Count()/columnResult) > 2)
                            {
                                
                                columnResult = filterGroup.FiltersToShow.Count()/cantColumns + 1;
                            }

                            var orderedFilter = filterGroup.FiltersToShow.OrderBy(x => x.Name);
                            
                        %><br />
                       <%for (int iColumn = 1; iColumn <= cantColumns; iColumn++)
                        {
                        %>
                              <div style="width:200px; float:left;">
                                <ul>
                                       <% //foreach (var filter in filterGroup.FiltersToShow.Except(filterGroup.FiltersToShow.Take(5))
                                        //.Except(filterGroup.FiltersToShow.Take(10).Except(filterGroup.FiltersToShow.Take(5))))
                                        foreach (var filter in orderedFilter.Take(iColumn * columnResult).Except(orderedFilter.Take(columnResult * (iColumn - 1))))
                                        {%>
                                             <li>
                                                                    
                                                                                    <%
                                                    Html.RenderPartial("FilterSection", filter);%>
                                                                                               
                               
                                            </li>
                                                                    <%
                                        }%> 
                                </ul>
                             </div>
                                
                           
                       <%
                            }%>
                    </div>
                </div>
                <% } %>
            </div>
        </div>
        <% i++;
           } %>
        <script type="text/javascript">
            $(document).ready(function () {
                $('div.twisty').twisty();  // Find all DIV tags with class "twisty" and then apply Twisty plugin.
            });   
        </script>
        <script type="text/javascript">
          
            function OnSubmitRangeForm(form,type) {
                var desdeValue = form.elements[0].value;
                var hastaValue = form.elements[1].value;
                
				if(desdeValue=="" || hastaValue=="")
				{ 
                    form.txtDesde.style.backgroundColor = "#FEE";
                    form.txtHasta.style.backgroundColor = "#FEE";
                    return false;
                }
				if(isNaN(desdeValue) || isNaN(hastaValue))
                {
                    form.txtDesde.style.backgroundColor = "#FEE";
                    form.txtHasta.style.backgroundColor = "#FEE";
                    return false;
                }
                else
                {
                    if(parseInt(desdeValue)>parseInt(hastaValue))
                    {form.txtDesde.style.backgroundColor = "#FEE";
                    form.txtHasta.style.backgroundColor = "#FEE";
                    return false;}
                        
                }
                var newAction;
                if(type=="PR")
                    newAction = form.getAttribute("url").replace("PRYYvehicle_price_absolute", "PRYY" + desdeValue + "-" + hastaValue);
                if(type=="VK")
                    newAction = form.getAttribute("url").replace("VKYYvehicle_km", "VKYY" + desdeValue + "-" + hastaValue);
                if(type=="YE")
                    newAction = form.getAttribute("url").replace("YEYYvehicle_year", "YEYY" + desdeValue + "-" + hastaValue);
                form.action = newAction;
                return true;
            }

            function OnSubmitOrder() {
                var ddlOrder = window.document.getElementById("ddlOrder");
                var selectedValue = ddlOrder.options[ddlOrder.selectedIndex].value;
                var newAction;
			
		if(selectedValue=="Ordenar por")
		{
			return false;
		}

                if (document.URL.indexOf("SOYY") == -1) {
                    if(<%=result.AppliedFilters.Count%> == 0)
                        newAction = document.URL + "/SOYY" + selectedValue;
                    else
                        newAction = document.URL + "WWSOYY" + selectedValue;
                }
                else {
                    newAction = document.URL.replace(/SOYY\S\S\S/, "SOYY" + selectedValue);
                }

                newAction = newAction.replace(/PG\S\S\S/,"");
                
                if ($.browser.safari)
                {
                    document.location = newAction;
                    return true;
                }
                
                document.orderRangeForm.action = newAction;
                document.orderRangeForm.submit();
                return true;
            }



           


        </script>
    


	<div id="iAvisos-200x200">
	<!-- e-planning v3 - Comienzo espacio DeAutos.com _ Usados _ RightiAvisos200x200 -->
	<script type="text/javascript" language="JavaScript1.1">
	<!--
	var rnd = (new String(Math.random())).substring(2,8) + (((new Date()).getTime()) & 262143);
	var cs = document.charset || document.characterSet;
	document.write('<scri' + 'pt language="JavaScript1.1" type="text/javascript" src="http://ads.e-planning.net/eb/3/4d63/164efc5fa74c5204?o=j&rnd=' + rnd + '&crs=' + cs + '"></scr' + 'ipt>');
	//-->
	</script>
	<noscript><a href="http://ads.e-planning.net/ei/3/4d63/164efc5fa74c5204?it=i&rnd=$RANDOM" target="_blank"><img alt="e-planning.net ad" src="http://ads.e-planning.net/eb/3/4d63/164efc5fa74c5204?o=i&rnd=$RANDOM" border=0></a></noscript>
	<!-- e-planning v3 - Fin espacio DeAutos.com _ Usados _ RightiAvisos200x200 -->
	</div>

</div>

    <div class="navtrail">
        <% foreach (var filterApplied in result.VisibleAppliedFilters)
           {
               string a = filterApplied.Value;
               filterApplied.Value = filterApplied.Name;
               filterApplied.Name = a;
               

               
               %>
        <div class="globos">
            <span style="text-decoration: none;"><a href="<%=filterApplied.Url%>">
                <img border="0" src="../../../../Content/images/close.gif" alt="eliminar filtro"/>
            </a></span>
            <span class="">
                <%= (filterApplied.Name=="vehicle_price_absolute")? "$":string.Empty %> <%=Html.Encode(((Slice)filterApplied).Localize().ToProper())%> <%= (filterApplied.Name=="vehicle_km")? "km":string.Empty %></span>
        </div>
        <% } %>
    </div>
    <div class="optionals">
        <div id="h1_title" >
            <span style="font-family: Arial, Helvetica, sans-serif;font-size: 18px;font-weight: normal;color: black;text-decoration: none;display: inline;">
                <span style="float:left; padding-right:5px;line-height: 45px;"> Se han encontrado </span>
                <span class="numcars" style="float:left; padding-right:5px;line-height: 45px;"><%=int.Parse(ViewData["TotalResult"].ToString()).WithThousandsSeparator()%></span>
                <h2 style="float:left;position:relative; top:-1px;font-family: Arial, Helvetica, sans-serif;font-size: 18px;font-weight: normal;color: black;text-decoration: none;display: inline;line-height: 45px;">Autos <%=ViewData["Title"]%> </h2>
            </span>
            <div style=" display:inline-table; ">
            <!-- AddThis Button BEGIN -->
                <div class="addthis_toolbox addthis_default_style " style="float:left; margin-top:13px; margin-left:40px; width:150px;">
                <a class="addthis_button_preferred_1" style="margin-right:15px;"></a>
                <a class="addthis_button_preferred_3" style="margin-right:15px;"></a>
                <a class="addthis_button_compact"></a>
                <a class="addthis_counter addthis_bubble_style"></a>
                </div>
<script type="text/javascript">    var addthis_config = { "data_track_clickback": true };</script>
<script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d6e84a053a772da"></script>
<!-- AddThis Button END -->
            
            
            <!-- Añade esta etiqueta en la cabecera o delante de la etiqueta body. -->
            <script type="text/javascript" src="https://apis.google.com/js/plusone.js">
            { lang: 'es-419' }
            </script>
            <div style="margin-left:20px;margin-top: 13px; float:left">
            <!-- Añade esta etiqueta donde quieras colocar el botón +1 -->
            <g:plusone size="small"></g:plusone>
            </div>
            </div>
        </div>
        <div class="tools">
            <%--<div class="rss">
                <a href="">RSS</a></div>
            <%--<div class="savelist">
                <a rel="shadowbox;width=290;height=240" title="" href="../../../../Views/Home/clarin/partials/modal.html">
                    Guardar búsqueda</a></div>--%>
            <!-- <div class="fb"><a href="">Compartir en Facebook</a></div>
            <div class="tw"><a href="">Compartir en Twitter</a></div> -->
        </div>
    </div>
    <div class="filtros">
        <div class="desplegable">
            <form name='orderRangeForm' method='get'>
            <select class="styled" id="ddlOrder" onchange="OnSubmitOrder();">
                <option  selected="selected">Ordenar por</option>
                <option <%=result.Order.CurrentOrderValue=="vehicle_price_absolute asc"?"selected='true'":string.Empty %> value="PRA">Menor precio</option>
                <option <%=result.Order.CurrentOrderValue=="vehicle_price_absolute desc"?"selected='true'":string.Empty %> value="PRD">Mayor precio</option>
                <option <%=result.Order.CurrentOrderValue=="vehicle_km asc"?"selected='true'":string.Empty %> value="VKA">Menor Km</option>
                <option <%=result.Order.CurrentOrderValue=="vehicle_km desc"?"selected='true'":string.Empty %> value="VKD">Mayor Km</option>
                <option <%=result.Order.CurrentOrderValue=="vehicle_year asc"?"selected='true'":string.Empty %> value="YEA">Menor año</option>
                <option <%=result.Order.CurrentOrderValue=="vehicle_year desc"?"selected='true'":string.Empty %> value="YED">Mayor año</option>

            </select>
            <!-- <input type="button" value="IR" onClick="#" name="button"> -->
            </form>
        </div>
        <div class="tittabs">
            <ul id="FlotaIzquierda">
                <li class="tab01">Localidad</li>
                <li class="tab02">Km</li>
                <li class="tab03">Año</li>
                <li class="tab04">Combustible</li>
                <li class="tab05">Precio</li>
            </ul>
        </div>
    </div>


    <div class="banner_r">
    <%--<!-- e-planning v3 - Comienzo espacio DeAutos.com _ Usados _ SkyRight120x600 -->
    <script type="text/javascript" language="JavaScript1.1">
    <!--
    var rnd = (new String(Math.random())).substring(2,8) + (((new Date()).getTime()) & 262143);
    var cs = document.charset || document.characterSet;
    document.write('<script language="JavaScript1.1" type="text/javascript" src="http://ads.e-planning.net/eb/3/4d63/6ad6b164305a4b99?o=j&rnd=' + rnd + '&crs=' + cs + '"></script>');
    //-->
    </script>
    <noscript><a href="http://ads.e-planning.net/ei/3/4d63/6ad6b164305a4b99?it=i&rnd=$RANDOM" 
    target="_blank"><img alt="e-planning.net ad" 
    src="http://ads.e-planning.net/eb/3/4d63/6ad6b164305a4b99?o=i&rnd=$RANDOM" border=0></a></noscript>
    <!-- e-planning v3 - Fin espacio DeAutos.com _ Usados _ SkyRight120x600 -->--%>
    <%=ViewData["bannerRightHtml"] %>
    </script>
    </div>


    <div class="lisavisos">
        <% foreach (var publication in result.ResultList)
           {
               publication.CPublicationType.Accept(new PublicationTypeVisitor(publication, Html));
           }
        %>
        <center>
            <div class="pagination">
                <% Html.RenderPartial("PagerSection", result); %>
            </div>

			<div id="banner_bottom">
			<%--<!-- e-planning v3 - Comienzo espacio DeAutos.com _ Usados _ Top728x90 -->
			<script type="text/javascript" language="JavaScript1.1">
			<!--
			var rnd = (new String(Math.random())).substring(2,8) + (((new Date()).getTime()) & 262143);
			var cs = document.charset || document.characterSet;
			document.write('<scri' + 'pt language="JavaScript1.1" type="text/javascript" src="http://ads.e-planning.net/eb/3/4d63/ad075f6d3d86c36c?o=j&rnd=' + rnd + '&crs=' + cs + '"></scr' + 'ipt>');
			//-->
			</script>
			<noscript><a href="http://ads.e-planning.net/ei/3/4d63/ad075f6d3d86c36c?it=i&rnd=$RANDOM" target="_blank"><img alt="e-planning.net ad" src="http://ads.e-planning.net/eb/3/4d63/ad075f6d3d86c36c?o=i&rnd=$RANDOM" border=0></a></noscript>
			<!-- e-planning v3 - Fin espacio DeAutos.com _ Usados _ Top728x90 -->--%>
            <%=ViewData["bannerBottomHtml"] %>
            </script>
            </div>


        </center>
    </div>






</asp:Content>
