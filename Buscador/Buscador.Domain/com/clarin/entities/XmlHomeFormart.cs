using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buscador.Domain.com.clarin.entities
{
    public class News
    {
        public virtual string Title { get; set; }
        public virtual string Picture { get; set; }
        public virtual string Link { get; set; }
        public virtual string Description { get; set; }
    }
}
