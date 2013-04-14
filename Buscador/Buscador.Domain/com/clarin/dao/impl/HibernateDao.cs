using System;
using System.Collections.Generic;
using Spring.Data.NHibernate.Generic.Support;

namespace Buscador.Domain.com.clarin.dao.impl
{
    public class HibernateDao<T, TId> : HibernateDaoSupport, IBaseDao<T, TId> 
    {
        public T GetById(TId id)
        {
            var entity = HibernateTemplate.Get<T>(id);
            return entity;
        }

        public void RemoveByPrimaryKey(TId key)
        {
            HibernateTemplate.Delete(GetById(key));
        }

        public void Remove(T entity)
        {
            HibernateTemplate.Delete(entity);
        }

        public void RemoveAll(List<T> entities)
        {
            HibernateTemplate.ClassicHibernateTemplate.DeleteAll(entities);
        }

        public List<T> GetAll()
        {
           var lista = (List<T>) HibernateTemplate.LoadAll<T>();
           return lista;
        }

        public List<T> Find(KeyValuePair<string, string> restrictions)
        {
            throw new NotImplementedException();
        }

        public List<T> Find(KeyValuePair<string, string> restrictions, KeyValuePair<string, string> orderBy, int inicio, int maxResults)
        {
            throw new NotImplementedException();
        }

        public T Save(T entity)
        {
            var savedEntity = HibernateTemplate.Save(entity);
            return (T) savedEntity;
        }
    }
}
