using Buscador.Domain.com.clarin.slices;
using Spring.Context;
using Spring.Context.Support;

namespace Buscador.Domain
{
    public static class LocalizationExtensionMethods
    {
        public static string Localize(this string text)
        {
            var xmlGlobalizator = (XmlBaseTextGloblalizator)ContextRegistry.GetContext().GetObject("textGlobalizator");

            string localizedValue = xmlGlobalizator.ForSite("clarin").Localize(text);

            return localizedValue ?? text;
        }

        public static string Localize(this Slice slice)
        {

                var xmlGlobalizator = (XmlBaseTextGloblalizator)ContextRegistry.GetContext().GetObject("textGlobalizator");
                var localizedValue= xmlGlobalizator.ForSite("clarin").Localize(slice.Name);

                if(localizedValue==null)
                {
                    localizedValue = xmlGlobalizator.ForSite("clarin").Localize(slice.SliceKey + "_" + slice.Name);    
                }
                

                return localizedValue ?? slice.Name;






        }
    }
}