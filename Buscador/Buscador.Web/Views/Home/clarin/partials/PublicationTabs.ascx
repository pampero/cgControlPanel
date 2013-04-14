<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Buscador.Domain.com.clarin.entities.Publication>" %>
<%@ Import Namespace="Buscador.Domain.com.clarin.entities" %>
<%@ Import Namespace="Buscador.Web.Controllers.Controllers" %>
<script type="text/javascript">

    function addBookmark() {
        var url = jQuery(location).attr('href');
        var titulo = $("title").text();
       
        if (window.sidebar) {
            window.sidebar.addPanel(titulo, url, "");
        } else if (document.all) {
            window.external.AddFavorite(url, titulo);
        } else if (window.opera && window.print) {
            return true;
        }
    }

//    $(document).ready(function () {
//        var url = window.location;
//        $("#iframeFaceBook").attr('src', "http://www.facebook.com/plugins/like.php?app_id=359715566240&" + url + "&amp;href=http://www.deautos.com&send=false&layout=button_count&width=120&show_faces=false&action=like&colorscheme=light&font&height=21");
//    });


</script>
                    
                 <div class="solapasCont">                    	 
                             <a href="javascript:ChangeTab('fotos')" id="fotos" title="Fotos" class="solapaDinamica solFotos active"><!--AGREGARLE LA CALSE "active" AL "A" PARA ACTIVAR LA SOLAPA -->
                        	    <span class="L pngfix"></span>
                                <span class="M">Fotos</span>
                                <span class="R pngfix"></span>
                            </a>                       
                        
                        <% if (Model.SegmentCatalogInfo != null  && Model.ShowCatalogInfo && !string.IsNullOrEmpty(Model.SegmentCatalogInfo.LinkToVideo)) { %>
                           <a href="javascript:ChangeTab('videos')" id="videos" title="Videos" class="solapaDinamica solVideos"><!--AGREGARLE LA CALSE "active" AL "A" PARA ACTIVAR LA SOLAPA -->
                        	    <span class="L pngfix"></span>
                                <span class="M">Videos</span>
                                <span class="R pngfix"></span>
                            </a>
                        <% } %>                                                                     
                        <% if ((Model.VersionCatalogInfo != null && (Model.VersionCatalogInfo.EquipmentAttributes.Count > 0 || Model.HasTechnicalFeatures())) || (Model.SegmentCatalogInfo != null && Model.SegmentCatalogInfo.Colours.Count > 0 && Model.VehicleType == 2))
                           {%>
                            <a href="javascript:ChangeTab('especific')" id="especific" title="Especificaciones" class="solapaDinamica solEspecif"><!--AGREGARLE LA CALSE "active" AL "A" PARA ACTIVAR LA SOLAPA -->
                        	    <span class="L pngfix"></span>
                                <span class="M">Especificaciones</span>
                                <span class="R pngfix"></span>
                            </a>
                        <% } %>

						<% if (Model.SegmentCatalogInfo != null && (!string.IsNullOrEmpty(Model.SegmentCatalogInfo.ExpertReview) || Model.SegmentCatalogInfo.AverageRanking > 0 || Model.SegmentCatalogInfo.Positives.Count > 0 || Model.SegmentCatalogInfo.Negatives.Count > 0)){%>						
                            <a href="javascript:ChangeTab('review')" id="review" title="Review" class="solapaDinamica solReview">
                        	    <span class="L pngfix"></span>
                                <span class="M">Review</span>
                                <span class="R pngfix"></span>
                            </a>
                        <% } %>
                    </div>
                    

                     <%if (Model.State == PublicationOrderState.Active.ToString() || Model.State == PublicationOrderState.ActivatedByClienting.ToString())
                     {%>
                    <div class="iconos">
                        <div class="iconosTop">
                            <a class="pngfix favoritos" href="javascript:addBookmark()" title="Favoritos"><span class="pngfix favoritos"></span></a><!--AGREGARLE LA CLASE "active" AL "A" PARA ACTIVAR FAVORITOS-->
                        	<span class="pipeline"></span>
                            <a class="pngfix" href="#" title="Imprimir aviso" onclick="javascript:window.open('/Autos/Print', 'Imprimir', 'location = 1, status = 1, toolbar = 0, menubar = 0, scrollbars = 1, width = 800, height = 800')"><span class="pngfix imprimir"></span></a>
                            <span class="pipeline"></span>
                            <div class="imgBoton" id="basic-modal">
                                <a class="pngfix basic" onclick="javascript:fShowPopUp(this);" id="SendToAFriend" title="Enviar mail a un amigo"><span class="pngfix mail"></span></a>
                            </div>
                        </div>
            
                        <div class="facebookConteiner ">
                            				 
                            <div class="iconosFacebook">
                                <div class="new count">
                                    <div id="fb-root" style="display: table-column-group;"></div><script src="http://connect.facebook.net/es_LA/all.js#appId=359715566240&amp;xfbml=1"></script><fb:like href="" send="false" layout="button_count" width="120" show_faces="false" action="like" font="arial"></fb:like>
                                </div>
                                <div class="new count2">
                                    <!-- AddThis Button BEGIN -->
                                    <div class="addthis_toolbox addthis_default_style ">
                                        <a class="addthis_button_preferred_1"></a>
                                        <a class="addthis_button_preferred_2"></a>                      
                                        <a class="addthis_button_compact"></a>
                                        <a class="addthis_counter addthis_bubble_style"></a>
                                    </div>
                                    <script type="text/javascript">                            var addthis_config = { "data_track_clickback": true };</script>
                                    <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pubid=ra-4d6e84a053a772da"></script>
                                   <!-- AddThis Button END -->                   
                                </div>
                                <div  class="new count3">
                                    <!-- Añade esta etiqueta en la cabecera o delante de la etiqueta body. -->
                                    <script type="text/javascript" src="https://apis.google.com/js/plusone.js">                            { lang: 'es' }</script>
                                    <!-- Añade esta etiqueta donde quieras colocar el botón +1 --><g:plusone size="small"></g:plusone>
                                </div>
                                  <!--REEMPLAZAR ESTA IMAGEN DE FACEBOOK, POR EL CODIGO DE LA CAJA CORRESPONDIENTE -->
                            </div>
                        </div>
                        
                             <div style="width:333px;left: -29px; position: relative;">
                                <div class="imgBoton" id="basic-modal7">
						            <a onclick="javascript:fShowPopUp(this);" class="consejos basic"  id="consejos" title="Consejos de seguridad para el comprador">Consejos de seguridad para el comprador</a>
						        </div>
                                <span id="pipeline2"></span>
                                <div class="imgBoton" id="basic-modal2">
						            <a onclick="javascript:fShowPopUp(this);" class="denunciar basic"  id="DenunciatePublication" title="Denunciar este aviso">Denunciar este aviso</a>
        						 </div>
                            </div>
                    </div>

                    <script type ="text/javascript">
                        var addthis_config = {
                            services_exclude: 'amazonwishlist, aviary, camyoo, care2, classicalplace, doower, dotnetkicks, dotnetshoutout, embarkons, farkinda, flosspro, fnews, forgetfoo, gamesnetworks, globalgrind, gluvsnap, grumper, hazarkor, hedgehogs, hipstr, w3validator, investorlinks, linkedin, mindbodygreen, n4g, pdfonline, quantcast, slashdot, technet, tellmypolitician, tipd, domaintoolswhois, windycitizen, print,email, favorites, myspace, delicious, digg, stumbleupon, blogger, buzz, google, more',
                            services_compact: 'facebook, twitter',
                            ui_header_color: "#FFF",
                            ui_header_background: "#3B0B0B",
                            ui_offset_top: -10,
                            ui_offset_left: -224,
                            ui_use_addressbook: true
                        }
</script>
                </script>

                    <%} %>