using Buscador.Domain.com.clarin.dao;
using Buscador.Domain.com.clarin.entities;
using Microsoft.Practices.ServiceLocation;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Buscador.Services.com.clarin.services.impl
{
    public class IndexServicePublicationImpl : IIndexService<Publication>
    {
        //public string ServerUrl { get; set; }
        public IPublicationDao PublicationDao { get; set; }

        private ISolrOperations<Publication> _solr; 

        public IndexServicePublicationImpl(string serverUrl)
        {
            InitializeSolrServer(serverUrl);
        }
        
        public IndexServicePublicationImpl(IPublicationDao publicationDao, string serverUrl)
        {
            PublicationDao = publicationDao;
            InitializeSolrServer(serverUrl);
        }

        private void InitializeSolrServer(string serverUrl)
        {
            Startup.Init<Publication>(serverUrl);
            _solr = ServiceLocator.Current.GetInstance<ISolrOperations<Publication>>();
        }

        public void Index()
        {
            var allPublications = PublicationDao.GetAll();
            allPublications.ForEach(IndexPublication);

        }

        private void IndexPublication(Publication publication)
        {
            _solr.Delete(SolrQuery.All)
                 .Add(publication)
                 .Commit();
        }

        public ISolrQueryResults<Publication> Query(ISolrQuery query)
        {
            return _solr.Query(new SolrQuery(query.Query));
        }

        public ISolrQueryResults<Publication> Query(ISolrQuery query, QueryOptions queryOptions)
        {
            return _solr.Query(query, queryOptions);
        }
    }
}
