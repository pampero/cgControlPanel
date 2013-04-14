using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Buscador.Domain;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Services.com.clarin.services
{
    public interface IEntityLoader<T>
    {
        T LoadEntity(T entity, ISliceCacheProvider cacheProvider, IDictionary<Expression<Func<T, int>>, Expression<Func<T, string>>> propertiesToLoad, Action<T> postLoadAction);
    }

    public class PostSolrEntityLoader<T> : IEntityLoader<T>
    {
        public T LoadEntity(T entity, ISliceCacheProvider cacheProvider, IDictionary<Expression<Func<T, int>>, Expression<Func<T, string>>> propertiesToLoad, Action<T> postLoadAction)
        {
            foreach (var propertyInfo in propertiesToLoad)
            {
                var customSolrAttribute = propertyInfo.Key.ToPropertyInfo().GetCustomAttributes(false)[0];
                var facet = ((SolrNet.Attributes.SolrFieldAttribute)(customSolrAttribute)).FieldName;
                propertyInfo.Value.ToPropertyInfo().SetValue(entity, cacheProvider.GetName(facet, propertyInfo.Key.ToPropertyInfo().GetValue(entity, null).ToString()), null);
            }

            postLoadAction(entity);

            return entity;
        }
    }
}
