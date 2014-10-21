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


        public IEnumerable<Mem> PobierzDemotywatoryZGłownej()
        {
            return this.ParsujStrone(1);
        }
        
        private IEnumerable<Mem> ParsujStrone(int strona)
        {
            var rezult = new List<Mem>();

            HtmlDocument html = new HtmlDocument();

            var www = new HtmlWeb
            {
                AutoDetectEncoding = true,
            };

            html = www.Load(adresWWW + "page/" + strona);


            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                var czySlajdy = htmlNode.SelectSingleNode("h2/span[@class=\"gallery_pics_count\"]") != null;

                var link = htmlNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

                if (link == null) continue;

                var tagObrazka = link.SelectSingleNode("img");

                if (tagObrazka == null) continue;

                IEnumerable<DemotywatorSlajd> slajdy = null;

                if (czySlajdy)
                {
                    slajdy = this.PobierzDemotywatoryZeSlajdow(link.Attributes["href"].Value);
                }

                var demot = new Mem
                {
                    ObrazekUrl = tagObrazka.Attributes["src"].Value,
                    AdresUrl = adresWWW + link.Attributes["href"].Value,
                    czySlajdy = czySlajdy,
                    slajdy = slajdy
                };

                rezult.Add(demot);
               
            }
         
            return rezult;
        }


    }
}
