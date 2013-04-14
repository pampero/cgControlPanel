using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Buscador.Services.com.clarin.services.builders.solr;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;
using SolrNet.DSL;

namespace Buscador.Services.com.clarin.services.impl
{
    public class IndexServiceSegmentCatalogInfoSolrImpl : IIndexService<SegmentCatalogInfo>
    {
        public IndexServiceSegmentCatalogInfoSolrImpl(string serverUrl)
        {
            InitializeSolrServer(serverUrl);
        }

        private void InitializeSolrServer(string serverUrl)
        {
            try
            {
                if (ServiceLocator.Current.GetInstance<ISolrOperations<SegmentCatalogInfo>>() == null)
                    Startup.Init<SegmentCatalogInfo>(serverUrl);
            }
            catch (Exception)
            {
                Startup.Init<SegmentCatalogInfo>(serverUrl);
            }
        }

        public ISolrOperations<SegmentCatalogInfo> Solr
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<SegmentCatalogInfo>>(); }
        }

        public IResults<SegmentCatalogInfo> Query(ISearchParameters<SegmentCatalogInfo> searchParameters)
        {
            throw new NotImplementedException();
        }

        public IList<SegmentCatalogInfo> Query(IList<KeyValuePair<Expression<Func<SegmentCatalogInfo, object>>, string>> query)
        {
            return Query(query, default(int));
        }

        public IList<SegmentCatalogInfo> Query(IList<KeyValuePair<Expression<Func<SegmentCatalogInfo, object>>, string>> query, int maxResult)
        {
            ISolrQueryResults<SegmentCatalogInfo> solrResult;

            if (maxResult == default(int))
                solrResult = Solr.Query(SolrQueryBuilder<SegmentCatalogInfo>.BuildQuery(query));
            else
                solrResult = Solr.Query(SolrQueryBuilder<SegmentCatalogInfo>.BuildQuery(query), new QueryOptions { Rows = maxResult });

            return solrResult;
        }

        public IResults<SegmentCatalogInfo> QueryAll(int page, OrderInfo order)
        {
            throw new NotImplementedException();
        }

        public List<SelectedFilter> SelectedFiltersFor(SegmentCatalogInfo publication)
        {
            throw new NotImplementedException();
        }

        public IResults<SegmentCatalogInfo> QueryResults(ISearchParameters<Publication> searchParameters)
        {
            throw new NotImplementedException();
        }

        public IList<SegmentCatalogInfo> Query(List<KeyValuePair<Expression<Func<Publication, object>>, string>> query, int maxsize, OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
