using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MojeDemotywatoryApi
{
    internal class DemotywatorParser
    {
        private Builder demotywatorBuldier;

        private string url;

        public DemotywatorParser(Builder demotywatorBuldier, string url)
        {
            if (demotywatorBuldier == null)
            {
                throw new ArgumentNullException("DemotywatorBuldier");
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("adres");
            }

            this.url = url;
            
            this.demotywatorBuldier = demotywatorBuldier;
        }

        public Demotywator Parse(HtmlNode htmllNode)
        {
            if (htmllNode == null)
            {
                throw new ArgumentNullException("XmlNode");
            }

            var link = htmllNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

            if (link == null) return null;

            var tagObrazka = link.SelectSingleNode("img");

            if (tagObrazka == null) return null;
             

            demotywatorBuldier.ImgUrl = tagObrazka.Attributes["src"].Value;
            demotywatorBuldier.Url = url + link.Attributes["href"].Value;

            return this.demotywatorBuldier.Build();
        }
    }

  
}
