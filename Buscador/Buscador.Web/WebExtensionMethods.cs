using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Web
{
    public static class WebExtensionMethods
    {
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
            return string.Format("{0}{1}", currency.Symbol, text);
        }

        public static string ToProper(this string value)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
            //return Regex.Replace(value, @"\b(\w)(\w+)?\b", new MatchEvaluator(match =>
            //                string.Concat(match.Groups[1].Value.ToUpper(),
            //                match.Groups[2].Value)), RegexOptions.IgnoreCase);
        }
    }
}