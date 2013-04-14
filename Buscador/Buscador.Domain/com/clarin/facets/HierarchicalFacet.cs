using System;

namespace Buscador.Domain.com.clarin.facets
{
    public class HierarchicalFacet : IFacet
    {
        public HierarchicalFacet(string name)
        {
            Name = name;
        }

        public HierarchicalFacet()
        {

        }

        public IFacet Child { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Key { get; set; }

        public int Branch { get; set; }

        public int Level { get; set; }

        public bool UseForSeo { get; set; }

        public bool Visible { get; set; }

        public int Priority { get; set; }

        public void Accept(IFacetVisitor facetWithVisitor)
        {
            facetWithVisitor.Visit(this);
        }
    }
}
