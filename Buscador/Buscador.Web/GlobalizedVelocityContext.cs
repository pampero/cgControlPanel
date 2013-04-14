using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Services.com.clarin.services;
using NVelocity;

namespace Buscador.Web
{
    public class GlobalizedVelocityContext : VelocityContext
    {
        public static ITextGlobalizator TextGlobalizator { get; set; }

        public string CurrentSite { get; set; }

        public GlobalizedVelocityContext()
        {
            
        }

        public override object InternalGet(string key)
        {
            var objeto = base.InternalGet(key);

            var result = objeto as IResults<Publication>;

            if(result==null)
                return objeto;
            
            foreach (var filterGroup in result.FilterGroups)
            {
                filterGroup.Name = TextGlobalizator.ForSite(CurrentSite)
                                                   .Localize(filterGroup.Name);
            }

            foreach (var filterGroup in result.VisibleAppliedFilters)
            {
                filterGroup.Name = TextGlobalizator.ForSite(CurrentSite)
                                                   .Localize(filterGroup.Name);
            }
            return result;
        }
    }
}