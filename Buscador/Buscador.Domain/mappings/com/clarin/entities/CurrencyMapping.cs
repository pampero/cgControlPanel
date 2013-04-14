using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace Buscador.Domain.mappings.com.clarin.entities
{
    public class CurrencyMapping : ClassMap<Domain.com.clarin.entities.Currency>
    {
        public CurrencyMapping()
        {
            Table("CustomCurrency");
            Id(x => x.Id,"Id");
            Map(x => x.Symbol, "idSymbol");
            Map(x => x.Name);
        }
    }
}
