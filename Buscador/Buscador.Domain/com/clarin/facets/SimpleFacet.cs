using System;

namespace Buscador.Domain.com.clarin.facets
{
    public class SimpleFacet : IFacet
    {
        public SimpleFacet()
        {
            
        }
        public SimpleFacet(string name)
        {
            Name = name;
        }

        public SimpleFacet(string nombreFacet, string value)
        {
            Name = nombreFacet;
            Value = value;
        }

        public string Name { get; set; }

        public string Key { get; set; }

        public int Branch { get; set; }

        public int Level { get; set; }

        public bool UseForSeo { get; set; }

        public bool Visible { get; set; }

        public int Priority { get; set; }

        public string Value { get; set; }
        public void Accept(IFacetVisitor facetWithVisitor)
        {
            facetWithVisitor.Visit(this);
        }
    }
}