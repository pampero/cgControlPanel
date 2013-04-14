using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.slices;
using Buscador.Services.com.clarin.services;
using NUnit.Framework;

namespace Buscador.Domain.Test.entities
{
    [TestFixture]
    public class ResultTest
    {
        [Test]
        public void VisibleAppliedFilters_Should_Return_Only_Visible_Filters()
        {
            var visibleFilter1 = new Slice
                                     {
                                         Name = "Filtro 1",
                                         Visible = true
                                     };
            var visibleFilter2 = new Slice
                                     {
                                         Name = "Filtro 2",
                                         Visible = true
                                     };
            var invisibleFilter = new Slice
                                      {
                                          Name = "Filtro Invisible",
                                          Visible = false
                                      };

            var results = new Results<Publication>(1, 10);
            results.AddAppliedFilter(visibleFilter1);
            results.AddAppliedFilter(visibleFilter2);
            results.AddAppliedFilter(invisibleFilter);

            Assert.Contains(visibleFilter1, results.VisibleAppliedFilters);
            Assert.Contains(visibleFilter2, results.VisibleAppliedFilters);
            Assert.IsFalse(results.VisibleAppliedFilters.Contains(invisibleFilter));
        }
    }
}
