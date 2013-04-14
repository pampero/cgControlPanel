function alertSize(){
	var myWidth=0,myHeight=0;
	if(typeof(window.innerWidth)=='number'){
		//Non-IE
		myWidth = window.innerWidth;
		myHeight = window.innerHeight;
	}else if(document.documentElement && (document.documentElement.clientWidth||document.documentElement.clientHeight)){
		//IE 6+ in 'standards compliant mode'
		myWidth = document.documentElement.clientWidth;
		myHeight = document.documentElement.clientHeight;
	}else if(document.body&&(document.body.clientWidth||document.body.clientHeight)){
		//IE 4 compatible
		myWidth = document.body.clientWidth;
		myHeight = document.body.clientHeight;
	}
	return myWidth;
}

window.onload=function(){

	var fixed = document.getElementById("fixed");
	
	/*var width = alertSize();
	if(width<1100){
		fixed.style.display='none';
	}else{
		fixed.style.display='block';
	}*/
	
	var top = (0-fixed.offsetHeight+(document.documentElement.clientHeight?document.documentElement.clientHeight:document.body.clientHeight)+(ignoreMe=document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop)-198);
	fixed.style.top = (top>10)?top+'px':'250px';	
	
	window.onscroll=function(){
		top = (0-fixed.offsetHeight+(document.documentElement.clientHeight?document.documentElement.clientHeight:document.body.clientHeight)+(ignoreMe=document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop)-198);
		fixed.style.top = (top>10)?top+'px':'250px';
	}
	
	window.onresize=function(){
		var width = alertSize();
		if(width<1100){
			fixed.style.display='none';
		}else{
			fixed.style.display='block';
		}
	}
	
}