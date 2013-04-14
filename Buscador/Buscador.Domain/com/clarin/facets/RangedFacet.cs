using System;
using System.Collections.Generic;

namespace Buscador.Domain.com.clarin.facets
{
    public class RangedFacet : RangedFacet<int>, IFacet
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public string Key { get; set; }

        //public List<Range<int>> Ranges { get; set; }

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

    public class InputRangedFacet : IFacet
    {
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

    public class RangedFacet<T>
    {
        public List<Range<T>> Ranges { get; set; }
    }

    public class Range<T>
    {
        public T From { get; set; }
        public T To { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", From, To);
        }
    }
}
