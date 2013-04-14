using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Buscador.Services.com.clarin.services.impl
{
    public class RequestCreatorService : IRequestCreatorService
    {
        public string CreateRequest(string url, string username, string password)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                myRequest.Headers.Add("username", username);
                myRequest.Headers.Add("password", password);
            }

            // We use POST ( we can also use GET )
            myRequest.Method = "GET";

            // Set the content type to a FORM
            myRequest.ContentType = "application/json";

            // Get response for http web request

            HttpWebResponse webResponse = (HttpWebResponse)myRequest.GetResponse();

            StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());

            // Read web response into string

            string webResponseStream = responseStream.ReadToEnd();

            return webResponseStream;
        }

        public HttpWebResponse CreateRequest(string url)
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "GET";
                return (HttpWebResponse)myRequest.GetResponse();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
