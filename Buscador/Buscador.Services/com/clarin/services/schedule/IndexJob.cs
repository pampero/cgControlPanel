using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Buscador.Domain.com.clarin.entities;
using NHibernate;
using Quartz;
using Quartz.Impl;
using Spring.Data.NHibernate.Support;


namespace Buscador.Services.com.clarin.services.schedule
{
    public class IndexJob : IJob
    {
        public void Execute(JobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            var sessionFactory = (ISessionFactory)dataMap["sessionFactory"];
            var indexService = (IIndexService<Publication>)dataMap["indexService"];

            //using (var ss = new SessionScope(sessionFactory, true))
            //{
            //    indexService.Index();
            //    ss.Close();
            //}
        }
    }
}
