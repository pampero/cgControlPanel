using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Buscador.Domain
{
    public static class JsonData
    {
        public class ResultType<T>
        {
            private static Func<int, IList<T>> _getListMethod;
            private static Func<int, T> _getObjectMethod;

            public static ResultType<T> GetListWith(Func<int, IList<T>> getMethod)
            {
                _getListMethod = getMethod;
                return new ResultType<T>();
            }

            public static ResultType<T> GetWith(Func<int, T> getMethod)
            {
                _getObjectMethod = getMethod;
                return new ResultType<T>();
            }

            public JsonResult WithParameter(string id)
            {
                if (_getListMethod != null)
                {
                    var filteredModels = _getListMethod(id.As<int>()) ?? new List<T>();
                    var result = new JsonResult
                    {
                        Data = filteredModels.ToList(),
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    return result;
                }
                else
                {
                    var filteredModels = _getObjectMethod(id.As<int>());
                    var result = new JsonResult
                    {
                        Data = filteredModels,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                    return result;
                }
            }
        }
    }
}
