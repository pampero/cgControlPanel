using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Services.com.clarin.services.builders.solr;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Buscador.Services.com.clarin.services.impl
{
    public class IndexServiceVersionCatalogInfoSolrImpl : IIndexService<VersionCatalogInfo>
    {
        private ISolrSearchService<VersionCatalogInfo> _solrService;
        private Action<VersionCatalogInfo> _onPostLoadPublication;
        private IDictionary<Expression<Func<Publication, int>>, Expression<Func<Publication, string>>> _propertiesToLoad;

        public ISolrOperations<VersionCatalogInfo> Solr
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<VersionCatalogInfo>>(); }
        }

        public IndexServiceVersionCatalogInfoSolrImpl(string serverUrl)
        {
            InitializeSolrServer(serverUrl);
        }

        private void InitializeSolrServer(string serverUrl)
        {
            try
            {
                if (ServiceLocator.Current.GetInstance<ISolrOperations<VersionCatalogInfo>>() == null)
                    Startup.Init<VersionCatalogInfo>(serverUrl);
            }
            catch (Exception)
            {
                Startup.Init<VersionCatalogInfo>(serverUrl);
            }
        }
     
        public IResults<VersionCatalogInfo> Query(ISearchParameters<VersionCatalogInfo> searchParameters)
        {
            var solrQueryBuilder = new SolrQueryBuilder<VersionCatalogInfo>(searchParameters);
            var solrQuery = solrQueryBuilder.BuildQuery();
            //return Solr.Query(solrQuery);
            //SolrService
            return null;

        }

        public IList<VersionCatalogInfo> Query(IList<KeyValuePair<Expression<Func<VersionCatalogInfo, object>>, string>> query)
        {
            return Query(query, default(int));
        }

        public IList<VersionCatalogInfo> Query(IList<KeyValuePair<Expression<Func<VersionCatalogInfo, object>>, string>> query, int maxResult)
        {
            ISolrQueryResults<VersionCatalogInfo> solrResult;

            if (maxResult == default(int))
                solrResult = Solr.Query(SolrQueryBuilder<VersionCatalogInfo>.BuildQuery(query));
            else
                solrResult = Solr.Query(SolrQueryBuilder<VersionCatalogInfo>.BuildQuery(query), new QueryOptions { Rows = maxResult });

            return solrResult;
        }

        public IResults<VersionCatalogInfo> QueryAll(int page, OrderInfo order)
        {
            throw new NotImplementedException();
        }

        public List<SelectedFilter> SelectedFiltersFor(VersionCatalogInfo publication)
        {
            throw new NotImplementedException();
        }

        public IResults<VersionCatalogInfo> QueryResults(ISearchParameters<Publication> searchParameters)
        {
            throw new NotImplementedException();
        }

        public IList<VersionCatalogInfo> Query(List<KeyValuePair<Expression<Func<Publication, object>>, string>> query, int maxsize, OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
