using HtmlAgilityPack;
using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
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
