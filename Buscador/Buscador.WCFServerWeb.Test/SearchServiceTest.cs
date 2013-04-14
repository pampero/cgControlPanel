using System.Collections.Generic;
using System.Collections.Specialized;
using Buscador.Domain;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Moq;
using NUnit.Framework;

namespace Buscador.WCFServerWeb.Test
{
    [TestFixture]
    public class SearchServiceTest
    {
        //[Test]
        //public void Test_GetResults_Without_Lineals()
        //{
        //    #region Mocks
        //    var facetConfiguration = new Mock<IFacetConfiguration>();
        //    var jsonSerializer = new Mock<IJsonSerializer>();
        //    var urlOfuscator = new Mock<IUrlOfuscator>();

        //    var ofuscatedCharacters = new HybridDictionary();
        //    ofuscatedCharacters["&"] = "WW";
        //    ofuscatedCharacters["="] = "YY";

        //    urlOfuscator.Setup(x => x.OfuscatedCharacters).Returns(ofuscatedCharacters);

        //    var facets = new List<IFacet>();

        //    facets.AddRange(new IFacet[] {
        //                            new SimpleFacet
        //                            {
        //                                Name = "publication_type_id",
        //                                Branch = 1,
        //                                Level = 1,
        //                                Key = "PT",
        //                                UseForSeo = false,
        //                                Visible = false,
        //                                Priority = 17
        //                            },
        //                            new HierarchicalFacet
        //                            {
        //                                Name = "vehicle_make_id",
        //                                Branch = 1,
        //                                Level = 1,
        //                                Key = "MA",
        //                                UseForSeo = true,
        //                                Visible = true,
        //                                Priority = 2
        //                            },
        //                            new SimpleFacet
        //                            {
        //                                Name = "vehicle_type_id",
        //                                Branch = 5,
        //                                Level = 1,
        //                                Key = "VT",
        //                                UseForSeo = true,
        //                                Visible = true,
        //                                Priority = 1
        //                            }
        //    });

        //    facetConfiguration.Setup(x => x.FacetHierarchy).Returns(new FacetHierarchy
        //                                                                {
        //                                                                    Facets = facets,
        //                                                                });
        //    #endregion

        //    var indexService = new IndexServicePublicationSolrImpl("http://localhost:8983/solr/live")
        //                           {
        //                               FacetConfiguration = facetConfiguration.Object
        //                           };
        //    var solrOperations = new Mock<ISolrOperations<Publication>>();

        //    var container = ServiceLocator.Current as SolrNet.Utils.Container;
        //    container.Remove<ISolrOperations<Publication>>();
        //    container.Register<ISolrOperations<Publication>>(c => solrOperations.Object);

        //    var indexServiceMock = new Mock<IIndexService<Publication>>();
        //    solrOperations
        //        .Setup(x => x.Query(It.IsAny<ISolrQuery>(), It.IsAny<QueryOptions>()));

        //    // indexServiceMock.Setup(x => x.Query(It.IsAny<ISearchParameters<Publication>>())).Returns(results);

        //    var service = new SearchService
        //                      {
        //                          FacetConfiguration = facetConfiguration.Object,
        //                          IndexService = indexService,
        //                          JsonSerializer = jsonSerializer.Object,
        //                          UrlOfuscator = urlOfuscator.Object,
        //                      };

        //    var searchResults = service.Search("VTYY1WWMAYY371"); // Publicaciones activas, modelo Focus
        //    Assert.IsNotEmpty(searchResults);
        //}
    }
}
