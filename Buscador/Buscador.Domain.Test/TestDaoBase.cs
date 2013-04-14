//using Buscador.Domain.com.clarin.entities;
//using Buscador.Domain.mappings.com.clarin.entities;
using Buscador.Domain.com.clarin.entities;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NUnit.Framework;
using Spring.Data.Common;
using Spring.Testing.NUnit;

namespace Buscador.Domain.Test
{
    public class TestDaoBase : AbstractTransactionalSpringContextTests
    {
        public ISessionFactory SessionFactory { get; set; }
        protected SessionSource SessionSource { get; set; }
        protected ISession _session;
        
        [SetUp]
        public void SetupContext()
        {
            var dbProvider = (DbProvider)applicationContext.GetObject("dbProvider");

            var connectionString = dbProvider.ConnectionString;
            var cfg = MsSqlConfiguration.MsSql2005
                                        .ShowSql()
                                        .ConnectionString(connectionString);

            var fluentCfg = Fluently.Configure()
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Publication>().ExportTo(@"C:\temp"))
                .Database(cfg)
                .BuildConfiguration();
            fluentCfg.SetProperty("proxyfactory.factory_class", "NHibernate.ByteCode.Spring.ProxyFactoryFactory, NHibernate.ByteCode.Spring");

            _session = fluentCfg.BuildSessionFactory().OpenSession();
            _session.BeginTransaction();
        }

        [TearDown]
        public void TearDownContext()
        {
            _session.Close();
            _session.Dispose();
        }

        protected override string[] ConfigLocations
        {
            get
            {
                return new[]
                           {
                               "assembly://Buscador.Domain/Buscador.Domain/hibernate-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/dao-config.xml",
                               "assembly://Buscador.Domain/Buscador.Domain/facets-config.xml"
                           };
            }
        }
    }
}
