namespace Buscador.Domain.com.clarin.facets
{
    public interface IFacet
    {
        string Name { get; set; }
        string Value { get; set; }
        string Key { get; set; }
        int Branch { get; set; }
        int Level { get; set; }
        bool UseForSeo { get; set; }
        bool Visible { get; set; }
        int Priority { get; set; }
        void Accept(IFacetVisitor facetWithVisitor);
    }
}
