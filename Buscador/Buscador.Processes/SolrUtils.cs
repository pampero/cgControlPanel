using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Buscador.Processes
{
    public static class SolrUtils
    {
        public static string GetDataImportStatus(string serverUrl)
        {
            try
            {
                var statusNode = GetNodeWithName(serverUrl,"status");
                    
                if (statusNode == null)
                    throw new SolrNotRespondException("no se pudo resolver el status node");

                return statusNode.Value;
            }
            catch (WebException webException)
            {
                throw new SolrNotRespondException("no se pudo conectar al servidor");
            }
        }

        private static XElement GetNodeWithName(string serverUrl, string nodeName)
        {
            return XDocument.Load(serverUrl).Descendants(XName.Get("str"))
                                            .Where(a => a.Attribute(XName.Get("name")) != null && a.Attribute(XName.Get("name")).Value == nodeName)
                                            .FirstOrDefault<XElement>();
        }

        public static string GetDataImportTimestamp(string pathProperties)
        {
            var sr = File.OpenText(pathProperties);
            var fileContent = sr.ReadToEnd();
            sr.Close();
            return fileContent.Substring(fileContent.IndexOf("=") + 1, 21);
        }

        public static void UpdateDataImportTimestamp(string pathProperties, string newTimestamp)
        {
            var sr = File.OpenText(pathProperties);
            var fileContent = sr.ReadToEnd();
            sr.Close();
            var newContent = fileContent.Replace(GetDataImportTimestamp(pathProperties), newTimestamp);
            var sw = new StreamWriter(pathProperties, false);
            sw.WriteLine(newContent);
            sw.Close();
        }

        public static string ToSolrDate(DateTime dateTime)
        {
            return dateTime.ToString(@"yyyy-MM-dd HH\\:mm\\:ss");
        }

        public static string GetLastDataImportStartTimestamp(string serverUrl)
        {
            return GetNodeWithName(serverUrl, "Full Dump Started").Value;
        }

        public static bool IsIndexing(string serverUrl)
        {
            return GetDataImportStatus(serverUrl) == "busy";
        }
    }
}