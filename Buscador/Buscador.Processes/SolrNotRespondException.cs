using System;

namespace Buscador.Processes
{
    public class SolrNotRespondException : Exception
    {
        public SolrNotRespondException(string message) : base(message)
        {   
        }
    }
}