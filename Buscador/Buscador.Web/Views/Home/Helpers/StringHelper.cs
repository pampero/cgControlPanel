using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buscador.Web.Views.Home.Helpers
{
    public class StringHelper
    {
        public static string RemoveWhiteSpace(string str)
        {
            str = str.ToLower();
            var words = str.Split(' ');
            string result = "";
            if (words.Count() > 1)
            {
                foreach (var word in words)
                {
                    result += word;
                }
                return result;
            }
            return str;
        }
    }
}