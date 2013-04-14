using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Moq;
using NUnit.Framework;

namespace Buscador.Domain.Test
{
    [TestFixture]
    public class QueryUrlParserTest
    {
        private Mock<IFacetConfiguration> _facetConfiguration;
        private Mock<IUrlOfuscator> _urlOfuscator;

        [SetUp]
        public void InitMocks()
        {
            _facetConfiguration = new Mock<IFacetConfiguration>();
            _urlOfuscator = new Mock<IUrlOfuscator>();

            var ofuscatedCharacters = new HybridDictionary();
            ofuscatedCharacters["&"] = "WW";
            ofuscatedCharacters["="] = "YY";

            _urlOfuscator.Setup(x => x.OfuscatedCharacters).Returns(ofuscatedCharacters);

            var facets = new List<IFacet>();

            facets.AddRange(new IFacet[]
                                {
                                    new SimpleFacet
                                        {
                                            Name = "publication_type_id",
                                            Branch = 1,
                                            Level = 1,
                                            Key = "PT",
                                            UseForSeo = false,
                                            Visible = false,
                                            Priority = 17
                                        },
                                    new HierarchicalFacet
                                        {
                                            Name = "vehicle_make_id",
                                            Branch = 1,
                                            Level = 1,
                                            Key = "MA",
                                            UseForSeo = true,
                                            Visible = true,
                                            Priority = 2
                                        },
                                    new SimpleFacet
                                        {
                                            Name = "vehicle_type_id",
                                            Branch = 5,
                                            Level = 1,
                                            Key = "VT",
                                            UseForSeo = true,
                                            Visible = true,
                                            Priority = 1
                                        }
                                });

            _facetConfiguration.Setup(x => x.FacetHierarchy).Returns(new FacetHierarchy
            {
                Facets = facets,
            });

            _facetConfiguration.Setup(x => x.PageSize).Returns(20);
        }

        [Test]
        public void Test_SearchParameters_Exclude_Lineals()
        {
            var searchQuery = "VTYY1WWMAYY371";

            var conditions = Conditions.From(searchQuery, _urlOfuscator.Object);
            var parameters = QueryUrlParser.With(_facetConfiguration.Object.FacetHierarchy, _urlOfuscator.Object)
                                           .Parse(conditions)
                                           .ExcludeLineals()
                                           .GetSelectedFilters();

            Assert.IsTrue(parameters.SelectedFilters.Count == 3);
            Assert.IsTrue(parameters.SelectedFilters[2].Name.Equals("publication_type_id"));
        }

        [Test]
        public void Test_SearchParameters_Accept_Custom_Page_Size()
        {
            var searchQuery = "VTYY1WWMAYY371WWPSYY35";

            var conditions = Conditions.From(searchQuery, _urlOfuscator.Object);
            var parameters = QueryUrlParser.With(_facetConfiguration.Object.FacetHierarchy, _urlOfuscator.Object)
                                           .Parse(conditions)
                                           .ExcludeLineals()
                                           .GetSelectedFilters();

            Assert.IsTrue(parameters.PageSize == 35);
        }
    }
}
