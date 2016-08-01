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

        public static IEnumerable<DemotivatorSlide> PobierzDemotywatoryZeSlajdow(string url)
        {
            var rezult = new List<DemotivatorSlide>();
            
            var html = LoadHtml(url);

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"rsSlideContent\"]"))
            {
                var demotywatorSlajd = new DemotivatorSlideParser(new DemotivatorSlideBuilder()).Parsuj(htmlNode);

                if (demotywatorSlajd == null) continue;
                
                rezult.Add(demotywatorSlajd);
            }

            return rezult;
        }
    }
}
