using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Services.com.clarin.services
{
    public interface IIndexService<T>
    {
        IResults<T> Query(ISearchParameters<T> searchParameters);
        //IList<T> Query(List<KeyValuePair<Expression<Func<T,string>>,string>> query);
        IList<T> Query(IList<KeyValuePair<Expression<Func<T, object>>, string>> query);
        IList<T> Query(IList<KeyValuePair<Expression<Func<T, object>>, string>> query, int maxResult);

        IResults<T> QueryAll(int page, OrderInfo order);
        List<SelectedFilter> SelectedFiltersFor(T publication);
        IResults<T> QueryResults(ISearchParameters<Publication> searchParameters);
        IList<T> Query(List<KeyValuePair<Expression<Func<Publication, object>>, string>> query, int maxsize, OrderInfo orderInfo);
    }
}
