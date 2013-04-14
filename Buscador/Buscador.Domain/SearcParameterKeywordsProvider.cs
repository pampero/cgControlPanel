using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Domain
{
    public class SearcParameterKeywordsProvider : IKeywordsProvider
    {
        private List<SelectedFilter> _selectedFilters;
        private IDictionary<string, string> _fieldsName;


        public SearcParameterKeywordsProvider()
        {
           
            _selectedFilters = new List<SelectedFilter>();
            _fieldsName = new Dictionary<string,string>();
        }

        public SearcParameterKeywordsProvider(List<SelectedFilter> selectedFilters, IDictionary<string, string> fieldsName)
        {
            if (fieldsName == null)
                throw new ArgumentNullException("The fieldnames cannot be null");

            _selectedFilters = selectedFilters;
            _fieldsName = fieldsName;
        }

        public string GetParametersString(string parameters, string section)
        {
            var parametros = parameters.Split('&');
            var parametrosConvertidos = new List<string>();

            foreach (var parametro in parametros)
            {
                var key = parametro.Split('=')[0];
                var value = string.Empty;

                if ((parametro.Split('=')[1] == "Request(\"2\")") || (parametro.Split('=')[1] == "Request(\"1\")"))
                    value = parametro.Split('=')[1].Replace("\"", string.Empty).Replace("Request", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
                else
                {
                    value = parametro.Split('=')[1].Substring(parametro.Split('=')[1].IndexOf('"') + 1,
                                                              parametro.Split('=')[1].IndexOf('"', parametro.Split('=')[1].IndexOf('"')));
                }

                if (parametro.Split('=')[0] == "kw_nuevousado")
                {
                    if ((_selectedFilters != null) && _selectedFilters.Exists(x => x.Name == "vehicle_type_id"))
                        parametrosConvertidos.Add(string.Format("{0}={1}", key, value));
                }

                else
                    parametrosConvertidos.Add(string.Format("{0}={1}", 
                                                            key,
                                                            _fieldsName.ContainsKey(value) ?
                                                            (_selectedFilters != null && _selectedFilters.Where(x => x.Name == _fieldsName[value]).Count() > 0 ?
                                                            _selectedFilters.Where(x => x.Name == _fieldsName[value]).First().Value : "0")
                                                            : "0"));
            }

            var parametrosJoineados = string.Empty;

            if (string.IsNullOrEmpty(section))
            {
                parametrosConvertidos.RemoveAll(x => x.IndexOf("kw_nuevousado") > 0);
                parametrosJoineados = string.Join("&", parametrosConvertidos.ToArray());
            }
            else
            {
                parametrosJoineados = string.Join("&", parametrosConvertidos.ToArray());
            }
            return parametrosJoineados;
        }
    }
}