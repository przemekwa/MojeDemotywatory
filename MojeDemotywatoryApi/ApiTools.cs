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
        public static string AdresWWW { get; set; }

        public static HtmlDocument ŁadujStronę(string adres)
        {
            var www = new HtmlWeb
            {
                AutoDetectEncoding = true,
            };

            return www.Load(adres);
        }

        public static IEnumerable<DemotywatorSlajd> PobierzDemotywatoryZeSlajdow(string adres)
        {
            var rezult = new List<DemotywatorSlajd>();

            var właściwyAdres = AdresWWW + adres;

            var html = ŁadujStronę(właściwyAdres);

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
