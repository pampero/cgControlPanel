$(document).ready(function () {
	/*variables*/							
	var sliderImage = $(".sliderImage ul");
	var totalImages = $(".sliderImage li").length;
	var sliderThumb = $(".slideImg ul");
	var totalThumb = $(".slideImg li").length;
	var count=1;
	for(var k=0;k<totalImages;k++){
		$(".sliderImage li").eq(k).attr("id", "btn-"+(k+1));
	}	
	sliderImage.width(520*totalImages);
	$(".sliderImage li:first").addClass("first");
	$(".sliderImage li:last").addClass("last");
	$(".sliderImage li:first, .slidesCont .btnL, .slidesCont .btnR, .slideImg li:first").addClass("active");
	$(".sliderImage li:first").before($(".sliderImage li:last"));
	$(".enumerar p").text("de "+totalImages);
	sliderThumb.height(78*totalThumb);
	sliderImage.css("left", "-520px");
	/*animacion boton right*/
	$(".slidesCont .btnR").click(function(){
		if(sliderImage.is(":animated")){return true;}	
						
			sliderImage.animate({
				"left": "-=520px"
			}, 300,function(){
					$(".sliderImage li:last").after($(".sliderImage li:first"));
					sliderImage.css("left","-520px");
			});
			if (count==totalImages){
			count=1;
			sliderThumb.animate({"top": "0px"});
			}
			else {
				count= count+1;
				if((count-1)%5 == 0){
					sliderThumb.animate({	"top": "-=390px"});
				}
			}
			$(".enumerar span").text(count);
			
		
			
			$(".slideImg li").removeClass("active");
			$(".slideImg li").eq(count-1).addClass("active");	
			
			//col right
	});
	/*animacion boton Left*/
	$(".slidesCont .btnL").click(function(){
			if(sliderImage.is(":animated")){return true;}
			sliderImage.animate({
				"left": "0"					
			}, 300,function(){
					$(".sliderImage li:first").before($(".sliderImage li:last"));
					sliderImage.css("left","-520px");
			});			
			if(count==1){
				count = totalImages;
				sliderThumb.animate({"top": -(Math.floor(totalThumb/5)*390)+"px"});
			}
			else{
				count = count-1;	
				if((count)%5 == 0){
					sliderThumb.animate({"top": "+=390px"});
				}
			}
			$(".enumerar span").text(count);
			
			$(".slideImg li").removeClass("active");
			$(".slideImg li").eq(count-1).addClass("active");

	});
	/*seleccion del thumb*/
	$(".slideImg li").click(function(){
		var $this=$(this);
		$this.siblings().removeClass("active");
		$this.addClass("active");
		var idxThumb= $this.index()+1;	
		var num = $(".sliderImage li").eq(1).attr("id").substring(4, 5);
		if(idxThumb>num){			
			for(var h=0;h<(idxThumb-num);h++){
				$(".sliderImage li:last").after($(".sliderImage li:first"));
			}
		}
		else{
			for(var h=0;h<(num-idxThumb);h++){
				$(".sliderImage li:first").before($(".sliderImage li:last"));
			}
		}	
		//sliderImage.animate({"left": "-520px"});
		$(".enumerar span").text(idxThumb);
		count = idxThumb;
	});	
});