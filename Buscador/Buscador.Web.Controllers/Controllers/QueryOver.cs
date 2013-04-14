using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Web.Controllers.Controllers
{
    public class QueryOver<T>
    {
        private Expression<Func<T, object>> _query;
        private List<KeyValuePair<Expression<Func<T, object>>, string>> _listExpression;

        private QueryOver(Expression<Func<T, object>> query)
        {
            _listExpression = new List<KeyValuePair<Expression<Func<T, object>>, string>>();
            _query = query;
        }

        public static QueryOver<T> Property(Expression<Func<T, object>> query)
        {
            return new QueryOver<T>(query);
        }

        public QueryOver<T> WithValue(string value)
        {
            _listExpression.Add(new KeyValuePair<Expression<Func<T, object>>, string>(_query, value));
            return this;
        }

        public List<KeyValuePair<Expression<Func<T, object>>, string>> Build()
        {
            return _listExpression;
        }

        public QueryOver<T> AndProperty(Expression<Func<T, object>> query)
        {
            _query = query;
            return this;
        }
    }
}