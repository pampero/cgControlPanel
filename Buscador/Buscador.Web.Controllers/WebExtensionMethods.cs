using System;
using System.Text;
using System.Threading;
using System.Web.Configuration;
using System.Web.Mvc;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Spring.Context.Support;

namespace Buscador.Web.Controllers
{
    public static class WebExtensionMethods
    {
        private static IUrlOfuscator _urlOfuscator
        {
            get
            {
                return (IUrlOfuscator) ContextRegistry.GetContext().GetObject("urlOfuscator");
            }
        }

        private static string videoPlayerLink { get { return "http://www.clarin.com/static/CLAClarin/swf/mediaplayer/videoPlayer.swf"; } }
        private static string pluginPageLink { get { return "http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash"; } }

        public static string LimitTo(this string cadena,int limit)
        {
            if (cadena.Length > limit)
                return cadena.Substring(0, limit) + "...";
            return cadena;
        }

        public static string WithThousandsSeparator(this int number)
        {
            return number < 1000 ? number.ToString() : String.Format("{0:0,0}", number).Replace(",",".");
        }

        public static string WithThousandsSeparator(this double number)
        {
            return number < 1000 ? number.ToString() : String.Format("{0:0,0}", number).Replace(",", ".");
        }

        public static string AsPrice(this string text, Currency currency)
        {
            return string.Format("{0}{1}",currency==null?string.Empty: currency.Symbol, text);
        }

