<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Buscador.Web.Controllers.ViewModels.HomeViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="lisresultado home">
	<!-- CONTENIDO -->

	<div class="Cont clearfix ">   		
        <!--CONTEINER -->
        <div class="conteiner colMargen clearfix"><!--segin el modificador que tenga "conteiner", cambiará la columna left -->
        	<h1 class="textUp">Compra y Venta de autos Usados y Autos 0 km</h1>
            
            <div class="bannersCont mod bann clearfix">
                <div class="bn950x50">
                    <div style="background-color: rgb(102, 102, 102); text-align: center; width:950px; height:50px; float: left;">
                        <p style="padding-top:17px; color: rgb(255, 255, 255); font-weight:normal;">Banner 950 x 50</p>
                    </div>
                </div>
            </div>
            
        	<div class="colLeft">
                <div class="columnaLeft">
                	
                 <div class="cajaNegra">   
                            <div class="Cv Tl"></div>
                            <div class="Cv Tr"></div>
                            <div class="Cv Bl"></div>
                            <div class="Cv Br"></div>
                    <nav class="boxTabs clearfix">
                    	<ul class="clearfix">
                        	
                            <li class="Contenedor active">
                            	<h2>
                                    <a class="tab" title="Buscar Autos Usados">
                                    	<span class="L"></span>
                                        <span class="M">Autos Usados</span>
                                        <span class="R"></span>
                                    </a>
                                </h2>
                            </li>
                            <li class="Contenedor">
                            	<h2>
                                    <a class="tab"  title="Buscar Autos Nuevos">
                                    	<span class="L"></span>
                                        <span class="M">Autos Nuevos</span>
                                        <span class="R"></span>
                                    </a>
                                </h2>
                            </li>
                            <li class="Contenedor">
                            	<h2>
                                    <a class="tab" title="Buscar Planes de Ahorro">
                                    	<span class="L"></span>
                                        <span class="M">Planes de Ahorro</span>
                                        <span class="R"></span>
                                    </a>
                                </h2>
                            </li>
                            
                            <!--<li class="Contenedor">
                            	<h2>
                                	<a class="tab" title="Catálogo">
                                    	<span class="L"></span>
                                        <span class="M">Catálogo</span>
                                        <span class="R"></span>
                                    </a>
                                </h2>
                            </li>-->
                        </ul>
                        
                        
                    </nav>
                     <article class="boxTabsCont2 clearfix">
                       
                            <!--AUTOS USADOS -->
                            <section class="Contenedor usados clearfix activo">
                        	<form action="post">
                            	<ul class="clearfix">
                                	
                                   <li>
                                    	<label>Marca:</label>
                                        <div class="selectDiv z1">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Precio:</label>
                                        <div class="input clearfix">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        	<input class="desde" type="text" value="Desde"/>
                                        </div>
                                         <div class="input mod  clearfix">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        <input class="hasta" type="text" value="Hasta"/>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Modelo:</label>
                                       <div class="selectDiv z2">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Año:</label>
                                        <div class="selectDiv first z1 little">
                                        	<div class="Cv Tl"></div>
                                            <div class="Cv Tr"></div>
                                            <div class="Cv Bl"></div>
                                            <div class="Cv Br"></div>
                                                
                                            <ul style="height: 26px; overflow-y: hidden;" class="selectUl" id="pais">
                                                <li class="act first" style="display: list-item;"><span id="bolivia" title="Bolivia">Desde</span></li>
                                                <li style="display: none;"><a href="#" id="seleccionar" title="Seleccionar País">option 1</a></li>                                                <li class="" style="display: none;"><a href="#" id="argentina" title="Argentina">option 2</a></li>
                                                <li class="" style="display: none;"><a href="#" id="argentina" title="Argentina">option 3</a></li>
                                                <li class="" style="display: none;"><a href="#" id="argentina" title="Argentina">option 4</a></li>
                                                <li style="display: none;"><a href="#" id="brasil" title="Brasil">option 5</a></li>
                                                <li style="display: none;" class="last"><a href="#" id="otros" title="Otros">option 6</a></li>
                                            </ul>
                                            <span style="display: block;" class="selectSpan"><span class="pngfix"></span></span>
                                        </div>
                                       <div class="selectDiv first little z1">
                                       		<div class="Cv Tl"></div>
                                            <div class="Cv Tr"></div>
                                            <div class="Cv Bl"></div>
                                            <div class="Cv Br"></div>
                                                
                                            <ul style="height: 26px; overflow-y: hidden;" class="selectUl" id="pais">
                                                <li class="act first" style="display: list-item;"><span id="bolivia" title="Bolivia">Hasta</span></li>
                                                <li style="display: none;"><a href="#" id="seleccionar" title="Seleccionar País">option 1</a></li>                                                <li class="" style="display: none;"><a href="#" id="argentina" title="Argentina">option 2</a></li>
                                                <li class="" style="display: none;"><a href="#" id="argentina" title="Argentina">option 3</a></li>
                                                <li class="" style="display: none;"><a href="#" id="argentina" title="Argentina">option 4</a></li>
                                                <li style="display: none;"><a href="#" id="brasil" title="Brasil">option 5</a></li>
                                                <li style="display: none;" class="last"><a href="#" id="otros" title="Otros">option 6</a></li>
                                            </ul>
                                            <span style="display: block;" class="selectSpan"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Version:</label>
                                        <div class="selectDiv z3">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                     <li>
                                    	<label>Provincia:</label>
                                        <div class="selectDiv first z2">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Km:</label>
                                         <div class="input">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        <input class="desde" type="text" value="Desde"/>
                                        </div>
                                         <div class="input mod">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        <input class="hasta" type="text" value="Hasta"/>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Localidad:</label>
                                        <div class="selectDiv">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                </ul>
                                
                                <div class="search clearfix">
                                    <a title="Buscar" href="#" class="btnNar">
                                        <span class="L"></span>
                                        <span class="M">Buscar</span>
                                        <span class="R"></span>
                                    </a>
                                </div>
                                
                            </form>
                            <div class="segSearch">
                            	<label class="busPorSeg">Búsqueda por segmento:</label>
                                <div class="porSeg">
                                	<a href="#" title="#">Sedan 4P</a>
                                    <span>|</span>
                                    <a href="#" title="#">Hatchback 3P</a>
                                    <span>|</span>
                                    <a href="#" title="#"> Coupé </a>
                                    <span>|</span>
                                    <a href="#" title="#">Familiar</a>
                                    <span>|</span>
                                    <a href="#" title="#">PickUp  </a>
                                    <span>|</span>
                                    <a href="#" title="#">Todo Terreno / Suv </a>
                                    <span>|</span>
                                    <a href="#" title="#">Coupé </a>
                                    <span>|</span>
                                    <a href="#" title="#">Utilitarios  </a>
                                    <span>|</span>
                                    <a href="#" title="#">Hatchback 5P </a>
                                    <span>|</span>
                                    <a href="#" title="#">Monovolumen  </a>
                                    <span>|</span>
                                    <a href="#" title="#">Otros </a>
                                  </div>
                            </div>
                            
                            <a class="irAlCompa" title="Ir al comparador" href="#">
                        		Ir al comparador
                       		 </a>
                             
                        	</section>
                            <!--FIN AUTOS USADOS -->
                            
                            <section class="Contenedor nuevos clearfix"><!--AGREGARLE LA CLASE "activo" A ESTE SECTION PARA VER EL CONTENIDO DE LAS SOLAPAS: NUEVOS, USADOS O PLAN DE AHORRO. -->
                        	<form action="post">
                            	<ul class="clearfix">
                                    <li>
                                    	<label>Marca:</label>
                                        <div class="selectDiv z1">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Precio:</label>
                                         <div class="input">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        <input type="text" value="Desde" class="desde">
                                        </div>
                                         <div class="input mod">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        <input type="text" value="Hasta" class="hasta">
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Modelo:</label>
                                        <div class="selectDiv z2">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Provincia:</label>
                                        <div class="selectDiv z2">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    
                                    <li>
                                    	<label>Versión:</label>
                                        <div class="selectDiv z3">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                     <li>
                                    	<label>Localidad:</label>
                                        <div class="selectDiv z3">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                </ul>
                                
                                <div class="search clearfix">
                                	<a class="btnNar" href="#" title="Buscar">
                                        <span class="L"></span>
                                        <span class="M">Buscar</span>
                                        <span class="R"></span>
                                    </a>                                  
                                </div>
                                
                            </form>
                            <div class="segSearch">
                            	<label class="busPorSeg">Búsqueda por segmento:</label>
                                <div class="porSeg">
                                	<a href="#" title="buscar #segmento">Sedan 4P</a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Hatchback 3P</a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento"> Coupé </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Familiar</a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">PickUp  </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Todo Terreno / Suv </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Coupé </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Utilitarios  </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Hatchback 5P </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Monovolumen  </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Otros </a>
                                  </div>
                            </div>
                            
                            
                             <a href="#" title="Ir al comparador" class="irAlCompa">
                        		Ir al comparador
                       		 </a>
                            
                        	</section>
                        
                        	<!--PLANES DE AHORRO -->
                        	<section class="Contenedor plan clearfix">
                        	<form action="post">
                            	<ul class="clearfix">
                                	<li>
                                    	<label>Tipo de Plan:</label>
                                        <div class="selectDiv z1">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Marca:</label>
                                        <div class="selectDiv z1">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Valor Cuota:</label>
                                         <div class="input">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        <input class="desde" type="text" value="Desde"/>
                                        </div>
                                         <div class="input mod">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                        <input class="hasta" type="text" value="Hasta"/>
                                        </div>
                                    </li>
                                     <li>
                                    	<label>Modelo:</label>
                                        <div class="selectDiv z2">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                </ul>
                                
                                <div class="search clearfix">
                                    <a title="Buscar" href="#" class="btnNar">
                                        <span class="L"></span>
                                        <span class="M">Buscar</span>
                                        <span class="R"></span>
                                    </a>
                                </div>
                                
                            </form>
                            <section class="planesCont2">
                            	<ul>
                                	<li>
                                    	<a href="#" title="plan de ahorro #marca">
                                    	<img src="img/fd_home_reemplazable1.gif" alt="deautos">
                                        </a>
                                        <a class="planes" href="#" title="plan de ahorro #marca">Autoahorro Volkswagen</a>
                                    </li>
                                    <li>
                                    	<a href="#" title="plan de ahorro #marca">
                                    	<img src="img/fd_home_reemplazable1.gif" alt="deautos">
                                        </a>
                                        <a class="planes" href="#" title="plan de ahorro #marca">Autoahorro Volkswagen</a>
                                    </li>
                                    <li>
                                    	<a href="#" title="plan de ahorro #marca">
                                    	<img src="img/fd_home_reemplazable1.gif" alt="deautos">
                                        </a>
                                        <a class="planes" href="#" title="plan de ahorro #marca">Autoahorro Volkswagen</a>
                                    </li>
                                    <li>
                                    	<a href="#" title="plan de ahorro #marca">
                                    	<img src="img/fd_home_reemplazable1.gif" alt="deautos">
                                        </a>
                                        <a class="planes" href="#" title="plan de ahorro #marca">Autoahorro Volkswagen</a>
                                    </li>
                                    <li>
                                    	<a href="#" title="plan de ahorro #marca">
                                    	<img src="img/fd_home_reemplazable1.gif" alt="deautos">
                                        </a>
                                        <a class="planes" href="#" title="plan de ahorro #marca">Autoahorro Volkswagen</a>
                                    </li>
                                    <li class="verTodos">
                                    	<a class="ver21" href="#" title="Ver Todos los planes de ahorro">Ver Todos</a>
                                    </li>
                                </ul>
                            </section>
                        	</section>
                            <!--FIN PLANES DE AHORRO -->
                                                      
                            <!--CATALOGO -->
                            <section class="Contenedor nuevos clearfix"><!--AGREGARLE LA CLASE "activo" A ESTE SECTION PARA VER EL CONTENIDO DE LAS SOLAPAS: NUEVOS, USADOS O PLAN DE AHORRO. -->
                        	<form action="post">
                            	<ul class="clearfix">
                                    
                                    
                                    <li>
                                    	<label>Marca:</label>
                                        <div class="selectDiv z2">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                    <li>
                                    	<label>Modelo:</label>
                                        <div class="selectDiv z2">
                                        		<div class="Cv Tl"></div>
                                                <div class="Cv Tr"></div>
                                                <div class="Cv Bl"></div>
                                                <div class="Cv Br"></div>
                                                
                                            <ul id="pais" class="selectUl" style="height:21px; overflow-y: hidden;">
                                            	<li style="display: list-item;" class="act"><span title="Seleccionar" id="option0">Seleccionar</span></li>
                                                <li style="display: none;"><a title="#" id="option1" href="#">Option 1</a></li>                                                <li style="display: none;" class=""><a title="#" id="Option2" href="#">Option 2</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option3" href="#">Option 3</a></li>
                                                <li style="display: none;" class=""><a title="#" id="Option4" href="#">Option 4</a></li>
                                                <li style="display: none;"><a title="#" id="Option5" href="#">Option 5</a></li>
                                                <li class="last" style="display: none;"><a title="#" id="option6" href="#">Option 6</a></li>
                                            </ul>
                                            <span class="selectSpan" style="display: block;"><span class="pngfix"></span></span>
                                        </div>
                                    </li>
                                </ul>
                                
                                <div class="search clearfix">
                                	<a class="btnNar" href="#" title="Buscar">
                                        <span class="L"></span>
                                        <span class="M">Buscar</span>
                                        <span class="R"></span>
                                    </a>                                  
                                </div>
                                
                            </form>
                            <div class="segSearch">
                            	<label class="busPorSeg">Búsqueda por segmento:</label>
                                <div class="porSeg">
                                	<a href="#" title="buscar #segmento">Sedan 4P</a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Hatchback 3P</a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento"> Coupé </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Familiar</a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">PickUp  </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Todo Terreno / Suv </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Coupé </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Utilitarios  </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Hatchback 5P </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Monovolumen  </a>
                                    <span>|</span>
                                    <a href="#" title="buscar #segmento">Otros </a>
                                  </div>
                            </div>
                            
                             <a href="#" title="Ir al comparador" class="irAlCompa">
                        		Ir al comparador
                       		 </a>
                            
                        	</section>
                            <!--FIN CATALOGO -->
                     </article>
                    
                 </div>   
                    
                    
                 <section class="promoCont clearfix">
				</section>

					<!--SLIDER -->
                   <article class="boxSlider clearfix cajaGris">
                   		<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                        <div class="sombraBotonL"></div>
                        <div class="sombraBotonR"></div>
                        
                   		<div class="titular gris clearfix" style="height:30px;">
                           <h3 class="avisos">Autos destacados de hoy</h3>
                            <a title="Ver todos los autos destacados" href="#" class="verTodos_home pngfix">Todos los autos</a>
                   		</div>
                   		<div class="btnNavAnt">
							<span class="pngfix anterior active" title="Preview"></span>                   		</div>
       		    <div class="btnNavSig">
							<span class="pngfix siguiente active" title="Next"></span>                   		</div>
			    <div class="maskSlider">
							<ul>
								<li>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
								</li>
								<li>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
								</li>
								<li>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
									<article class="boxProduct clearfix">
										<figure>
											<a title="#title" href="#">
												<img src="img/img_reemplazable_4.gif" alt="#title"/>											</a>										</figure>
										<section class="avisosCont clearfix">
											<a title="#title" href="#">Renault Scenic 2 RXE PRIVILEGE</a>
											<span class="datos_home">Nafta | 2005 | 88000 Km</span>
											<h5 class="precio_home">U$S 50.900</h5>
										</section>
									</article>
								</li>
							</ul>
						</div>
			    <section class="selects clearfix">
							<ul>
								<li class="btnSelect"><!--AGREGAR LA CLASE "act" PARA MOSTRAR EL ESTADO ACTIVO-->
										<a title="#"  class="first pngfix"></a>
										<span class="pngfix"></span>
								</li>
								<li class="btnSelect"><!--AGREGAR LA CLASE "act" PARA MOSTRAR EL ESTADO ACTIVO-->
										<a title="#"  class="first pngfix"></a>
										<span class="pngfix"></span>
								</li>
								<li class="btnSelect"><!--AGREGAR LA CLASE "act" PARA MOSTRAR EL ESTADO ACTIVO-->
										<a title="#"  class="first pngfix"></a>
										<span class="pngfix"></span>
								</li>
							</ul>
						</section>
					</article>	
					<!--FIN SLIDER -->
                       
                   <% Html.RenderPartial("Ranking",Model.RankingResults); %>     
                                      
                    <aside>
                        <div class="bannersCont mod clearfix">
                            <div class="bn200x100">
                                <div style="background-color: rgb(102, 102, 102); text-align: center; width:590px; height:120px; float: left;">
                                    <p style="padding-top: 37px; color: rgb(255, 255, 255); font-weight: bold;">Banner<br>590 x 120</p>
                                </div>
                            </div>
                        </div>
                    </aside>
                    
                    
                    <article class="box2 cajaGris" style="width:auto;">
                    
                    	<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                        

                        <nav class="titular_home gris clearfix">
                        	
                         	<ul class="tabsNotiRoad">
                            	<li class="noticias act"><!--AGREGAR LA CLASE "act" AL "LI" PARA MOSTRAR EL ACTIVO-->
                                    <h3 style="line-height:15px;">	
                                        <span class="tab">
                                            <span class="L"></span>
                                            <span class="M">Noticias</span>
                                            <span class="R"></span>
                                        </span>
                                        <a title="Noticias">Noticias</a>
                                    </h3>
                                </li>
                                
                                
                            </ul>
                            
                            <a class="verTodos_home VtodosN act pngfix" style="padding-top: 6px; margin-right:10px;" href="#" title="Ver más noticias de autos">Ver más noticias de autos</a>
                           
                            
                   		</nav>
                        
                        <article class="agrup">
                         <!-- Render de News -->
                         <%Html.RenderAction("News"); %>                                      
                                                  
						</article>

                    </article>
                    
                    
                    
                    <section class="boxContBox clearfix">
                    
                        <article class="box3">
                            <div class="Cv Tl"></div>
                            <div class="Cv Tr"></div>
                            <div class="Cv Bl"></div>
                            <div class="Cv Br"></div>
                            <div class="inner pngfix">
                                <h4>Servicio de Atención y Ventas</h4>
                                <div class="col">
                                    <span class="tel">(011) 4346 0041</span>
                                    <p>(desde todo el país)</p>
                                    <span>Lu a Vie de 9 a 21hs</span>
                                </div>
                        	</div>
                        </article>
                    
                        <article class="box3 mod">
                        
                            <div class="Cv Tl"></div>
                            <div class="Cv Tr"></div>
                            <div class="Cv Bl"></div>
                            <div class="Cv Br"></div>
                            <div class="inner">
                                <h4>
                                    <a href="#" title="¿Compraste tu aviso en una Receptoría?" class="aLie">¿Compraste tu aviso en una <strong>Receptoría</strong>?</a>
                                </h4>
                                <div class="col u">
                                    Registrate Gratis o ingresá en Mi Auto y cargá allí tu código de publicación.
                                </div>
                                
                                <a class="seeMore" title="Enriquecé tu aviso aquí" href="#">Enriquecé tu aviso aquí</a>                        </div>
                        </article>
                    
                    </section>
                    
                </div>
                
                <div class="columnaRight">
                	<!--PROMO LEFT -->
                    <div class="promo mod">
                        <article class="vendeTuAutoAhora">
                        	<h2 class="vendeTuAuto">¡Vendé tu auto ahora!</h2>
                          <a href="#" title="¡Vendé tu auto ahora!" class="areaActiva">Elegí el aviso que más se ajuste a tu medida. Miles de compradores esperan tu aviso.
                                <span class="btnNarMed" title="Publicá y Vendé Ya">
                                    <span class="L"></span>
                                    <span class="M">Publicá y Vendé Ya!</span>
                                    <span class="R"></span>                                </span>                            </a>                        </article>
                        
					</div>
					<!--FIN PROMO LEFT -->
                    
                    <aside>
                        <div class="bn300x250">
                            <div style="background-color: rgb(51, 51, 51); text-align: center; width: 300px; height: 250px; float: left;">
                                <p style="padding-top: 106px; color: rgb(255, 255, 255);"><br />300 x 250</p>
                            </div>
                        </div>
                    </aside>
                    
                    <article class="box4 clearfix">
                    	<div class="Cv Tl"></div>
                        <div class="Cv Tr"></div>
                        <div class="Cv Bl"></div>
                        <div class="Cv Br"></div>
                        <h3 class="tit">Consultá los paquetes y avisos disponibles:</h3>
                        <div class="inner clearfix">
                        	<a href="#" title="Más información sobre Aviso Súper Premium" class="pngfix">Aviso Súper Premium</a>
                            <a href="#" title="Más información sobre Aviso Premium" class="pngfix">Aviso Premium</a>
                            <a href="#" title="Más información sobre Aviso Simple" class="pngfix">Aviso Simple</a>
                            <a href="#" title="Más información sobre Paquetes" class="pngfix">Paquetes</a>
                        </div>
                    </article>
                    
                    <section class="promoCont">
                    	<article class="boxPromo etqNuevo serv pngfix" style="height:89px;">
                        	
					  <div class="content clearfix cajaGris">
                        	<div class="Cv Tl"></div>
                            <div class="Cv Tr"></div>
                            <div class="Cv Bl"></div>
                            <div class="Cv Br"></div>
							<h2><a href="#" title="Servicios para concesionarias" class="aLie">Servicios <br>para concesionarias</a></h2>
							<a href="#" title="Ver más Servicios para concesionarias"  class="seeMore pngfix">Ver más</a>
						<div class="etiqueta pngfix"></div>
							
						</div>	
					</article>
                    </section>
                    
                    
                    <!--RECURSOS -->
                  <article>  
                    <ul class="recursos">
                    	
                    	<li>
                        	
                            <div class="Cv Tl"></div>
                            <div class="Cv Tr"></div>
                            <div class="Cv Bl"></div>
                            <div class="Cv Br"></div>
                        	<article class="inner seguros">
                            	<h3>
                                	<a href="#" title="Seguros" class="aLie">Seguros</a>
                                </h3>
                                <p>Seguros con cobertura a medida para los usuarios de deautos.com</p>
                                <a title="Ver más seguros" href="#" class="more">Ver m&aacute;s</a>                            </article>
                        </li>
                    </ul>
                 </article>   
                    <!--FIN RECURSOS -->
                    
                    
                  <aside> 
                    <div class="bannersCont_home">
                    	<div class="bn200x100">
                            <div style="background-color:#666666; text-align: center; width:200px; height:110px; float: left; margin-bottom:10px;">
                                <p style="padding-top: 37px; color:#ffffff; font-weight:bold;">Banner<br />200 x 110</p>
                            </div>
                		</div>
                        
                        <div class="bn200x100">
                            <div style="background-color:#666666; text-align: center; width:200px; height:110px; float: left; margin-bottom:10px;">
                                <p style="padding-top: 37px; color:#ffffff; font-weight:bold;">Banner<br />200 x 110</p>
                            </div>
                		</div>
                        
                        <div class="bn200x100">
                            <div style="background-color:#666666; text-align: center; width:200px; height:110px; float: left; margin-bottom:10px;">
                                <p style="padding-top: 37px; color:#ffffff; font-weight:bold;">Banner<br />200 x 110</p>
                            </div>
                		</div>
                        
                        <div class="bn200x100">
                            <div style="background-color:#666666; text-align: center; width:200px; height:110px; float: left; margin-bottom:10px;">
                                <p style="padding-top: 37px; color:#ffffff; font-weight:bold;">Banner<br />200 x 110</p>
                            </div>
                		</div>
                    </div>
                  </aside>  
                    
                    
				</div>
            
            	
                
                <aside class="bn728x90">
                        <div style="background-color:#666666; text-align: center; width:728px; height:90px; float: left;">
                            <p style="padding-top:30px; color:#ffffff; font-weight:bold;">Banner<br />728 x 90</p>
                        </div>
                </aside>
                
                <article class="allMarcs">
                	<section class="first">
                    	<h3 class="tit">Todas las marcas a un solo clic</h3>
                    	<ul class="clearfix">
                        	<li class="first"><a href="#" title="#">Alfa Romeo</a></li>
                            <li><a href="#" title="#marca"> Daihatsu</a></li>
                            <li><a href="#" title="#marca"> Isuzu</a></li>
                            <li><a href="#" title="#marca"> Mercedes Benz</a></li>
                            <li><a href="#" title="#marca"> Saab</a></li>
                            <li><a href="#" title="#marca"> Audi</a></li>
                            <li><a href="#" title="#marca"> Dodge</a></li>
                            <li><a href="#" title="#marca"> Jaguar</a></li>
                            <li><a href="#" title="#marca"> Mini</a></li>
                            <li><a href="#" title="#marca"> Seat</a></li>
                            <li><a href="#" title="#marca"> BMW</a></li>
                            <li><a href="#" title="#marca"> Ferrari</a></li>
                            <li><a href="#" title="#marca"> Jeep</a></li>
                            <li><a href="#" title="#marca"> Mitsubishi</a></li>
                            <li><a href="#" title="#marca"> Ssangyong</a></li>
                            <li><a href="#" title="#marca"> Chery</a></li>
                            <li><a href="#" title="#marca"> Fiat</a></li>
                            <li><a href="#" title="#marca"> Kia</a></li>
                            <li><a href="#" title="#marca"> Nissan</a></li>
                            <li><a href="#" title="#marca"> Subaru</a></li>
                            <li><a href="#" title="#marca"> Chevrolet</a></li>
                            <li><a href="#" title="#marca"> Ford</a></li>
                            <li><a href="#" title="#marca"> Lada</a></li>
                            <li><a href="#" title="#marca"> Peugeot</a></li>
                            <li><a href="#" title="#marca"> Suzuki</a></li>
                            <li><a href="#" title="#marca"> Chrysler</a></li>
                            <li><a href="#" title="#marca"> Honda</a></li>
                            <li><a href="#" title="#marca"> Land Rover</a></li>
                            <li><a href="#" title="#marca"> Porsche</a></li>
                            <li><a href="#" title="#marca"> Toyota</a></li>
                            <li><a href="#" title="#marca"> Citroen</a></li>
                            <li><a href="#" title="#marca"> Hyundai</a></li>
                            <li><a href="#" title="#marca"> Lincoln</a></li>
                            <li><a href="#" title="#marca"> Renault</a></li>
                            <li><a href="#" title="#marca"> Volkswagen</a></li>
                            <li><a href="#" title="#marca"> Daewoo</a></li>
                            <li><a href="#" title="#marca"> IKA</a></li>
                            <li><a href="#" title="#marca"> Mazda </a></li>
                            <li><a href="#" title="#marca"> Rover</a></li>
                            <li><a href="#" title="#marca"> Volvo</a></li>
                                                       
                        </ul>
                    </section>
                    
                    <section class="last">
                    	<h3 class="tit">Modelos más buscados a un solo clic</h3>
                    	<ul class="clearfix">
                        	<li class="first"><a href="#" title="#"></a></li>
                            <li><a href="#" title="#modelo"> Audi A3</a></li>
                            <li><a href="#" title="#modelo"> Fiat Palio</a></li>
                            <li><a href="#" title="#modelo"> Peugeot 206</a></li>
                            <li><a href="#" title="#modelo"> Renault Megane</a></li>
                            <li><a href="#" title="#modelo"> Volkswagen Fox</a></li>
                            <li><a href="#" title="#modelo"> BMW Serie 3</a></li>
                            <li><a href="#" title="#modelo"> Ford EcoSport</a></li>
                            <li><a href="#" title="#modelo"> Peugeot 307</a></li>
                            <li><a href="#" title="#modelo"> Renault Sandero</a></li>
                            <li><a href="#" title="#modelo"> Volkswagen Gol</a></li>
                            <li><a href="#" title="#modelo"> Chevrolet Corsa</a></li>
                            <li><a href="#" title="#modelo"> Ford Fiesta</a></li>
                            <li><a href="#" title="#modelo"> Renault Clio</a></li>
                            <li><a href="#" title="#modelo"> Renault Symbol</a></li>
                            <li><a href="#" title="#modelo"> Volkswagen Gol Trend</a></li>
                            <li><a href="#" title="#modelo"> Citroen C4</a></li>
                            <li><a href="#" title="#modelo"> Ford Focus</a></li>
                            <li><a href="#" title="#modelo"> Renault Kangoo 2</a></li>
                            <li><a href="#" title="#modelo"> Toyota Hilux</a></li>
                            <li><a href="#" title="#modelo"> Volkswagen Suran</a></li>
                            <li><a href="#" title="#modelo"> Fiat Uno</a></li>
                            <li><a href="#" title="#modelo"> Ford Ranger</a></li>
                            <li><a href="#" title="#modelo"> Renault Logan</a></li>
                            <li><a href="#" title="#modelo"> Volkswagen Bora</a></li>
                            <li><a href="#" title="#modelo"> Volkswagen Vento</a></li>
                        </ul>
                    </section>
                	
                </article>
                
                
        </div>
                <!--FIN CONTEINER -->
	</div>
	<!-- fin CONTENIDO -->
</div>
</div>
</asp:Content>
