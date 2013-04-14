$(document).ready(function() {
	$(".notaMultimedia .sliderImg li").first().addClass("act");
	$(".sliderImg").width(($(".sliderImg li").length * 862)+"px")
	$(".ant, .sig").click(function(){
		 if ($(this).hasClass("inact"))
			return true
		 var n = $(".notaMultimedia .sliderImg li.act").index();
		 if ($(this).hasClass("ant"))
			  n--;
		 else
			  n++;
		 $(".ant").removeClass("inact");
		 $(".sig").removeClass("inact");
		 if (n == ($(".notaMultimedia .sliderImg li").length -1))
			$(".sig").toggleClass("inact");
		 if (n==0)
			$(".ant").toggleClass("inact");
		 $(".notaMultimedia .sliderImg li.act").removeClass("act");
		 $(".notaMultimedia .sliderImg li").eq(n).addClass("act");
		 if ($(this).hasClass("ant"))
			$(".notaMultimedia .sliderImg").animate({"left": "+=862px"}, 500);
		 else
			$(".notaMultimedia .sliderImg").animate({"left": "-=862px"}, 500);
	});
})
