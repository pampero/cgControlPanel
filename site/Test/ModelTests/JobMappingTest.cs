using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using NUnit.Framework;

namespace Test.ModelTests
{
    [TestFixture]
    public class JobMappingTest
    {
        [Test]
        public void SQLMappingTest()
        {
            var sqlJob = new SqlJob
                             {
                                 Comments = "blabla",
                                 CreatedBy = "sdsd",
                                 DatabaseName = "CGControlPanel",
                                 CreatedDate = DateTime.Now,
                                 Deleted = false,
                                 DeletedBy = string.Empty,
                                 Description = "Descripcion",
                                 IsFavorite = true,
                                 Group = "Replicación",
                                 Name = "Job Replicación 1",
                                 JobType = JobType.Automático,
                                 InputSchemaProcedure = "wdwdsadsa",
                                 JobTypeEnum = 1,
                                 Password = "PASSWORD",
                                 Triggers = new List<JobTrigger>(),
                                 ServerName = "SQL",
                                 UserName = "PEPE",
                                 ExecProcedure = "sarlanga"
                             };
            var unitOfWork = new UnitOfWork();
            unitOfWork.JobsRepository.Insert(sqlJob);
            unitOfWork.Save();
        }
    }
}
