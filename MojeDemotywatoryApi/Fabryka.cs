using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MojeDemotywatoryApi
{
    public class Fabryka
    {
        private string adresWWW;

        public Fabryka(string Url)
        {
            this.adresWWW = Url;
        }

        public List<Demotywator> PobierzDemotywatory()
        {
            return this.ParsujStrone();
        }
        
        private List<Demotywator> ParsujStrone()
        {
            var rezult = new List<Demotywator>();

            HtmlDocument html = new HtmlDocument();

            var www = new HtmlWeb
            {
                AutoDetectEncoding = true,
            };

            html = www.Load(adresWWW);


            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//a[@class=\"picwrapper\"]"))
            {
                var tagObrazka = htmlNode.SelectSingleNode("img");

                if (tagObrazka == null)
                {
                    throw new ArgumentNullException("Brak taga <img> w linku demotywatora.");
                }

                var demot = new Demotywator
                {
                    ObrazekUrl = tagObrazka.Attributes["src"].Value
                };

                rezult.Add(demot);
            }
         
            return rezult;
        }


    }
}
