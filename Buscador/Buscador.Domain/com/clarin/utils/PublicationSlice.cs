using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.com.clarin.slices;

namespace Buscador.Domain.com.clarin.utils
{
    [DataContract]
    public class PublicationSlice
    {
        [DataMember(Name = "AppliedSlices")]
        public List<Slice> AppliedSlices { get; set; }
        [DataMember(Name = "AvaiableSlices")]
        public List<AvaiableSlice> AvaiableSlices { get; set; }
        

         public PublicationSlice()
         {
             
         }

         public PublicationSlice(List<Slice> appliedSlices, List<AvaiableSlice> avaiableSlices)
        {
            AppliedSlices = appliedSlices;
            AvaiableSlices = avaiableSlices;
        }


    }
}
