using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;

namespace Buscador.Domain.com.clarin.utils
{

    public class PaginData
    {
        [DataMember(Name = "CurrentPage")]
        public int CurrentPage { get; set; }
        [DataMember(Name = "ResultsPerPage")]
        public int ResultsPerPage { get; set; }
        [DataMember(Name = "TotalPages")]
        public int TotalPages { get; set; }

        public PaginData()
         {
             
         }


        public PaginData(int currentPage, int resultsPerPage, int totalPages)
        {
            CurrentPage = currentPage;
            ResultsPerPage = resultsPerPage;
            TotalPages = totalPages;
          
        }

    }


    [DataContract]
    public class PublicationSearch
    {
        [DataMember(Name = "TotalResults")]
        public int TotalResults { get; set; }
        [DataMember(Name = "Results")]
        public List<PublicationResult> Results { get; set; }
        [DataMember(Name = "Slices")]
        public PublicationSlice Slices { get; set; }
        [DataMember(Name = "Order")]
        public Order Order { get; set; }
        [DataMember(Name = "PaginData")]
        public PaginData PaginData { get; set; }


         public PublicationSearch()
         {
             
         }

         public PublicationSearch(int totalResults, List<PublicationResult> results,
            PublicationSlice slices, Order order, PaginData paginData)
        {
            TotalResults = totalResults;
            Results = results;
            Slices = slices;
            Order = order;
            PaginData = paginData;
        }

    }
}
