/* Certifica */


<!--DOCUMENT CONTENT_TYPE="text/javascript"  -->
/* 
  Copyright 2004 - Certifica.com 
  $Id: certifica.js,v 1.12 2004/10/27 20:12:21 leus Exp $
*/

DEFAULT_PIVOT_NAME = 'cert_Pivot';
DEFAULT_REDIRECT_TIME = 18000;
DEFAULT_PERIODIC_REDIRECT_TIME = 180000;

function cert_qVal(sValue) 
{
    var pos = String(document.location).indexOf('?');
    if (pos != -1) {
       var query = String(document.location).substring(pos+1);
       var vars = query.split("&");
       for (var i=0; i < vars.length; i++) {
          var pair = vars[i].split("=");
          if (pair[0] == sValue)
             return pair[1];
       }       
    }
    return null;  
}

function cert_getReferrer()
{
   var referrer = document.referrer;
   if (self.cert_getReferrer14)
      return cert_getReferrer14();
/*@cc_on
  @if(@_jscript_version >= 5 )
   try { 
      if ( self != top ) referrer = top.document.referrer;
   } catch(e) {};
  @end
  @*/
  return referrer;
}
 
function cert_getTagCertifica(iSiteId, sPath, sAppend) 
{
    var size, colors, referrer, url;
    size = colors = referrer = 'otro';
    var o = cert_qVal('url_origen');
    if (o != null && o != '')
       referrer = o;
    else 
       referrer = escape(cert_getReferrer());
    if ( window.screen.width ) size = window.screen.width;
    if ( window.screen.colorDepth ) colors = window.screen.colorDepth;
    else if ( window.screen.pixelDepth ) colors = window.screen.pixelDepth;
    url = 
       'http://prima.certifica.com/cert/hit.dll?sitio_id=' + iSiteId + '&path=' + sPath +
       '&referer=' + referrer + '&size=' + size + '&colors=' + colors;
    url += '&java=' + navigator.javaEnabled();
    if (sAppend)
        url += sAppend;
    return url;    
}


/* Obtiene el tipo de protocolo del documento actual. */
function cert_getProtocol()
{
    if (window && window.location && window.location.protocol)
        return window.location.protocol;
    return null;
}


/* Obtiene la versión de Flash. */
function cert_getFlashVersion()
{
	var flashVersion = -1;
	if (navigator.plugins && navigator.plugins.length) {
		var objFlash = navigator.plugins["Shockwave Flash"];
		if (objFlash) {
			if (objFlash.description) {
				flashDesc = objFlash.description;
				flashVersion = flashDesc.charAt(flashDesc.indexOf('.')-1);
			}
		}

		if (navigator.plugins["Shockwave Flash 2.0"]) {
			flashVersion = 2;
		}
	} else if (navigator.mimeTypes && navigator.mimeTypes.length) {
		x = navigator.mimeTypes['application/x-shockwave-flash'];
		if (x && x.enabledPlugin) {
			flashVersion = 0; // no detectada!
		}
	}

	return flashVersion;
}


/* Crea la URL para obtener un pageview de Certifica. */
/* Solo necesita los parametros iSiteId y sPath       */
function cert_getURL(iSiteId, sPath, sAppend) 
{
	
	var referrer, url;
    referrer = 'otro';
    var o = cert_qVal('url_origen');
    var proto = cert_getProtocol();
    if (proto != 'https:')
        proto = 'http:';
    
    if (o != null && o != '')
       referrer = o;
    else 
       referrer = escape(cert_getReferrer());
    url = 
       proto + '//hits.e.cl/cert/hit.dll?sitio_id=' + iSiteId + '&path=' + sPath +
       '&referer=' + referrer ;
    url += '&java=' + navigator.javaEnabled() + '&flash=' + cert_getFlashVersion();
    if (sAppend)
        url += sAppend;
    return url;    
}



