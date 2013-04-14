var page = {};

$(document).ready( function() {
  //LazyLoad
  $('.two-sidebar:not(.notLazy) img').lazyload({effect: 'fadeIn' ,threshold : '200'});
  $('.sidebar img').lazyload({effect: 'fadeIn' ,threshold : '200'});
  $('body').addClass('js-finished');
  
  $('.openajax').click(function(event) {
	event.preventDefault();
	$(this).next(".box-share").fadeIn(300);
  });
  $('.closeajax').click(function(event) {
	event.preventDefault();
	$(this).parents(".box-share").fadeOut(300);
  });
  
  //Input Radio Button
  $(".inputRa input").hide();
  $(".inputRa span, .inputRa label").click(function(){
		$(this).parents().find(".inputRa.act").removeClass("act");
		$(this).parents(".inputRa").addClass("act");
		$(this).prev("input").attr('checked', true);
  });
  //checkbox buttom
  $(".checkInput input").hide();
  $(".checkInput label, .checkInput span").click(function(){
		if ($(this).prev().attr('checked') || $(this).prev().prev().attr('checked'))
		{
			$(this).prev("#check").attr("checked",false);
			$(this).parents().find(".checkInput").removeClass("act");
		}
		else
		{
			$(this).prev("#check").attr("checked",true);
			$(this).parents().find(".checkInput").addClass("act");
		}
  });
  
  //Uls como selects
   $('.selectUl').css("height", "26px");
   $('.selectUl li:first-child').addClass("first");
   $('.selectUl li:last-child').addClass("last");
   $('.selectDiv li').hide();
   $('.selectDiv li.act').show();
   
	$('.selectSpan').click(function(){
		if(!$(this).prev("ul").hasClass("act"))
		{
			$(this).prev("ul").children('li:not(.act)').show();
			$(this).prev("ul").addClass("act").height("auto");
		}
		else
		{
			$(this).prev("ul").removeClass("act").height("26px");
			$(this).prev("ul").children('li:not(.act)').hide();
			$(this).prev("ul").addClass("act");
		}
	});
	$('.selectUl').mouseleave(function(){
		$(this).removeClass("act").height("26px").css("overflow-y", "hidden");
		$(this).children('li:not(.act)').hide();
		$(this).siblings(".selectSpan").show();
		$(this).scrollTop(0);
	});
	$('.selectDiv li a:not(animated)').live('click',function(ev){
		$(this).parent().siblings().children("span").replaceWith("<a href='#' id='"+$(this).parent().siblings().children("span").attr("id")+"' title='"+$(this).parent().siblings().children("span").attr("title")+"'>"+$(this).parent().siblings().children("span").text()+"</a>")
		if (!$(this).parents(".selectDiv").hasClass("conLink"))
			ev.preventDefault();			
		$(this).parent().parent().removeClass("act").scrollTop(0).css("overflow-y", "hidden").height("26px").siblings(".selectSpan").show();
		$(this).parent().parent().children("li.act").removeClass("act");
		$(this).parent().addClass("act");
		$(this).parent().parent().children("li:not(.act)").hide();
		$('.selectDiv li span')
		$(this).replaceWith("<span id='"+$(this).attr("id")+"' title='"+$(this).attr("title")+"'>"+$(this).text()+"</span>");
	});
	
	//Menu Más deportes
	$(".nav-menu .last span").click(function(){
		$(this).addClass("act");
		$(this).siblings(".desplegable").show();
	});
	$(".nav-menu .last").mouseleave(function(){
		$(this).children(".desplegable").hide();
		$(".nav-menu .last span.act").removeClass("act");
	});
	
	//Cambio Solapas
	$(".box-filtrar .filtrar span").click(function(){
		if($(this).parents("li").hasClass("act"))
			return true;
		$(".box-filtrar .filtrar li").toggleClass("act");
		$(".contComment .commentt, .boxProg, .boxProgramacion").toggleClass("act");
	});
});
