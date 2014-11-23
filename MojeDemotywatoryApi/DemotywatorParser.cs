using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MojeDemotywatoryApi
{
    internal class DemotywatorParser
    {
        private DemotywatorBuldier demotywatorBuldier;

        private string adresWWW;

        public DemotywatorParser(DemotywatorBuldier demotywatorBuldier, string adres)
        {
            if (demotywatorBuldier == null)
            {
                throw new ArgumentNullException("DemotywatorBuldier");
            }

            if (string.IsNullOrEmpty(adres))
            {
                throw new ArgumentNullException("adres");
            }

            this.adresWWW = adres;
            
            this.demotywatorBuldier = demotywatorBuldier;
        }

        public Demotywator Parsuj(HtmlNode htmllNode)
        {
            if (htmllNode == null)
            {
                throw new ArgumentNullException("XmlNode");
            }

            var czySlajdy = htmllNode.SelectSingleNode("h2/span[@class=\"gallery_pics_count\"]") != null;

            var link = htmllNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

            if (link == null) return null;

            var tagObrazka = link.SelectSingleNode("img");

            if (tagObrazka == null) return null;
             
            if (czySlajdy)
            {
                demotywatorBuldier.AsdresStronyZeSlajdami = link.Attributes["href"].Value;
            }

            demotywatorBuldier.AdresObrazka = tagObrazka.Attributes["src"].Value;
            demotywatorBuldier.AdresStrony = adresWWW + link.Attributes["href"].Value;
            demotywatorBuldier.CzySaSlajdy = czySlajdy;

            return this.demotywatorBuldier.Build();
        }
    }

    internal class DemotywatorSlajdParser
    {
        private DemotywatorSlajdBuldier demotywatorSlajdBuldier;

        private string adresWWW;

        public DemotywatorSlajdParser(DemotywatorSlajdBuldier demotywatorSlajdBuldier, string adres)
        {
            if (demotywatorSlajdBuldier == null)
            {
                throw new ArgumentNullException("DemotywatorSlajdBuldier");
            }

            if (string.IsNullOrEmpty(adres))
            {
                throw new ArgumentNullException("adres");
            }

            this.adresWWW = adres;

            this.demotywatorSlajdBuldier = demotywatorSlajdBuldier;
        }

        public DemotywatorSlajd Parsuj(HtmlNode htmlNode)
        {
            var tagObrazka = htmlNode.SelectSingleNode("div[@class=\"relative\"]/img[@class=\"rsImg \"]");

            var opisObrazka = htmlNode.SelectSingleNode("p");

            if (opisObrazka == null || string.IsNullOrEmpty(opisObrazka.InnerText))
            {
                opisObrazka = htmlNode.SelectSingleNode("h3");
            }

            if (tagObrazka == null) return null;

            demotywatorSlajdBuldier.AdresObrazka = tagObrazka.Attributes["src"].Value;

            demotywatorSlajdBuldier.Opis = opisObrazka == null ? "" : opisObrazka.InnerText;
           
            return this.demotywatorSlajdBuldier.Build();
        }
    }
}
