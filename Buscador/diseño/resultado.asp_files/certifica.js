/* Certifica */
function hitCertifica(sitio_id,path,descr) {
    var size, colors, referrer, url;
    size = colors = referrer = 'otro';
    referrer = escape(document.referrer);
//	alert("HOLA");
    if ( window.screen.width ) size = window.screen.width;
    if ( window.screen.colorDepth ) colors = window.screen.colorDepth;
    else if ( window.screen.pixelDepth ) colors = window.screen.pixelDepth;
    url = 'http://prima.certifica.com/cert/hit.dll?sitio_id=' + sitio_id + '&path=' + path + '&referer=' + referrer + '&size=' + size + '&colors=' + colors + '&java=' + navigator.javaEnabled();
	if (descr)
        url += '&descr=' + escape(descr);
    document.writeln( '<img src="' + url + '" width="1" height="1" border="0" alt="Certifica.com">' );
    
	//autorefresh IAB
	if (typeof(cert_IsAutoRefresh) == 'undefined') {
		url = 'http://hits.e.cl/cert/hit.dll?sitio_id=' + sitio_id + '&path=' + path ;
		document.writeln( '<img src="' + url + '" width="1" height="1" border="0" alt="Certifica.com">' );
	}
}

function JumpUrl(combo){
	window.location=combo.options[combo.selectedIndex].value;
}