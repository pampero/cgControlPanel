using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using Buscador.Domain.com.clarin.utils;

namespace Buscador.Services.com.clarin.services
{
    public interface IJsonSerializer
    {
        string Serialize<T>(T toSerialize, List<Type> knownTypes);
    }

    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T toSerialize, List<Type> knownTypes)
        {
            var serializer = new DataContractJsonSerializer(toSerialize.GetType(), knownTypes);
            var ms = new MemoryStream();
            serializer.WriteObject(ms, toSerialize);
            var json = Encoding.Default.GetString(ms.ToArray());

            var regex = new Regex(@"[""]__type[""] :[""]\s*\S*[,]");
            var jsonFixed = regex.Replace(json, string.Empty);
            return jsonFixed;
        }
    }
}
