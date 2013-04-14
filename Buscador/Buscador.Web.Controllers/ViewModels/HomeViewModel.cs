using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;

namespace Buscador.Web.Controllers.ViewModels
{
    public class HomeViewModel  
    {
        public IList<RankingResult> RankingResults { get; set; }
    }
}
