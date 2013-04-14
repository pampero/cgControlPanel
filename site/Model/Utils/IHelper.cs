using System;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using Model;

namespace Utils.ADO
{
    public interface IHelper
    {
        void KillProcess(SqlJobTrigger jobTrigger);
        string GetInputFormSchema(string commandText);
        void ExecuteAsyncNonQueryForTrigger(SqlJobTrigger trigger);
        string BuildRecursiveErrorMessage(Exception exception);
        string BuildSqlErrorMessage(SqlException exception);
        string BuildEntityValidationErrorMessage(DbEntityValidationException exception);
    }
}