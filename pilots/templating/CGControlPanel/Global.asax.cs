﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac;
using Autofac.Integration.Web;
using CG.Services.impl;
using Model;
using Services.Scheduling.impl;
using log4net.Config;
using Quartz;
using Quartz.Impl;
using CG.Services.interfaces;

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
            builder.Register(c => new StdSchedulerFactory().GetScheduler()).As<IScheduler>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().PropertiesAutowired(); 
            builder.RegisterType<FakeJobSchedulerService>().As<IJobSchedulerService>().PropertiesAutowired(); 
        //    builder.RegisterType<DefaultJobSchedulerService>().As<IJobSchedulerService>().PropertiesAutowired(); 

            _containerProvider = new ContainerProvider(builder.Build());
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
