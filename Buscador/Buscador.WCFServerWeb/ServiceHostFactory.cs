using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Util;


namespace Buscador.WCFServerWeb
{
    public class ServiceHostFactory : System.ServiceModel.Activation.ServiceHostFactory
    {
        /// <summary>
        /// Creates a <see cref="Spring.ServiceModel.SpringServiceHost"/> for
        /// a specified Spring-managed object with a specific base address.
        /// </summary>
        /// <param name="reference">
        /// A reference to a Spring-managed object or to a service type.
        /// </param>
        /// <param name="baseAddresses">
        /// The <see cref="System.Array"/> of type <see cref="System.Uri"/> that contains
        /// the base addresses for the service hosted.
        /// </param>
        /// <returns>
        /// A <see cref="Spring.ServiceModel.SpringServiceHost"/> for the Spring-managed object.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// If the Service attribute in the ServiceHost directive was not provided.
        /// </exception>
        public override ServiceHostBase CreateServiceHost(string reference, Uri[] baseAddresses)
        {
            if (StringUtils.IsNullOrEmpty(reference))
            {
                return base.CreateServiceHost(reference, baseAddresses);
            }

            IApplicationContext applicationContext = ContextRegistry.GetContext();
            if (applicationContext.ContainsObject(reference))
            {
                return new SpringServiceHost(reference, applicationContext, baseAddresses);
            }

            return base.CreateServiceHost(reference, baseAddresses);
        }
    }
}
