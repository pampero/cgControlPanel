

using Buscador.Contracts;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.facets;
using Buscador.Domain.com.clarin.filters;
using Buscador.Services.com.clarin.services;

namespace Buscador.SearchService
{

   //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class RestServiceImpl : IRestServiceImpl
    {

        #region Properties

        public IIndexService<Publication> IndexService { get; set; }
        

        public FacetConfiguration FacetConfiguration { get; set; }

        public IUrlOfuscator UrlOfuscator { get; set; }

      public IJsonSerializer JsonSerializer { get; set; }
        

        #endregion


        #region Methods

        public string JSONData(string id)
        {
            return "You request product " + id;
        }

        #endregion
    }
}
