using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.dao;
using Buscador.Domain.com.clarin.filters;
using NUnit.Framework;
using NUnit.Mocks;

namespace Buscador.Domain.Test.filters
{
    [TestFixture]
    public class FiltersTest
    {
        [Test]
        public void Slice_In_Cache_No_Roundtrip_To_Database()
        {
            var sliceCacheProvider = new SliceCacheProvider
                                         {
                                             Cache = new Spring.Caching.NonExpiringCache()
                                         };

            sliceCacheProvider.Cache.Insert("facetslice","value");
            var name = sliceCacheProvider.GetName("facet", "slice");
            Assert.NotNull(name);
        }

        [Test]
        [ExpectedException]
        public void Empty_Cache_Provider_Use_Null_SliceDao_Throw_Exception()
        {
            var sliceCacheProvider = new SliceCacheProvider
            {
                Cache = new Spring.Caching.NonExpiringCache()
            };

            sliceCacheProvider.GetName("facet", "slice");
        }

        [Test]
        public void CacheProvider_Goto_Database_Once()
        {
            var sliceDaoMock = new DynamicMock(typeof (ISliceDao));
            sliceDaoMock.SetReturnValue("Get","name");

            var sliceCacheProvider = new SliceCacheProvider
            {
                Cache = new Spring.Caching.NonExpiringCache(),
                SliceDao = (ISliceDao)sliceDaoMock.MockInstance
            };
            
            var name = sliceCacheProvider.GetName("facet", "slice");
            Assert.IsTrue(name=="name");
            Assert.IsTrue(sliceCacheProvider.Cache.Count==1);
        }
    }
}
