using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Exceptions
{
    public class QuartzException : Exception
    {
        public QuartzException()
        {
           
        }

        public QuartzException(string message) : base(message)
        {
            
        }

    }
}
