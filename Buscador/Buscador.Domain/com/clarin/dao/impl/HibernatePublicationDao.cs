
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Domain.com.clarin.dao.impl
{
    public class HibernatePublicationDao : HibernateDao<Publication,int> , IPublicationDao
    {
        public HibernatePublicationDao()
        {
            
        }
    }
}
