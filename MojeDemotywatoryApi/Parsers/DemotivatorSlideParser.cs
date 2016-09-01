using System;
using HtmlAgilityPack;
using MojeDemotywatoryApi.Buldiers;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Parsers
{
    internal class DemotivatorSlideParser : IParser<DemotivatorSlide>
    {
        private readonly Builder<DemotivatorSlide> buldier;

        public DemotivatorSlideParser(Builder<DemotivatorSlide> slideBuilder)
        {
            if (slideBuilder == null)
            {
                throw new ArgumentNullException(nameof(slideBuilder));
            }

            this.buldier = slideBuilder;
        }

        public DemotivatorSlide Parse(HtmlNode htmlNode)
        {
            var imgTag = htmlNode.SelectSingleNode("div[@class=\"relative\"]/img[@class=\"rsImg \"]");

            var imgDescription = htmlNode.SelectSingleNode("p");

            if (string.IsNullOrEmpty(imgDescription?.InnerText))
            {
                imgDescription = htmlNode.SelectSingleNode("h3");
            }

            if (imgTag == null) return null;

            buldier.ImgUrl = imgTag.Attributes["src"].Value;

            buldier.Description = imgDescription == null ? "" : imgDescription.InnerText;

            return this.buldier.Build();
        }
    }
}
