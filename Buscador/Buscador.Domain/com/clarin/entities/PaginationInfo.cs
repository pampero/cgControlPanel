using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Buscador.Domain.com.clarin.entities
{
    [DataContract]
    public class PaginationInfo
    {
        private List<PageInfo> _pages;
        private int _totalPages;

        public PaginationInfo(int totalResults, int pageSize)
        {
            TotalResults = totalResults;
            PageSize = pageSize;
            _pages = new List<PageInfo>();
        }

        public int TotalResults { get; set; }

        public int ActualPage { get; set; }

        public int PageSize { get; set; }



        public int TotalPages
        {
            get { return TotalResults/PageSize; }
            set { _totalPages = value; }
        }

        public void AddPage(PageInfo pageInfo)
        {
            Pages.Add(pageInfo);
        }

        public List<PageInfo> Pages
        {
            get {
                return _pages;
            }
            set {
                _pages = value;
            }
        }
    }
}