using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Domain.com.clarin.slices
{
    public interface ISlice
    {
        string Name { get; set; }
        string Value { get; set; }
        string Url { get; set; }
        string SliceKey { get; set; }
        void Accept(IFilterVisitor renderFilterVisitor);
    }

    [DataContract]
    public class AvaiableSlice : ISlice
    {
        public AvaiableSlice(string name, string sliceKey, string resultsFound, string url, string sliceValue, string _type_)
        {
            _type = _type_;
            Name = name;
            SliceKey = sliceKey;
            ResultsFound = resultsFound;
            Url = url;
            SliceValue = sliceValue;
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ResultsFound { get; set; }
        public string Url { get; set; }
        [DataMember]
        public string SliceKey { get; set; }
        [DataMember]
        public string SliceValue { get; set; }
        [DataMember]
        public string _type  { get; set; }


        public void Accept(IFilterVisitor renderFilterVisitor)
        {
            throw new NotImplementedException();
        }

        public string Value { get; set; }
    }

    [DataContract]
    public class Slice : ISlice
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public string SliceKey { get; set; }

        public string Url { get; set; }

        public int Priority { get; set; }

        public bool Visible { get; set; }
      
        public Slice() { }

        public Slice(string name,string sliceKey, string value, string url)
        {
            Name = name;
            Value = value;
            Url = url;
            SliceKey = sliceKey;
        }

       
        public void Accept(IFilterVisitor renderFilterVisitor)
        {
            renderFilterVisitor.Visit(this);
        }
    }

    [DataContract]
    public class DynamicRangeSlice : ISlice
    {
        [DataMember]
        public string Name { get; set; }
        [Required]
        [RegularExpression("*-*")]
        public string Value { get; set; }
        
        public string SliceKey { get; set; }
        
        public string Url { get; set; }

        public string CodifiedName { get; set; }

        public void Accept(IFilterVisitor renderFilterVisitor)
        {
            renderFilterVisitor.Visit(this);    
        }
    }
}