using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using CG.Services.interfaces;
using Model;
using Quartz;
using Quartz.Impl;
using Services.Scheduling.impl;

namespace Processes
{
    public class Program 
    {
        public static int Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new StdSchedulerFactory().GetScheduler()).As<IScheduler>().InstancePerLifetimeScope();
            builder.RegisterType<DefaultJobSchedulerService>().As<IJobSchedulerService>().PropertiesAutowired();
            builder.RegisterType<UnitOfWork>().PropertiesAutowired(); 
            using (var container = builder.Build())
            {
                var service = container.Resolve<IJobSchedulerService>();
                service.ProcessDailyJobs();
            }
            return 0;
        }
    }
}

