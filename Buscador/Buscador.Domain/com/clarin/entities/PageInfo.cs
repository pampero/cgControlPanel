using System;
using Buscador.Domain.com.clarin.filters;

namespace Buscador.Services.com.clarin
{
    [Serializable]
    public class PageInfo
    {
        public PageInfo(int number, string url, bool hasSelectedFilters, IUrlOfuscator urlOfuscator)
        {
            Number = number;
            if (!hasSelectedFilters)
                Url = url + "PG" + urlOfuscator.OfuscatedCharacters["="] + number;
            else
                Url = url + urlOfuscator.OfuscatedCharacters["&"] + "PG" + urlOfuscator.OfuscatedCharacters["="] + number;
        }

        public int Number { get; set; }

        public string Url { get; set; }
    }
}