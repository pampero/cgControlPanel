using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    public class RankingResult
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Url { get; set; }

        public RankingResult(string make, string model, string url)
        {
            Make = make;
            Model = model;
            Url = url;
        }
    }
}
