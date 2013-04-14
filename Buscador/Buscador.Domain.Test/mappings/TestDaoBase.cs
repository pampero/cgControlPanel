using Buscador.Domain.com.clarin.entities;
using Buscador.Domain.mappings.com.clarin.entities;
using FluentNHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Spring.Data.NHibernate;
using Spring.Testing.NUnit;

namespace Buscador.Domain.Test.mappings
{
    public class TestDaoBase : AbstractDependencyInjectionSpringContextTests
    {
        public ISessionFactory SessionFactory { get; set; }
        protected SessionSource SessionSource { get; set; }
        protected ISession _session;

        [SetUp]
        public void SetupContext()
        {
            var connectionString = @"Data Source=AGSMS-TDDB01\DESA;Initial Catalog=vehiclesClassifieds;Persist Security Info=True;User ID=uservehicles;Password=YUE7HJAI";//applicationContext.GetObject("").ToString();
            var cfg = MsSqlConfiguration.MsSql2005
                .ConnectionString(connectionString);

            var fluentCfg = Fluently.Configure()
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Publication>())
                .Database(cfg)
                .BuildConfiguration();
            fluentCfg.SetProperty("proxyfactory.factory_class", "NHibernate.ByteCode.Spring.ProxyFactoryFactory, NHibernate.ByteCode.Spring");

            _session = fluentCfg.BuildSessionFactory().OpenSession();
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
                               "assembly://Buscador.Domain/Buscador.Domain/dao-config.xml"
                           };
            }
        }
    }

    public class TestModel : PersistenceModel
    {
        public TestModel()
        {
            AddMappingsFromAssembly(typeof(PublicationMapping).Assembly);
            //Configure();
        }
    }
}
