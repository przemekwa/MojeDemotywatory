using System;
using HtmlAgilityPack;
using MojeDemotywatoryApi.Buldiers;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Parsers
{
    internal class DemotivatorSlideParser
    {
        private SlideBuilder demotywatorSlajdBuldier;

        public DemotivatorSlideParser(SlideBuilder demotywatorSlajdBuldier)
        {
            if (demotywatorSlajdBuldier == null)
            {
                throw new ArgumentNullException("DemotywatorSlajdBuldier");
            }

            this.demotywatorSlajdBuldier = demotywatorSlajdBuldier;
        }

        public DemotivatorSlide Parsuj(HtmlNode htmlNode)
        {
            var tagObrazka = htmlNode.SelectSingleNode("div[@class=\"relative\"]/img[@class=\"rsImg \"]");

            var opisObrazka = htmlNode.SelectSingleNode("p");

            if (opisObrazka == null || string.IsNullOrEmpty(opisObrazka.InnerText))
            {
                opisObrazka = htmlNode.SelectSingleNode("h3");
            }

            if (tagObrazka == null) return null;

            demotywatorSlajdBuldier.ImgUrl = tagObrazka.Attributes["src"].Value;

            demotywatorSlajdBuldier.Description = opisObrazka == null ? "" : opisObrazka.InnerText;

            return this.demotywatorSlajdBuldier.Build();
        }
    }
}
