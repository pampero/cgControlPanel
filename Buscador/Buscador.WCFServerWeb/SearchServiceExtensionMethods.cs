using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Buscador.WCFServerWeb
{
    public static class SearchServiceExtensionMethods
    {
        public static KeyValuePair<string,string> ExtractCredentials(this WebHeaderCollection webHeaderCollection)
        {
            return new KeyValuePair<string, string>(webHeaderCollection["username"], webHeaderCollection["password"]);
        }
    }
}