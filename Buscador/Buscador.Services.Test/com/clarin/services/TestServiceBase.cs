using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Spring.Testing.NUnit;

namespace Buscador.Services.Test.com.clarin.services
{
    public class TestServiceBase : AbstractDependencyInjectionSpringContextTests
    {
        [SetUp]
        public void SetupContext()
        {
           
        }
       
        [TearDown]
        public void TearDownContext()
        {
         
        }

        protected override string[] ConfigLocations
        {
            get
            {
                return new[]
                    {
                        "assembly://Buscador.Domain/Buscador.Domain/hibernate-config.xml",
                        "assembly://Buscador.Domain/Buscador.Domain/dao-config.xml"
                    };
            }
        }
    }


    
}
