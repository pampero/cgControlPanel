using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.facets;
using NUnit.Framework;
using NUnit.Mocks;

namespace Buscador.Domain.Test.facets
{
    [TestFixture]
    public class FacetHierarchyTest
    {
        [Test]
        public void FacetHierachy_Get_Facet_By_Name()
        {
            var facet = new SimpleFacet("facet1");
            var facets = new List<IFacet>
                             {
                                 facet
                             };

            var facetHierarchy = new FacetHierarchy {Facets = facets};

            Assert.IsTrue(facetHierarchy.ByName("facet1").Name==facet.Name);
        }

        [Test]
        public void FacetHierachy_Test_Get_Parent_Of_A_Facet()
        {
            var childFacet = new SimpleFacet("childFacet");
            var parentFacet = new HierarchicalFacet("parentFacet");
            parentFacet.Child = childFacet;

            var facets = new List<IFacet>
                             {
                                childFacet,
                                parentFacet
                             };

            var facetHierarchy = new FacetHierarchy { Facets = facets };

            Assert.IsTrue(facetHierarchy.ParentOf("childFacet").Name == "parentFacet");
        }

        [Test]
        public void FacetHierachy_Test_Get_Parent_Of_A_Facet_Null_Parent()
        {
            var childFacet = new SimpleFacet("childFacet");
            var childFacet1 = new SimpleFacet("childFacet1");
            var childFacet2 = new SimpleFacet("childFacet2");

            var facets = new List<IFacet>
                             {
                                childFacet,
                                childFacet1,
                                childFacet2
                             };

            var facetHierarchy = new FacetHierarchy { Facets = facets };

            Assert.IsTrue(facetHierarchy.ParentOf("childFacet") == null);
        }

        [Test]
        public void FacetHierachy_Test_Get_Parent_Of_A_Facet_That_Has_A_Parent()
        {
            var childFacet = new SimpleFacet("childFacet");
            var parentFacet1 = new HierarchicalFacet(("parentFacet1"));
            var parentFacet2 = new HierarchicalFacet("parentFacet2") { Child = parentFacet1 };

            parentFacet1.Child = childFacet;

            var facets = new List<IFacet>
                             {
                                childFacet,
                                parentFacet1,
                                parentFacet2
                             };

            var facetHierarchy = new FacetHierarchy { Facets = facets };

            Assert.IsTrue(facetHierarchy.ParentOf("childFacet").Name == "parentFacet1");
            Assert.IsTrue(facetHierarchy.ParentOf("parentFacet1").Name == "parentFacet2");
        }
    }
}
