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


        public List<Demotywator> PobierzDemotywatoryZeStron(int page)
        {
            var rezult = new List<Demotywator>();

            for (int i=1;i<=page;i++)
            {
                rezult.AddRange(this.ParsujStrone(i));
            }

            return rezult;
        }


        public List<Demotywator> PobierzDemotywatoryZGłownej()
        {
            return this.ParsujStrone(1);
        }
        
        private List<Demotywator> ParsujStrone(int strona)
        {
            var rezult = new List<Demotywator>();

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
