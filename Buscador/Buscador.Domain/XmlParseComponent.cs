using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Buscador.Domain.com.clarin.entities;
using HtmlAgilityPack;

namespace Buscador.Domain
{
    public interface IXmlParseComponent
    {
        IList<News> ParseFileXml(XDocument document, int newsLastSet);
    }

    public class XmlParseComponent : IXmlParseComponent
    {
        public IList<News> ParseFileXml(XDocument document, int newsLastSet)
        {
            var news = new List<News>();
            
            var myNamespace= "http://www.w3.org/2005/Atom";
            
            var newshtml = document.Descendants(XName.Get("entry", myNamespace));

            foreach (var xEntry in newshtml)
            {
                var newhtml = new News();

                try
                {
                    newhtml.Link = xEntry.Descendants(XName.Get("link", myNamespace))
                        .Where(x => x.Attribute(XName.Get("href"))
                                        .Value.Contains("html"))
                        .Attributes(XName.Get("href"))
                        .First()
                        .Value;
                    

                    var contentNode = new HtmlDocument();
                    contentNode.LoadHtml(xEntry.Descendants(XName.Get("content", myNamespace)).First().Value);
                    newhtml.Description = contentNode.DocumentNode.ChildNodes.Where(n => n.NodeType == HtmlNodeType.Text).Last().InnerText;

                    if (contentNode.DocumentNode.SelectSingleNode("/img[contains(@src,'.jpg')]") == null)
                    {
                        newhtml.Picture =
                            contentNode.DocumentNode.SelectSingleNode("/a[contains(@href,'.jpg')]").Attributes.
                                AttributesWithName("href").First().Value;
                    }
                    else
                    {
                        newhtml.Picture = contentNode.DocumentNode.SelectSingleNode("/img[contains(@src,'.jpg')]").Attributes.AttributesWithName("src").First().Value;
                    }

                    if (contentNode.DocumentNode.SelectSingleNode("/div/strong/text()") != null)
                    {
                        newhtml.Title = contentNode.DocumentNode.SelectSingleNode("/div/strong/text()").InnerText;

                    }
                    else if (contentNode.DocumentNode.SelectSingleNode("/strong/text()") != null)
                    {
                        newhtml.Title = contentNode.DocumentNode.SelectSingleNode("/strong/text()").InnerText;
                    }
                    else
                    {
                        newhtml.Title =
                            contentNode.DocumentNode.ChildNodes.Where(n => n.NodeType == HtmlNodeType.Text).Last().
                                InnerText.Substring(0, 20);

                    }
                    news.Add(newhtml);
                    if(news.Count == newsLastSet)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    var err = e.ToString();
                }
            }
            return news;
        }
    }
}
