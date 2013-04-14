
using System.Reflection;
using FluentNHibernate;
using NHibernate.Cfg;
using Spring.Data.NHibernate;

namespace Buscador.Domain.com.clarin.utils
{
    public class FluentNhibernateLocalSessionFactoryObject : LocalSessionFactoryObject
    {
        /// <summary>
        /// Sets the assemblies to load that contain fluent nhibernate mappings.
        /// </summary>
        /// <value>The mapping assemblies.</value>
        public string[] FluentNhibernateMappingAssemblies
        {
            get;
            set;
        }

        protected override void PostProcessConfiguration(Configuration config)
        {
            base.PostProcessConfiguration(config);
            if (FluentNhibernateMappingAssemblies != null)
            {
                foreach (string assemblyName in FluentNhibernateMappingAssemblies)
                {
                    config.AddMappingsFromAssembly(Assembly.Load(assemblyName));
                }
            }
        }
    }
}
