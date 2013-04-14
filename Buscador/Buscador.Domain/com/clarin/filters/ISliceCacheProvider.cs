using System;
using Buscador.Domain.com.clarin.dao;


namespace Buscador.Domain.com.clarin.filters
{
    public interface ISliceCacheProvider
    {
        string GetName(string facet, string slice);
    }

    public class SliceCacheProvider : ISliceCacheProvider
    {
        public Spring.Caching.ICache Cache { get; set; }

        public ISliceDao SliceDao { get; set;}

        public string GetName(string facet, string slice)
        {
            var cacheObject = Cache.Get(facet + slice);

            if (cacheObject == null)
            {
                var value = SliceDao.Get(facet, slice);
                Cache.Insert(facet + slice, value);
                return value.ToString();
            }

            return cacheObject.ToString();
        }
    }
}