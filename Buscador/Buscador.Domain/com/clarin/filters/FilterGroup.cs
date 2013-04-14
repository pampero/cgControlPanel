using System;
using System.Collections.Generic;
using Buscador.Domain.com.clarin.slices;

namespace Buscador.Domain.com.clarin.filters
{
    [Serializable]
    public class FilterGroup
    {
        private List<ISlice> _filtersToShow;

        public string Name { get; set; }

        public FilterGroup(string name)
        {
            Name = name;
        }

        public List<ISlice> FiltersToShow
        {
            get
            {
                if (_filtersToShow == null) 
                    _filtersToShow=new List<ISlice>();
                return _filtersToShow;
            }
            set {
                _filtersToShow = value;
            }
        }
    }
}