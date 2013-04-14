using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;

namespace Utils.ADO
{
    public static class Helper
    {
        public static DbDataReader ExecuteReader(string connectionString, string commandText)
        {
            DbCommand command = new SqlCommand();

            command.Connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = commandText;
            
            return command.ExecuteReader();
        }
    }
}
