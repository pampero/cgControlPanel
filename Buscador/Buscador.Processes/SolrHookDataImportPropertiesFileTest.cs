using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using NUnit.Framework;
using SolrNet;

namespace Buscador.Processes
{
    [TestFixture]
    public class SolrHookDataImportPropertiesFileTest
    {
        private string _serverUrl;

        [SetUp]
        public void Setup()
        {
            _serverUrl = "http://localhost:8983/solr/live/dataimport";
        }

        [Test]
        public void Can_Get_Solr_DataImport_Status()
        {
            SolrUtils.GetDataImportStatus(_serverUrl);
        }

        [Test]
        [ExpectedException(typeof(SolrNotRespondException))]
        public void DataImport_Status_With_Invalid_Solr_Url_Throws_Exception()
        {
            SolrUtils.GetDataImportStatus("http://localhost:45/solr/live/dataimport");
        }

        [Ignore]
        [Test]
        public void Can_Parse_DataImport_Properties()
        {
            var path = @"C:\Users\gpineiro\Desktop\buscador\BuscadorClasificados\branches\Buscador-v1.0\Buscador.Processes\dataimport.properties";
            var importTimestamp = SolrUtils.GetDataImportTimestamp(path);
            Assert.IsNotNull(importTimestamp);
        }

        [Ignore]
        [Test]
        public void Can_Update_DataImport_Timestamp()
        {
            var path = @"C:\Users\gpineiro\Desktop\buscador\BuscadorClasificados\branches\Buscador-v1.0\Buscador.Processes\dataimport.properties";
            var importTimestamp = SolrUtils.GetDataImportTimestamp(path);

            var newTimestamp = DateTime.Now;
            SolrUtils.UpdateDataImportTimestamp(path, SolrUtils.ToSolrDate(newTimestamp));

            Assert.IsTrue(SolrUtils.GetDataImportTimestamp(path) == SolrUtils.ToSolrDate(newTimestamp));
            Assert.IsFalse(importTimestamp == SolrUtils.ToSolrDate(newTimestamp));
        }

        
        [Test]
        [Ignore]
        public void Can_Get_Last_DataImport_Timestamp()
        {
            Assert.IsNotNull(SolrUtils.GetLastDataImportStartTimestamp(_serverUrl));
        }
        
        [Ignore]
        [Test]
        public void Can_Tell_If_Solr_Instance_Is_Indexing()
        {
            Assert.IsFalse(SolrUtils.IsIndexing(_serverUrl));
        }
    }
}