/* Efectua un hit en certifica usando una imagen pivote. */
function cert_registerHit(iSiteId, sPath, sPivotName) 
{
   var sAppend = '&cert_cachebuster=' + (1 + Math.floor (Math.random() * 10000));
   if ( !sPivotName )
      sPivotName = DEFAULT_PIVOT_NAME;
   if ( document.images )
      if ( document.images[sPivotName] )
         //document.images[sPivotName].src = cert_getTagCertifica(iSiteId, sPath, sAppend);
		 document.images[sPivotName].src = cert_getURL(iSiteId, sPath, sAppend);
}

/* Efecta una redirecci n marcando la ruta de salida */
function cert_registerHitAndRedirect( sURL, iSiteId, sPath, sPivotName ) 
{
   cert_registerHit( iSiteId, sPath, sPivotName );
   setTimeout( "location.href = '" + sURL + "'", DEFAULT_REDIRECT_TIME );
}

/* Abre una nueva ventana, marcando el hit */
function cert_registerHitAndOpenWindow( sURL, iSiteId, sPath, sPivotName, sName, sFeatures, bReplace )
{
   cert_registerHit( iSiteId, sPath, sPivotName );
   if (!sName)
      sName = 'Downloads';
   if (!sFeatures)
      sFeatures = 'toolbar=no,location=no,directories=no,status=yes,menubar=no, scrollbars=no,resizable=no,width=425,height=510,screenX=20,screenY=20';
   window.open( sURL, 
      sName, 
      sFeatures, 
      bReplace 
   );
   return false;
}

/* Marca el hit y reemplaza/abre una URL en el frame 'sName' */
function cert_registerHitAndReplaceOtherFrame( sURL, sName, iSiteId, sPath, sPivotName ) 
{
   cert_registerHitAndOpenWindow( sURL, iSiteId, sPath, sPivotName, sName, 0, true );
}

/* Marca el hit y reemplaza/abre una URL en el frame 'sName' */
function cert_registerHitAndReplaceThisFrame( sURL, iSiteId, sPath, sPivotName ) 
{
   cert_registerHitAndRedirect( sURL, iSiteId, sPath, sPivotName );
}

/* Marca el hit y baja un archivo */
function cert_registerHitAndDownloadFile( sURL, iSiteId, sPath, sPivotName ) 
{
   cert_registerHitAndRedirect( sURL, iSiteId, sPath, sPivotName );
}

/* Marca un hit en la pgina actual */
function tagCertifica(iSiteId, sPath) 
{
    document.writeln( '<img src="' + cert_getTagCertifica(iSiteId, sPath) + '" width="1" height="1" border="0" alt="Certifica.com">' );
}

/* Marca un registro cada iTime milisegundos.  */
function cert_registerPeriodicHit( iSiteId, sPath, sPivotName, iTime ) 
{
   if ( !sPivotName )
      sPivotName = DEFAULT_PIVOT_NAME;
   if ( !iTime )
      iTime = DEFAULT_PERIODIC_REDIRECT_TIME;

   cert_registerHit( iSiteId, sPath, sPivotName );
   setTimeout( 'cert_registerPeriodicHit( ' + iSiteId + ', "' + sPath + '", "' + sPivotName + '", ' + iTime + ')', iTime );
}

/* Certifica */

function hitCertifica(sitio_id,path,descr) {
    var size, colors, referrer, url;
    size = colors = referrer = 'otro';
    referrer = escape(document.referrer);
    if ( window.screen.width ) size = window.screen.width;
    if ( window.screen.colorDepth ) colors = window.screen.colorDepth;
    else if ( window.screen.pixelDepth ) colors = window.screen.pixelDepth;
	
	/*
	url = 'http://prima.certifica.com/cert/hit.dll?sitio_id=' + sitio_id + '&path=' + path + '&referer=' + referrer + '&size=' + size + '&colors=' + colors + '&java=' + navigator.javaEnabled();
	if (descr)
        url += '&descr=' + escape(descr);
	document.writeln( '<img src="' + url + '" width="1" height="1" border="0" alt="Certifica.com">' );
	*/
	
	url = 'http://hits.e.cl/cert/hit.dll?sitio_id=' + sitio_id + '&path=' + path ;
	document.writeln( '<img src="' + url + '" width="1" height="1" border="0" alt="Certifica.com">' );
	
}