        public static string ToProper(this string value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public static string BreadcrumbFor(this HtmlHelper<Publication> helper, Publication publication)
        {
            var and = _urlOfuscator.OfuscatedCharacters["&"];
            var equal = _urlOfuscator.OfuscatedCharacters["="];

            string vehicletypeurl = "http://www.deautos.com/autos-" + publication.VehicleTypeText + "s";
            string vehiclemakeurl = vehicletypeurl + "-" + publication.VehicleMakeText.ToLower() + "/VT" + equal + publication.VehicleType.ToString() + and + "MA" + equal + +publication.VehicleMake;
            string vehiclemodelurl = vehicletypeurl + "-" + publication.VehicleMakeText.ToLower() + "-" + publication.VehicleModelText.ToLower() + "/VT" + equal + publication.VehicleType.ToString() + and + "MA" + equal + publication.VehicleMake + and + "MO" + equal + publication.VehicleModel;
            
            var aTagHome = new TagBuilder("a");
            aTagHome.Attributes["href"] = "http://www.deautos.com";
            aTagHome.InnerHtml = "DeAutos";

            var aTagVehicleType = new TagBuilder("a");
            aTagVehicleType.Attributes["href"] = vehicletypeurl + "/VT" + equal + publication.VehicleType;
            aTagVehicleType.InnerHtml = publication.VehicleTypeText.Substring(0, 1).ToUpper() + publication.VehicleTypeText.Substring(1) + "s";

            var aTagMake = new TagBuilder("a");
            aTagMake.Attributes["href"] = vehiclemakeurl;
            aTagMake.InnerHtml = publication.VehicleMakeText;

            var aTagModel = new TagBuilder("a");
            aTagModel.Attributes["href"] = vehiclemodelurl;
            aTagModel.InnerHtml = publication.VehicleModelText;

            return string.Format("{0} > {1} > {2} > {3} > {4} ", aTagHome, aTagVehicleType, aTagMake, aTagModel, publication.VehicleVersionText);
        }

        public static string ItemLocation(this HtmlHelper<Publication> helper, Publication publication)
        {
            return string.Format("{0}, {1}", publication.VehicleLocLocText, publication.VehicleLocPartText.ToProper());
        }

        public static string MapCenterIn<T>(this HtmlHelper<T> helper,string locationCoordinates,string googleKey,int width, int height)
        {
            //<script src="http://maps.google.com/maps?file=api&v=2&sensor=false&key=ABQIAAAA0B1myXxg790GVj8JEg0EvBSeSlW9vW7u8j6xEORhq-WIcyI06BQiJJLQIAKiJzEKAV6jiLPP3uxwtA" type="text/javascript"></script>
            //<div id="map_canvas" style="width: 570px; height: 215px"></div>
            //<input id="gmap_punto" name="gmap_punto" type="hidden" size="40" value="-34.434735,-58.828096"/>

            var scriptBuilder = new TagBuilder("script");
            scriptBuilder.MergeAttribute("src","http://maps.google.com/maps?file=api&v=2&sensor=false&key=" + googleKey);

            var mapBuilder = new TagBuilder("div");
            mapBuilder.MergeAttribute("id","map_canvas");
            mapBuilder.MergeAttribute("style",string.Format("width: {0}px; height: {1}px",width,height));

            var mapPuntoBuilder = new TagBuilder("input");
            mapPuntoBuilder.MergeAttribute("id", "gmap_punto");
            mapPuntoBuilder.MergeAttribute("name", "gmap_punto");
            mapPuntoBuilder.MergeAttribute("type", "hidden");
            mapPuntoBuilder.MergeAttribute("size", "40");
            mapPuntoBuilder.MergeAttribute("value", locationCoordinates);

            return scriptBuilder + mapBuilder.ToString() + mapPuntoBuilder;
        }

        public static string AsText(this int integer)
        {
            string result = "";
            switch (integer)
            {
                case 0:
                    result = "cero";
                    break;
                case 1:
                    result = "uno";
                    break;
                case 2:
                    result = "dos";
                    break;
                case 3:
                    result = "tres";
                    break;
                case 4:
                    result = "cuatro";
                    break;
                case 5:
                    result = "cinco";
                    break;
                case 6:
                    result = "seis";
                    break;
                case 7:
                    result = "siete";
                    break;
                case 8:
                    result = "ocho";
                    break;
                case 9:
                    result = "nueve";
                    break;
            }
            return result;
        }

        public static int IntegerPart(this double number)
        {
            return Convert.ToInt32(number);
        }

        public static decimal DecimalPart(this double number)
        {
            return Decimal.Parse((number - Convert.ToInt32(number)).ToString());
        }

        private static string GetCascadeDropDownScript(string parentDropDownId, string childDropDownId, string url, string emptyItemText)
        {
            if (emptyItemText == null)
            {
                emptyItemText = string.Empty;
            }
            StringBuilder script = new StringBuilder();
            script.AppendLine(@"<script type='text/javascript'>");
            script.AppendLine(@"    $(document).ready(function () {");
            script.AppendLine(@"        $('#PARENTID').change(function () {");
            script.AppendLine(@"            var url = '" + url + "';");
            script.AppendLine("            $('#CHILDID').html('<option value=\"\">" + emptyItemText + "</option>');");
            script.AppendLine(@"            $.getJSON(url, { id: $('#PARENTID').val() }, function (data) {");
            script.AppendLine(@"                data.sort(function(a,b) {");
            script.AppendLine(@"                     return (a.Name < b.Name) ? -1 : (a.Name > b.Name) ? 1 : 0;");
            script.AppendLine(@"                });");
            script.AppendLine(@"                $.each(data, function (index, optionData) {");
            script.AppendLine(@"                    $('#CHILDID').append('<option value=' + optionData.Id + '>' + optionData.Name + '</option>');");
            script.AppendLine(@"                });");
            script.AppendLine(@"            $('#CHILDID').change();");
            script.AppendLine(@"            });");
            script.AppendLine(@"        });");
            script.AppendLine(@"    });");
            script.AppendLine(@"</script>");

            return script.ToString().Replace("#PARENTID", "#" + parentDropDownId)
                .Replace("#CHILDID", "#" + childDropDownId);
        }

        public static string ConfigureCascadeDropDowns<TModel>(this HtmlHelper<TModel> htmlHelper, string parentId, string childId, string action)
        {
            return GetCascadeDropDownScript(parentId, childId, action, "Seleccionar");
        }

        public static string ConfigureCascadeDropDowns<TModel>(this HtmlHelper<TModel> htmlHelper, string parentId, string childId, string action, string emptyItemText)
        {
            return GetCascadeDropDownScript(parentId, childId, action, emptyItemText);
        }

        public static string Video<TModel>(this HtmlHelper<TModel> htmlHelper, string linkToVideo, string width, string height,string urlImage)
        {
            var objectBuilder = new TagBuilder("object");
            objectBuilder.MergeAttribute("width", width);
            objectBuilder.MergeAttribute("height", height);
            objectBuilder.MergeAttribute("data", videoPlayerLink);
            objectBuilder.MergeAttribute("type", "application/x-shockwave-flash");

            var param1Builder = new TagBuilder("param");
            param1Builder.MergeAttribute("value", videoPlayerLink);
            param1Builder.MergeAttribute("name","movie");
            
            var param2Builder = new TagBuilder("param");
            param2Builder.MergeAttribute("value", "opaque");
            param2Builder.MergeAttribute("name","wmode");

            var param3Builder = new TagBuilder("param");
            var link = string.Format("titulo=video&seccion=video&w=512&h=312&flv={0}&thumb={1}", linkToVideo, urlImage);
            param3Builder.MergeAttribute("value", link);
            param3Builder.MergeAttribute("name", "flashvars");

            var param4Builder = new TagBuilder("param");
            param4Builder.MergeAttribute("value", "true");
            param4Builder.MergeAttribute("name", "allowFullScreen");

            var param5Builder = new TagBuilder("param");
            param5Builder.MergeAttribute("value", "always");
            param5Builder.MergeAttribute("name", "allowScriptAccess");

            objectBuilder.InnerHtml = string.Concat(param1Builder, param2Builder, param3Builder, param4Builder,
                                                    param5Builder);

            return objectBuilder.ToString();
            //<object width="512" height="313">

            //    <param value="http://www.clarin.com/static/CLAClarin/swf/mediaplayer/videoPlayer.swf" name="movie">

            //    <param value="high" name="quality">

            //    <param value="opaque" name="wmode">

            //    <param value="&link=http://www.clarin.com/mundo/invisibles-Libia-Marcelo-Cantelmi-

            //    especialb_3_549575046.html&titulo=LasvictimasinvisiblesdeLibiabPorMarceloCantelmienviadoespecialb

            //    &seccion=LasvictimasinvisiblesdeLibiabPorMarceloCantelmienviadoespecialb/Mundo/nota/cuerpo&w=512&

            //    h=313&flv=http://contenidos2.clarin.com/sincro/diario/flv/2011/06/03/VID/CLAVID20110603_0014/vide

            //    o_web.flv&thumb=/mundo/invisibles-Libia-Marcelo-Cantelmi-especialb_CLAVID20110906_0009_25.jpg" 

            //    name="flashVars">

            //    <param value="true" name="allowFullScreen">

            //    <param value="always" name="allowScriptAccess">

            //    <embed width="512" height="313" type="application/x-shockwave-flash" 

            //    pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash" 

            //    quality="high" allowfullscreen="true" flashvars="&link=http://www.clarin.com/mundo/invisibles-

            //    Libia-Marcelo-Cantelmi-

            //    especialb_3_549575046.html&titulo=LasvictimasinvisiblesdeLibiabPorMarceloCantelmienviadoespecialb

            //    &seccion=LasvictimasinvisiblesdeLibiabPorMarceloCantelmienviadoespecialb/Mundo/nota/cuerpo&w=512&

            //    h=313&flv=http://contenidos2.clarin.com/sincro/diario/flv/2011/06/03/VID/CLAVID20110603_0014/vide

            //    o_web.flv" src="http://www.clarin.com/static/CLAClarin/swf/mediaplayer/videoPlayer.swf" 

            //    wmode="opaque" allowscriptaccess="always">            

            //</object>
        }
    }
}