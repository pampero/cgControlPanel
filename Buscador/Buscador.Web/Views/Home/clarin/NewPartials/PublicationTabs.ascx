<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div class="solapasCont">
                    	<a href="javascript:ChangeTab('fotos')" id="fotos" title="Fotos" class="solapaDinamica solFotos active"><!--AGREGARLE LA CALSE "active" AL "A" PARA ACTIVAR LA SOLAPA -->
                        	<span class="L pngfix"></span>
                            <span class="M">Fotos</span>
                            <span class="R pngfix"></span>
                        </a>
                        
                        <a href="javascript:ChangeTab('videos')" id="videos" title="Videos" class="solapaDinamica solVideos"><!--AGREGARLE LA CALSE "active" AL "A" PARA ACTIVAR LA SOLAPA -->
                        	<span class="L pngfix"></span>
                            <span class="M">Videos</span>
                            <span class="R pngfix"></span>
                        </a>
                        
                        <a href="javascript:ChangeTab('especific')" id="especific" title="Especificaciones" class="solapaDinamica solEspecif"><!--AGREGARLE LA CALSE "active" AL "A" PARA ACTIVAR LA SOLAPA -->
                        	<span class="L pngfix"></span>
                            <span class="M">Especificaciones</span>
                            <span class="R pngfix"></span>
                        </a>
												
                        <a href="javascript:ChangeTab('review')" id="review" title="Review" class="solapaDinamica solReview">
                        	<span class="L pngfix"></span>
                            <span class="M">Review</span>
                            <span class="R pngfix"></span>
                        </a>
                    </div>
                    
<div class="iconos">
                    	
                    	<div class="iconosTop">
                        	<span class="pipeline first"></span>
                            <a class="pngfix favoritos " href="#" title="Favoritos"><span class="pngfix favoritos"></span></a><!--AGREGARLE LA CLASE "active" AL "A" PARA ACTIVAR FAVORITOS-->
                            <span class="pipeline"></span>
                            <a class="pngfix" href="#" title="Imprimir aviso"onclick="javascript:window.open('popup_ficha_imprimir.html', 'Imprimir', 'location = 1, status = 1, toolbar = 0, menubar = 0, scrollbars = 1, width = 800, height = 800')" ,=""><span class="pngfix imprimir"></span></a>
                            <span class="pipeline"></span>
                            <a class="pngfix" href="#" title="Enviar mail a un amigo"><span class="pngfix mail"></span></a>
                        </div>
                        
                        <a class="denunciar" href="#" title="Denunciar este aviso">Denunciar este aviso</a>
                    </div>