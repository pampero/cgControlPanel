using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.exceptions;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Buscador.Services.com.clarin.services.builders.solr
{
    public class SolrQueryBuilder<T>
    {
        private ISearchParameters<T> _searchParameters;

        public SolrQueryBuilder(ISearchParameters<T> searchParameters)
        {
            _searchParameters = searchParameters;
        }

        public AbstractSolrQuery BuildQuery()
        {
            var queries = new List<string>();

            queries.Add(string.Format("{0}:{1}", "publication_state_id", "Active"));
            queries.Add(string.Format("{0}:{1}", "publication_visible", "true"));

            if(!string.IsNullOrEmpty(_searchParameters.FreeText))
                queries.Add(string.Format("{0}:{1}","campo_busqueda" ,_searchParameters.FreeText ));

            if (_searchParameters.SelectedFilters!=null)
                foreach (var selectedFilter in _searchParameters.SelectedFilters)
                {
                    if(!selectedFilter.Value.Contains("-"))
                    {
                        if (string.IsNullOrEmpty(selectedFilter.Name)) throw new SelectedFilterException("SelectedFilter name cannot be empty");
                        queries.Add(string.Format("{0}{1}:{2}", selectedFilter.Deny ? "-" : string.Empty, selectedFilter.Name, selectedFilter.Value));
                    }
                    else
                    {
                        if (selectedFilter.Value == "-") continue;
                        var from = selectedFilter.Value.Split('-')[0];
                        var to = selectedFilter.Value.Split('-')[1];
                        queries.Add(string.Format("{0}{1}:{2}", selectedFilter.Deny ? "-" : string.Empty, selectedFilter.Name, "[" + from + " TO " + to + "]"));
                    }
                }

            

            return new SolrQuery(string.Join(" AND ", queries.ToArray()));
        }

        public QueryOptions BuildQueryOptions(int pageSize, int page, string order,string direction)
        {
            var queryOptions = new QueryOptions
                                   {
                                       Rows = pageSize,
                                       Start = page == 1 ? page : pageSize * (page - 1),
                                   };

            if (queryOptions.Start == 1)
                queryOptions.Start = 0;

            if (!string.IsNullOrEmpty(order))
                queryOptions.AddOrder(new SortOrder(order, GetDirection(direction)));

            queryOptions.AddOrder(new SortOrder("index_weight", Order.DESC))
                        .AddOrder(new SortOrder("publication_start_date", Order.DESC));

            var facetParameters = new FacetParameters
                                      {
                                          Queries = _searchParameters.FacetWith != null ? _searchParameters.FacetWith
                                                                                                           .Select(x => (ISolrFacetQuery) (new SolrFacetFieldQuery(x.Name)))
                                                                                                           .ToList()
                                                                                        : null
                                      };

            queryOptions.Facet = facetParameters;

            return queryOptions;
        }

        public static QueryOptions BuildAllQueryOptions(List<IFacet> facets, int pageSize, int page, string order, string direction)
        {
            var queryOptions = new QueryOptions();

            if(pageSize!=0)
                queryOptions = new QueryOptions
                                   {
                                       Rows = pageSize,
                                       Start = page==1?page:pageSize*page-1,
                                   };

            if (queryOptions.Start == 1)
                queryOptions.Start = 0;

            if(!string.IsNullOrEmpty(order))
                queryOptions.AddOrder(new SortOrder(order, GetDirection(direction)));
            //else
            //    queryOptions.AddOrder(new SortOrder("publication_type_id", Order.ASC));

            queryOptions.AddOrder(new SortOrder("index_weight", Order.DESC))
                        .AddOrder(new SortOrder("publication_start_date", Order.DESC));

            var facetParameters = new FacetParameters
            {
                Queries = facets.Select(x => (ISolrFacetQuery)(new SolrFacetFieldQuery(x.Name)))
                                .ToList()
            };

            queryOptions.Facet = facetParameters;

            return queryOptions;
        }

        private static Order GetDirection(string direction)
        {
            switch (direction)
            {
                case "A":
                    return Order.ASC;
                case "D":
                    return Order.DESC; 
            }
            return Order.DESC;
        }

        public static ISolrQuery BuildQuery(IList<KeyValuePair<Expression<Func<T, object >>, string>> query)
        {
            var s = string.Join(" AND ",query.Select(x => string.Format("{0}:{1}", SolrFieldName(x.Key.MemberName()), x.Value)).ToArray());
            return new SolrQuery(s);
        }

        private static string SolrFieldName(string memberName)
        {
            var solrAtt = typeof (T).GetProperty(memberName).GetCustomAttributes(false)[0];
            return ((SolrNet.Attributes.SolrFieldAttribute) (solrAtt)).FieldName;
        }

        //public static ISolrQuery BuildQuery(List<KeyValuePair<Expression<Func<Publication, string>>, string>> query)
        //{
        //    return new SolrQuery(string.Join(" AND ", query.Select(x => string.Format("{0}:{1}", x.Key.MemberName(), x.Value)).ToArray()));
        //}

        //public static ISolrQuery BuildQuery(List<KeyValuePair<Expression<Func<Publication, int>>, string>> query)
        //{
        //    return new SolrQuery(string.Join(" AND ", query.Select(x => string.Format("{0}:{1}", x.Key.MemberName(), x.Value)).ToArray()));
        //}

        //public static ISolrQuery BuildQuery(List<KeyValuePair<Expression<Func<Agency, string>>, string>> query)
        //{
        //    return new SolrQuery(string.Join(" AND ", query.Select(x => string.Format("{0}:{1}", x.Key.MemberName(), x.Value)).ToArray()));
        //}

        //public static ISolrQuery BuildQuery(List<KeyValuePair<Expression<Func<Agency, int>>, string>> query)
        //{
        //    return new SolrQuery(string.Join(" AND ", query.Select(x => string.Format("{0}:{1}", x.Key.MemberName(), x.Value)).ToArray()));
        //}
    }
}
