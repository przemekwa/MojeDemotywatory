using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MojeDemotywatoryApi
{
    public class FabrykaDemotywatorow
    {
        private string adresWWW;

        public FabrykaDemotywatorow(string Url)
        {
            this.adresWWW = Url;
        }

        public List<DemotywatorSlajd> PobierzDemotywatoryZeSlajdow(string adres)
        {
            var dobryAdres = adresWWW + adres;

            HtmlDocument html = new HtmlDocument();

            var www = new HtmlWeb
            {
                AutoDetectEncoding = true,
            };

            html = www.Load(dobryAdres);

            var rezult = new List<DemotywatorSlajd>();

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"rsSlideContent\"]"))
            {
                var tagObrazka = htmlNode.SelectSingleNode("div[@class=\"relative\"]/img[@class=\"rsImg \"]");
                
                var opisObrazka = htmlNode.SelectSingleNode("p");

                if (opisObrazka == null) continue;

                var demot = new DemotywatorSlajd
                {
                    ObrazekUrl = tagObrazka.Attributes["src"].Value,
                    Opis = opisObrazka.InnerText
                };

                rezult.Add(demot);
            }
            
            return rezult;
        }

        public List<Mem> PobierzDemotywatoryZeStron(int page)
        {
            var rezult = new List<Mem>();

            for (int i=1;i<=page;i++)
            {
                rezult.AddRange(this.ParsujStrone(i));
            }

            return rezult;
        }


        public List<Mem> PobierzDemotywatoryZGłownej()
        {
            return this.ParsujStrone(1);
        }
        
        private List<Mem> ParsujStrone(int strona)
        {
            var rezult = new List<Mem>();

            HtmlDocument html = new HtmlDocument();

            var www = new HtmlWeb
            {
                AutoDetectEncoding = true,
            };

            html = www.Load(adresWWW + "page/" + strona);


            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//a[@class=\"picwrapper\"]"))
            {
                var tagObrazka = htmlNode.SelectSingleNode("img");

                if (tagObrazka == null)
                {
                    throw new ArgumentNullException("Brak taga <img> w linku demotywatora.");
                }

                var demot = new Demotywator
                {
                    ObrazekUrl = tagObrazka.Attributes["src"].Value,
                    AdresUrl = adresWWW + htmlNode.Attributes["href"].Value
                };

                rezult.Add(demot);
            }
         
            return rezult;
        }


    }
}
