using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Buscador.Domain.com.clarin.dao
{
    public interface IBaseDao<T, TId> 
    {
        T GetById(TId id);
        void RemoveByPrimaryKey(TId key);
        void Remove(T key);
        void RemoveAll(List<T> entities);
        List<T> GetAll();
        List<T> Find(KeyValuePair<string, string> restrictions);
        List<T> Find(KeyValuePair<string, string> restrictions, KeyValuePair<string, string> orderBy,int inicio, int maxResults);
        T Save(T entity);
    }

}
