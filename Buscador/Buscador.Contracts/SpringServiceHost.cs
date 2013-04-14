using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Util;


namespace Buscador.Contracts
{
   
        public class SpringServiceHost : System.ServiceModel.ServiceHost
        {
            #region Constructor(s) / Destructor

            
            public SpringServiceHost(string serviceName, params Uri[] baseAddresses)
                : this(serviceName, GetApplicationContext(null), baseAddresses)
            {
            }

            
            public SpringServiceHost(string serviceName, string contextName, params Uri[] baseAddresses)
                : this(serviceName, GetApplicationContext(contextName), baseAddresses)
            {
            }

            
            public SpringServiceHost(string serviceName, IObjectFactory objectFactory, params Uri[] baseAddresses)
                : this(serviceName, objectFactory, true, baseAddresses)
            {
            }

           
            public SpringServiceHost(string serviceName, IObjectFactory objectFactory, bool useServiceProxyTypeCache, params Uri[] baseAddresses)
                : base(CreateServiceType(serviceName, objectFactory, useServiceProxyTypeCache), baseAddresses)
            {
            }

            private static IApplicationContext GetApplicationContext(string contextName)
            {
                if (StringUtils.IsNullOrEmpty(contextName))
                {
                    return ContextRegistry.GetContext();
                }
                else
                {
                    return ContextRegistry.GetContext(contextName);
                }
            }

            private static Type CreateServiceType(string serviceName, IObjectFactory objectFactory, bool useServiceProxyTypeCache)
            {
                if (StringUtils.IsNullOrEmpty(serviceName))
                {
                    throw new ArgumentException("The service name cannot be null or an empty string.", "serviceName");
                }

                if (objectFactory.IsTypeMatch(serviceName, typeof(Type)))
                {
                    return objectFactory.GetObject(serviceName) as Type;
                }

                return new ServiceProxyTypeBuilder(serviceName, objectFactory.GetType(serviceName), useServiceProxyTypeCache)
                    .BuildProxyType(objectFactory);
            }

            #endregion
        
    }
}
