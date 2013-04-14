$(document).ready(function(){
		var q = $(".boxSlider .maskSlider li").length;
		var n = 0;
		$(".boxSlider .maskSlider ul").css("width", (q * 634)+"px");
		$(".boxSlider .maskSlider li:first-child, .selects li:first-child").addClass("active");
		function ulpager()
		{
			var p = $(".boxSlider .maskSlider li.active").index();
			$(".boxSlider .anterior, .boxSlider .siguiente").addClass("active");
			if (p == 0)
				$(".anterior").removeClass("active");
			else if (p == q-1)
				$(".siguiente").removeClass("active");
		}
		ulpager();
		$(".boxSlider .selects li").click(function(){
			if ($(this).hasClass("active") || $(".boxSlider .maskSlider ul").is(":animated"))
				return true
			var a = $(".boxSlider .maskSlider li.active").index();
			var d = $(this).index();
			$(".boxSlider .selects li.active, .boxSlider .maskSlider li.active").removeClass("active");
			if(a > d)
			{
				$(".boxSlider .maskSlider ul").animate({"left": (parseInt($(".boxSlider .maskSlider ul").css("left"))+(634*(a-d)))+"px"}, 300);
				$(".boxSlider .maskSlider li").eq(d).addClass("active");
				$(".boxSlider .selects li").eq(d).addClass("active");
			}
			else
			{
				$(".boxSlider .maskSlider ul").animate({"left": (parseInt($(".boxSlider .maskSlider ul").css("left"))-(634*(d-a)))+"px"}, 300);
				$(".boxSlider .maskSlider li").eq(d).addClass("active");
				$(".boxSlider .selects li").eq(d).addClass("active");
			}
			ulpager();
		})
		$(".boxSlider .btnNavAnt span, .boxSlider .btnNavSig span").click(function(){
			if (!$(this).hasClass("active") || $(".boxSlider .maskSlider ul").is(":animated"))
				return true;
			var c= $(".boxSlider .maskSlider li.active").index();
			$(".boxSlider .selects li.active, .boxSlider .maskSlider li.active").removeClass("active");
				if ($(this).hasClass("siguiente"))
				{
					$(".boxSlider .maskSlider ul").animate({"left": (parseInt($(".boxSlider .maskSlider ul").css("left"))-634)+"px"}, 300);
					$(".boxSlider .maskSlider li").eq(c+1).addClass("active");
					$(".boxSlider .selects li").eq(c+1).addClass("active");
				}
				else
				{
					$(".boxSlider .maskSlider ul").animate({"left": (parseInt($(".boxSlider .maskSlider ul").css("left"))+634)+"px"}, 300);
					$(".boxSlider .maskSlider li").eq(c-1).addClass("active");
					$(".boxSlider .selects li").eq(c-1).addClass("active");
					
				}
				ulpager();
			})
})
