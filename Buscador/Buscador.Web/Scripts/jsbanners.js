function phpads_deliverActiveX(content){
	document.write(content);
}
var epl_rnd =(new String(Math.random())).substring(2,8) + (((new Date()).getTime()) & 262143);
function printJSEplanning(codigo,masparam){
document.write('<div id="banner_' + codigo + '">');
document.write('<script type="text/javascript" language="JavaScript1.1">var rnd = (new String(Math.random())).substring(2,8) + (((new Date()).getTime()) & 262143);var cs = document.charset || document.characterSet;');
document.write('document.write(\'<scri\' + \'pt language="JavaScript1.1" type="text/javascript" src="http://ads.e-planning.net/eb/3/5d63/' + codigo + '?o=j&rnd=\' + rnd + \'&crs=\' + cs + \'' + masparam + '"></scr\' + \'ipt>\');');
document.write('</scr' + 'ipt>');
document.write('<noscr' + 'ipt><a	href="http://ads.e-planning.net/ei/3/4d63/' + codigo + '?it=i&rnd=$RANDOM' + masparam + '" target="_blank"><img alt="e-planning.net ad" src="http://ads.e-planning.net/eb/3/4d63/' + codigo + '?o=i&rnd=$RANDOM' + masparam + '" border=0></a></noscript>');
document.write('</div>');
}
