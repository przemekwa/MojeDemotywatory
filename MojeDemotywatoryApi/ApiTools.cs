using HtmlAgilityPack;
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

        public static IEnumerable<DemotywatorSlajd> PobierzDemotywatoryZeSlajdow(string adres)
        {
            var rezult = new List<DemotywatorSlajd>();

            var właściwyAdres = DemotywatorApi.DemotywatorAddress + adres;

            var html = LoadHtml(właściwyAdres);

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"rsSlideContent\"]"))
            {
                var demotywatorSlajd = new DemotywatorSlajdParser(new NowyDemotywatorSlajd(), właściwyAdres).Parsuj(htmlNode);

                if (demotywatorSlajd == null) continue;
                
                rezult.Add(demotywatorSlajd);
            }

            return rezult;
        }
    }
}
