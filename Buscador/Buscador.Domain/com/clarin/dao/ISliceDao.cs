using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data.NHibernate.Generic;

namespace Buscador.Domain.com.clarin.dao
{
    public interface ISliceDao
    {
        HibernateTemplate HibernateTemplate { get; set; }
        object Get(string facet, string slice);
    }

    public class SliceDao : ISliceDao       
    {
        public HibernateTemplate HibernateTemplate { get; set; }
        public FacetTableName FacetTableName { get; set; }

        public object Get(string facet, string slice)
        {
            try
            {
                var tableNameXIdColumn = (TableNameXIdColumn)FacetTableName.FacetTableNameMap[facet];

                if (tableNameXIdColumn == null) return slice;

                var sql = string.Format("SELECT {0} FROM {1} WHERE {2} =" + slice,
                                        tableNameXIdColumn.ValueColumnName,
                                        tableNameXIdColumn.TableName,
                                        tableNameXIdColumn.IdColumnName
                                        );

                var result = HibernateTemplate.ExecuteFind(x => new List<object> { x.CreateSQLQuery(sql).UniqueResult() });

                return result[0] == null ? slice : result[0].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex + ". " + slice + ". " + facet);
            }
            
        }
    }

    public class FacetTableName
    {
        public System.Collections.Specialized.HybridDictionary FacetTableNameMap { get; set; }
    }

    public class TableNameXIdColumn
    {
        public string TableName { get; set; }
        public string IdColumnName { get; set; }
        public string ValueColumnName { get; set; }
    }
}

