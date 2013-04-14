using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    public class Currency
    {
        public virtual int Id { get; set; }

        //public virtual string Symbol { get; set; }

        public virtual string Name { get; set; }

        public virtual string Symbol { get; set; }
    }
}
