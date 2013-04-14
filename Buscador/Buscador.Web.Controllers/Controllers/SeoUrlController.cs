using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.Linq;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.utils;
using Buscador.Services.com.clarin.services;

namespace Buscador.Web.Controllers.Controllers
{
    [HandleError]
    public class SeoUrlController : SearcherController
    {
        public IIndexService<Publication> IndexService { get; set; }

        public OldParametersReplace OldParametersReplace { get; set; }

        public IUrlOfuscator UrlOfuscator { get; set; }

        [AcceptVerbs("Get")]
        public JsonResult Search(SearchParameters<Publication> searchParameters)
        {
            Response.ContentType = "application/json";
            var result = IndexService.Query(searchParameters);

            return result.SerializeToJson();
        }

        [AcceptVerbs("Get")]
        public void RedirectOldParameters()
        {
            //var parameters = ((System.Collections.Specialized.NameObjectCollectionBase)
            //                 ((((System.Web.Mvc.Controller) (this)).Request).QueryString)).ToString();

            var parameters= Request.Url.ToString().Substring(Request.Url.ToString().IndexOf("Redirect"),
                                                             Request.Url.ToString().Length-Request.Url.ToString().IndexOf("Redirect"))
                                                  .Replace("RedirectOldParameters/", string.Empty);

            var newParameters = string.Empty;

            foreach (DictionaryEntry parameterReplace in OldParametersReplace.OldParametersReplaceMap)
            {
                parameters = parameters.Replace(parameterReplace.Key.ToString(), parameterReplace.Value.ToString());
                parameters = parameters.Replace(parameterReplace.Key.ToString().ToLower(), parameterReplace.Value.ToString());
            }

            foreach (var pair in parameters.Split('&'))
            {
                if (pair.Split('=')[1] != "0" || pair.Split('=')[0]=="VT")
                {

                    newParameters += pair.Replace("=", UrlOfuscator.OfuscatedCharacters["="].ToString()) + UrlOfuscator.OfuscatedCharacters["&"];
                }
                
            }

            newParameters = newParameters.Substring(0, (newParameters.Length - 2));

            //Response.Redirect(Url.Action("Search","Home",new RouteValueDictionary()) + "/" + newParameters);

            Response.StatusCode = 301;
            Response.Redirect("/buscar.mvc/Autos/" + newParameters,true);
        }
    }

    public  class OldParametersReplace
    {
        public static System.Collections.Specialized.HybridDictionary OldParametersReplaceMap { get; set; }

        public OldParametersReplace()
        {
            
        }
    }

    public static class ResultExtensionMethods
    {
        public static JsonResult SerializeToJson(this IResults<Publication> results)
        {
            var jsonResults = new JsonResult
                                  {
                                      Data = results.ResultList,
                                      JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                  };
            return jsonResults;
        }

       /* public static PublicationFullResult ToPublicationResult(this IResults<Publication> results)
        {
            var publicationsResult = new List<PublicationResult>();

            foreach (var publication in results.ResultList)
            {
                publicationsResult.Add(PublicationResult.BuildFrom(publication));
            }

            return new PublicationFullResult
            {
                PublicationResult = publicationsResult
                //Results = results
            };
        }*/

    
       
    }
}
