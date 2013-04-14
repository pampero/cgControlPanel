using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using FluentNHibernate.Mapping;

namespace Buscador.Domain.mappings.com.clarin.entities
{
    public class IndexationAttrMapping : ClassMap<IndexationAttr>
    {
        public IndexationAttrMapping()
        {
            Table("INDEX_ATTR_TABLE");
            Id(x => x.Id, "ID").GeneratedBy.Identity();

            Map(x => x.IndexationEntityId, "INDEX_TABLE_ID");
            Map(x => x.AttrKey, "ATTR_ID");
            Map(x => x.AttrValue, "ATTR_VALUE");
            Map(x => x.AttrType, "ATTR_VALUE_TYPE");

            DiscriminateSubClassesOnColumn("ATTR_TYPE");


        }


    }

  
}
