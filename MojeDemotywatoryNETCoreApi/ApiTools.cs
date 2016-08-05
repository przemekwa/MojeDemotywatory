using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryNETCoreApi.Buldiers;
using MojeDemotywatoryNETCoreApi.Models;
using MojeDemotywatoryNETCoreApi.Parsers;


namespace MojeDemotywatoryNETCoreApi
{
    public static class ApiTools
    {
        public static HtmlDocument LoadHtml(string addres)
        {
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(addres);
            
            return htmlDocument;
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
