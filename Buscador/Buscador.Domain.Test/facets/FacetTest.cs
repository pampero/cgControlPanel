using System.Collections.Generic;
using System.Linq;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Services.com.clarin.services;
using NUnit.Framework;
using SolrNet;
using SolrNet.Commands.Parameters;
using Spring.Objects.Factory.Config;
using Spring.Testing.NUnit;

namespace Buscador.Domain.Test.facets
{
    [TestFixture]
    public class FacetTest : AbstractDependencyInjectionSpringContextTests
    {
        public FacetConfiguration facetConfiguration { get; set; }
        public IIndexService<Publication> indexServiceImpl { get; set; }
        public IUrlOfuscator urlOfuscator { get; set; } 

        public FacetTest()
        {
            AutowireMode = AutoWiringMode.ByName;
        }

        [Test]
        public void Test_Selected_Filters_To_Search_Parameter()
        {
            var query = Conditions.From("MAYY380WWPGYY1", urlOfuscator);
            var selectedFiltersContext = new QueryUrlParser(facetConfiguration.FacetHierarchy, urlOfuscator).Parse(query).GetSelectedFilters();
            var searchParameter = new SearchParameters<Publication>(string.Empty, selectedFiltersContext, 
                                                                    facetConfiguration.FacetHierarchy.ByName(selectedFiltersContext.SelectedFilters.Last().Name),
                                                                    facetConfiguration.FacetHierarchy.FacetsNotInBranchOf((selectedFiltersContext.SelectedFilters.Last().Name)));
            var result = indexServiceImpl.Query(searchParameter);
        }

        protected override string[]  ConfigLocations
        {
            get
            {
                return new[]
                           {
                               "assembly://Buscador.Domain/Buscador.Domain/facets-config.xml",
                               "assembly://Buscador.Services/Buscador.Services/services-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/dao-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/hibernate-config.xml"
                           };
            }
        }
    }
}
