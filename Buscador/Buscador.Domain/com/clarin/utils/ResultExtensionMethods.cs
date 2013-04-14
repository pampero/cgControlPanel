using System.Collections.Generic;
using System.Web.Mvc;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Domain.com.clarin.utils
{
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

        public static PublicationFullResult ToPublicationResult(this IResults<Publication> results)
        {
            var publicationsResult = new List<PublicationResult>();

            foreach (var publication in results.ResultList)
            {
                publicationsResult.Add(PublicationResult.BuildFrom(publication));
            }

            return new PublicationFullResult
                       {
                           PublicationResult = publicationsResult,
                           Results = results
                       };
        }
    }
}