using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.exceptions;
using Buscador.Services.com.clarin.services.builders.solr;
using NUnit.Framework;
using NUnit.Mocks;

namespace Buscador.Services.Test.builders
{
    [TestFixture]
    public class SolrQueryBuilderTest
    {
        [Test]
        public void SearchParameters_With_No_SelectedFilters_Return_Only_Actives_And_Visibles()
        {
            var searchParameterMock = new DynamicMock(typeof(ISearchParameters<Publication>));
            searchParameterMock.SetReturnValue("get_SelectedFilters", null);


            var solrQueryBuilder = new SolrQueryBuilder<Publication>((ISearchParameters<Publication>)searchParameterMock.MockInstance);
            var query = solrQueryBuilder.BuildQuery();

            Assert.IsTrue(query.Query.Equals("publication_state_id:Active AND publication_visible:true"));
        }

        [Test]
        public void SearchParameters_With_Empty_SelectedFilters_Return_Only_Actives_And_Visibles()
        {
            var selectedFilters = new List<SelectedFilter>();

            var searchParameterMock = new DynamicMock(typeof(ISearchParameters<Publication>));
            searchParameterMock.SetReturnValue("get_SelectedFilters", selectedFilters);


            var solrQueryBuilder = new SolrQueryBuilder<Publication>((ISearchParameters<Publication>)searchParameterMock.MockInstance);
            var query = solrQueryBuilder.BuildQuery();

            Assert.IsTrue(query.Query.Equals("publication_state_id:Active AND publication_visible:true"));
        }

        [Test]
        [ExpectedException(typeof(SelectedFilterException))]
        public void SearchParameters_With__SelectedFilters_With_NoName_Return_SelectedFilterException()
        {
            var selectedFilters = new List<SelectedFilter>
                                      {
                                          new SelectedFilter(string.Empty, "val1", true, 1)
                                      };

            var searchParameterMock = new DynamicMock(typeof(ISearchParameters<Publication>));
            searchParameterMock.SetReturnValue("get_SelectedFilters", selectedFilters);


            var solrQueryBuilder = new SolrQueryBuilder<Publication>((ISearchParameters<Publication>)searchParameterMock.MockInstance);
            solrQueryBuilder.BuildQuery();
        }

        [Test]
        public void SimpleFilters_Return_SolrQuery()
        {
            var selectedFilters = new List<SelectedFilter>
                                      {
                                          new SelectedFilter("sl1", "val1", true, 1),
                                          new SelectedFilter("sl2", "val2", true, 1),
                                          new SelectedFilter("sl3", "val3", true, 1)
                                      };

            var searchParameterMock = new DynamicMock(typeof (ISearchParameters<Publication>));
            searchParameterMock.SetReturnValue("get_SelectedFilters", selectedFilters);


            var solrQueryBuilder = new SolrQueryBuilder<Publication>((ISearchParameters<Publication>)searchParameterMock.MockInstance);
            var query = solrQueryBuilder.BuildQuery();

            Assert.IsTrue(query.Query == "publication_state_id:Active AND publication_visible:true AND sl1:val1 AND sl2:val2 AND sl3:val3");
        }

        [Test]
        public void SimpleFilters_And_RangeFilter_Return_SolrQuery_WithRangeQuery()
        {
            var selectedFilters = new List<SelectedFilter>
                                      {
                                          new SelectedFilter("sl1", "val1", true, 1),
                                          new SelectedFilter("sl2", "val2", true, 1),
                                          new SelectedFilter("sl3", "from-to", true, 1)
                                      };

            var searchParameterMock = new DynamicMock(typeof(ISearchParameters<Publication>));
            searchParameterMock.SetReturnValue("get_SelectedFilters", selectedFilters);


            var solrQueryBuilder = new SolrQueryBuilder<Publication>((ISearchParameters<Publication>)searchParameterMock.MockInstance);
            var query = solrQueryBuilder.BuildQuery();

            Assert.IsTrue(query.Query == "publication_state_id:Active AND publication_visible:true AND sl1:val1 AND sl2:val2 AND sl3:[from TO to]");
        }

        [Test]
        public void SimpleFilters_And_EmptyRangeFilter_Should_Not_Throw_SelectedFilterException()
        {
            var selectedFilters = new List<SelectedFilter>
                                      {
                                          new SelectedFilter("sl1", "val1", true, 1),
                                          new SelectedFilter("sl2", "val2", true, 1),
                                          new SelectedFilter("sl3", "-", true, 1)
                                      };

            var searchParameterMock = new DynamicMock(typeof(ISearchParameters<Publication>));
            searchParameterMock.SetReturnValue("get_SelectedFilters", selectedFilters);


            var solrQueryBuilder = new SolrQueryBuilder<Publication>((ISearchParameters<Publication>)searchParameterMock.MockInstance);
            solrQueryBuilder.BuildQuery();
        }
    }
}
