using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using SolrNet;

namespace Buscador.Services.com.clarin.services.impl
{
    public static class SolrQueryExtensionMethods
    {
        //public static IResults<Publication> ToResult(this ISolrQueryResults<Publication> solrQueryResults, IResultConverter resultConverter)
        //{
        //    return resultConverter.ConvertFrom(solrQueryResults);
        //}

        public static bool IsEmpty(this ISolrQuery solrQuery)
        {
            return string.IsNullOrEmpty(solrQuery.Query) || solrQuery.Query=="publication_state_id:Active AND publication_visible:true";
        }

        public static ISolrQuery OnlyActives(this ISolrQuery solrQuery)
        {
            return new SolrQuery("publication_state_id:Active");
        }
    }
}