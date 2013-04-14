using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Services.com.clarin.services
{
    public interface INewsService
    {
        IList<News> GetLastestFrom(string xmlstrUrl);

    }
}
