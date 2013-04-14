using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Buscador.Domain.com.clarin.slices
{
    [DataContract]
    public class SliceSet
    {
        private List<ISlice> _slices;

        [DataMember]
        public string Name { get; set; }

        public SliceSet(string name, string facetKey)
        {
            Name = name;
            FacetKey = facetKey;
        }

        public string FacetKey { get; set; }

        [DataMember]
        public List<ISlice> Slices
        {
            get
            {
                if (_slices == null)
                    _slices = new List<ISlice>();
                return _slices;
            }
            set {
                _slices = value;
            }
        }
    }
}