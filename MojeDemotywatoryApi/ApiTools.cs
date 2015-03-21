using HtmlAgilityPack;
using MojeDemotywatoryApi.Buldiers;
using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static IEnumerable<DemotywatorSlajd> PobierzDemotywatoryZeSlajdow(string url)
        {
            var rezult = new List<DemotywatorSlajd>();

            var html = LoadHtml(url);

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"rsSlideContent\"]"))
            {
                var demotywatorSlajd = new DemotywatorSlajdParser(new DemotywatorSlideBuilder()).Parsuj(htmlNode);

                if (demotywatorSlajd == null) continue;
                
                rezult.Add(demotywatorSlajd);
            }

            return rezult;
        }
    }
}
