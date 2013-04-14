using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Buscador.Domain.com.clarin.entities
{
    public class Banner
    {
        public string Heigh { get; set; }
        public string Width { get; set; }
        public string Behaviour { get; set; }
        public string Provider { get; set; }
        public string Zone { get; set; }
        public string Parameters { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public string Order { get; set; }
        public string ESection { get; set; }

        public IKeywordsProvider KeywordsProvider { get; set; }

        public string GetHtml()
        {
            switch (Behaviour)
            {
                    /*case "concesionaria":
                    var ubicacion = BannerDao.GetAttribute("ubicacion", seccion, codigo);
                    var outResult = default(int);
                    
                    if(!int.TryParse(ubicacion, out outResult))
                        throw new Exception("Falta definir el atributo Ubicacion del banner");

                    //If Not IsNumeric(intUbicacion) Then
					//    err.Raise 50001,"clsBanners.LoadBanner()", "Falta definir el atributo Ubicacion del banner:" & strSeccion & "/" & strCodigo 
				    //End If
                    LoadFromConcesionaria(result,outResult);
                    break;*/

                case "parametros":
                    
                    return ToHtml();

                default:
                    //var zona = BannerDao.GetAttribute("zona", seccion, codigo);
                    //Cliente_id = nodeBanner.getAttribute("cliente_id")
                    break;
            }
            return string.Empty;
        }

        private string ToHtml()
        {
            if (string.IsNullOrEmpty(Zone)) return string.Empty;

            switch (Provider)
            {
                case "eplanning":

                    var parametros = KeywordsProvider.GetParametersString(Parameters,Section);

                    var rnd = new Random().NextDouble().ToString().Substring(2, 8) + (DateTime.Now.TimeOfDay.Milliseconds & 262143);

                    
                 
                    var  innerScriptHtml = "var rnd = (new String(Math.random())).substring(2,8) + (((new Date()).getTime()) & 262143);" + Environment.NewLine +
                       "document.write (\"<script type='text/javascript' src='http://ads.e-planning.net/" + ESection + "/3/" + Order + "/" + Zone + "?o=j&rnd=" + rnd + "&" + parametros + "'\" + \"/>\");" + Environment.NewLine;
 
                 


                    var scriptBuilder = new TagBuilder("script");
                    scriptBuilder.Attributes.Add("type", "text/javascript");
                    scriptBuilder.Attributes.Add("language", "JavaScript1.1");
                    scriptBuilder.InnerHtml = innerScriptHtml;
                    scriptBuilder.InnerHtml += "</script>";
                    return scriptBuilder.ToString();

                default:
                    return string.Empty;
            }
        }
    }
}