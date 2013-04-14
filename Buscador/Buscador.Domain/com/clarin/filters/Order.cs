using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Buscador.Domain.com.clarin.filters
{

    public interface IOrder
    {
        string CurrentOrderValue { get; set; }
        string OrderKey { get; set; }
        IDictionary<string, string> AvailableOrderOptions { get; set; }
    }

    [DataContract]
    public class Order : IOrder
    {
        [DataMember]
        public string CurrentOrderValue { get; set; }
        [DataMember]
        public string OrderKey { get; set; }
        [DataMember]
        public IDictionary<string, string> AvailableOrderOptions { get; set; }

        public Order() { }

        public Order(string currentOrderValue, string orderKey, IDictionary<string, string> availableOrderOptions)
        {
            CurrentOrderValue = currentOrderValue;
            OrderKey = orderKey;
            AvailableOrderOptions = availableOrderOptions;
        }
    }
}
