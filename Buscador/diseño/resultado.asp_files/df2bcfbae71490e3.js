var sinBody = !document.body;
if (sinBody) { document.write('<bo'+'dy style="margin:0px;padding:0px;">'); }
if ("undefined" == typeof inIframe) inIframe=0;if ("undefined" != typeof inDapIF) inIframe =  inDapIF  ? -1 : inIframe;
if ("undefined" != typeof inFIF) inIframe = inFIF ? -1 : inIframe;
    var eplDoc = inIframe ? parent.document : document;var eplDiv;
    if (!inIframe) {
	document.write('<div id="eplParentContainer209479"></div>');eplDiv = document.getElementById("eplParentContainer209479");
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
	    eplDoc.eplF[ 209479 ] = cF;
	    if (inIframe<0) {
		    cF.height = '0px'; cF.width = '0px';
		    cF.style.height = '0px'; cF.style.width = '0px'
		    cF.style.display = 'none';		    
	    }
	    eplDiv = eplDoc.createElement('div'); eplDiv.name = "eplParentContainer209479"; eplDiv.id = "eplParentContainer209479";
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
document.write('<iframe width="728" scrolling="NO" frameborder="0" src="http://ad.jumbaexchange.com/st?ad_type=iframe&ad_size=728x90&section=444220" height="90" marginheight="0" marginwidth="0"></iframe>');
function eplResizeFrame() {
    var eplFrame = document.eplF ? document.eplF[ 209479 ] : null;
    if (!eplFrame && document.body.id) eplFrame = eplDoc.getElementById(document.body.id);
    if (inIframe!=0 && eplFrame && !document.eplDiframe) {
        eplFrame.style.width = '728px';
	eplFrame.style.height = '90px';
	eplFrame.style.display = '';
    }
    return false;
}
if (inIframe){ setTimeout("eplResizeFrame()", 250); }
	var tpit = ''; if (tpit) { var itag = new Image(); itag.src = tpit; }
if (sinBody) { document.write('</bo'+'dy>'); }
if (inIframe){ setTimeout("document.close();", 300); }