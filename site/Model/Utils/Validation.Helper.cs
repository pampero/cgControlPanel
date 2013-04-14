using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Xml;
using Model;

namespace Utils.Validation
{
    public static class Helper
    {
        public static string BuildValidationErrors(List<string> validationErrors)
        {
            string legend = String.Empty;

            foreach (var validationError in validationErrors)
            {
                legend += validationError;    
            }
                
            if (!String.IsNullOrEmpty(legend))
            {
                throw new Exception(legend);
            }

            return legend;
        }

        public static string BuildRecursiveErrorMessage(Exception exception)
        {
            string message = string.Empty;

            if (exception.InnerException != null)
            {
                message = exception.Message + "\r\n" + BuildRecursiveErrorMessage(exception.InnerException);
            }
            else
            {
                message = exception.Message;
            }

            return message;
        }
    }
}
