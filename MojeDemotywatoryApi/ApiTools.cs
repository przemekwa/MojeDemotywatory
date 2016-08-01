using HtmlAgilityPack;
using MojeDemotywatoryApi.Buldiers;
using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryApi.Parsers;

namespace MojeDemotywatoryApi
{
    public static class ApiTools
    {
        public static HtmlDocument LoadHtml(string addres)
        {
            var htmlDocument = new HtmlWeb
            {
                AutoDetectEncoding = true
            };
            
            return htmlDocument.Load(addres);
        }

        public static IEnumerable<DemotivatorSlide> GetDemovivatorSlides(string url)
        {
            return LoadHtml(url).DocumentNode.SelectNodes("//div[@class=\"rsSlideContent\"]")
                .Select(htmlNode => new DemotivatorSlideParser(new DemotivatorSlideBuilder()).Parse(htmlNode))
                .Where(demotywatorSlajd => demotywatorSlajd != null)
                .ToList();
        }
    }
}
