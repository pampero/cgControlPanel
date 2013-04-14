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

namespace Buscador.Services.com.clarin.services.impl
{
    public class IndexServiceAgencySolrImpl : MarshalByRefObject, IIndexService<Agency>
    {
        public IndexServiceAgencySolrImpl(string serverUrl)
        {
            InitializeSolrServer(serverUrl);
        }

        private void InitializeSolrServer(string serverUrl)
        {
            try
            {
                if (ServiceLocator.Current.GetInstance<ISolrOperations<Agency>>() == null)
                    Startup.Init<Agency>(serverUrl);
            }
            catch (Exception)
            {
                Startup.Init<Agency>(serverUrl);
            }
        }

        public ISolrOperations<Agency> Solr
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Agency>>(); }
        }

        public IResults<Agency> Query(ISearchParameters<Agency> searchParameters)
        {
            throw new NotImplementedException();
        }

        public IList<Agency> Query(IList<KeyValuePair<Expression<Func<Agency, object>>, string>> query)
        {
            return Query(query, default(int));
        }

        public IList<Agency> Query(IList<KeyValuePair<Expression<Func<Agency, object>>, string>> query, int maxResult)
        {
            ISolrQueryResults<Agency> solrResult;

            if (maxResult == default(int))
                solrResult = Solr.Query(SolrQueryBuilder<Agency>.BuildQuery(query));
            else
                solrResult = Solr.Query(SolrQueryBuilder<Agency>.BuildQuery(query), new QueryOptions { Rows = maxResult });

            return solrResult;
        }

        public IResults<Agency> QueryAll(int page, OrderInfo order)
        {
            throw new NotImplementedException();
        }

        public List<SelectedFilter> SelectedFiltersFor(Agency publication)
        {
            throw new NotImplementedException();
        }

        public IResults<Agency> QueryResults(ISearchParameters<Publication> searchParameters)
        {
            throw new NotImplementedException();
        }

        public IList<Agency> Query(List<KeyValuePair<Expression<Func<Publication, object>>, string>> query, int maxsize, OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
