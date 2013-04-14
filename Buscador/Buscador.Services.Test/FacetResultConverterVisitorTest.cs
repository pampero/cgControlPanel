using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Buscador.Services.com.clarin.services;
using NUnit.Framework;
using Spring.Testing.NUnit;

namespace Buscador.Services.Test
{
    [TestFixture]
    public class FacetResultConverterVisitorTest : AbstractDependencyInjectionSpringContextTests
    {
        
        public void Facet_Visitor_Make_Result_Object_With_Filters_Group()
        {
            var facetField = new KeyValuePair<string, ICollection<KeyValuePair<string, int>>>
                                 (
                                    "facetKey",
                                    new List<KeyValuePair<string,int>>{new KeyValuePair<string, int>("key",1)}
                                 );

            var selectedFilters = new List<SelectedFilter>
                                      {
                                          new SelectedFilter("sl1", "val1", true, 1),
                                          new SelectedFilter("sl2", "val2", true, 2),
                                          new SelectedFilter("sl3", "val3", true, 3),
                                          new SelectedFilter("sl4", "val4", true, 4),
                                      };

            var result = new Results<Publication>(10, 20);



            //var facetVisitor = new FacetResultConverterVisitor(facetField, selectedFilters, result,);
        }

        protected override string[] ConfigLocations
        {
            get
            {
                return new[]
                           {
                               "assembly://Buscador.Services/Buscador.Services/services-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/hibernate-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/dao-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/facets-config.xml"
                           };
            }
        }
    }
}
