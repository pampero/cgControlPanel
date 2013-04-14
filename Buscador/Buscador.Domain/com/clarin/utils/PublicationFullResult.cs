using System.Collections.Generic;
using System.Runtime.Serialization;
using Buscador.Domain.com.clarin.entities;
using Buscador.Services.com.clarin.services;

namespace Buscador.Domain.com.clarin.utils
{
    [DataContract]
    public class PublicationFullResult
    {
        [DataMember(Name = "PublicationResults")]
        public List<PublicationResult> PublicationResult { get; set; }
        [DataMember(Name = "Results")]
        public IResults<Publication> Results { get; set; }
       
    }
}