using System;
using HtmlAgilityPack;
using MojeDemotywatoryApi.Buldiers;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Parsers
{
    internal class DemotywatorParser
    {
        private readonly Builder builder;

        private readonly string url;

        public DemotywatorParser(Builder builder, string url)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            this.url = url;
            
            this.builder = builder;
        }

        public Demotivator Parse(HtmlNode htmllNode)
        {
            if (htmllNode == null)
            {
                throw new ArgumentNullException(nameof(htmllNode));
            }

            var link = htmllNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

            var imgTag = link?.SelectSingleNode("img");

            if (imgTag == null)
            {
                return null;
            }

            builder.ImgUrl = imgTag.Attributes["src"].Value;

            builder.Url = url + link.Attributes["href"].Value;

            return this.builder.Build();
        }
    }

  
}
