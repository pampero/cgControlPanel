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
    public class IndexServiceHomePublicationsImpl : IIndexService<PublicationHome>
    {

        public IndexServiceHomePublicationsImpl(string serverUrl)
        {
            InitializeSolrServer(serverUrl);
        }

        private void InitializeSolrServer(string serverUrl)
        {
            try
            {
                if (ServiceLocator.Current.GetInstance<ISolrOperations<PublicationHome>>() == null)
                    Startup.Init<PublicationHome>(serverUrl);
            }
            catch (Exception)
            {
                Startup.Init<PublicationHome>(serverUrl);
            }
        }

        public ISolrOperations<PublicationHome> Solr
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<PublicationHome>>(); }
        }


        public IResults<PublicationHome> Query(ISearchParameters<PublicationHome> searchParameters)
        {
            throw new NotImplementedException();
        }

        public IList<PublicationHome> Query(IList<KeyValuePair<Expression<Func<PublicationHome, object>>, string>> query)
        {
            return Query(query, default(int));
        }

        public IList<PublicationHome> Query(IList<KeyValuePair<Expression<Func<PublicationHome, object>>, string>> query, int maxResult)
        {
            ISolrQueryResults<PublicationHome> solrResult;

            if (maxResult == default(int))
                solrResult = Solr.Query(SolrQueryBuilder<PublicationHome>.BuildQuery(query));
            else
                solrResult = Solr.Query(SolrQueryBuilder<PublicationHome>.BuildQuery(query), new QueryOptions { Rows = maxResult });

            return solrResult;
        }

        public IResults<PublicationHome> QueryAll(int page, OrderInfo order)
        {
            throw new NotImplementedException();
        }

        public List<SelectedFilter> SelectedFiltersFor(PublicationHome publication)
        {
            throw new NotImplementedException();
        }

        public IResults<PublicationHome> QueryResults(ISearchParameters<Publication> searchParameters)
        {
            throw new NotImplementedException();
        }

        public IList<PublicationHome> Query(List<KeyValuePair<Expression<Func<Publication, object>>, string>> query, int maxsize, OrderInfo orderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
