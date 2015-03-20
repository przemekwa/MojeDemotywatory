using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MojeDemotywatoryApi
{
    public class DemotywatorApi : IDemotywatoryApi
    {

        public static string DemotywatorAddress { get; set; }

        private DemotywatorBuldier demotywatorBuldier;

        public DemotywatorApi(string Url, DemotywatorBuldier demotywatorBuldier = null)
        {
            if (demotywatorBuldier == null)
            {
                this.demotywatorBuldier = new NowyDemotywator();
            } 
            else
            {
                this.demotywatorBuldier = demotywatorBuldier;
            }

            if (string.IsNullOrEmpty(Url))
            {
                throw new ArgumentNullException("Url", "Adres strony demotywatorów nie może być pusty");
            }

            DemotywatorAddress = Url;
        }

        public IEnumerable<Demotywator> GetDemotywatorFromPages(int first, int last)
        {
            var rezult = new List<Demotywator>();

            for (int i=first;i<=last;i++)
            {
                rezult.AddRange(this.ParsujStrone(i));
            }

            return rezult;
        }

        public IEnumerable<Demotywator> GetDemotywatorFromPage(int page)
        {
            return this.ParsujStrone(page);
        }

        public IEnumerable<Demotywator> GetDemotywatorFromMainPage()
        {
            return this.ParsujStrone(1);
        }
        
        private IEnumerable<Demotywator> ParsujStrone(int strona)
        {
            var rezult = new List<Demotywator>();

            var html = ApiTools.LoadHtml(DemotywatorAddress + "page/" + strona);

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                var demotywator = new DemotywatorParser(demotywatorBuldier, DemotywatorAddress).Parsuj(htmlNode);

                if (demotywator == null) continue;

                rezult.Add(demotywator);
            }
         
            return rezult;
        }
    }
}
