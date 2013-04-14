using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.dao.impl
{
    public class HibernateCurrencyDao : HibernateDao<Buscador.Domain.com.clarin.entities.Currency, int>, ICurrencyDao
    {
        public HibernateCurrencyDao()
        {
            
        }
    }
}
