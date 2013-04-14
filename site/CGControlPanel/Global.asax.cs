using System;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Web;
using Utils.ADO;
using log4net;
using Model;
using Quartz;
using Quartz.Impl;
using Services.Scheduling.impl;
using log4net.Config;
using CG.Services.interfaces;
using Services.Security.Interface;
using Services.Security.impl;
using CG.Cryptography.Interface;
using Services.Cryptography.impl;

namespace CGControlPanel
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;
     
        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        void Application_Start(object sender, EventArgs e)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath(@"\_config\log4net.xml")));

            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();
            builder.Register(c => new StdSchedulerFactory().GetScheduler()).As<IScheduler>().SingleInstance();
            builder.RegisterType<UnitOfWork>().PropertiesAutowired();
            builder.RegisterType<Helper>().As<IHelper>().PropertiesAutowired();
            //  builder.RegisterType<FakeJobSchedulerService>().As<IJobSchedulerService>().PropertiesAutowired(); 
            builder.RegisterType<DefaultJobSchedulerService>().As<IJobSchedulerService>().PropertiesAutowired();
            builder.RegisterType<FormsMembershipService>().As<IMembershipService>().PropertiesAutowired();
            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().PropertiesAutowired();
            builder.RegisterType<DefaultNotificationService>().As<INotificationService>().PropertiesAutowired();
            builder.RegisterType<DefaultEncryptionService>().As<IEncryptionService>().PropertiesAutowired();

            _containerProvider = new ContainerProvider(builder.Build());
            var jobSchedulerService = _containerProvider.ApplicationContainer.Resolve<IJobSchedulerService>();
            jobSchedulerService.Start();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
