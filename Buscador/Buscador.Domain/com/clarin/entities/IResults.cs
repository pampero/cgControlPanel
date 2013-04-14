using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Buscador.Domain;
using Buscador.Domain.com.clarin.filters;
using Buscador.Domain.com.clarin.slices;

namespace Buscador.Services.com.clarin.services
{
    
    public interface IResults<T>
    {
        List<T> ResultList { get; }
        List<FilterGroup> FilterGroups { get; }
        List<Slice> AppliedFilters { get; }
        List<Slice> VisibleAppliedFilters { get; }
        [DataMember(Name = "TotalPages")]
        int TotalPages { get; }
        List<PageInfo> Pages { get; }
        void AddResult(T result);
        void AddFilterGroup(FilterGroup filterGroup);
        void AddAppliedFilter(Slice filter);
        void AddPage(PageInfo pageInfo);
        void SetActualPage(int actualPage);
        int ActualPage { get; }
        int PageSize { get; }
        List<Slice> Breadcrumbs { get; }
        [DataMember(Name = "TotalResults")]
        int TotalResults { get; set; }
        Order Order { get; }
        List<SliceSet> AvaiableSlices { get; }
        void SetOrder(string order, string orderKey, IDictionary<string, string> availableOrderOptions);
    }

    [DataContract]
    public class Results<T> : IResults<T>
    {
        private List<T> _resultList;
        private List<FilterGroup> _filterGroups;
        [DataMember(Name = "AppliedSlices")]
        private List<Slice> _appliedFilters;
        [DataMember(Name = "AvaiableSlices")]
        private List<SliceSet> _avaiableSlices;
        private PaginationInfo _paginationInfo;
        private List<Slice> _breadcrumbs;
        [DataMember(Name = "Order")]
        private Order _order;
       

        public Results(int numFound, int pageSize)
        {
            _paginationInfo = new PaginationInfo(numFound,pageSize);
        }

        public List<T> ResultList
        {
            get { return _resultList ?? (_resultList = new List<T>()); }
        }

        public List<FilterGroup> FilterGroups
        {
            get { return _filterGroups ?? (_filterGroups = new List<FilterGroup>()); }
        }

        public List<Slice> AppliedFilters
        {
            get { return _appliedFilters ?? (_appliedFilters = new List<Slice>()); }
        }

        public int PageSize
        {
            get { return _paginationInfo.PageSize; }
        }

        public Order Order
        {
            get { return _order ?? (_order = new Order()); }
        }

        public List<SliceSet> AvaiableSlices
        {
            get { return _avaiableSlices ?? (_avaiableSlices = new List<SliceSet>()); }
        }

        public List<Slice> Breadcrumbs
        {
            get
            {
                return _breadcrumbs ?? (_breadcrumbs = new List<Slice>());
            }
        }

        public int TotalResults { get; set; }
       // public string Order { get; set; }

        public int TotalPages
        {
            get { return _paginationInfo.TotalPages; }
        }

        public List<PageInfo> Pages
        {
            get { return _paginationInfo.Pages; }
        }

        public void AddResult(T result)
        {
            ResultList.Add(result);
        }

        public void AddFilterGroup(FilterGroup filterGroup)
        {
            FilterGroups.Add(filterGroup);
        }

        public void AddAppliedFilter(Slice filter)
        {
            AppliedFilters.Add(filter);
        }

        public void AddPage(PageInfo pageInfo)
        {
            _paginationInfo.AddPage(pageInfo);       
        }

        public void SetActualPage(int actualPage)
        {
            _paginationInfo.ActualPage = actualPage;
        }

        public void SetOrder(string order, string orderKey, IDictionary<string, string> availableOrderOptions)
        {
            Order.CurrentOrderValue = order;
            Order.OrderKey = orderKey;
            Order.AvailableOrderOptions = availableOrderOptions;

        }

        public int ActualPage
        {
            get { return _paginationInfo.ActualPage; }
        }

        public List<Slice> VisibleAppliedFilters
        {
            get { return AppliedFilters.Where(x => x.Visible).ToList(); }
        }
    }

    [Serializable]
    public class PaginationInfo
    {
        private List<PageInfo> _pages;

        public PaginationInfo(int numFound, int pageSize)
        {
            Total = numFound;
            PageSize = pageSize;
            _pages = new List<PageInfo>();
        }

        public int Total { get; set; }

        public int ActualPage { get; set; }

        public int PageSize { get; set; }

        public int TotalPages
        {
            get { return Total/PageSize; }
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