/* Certifica IAB */


<!--DOCUMENT CONTENT_TYPE="text/javascript"  -->

DEFAULT_REFRESH_TIME = 1800000; // original 600000
REFRESH_LIMIT = 1800000;
var cert_IsAutoRefresh = false;

/* Funciones internas al script Certifica-IAB */
function cert_setCookie(name, value, expires, path, domain, secure) {
  var curCookie = name + "=" + escape(value) +
      ((expires) ? "; expires=" + expires.toGMTString() : "") +
      ((path) ? "; path=" + path : "") +
      ((domain) ? "; domain=" + domain : "") +
      ((secure) ? "; secure" : "");
  document.cookie = curCookie;
}

function cert_getCookie(name) {
  var dc = document.cookie;
  var prefix = name + "=";
  var begin = dc.indexOf("; " + prefix);
  if (begin == -1) {
    begin = dc.indexOf(prefix);
    if (begin != 0) return null;
  } else
    begin += 2;
  var end = document.cookie.indexOf(";", begin);
  if (end == -1)
    end = dc.length;
  return unescape(dc.substring(begin + prefix.length, end));
}

function cert_deleteCookie(name, path, domain) {
  if (cert_getCookie(name)) {
    document.cookie = name + "=" +
    ((path) ? "; path=" + path : "") +
    ((domain) ? "; domain=" + domain : "") +
    "; expires=Thu, 01-Jan-70 00:00:01 GMT";
  }
}

function cert_RefreshInt()
{
  var now = new Date();

  cert_setCookie('autorefresh_time', now.getTime()); 
  location.reload();
}

function cert_IsAutoRefresh_func() {
    var now = new Date();
    var tsCookie = cert_getCookie('autorefresh_time');
  
    cert_deleteCookie('autorefresh_time');
  
    if (tsCookie) {
        var d = now.getTime() - tsCookie;
        if (d <= REFRESH_LIMIT) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}
/*
 * Funciones PUBLICAS
 */

/*
 * cert_Refresh: permite hacer autorefresh de la pagina y cumplir con las normas
 *               fijadas por el IAB al respecto.
 *
 * iTime: tiempo en segundos en el cual se deberá hacer autorefresh
 *
 */
var certtimer;

function cert_Refresh(iTime) {
  var refreshTime;
  refreshTime = ((iTime) ? iTime*1000 : DEFAULT_REFRESH_TIME);

  cert_IsAutoRefresh = cert_IsAutoRefresh_func();
  certtimer = setTimeout('cert_RefreshInt()', refreshTime);
}

function borrarCert_Refresh(lapso){
	window.clearTimeout(certtimer);
	cert_Refresh(lapso);
}

/* tagCertificaIAB: permite registrar un pageview, y cumplir con las normas del IAB en lo relativo a los autorefresh.
   isHome: Valor 1 o 0, para indicar si la pagina marcada es el home o no (1=Home). */
function tagCertificaIAB(iSiteId, isHome){
	/*
    var now = new Date();
    var mustCount = true;
    var path;

    if (cert_IsAutoRefresh) {
        path = '/autorefresh';
        if (isHome) {
            var tsCookie = cert_getCookie('cert_hit_time');
            var d = now.getTime() - tsCookie;
            if (d < DEFAULT_REFRESH_TIME) {
                mustCount = false;
            }
        } else {
            mustCount = false;
        }
    } else {
       path = '/normal';
    }
    if (mustCount) {
       var url;
       if (isHome) {
           cert_setCookie('cert_hit_time', now.getTime());
           path = '/home' + path;
       } else {
           path = '/resto_sitio' + path;
       }
       url = 
       'http://hits.e.cl/cert/hit.dll?sitio_id=' + iSiteId + '&path=' + path;
       document.writeln( '<img src="' + url + '" width="1" height="1" border="0" alt="Certifica.com">' );
    }
	*/
}

