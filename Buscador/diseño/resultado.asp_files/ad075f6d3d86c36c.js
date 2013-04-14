var sinBody = !document.body;
if (sinBody) { document.write('<bo'+'dy style="margin:0px;padding:0px;">'); }
if ("undefined" == typeof inIframe) inIframe=0;if ("undefined" != typeof inDapIF) inIframe =  inDapIF  ? -1 : inIframe;
if ("undefined" != typeof inFIF) inIframe = inFIF ? -1 : inIframe;
    var eplDoc = inIframe ? parent.document : document;var eplDiv;
    if (!inIframe) {
	document.write('<div id="eplParentContainer211983"></div>');eplDiv = document.getElementById("eplParentContainer211983");
    } else {
    var cF;
	if (inIframe > 0) {
    	    cF = eplDoc.getElementById(document.body.id);
	    if (!cF && window.frameElement) cF = window.frameElement;
	} else {
	    if (window.frameElement) {
		cF = window.frameElement;
	    } else {
		var pFs = eplDoc.frames;
		var pEs = eplDoc.getElementsByTagName("iframe");
		var pfx = -1;
		for (var i = 0; (i < pFs.length) && (-1 == pfx); i++) {
		    if (pFs[i].document == document) pfx = i;
		}
		if (-1 != pfx) cF = pEs[pfx];
	    }
	}
    if (cF) {
	    if (!eplDoc.eplF) eplDoc.eplF = new Array();
	    eplDoc.eplF[ 211983 ] = cF;
	    if (inIframe<0) {
		    cF.height = '0px'; cF.width = '0px';
		    cF.style.height = '0px'; cF.style.width = '0px'
		    cF.style.display = 'none';		    
	    }
	    eplDiv = eplDoc.createElement('div'); eplDiv.name = "eplParentContainer211983"; eplDiv.id = "eplParentContainer211983";
	    var pCF = cF.parentNode; pCF.insertBefore(eplDiv, cF);
	}
    }
if (eplDiv != null) {
	eplDiv.style.display='block';
	eplDiv.style.overflow='visible';
	eplDiv.style.textAlign='left';
	eplDiv.align='left';
	}
var eplTop = (navigator.appVersion.toLowerCase().indexOf('msie')&&!window.opera) ? eplDiv : eplDoc.body;
if (eplDiv && !eplTop) {
	var e = eplDiv;
	while (e.parent) { e = e.parent; }
	eplTop = e;
}
if ("undefined" != typeof inDapIF) { inDapIF = (0!=inIframe)?true:false; }
if ("undefined" != typeof inFIF) { inFIF = (0!=inIframe)?true:false; }
if ("undefined" != typeof eplDiv) {
	if (eplDiv && eplDiv.style) {
		eplDiv.style.visibility = 'hidden';
		eplDiv.style.display = 'none';
	}
}
document.write('<object width="468" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" height="60" border="0" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"><param value="always" name="allowscriptaccess"><param value="http://ar-pri2.img.e-planning.net/esb/4/1/4cde/68b0324b9c4ae83c.swf" name="movie"><param value="autohigh" name="quality"><param value="true" name="LOOP"><param value="transparent" name="wmode"><param value="clickTag=http://ads.e-planning.net/ei/3/4d63/ad075f6d3d86c36c%3fct%3d1%26pb%3d642d6c2d7e231a37%26fi%3d3484c32e59fa2178%26rnd%3d770558176885&bannerId=211983" name="flashvars"><embed width="468" allowscriptaccess="always" src="http://ar-pri2.img.e-planning.net/esb/4/1/4cde/68b0324b9c4ae83c.swf" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash" height="60" loop="true" border="0" wmode="transparent" flashvars="clickTag=http://ads.e-planning.net/ei/3/4d63/ad075f6d3d86c36c%3fct%3d1%26pb%3d642d6c2d7e231a37%26fi%3d3484c32e59fa2178%26rnd%3d770558176885&bannerId=211983" type="application/x-shockwave-flash" quality="autohigh"></embed></object>');
function eplResizeFrame() {
    var eplFrame = document.eplF ? document.eplF[ 211983 ] : null;
    if (!eplFrame && document.body.id) eplFrame = eplDoc.getElementById(document.body.id);
    if (inIframe!=0 && eplFrame && !document.eplDiframe) {
        eplFrame.style.width = '468px';
	eplFrame.style.height = '60px';
	eplFrame.style.display = '';
    }
    return false;
}
if (inIframe){ setTimeout("eplResizeFrame()", 250); }
	var tpit = ''; if (tpit) { var itag = new Image(); itag.src = tpit; }
if (sinBody) { document.write('</bo'+'dy>'); }
if (inIframe){ setTimeout("document.close();", 300); }