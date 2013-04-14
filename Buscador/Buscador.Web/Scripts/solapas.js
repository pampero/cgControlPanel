$(document).ready( function(){	
	//Cambio Solapas buscador
	$(".boxTabs .Contenedor h2 a").click( function(){
		$(".boxTabs .Contenedor").removeClass("active");
		$(this).parent().parent("li").addClass("active");
		
		$(".boxTabsCont2 .Contenedor").removeClass("activo");
		$(".boxTabsCont2 .Contenedor").eq($(this).parents("li").index()).addClass("activo"); 
	});
	//Cambio Solapas noticias
	$(".tabsNotiRoad .noticias h3 a").click( function(){
		$(".tabsNotiRoad .noticias").removeClass("act");
		$(this).parent().parent("li").addClass("act");
		
		$(".agrup .ContSec").removeClass("active");
		$(".agrup .ContSec").eq($(this).parents("li").index()).addClass("active"); 
		$(".titular.gris .VtodosN").removeClass("act");
		$(".titular.gris .VtodosN").eq($(this).parents("li").index()).addClass("act");
	});
	/*Slider fotografias*/
	$(".agrup .right ul li").hover(
		function(){
			$(this).parents(".ContSec").find(".imContent").removeClass("act");
			$(this).parents(".ContSec").find(".imContent").eq($(this).index()).addClass("act");
			$(this).siblings().removeClass("act");
			$(this).addClass("act");
			
		}
	);
	//Lazy Load
  $('.columnaRight img').lazyload({effect: 'fadeIn' ,threshold : '600'});
  $('.columnaLeft img').lazyload({effect: 'fadeIn' ,threshold : '600'});
  $('body').addClass('js-finished');
  
	
});
