using System.Collections;

namespace Buscador.Domain.com.clarin.slices
{
    public interface IUrlOfuscator
    {
        string Ofuscate(string url);
        System.Collections.Specialized.HybridDictionary OfuscatedCharacters { get; set; }
    }

    public class UrlOfuscator : IUrlOfuscator
    {
        public System.Collections.Specialized.HybridDictionary OfuscatedCharacters { get; set; }

        public string Ofuscate(string url)
        {
            var ofuscatedUrl = url;

            foreach (var character in OfuscatedCharacters)
            {
                ofuscatedUrl = ofuscatedUrl.Replace(((DictionaryEntry)character).Key.ToString(),
                                                   ((DictionaryEntry)character).Value.ToString());
            }
            return ofuscatedUrl;
        }
    }
}