using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Buscador.Services.com.clarin.services
{
    public interface IRequestCreatorService
    {
        String CreateRequest(string url, string username, string password);
        HttpWebResponse CreateRequest(string url);
    }
}
