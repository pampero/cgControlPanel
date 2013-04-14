using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.exceptions
{
    public class SelectedFilterException : Exception
    {
        public SelectedFilterException(string message) : base(message)
        {
            
        }

    }
}
