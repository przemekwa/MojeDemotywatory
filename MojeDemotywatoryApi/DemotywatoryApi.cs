using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MojeDemotywatoryApi
{
    public class DemotywatoryApi
    {
        private DemotywatorBuldier demotywatorBuldier;

        public DemotywatoryApi(string Url, DemotywatorBuldier demotywatorBuldier = null)
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

            ApiTools.AdresWWW = Url;
        }

        public IEnumerable<Demotywator> PobierzZeStron(int page)
        {
            var rezult = new List<Demotywator>();

            for (int i=1;i<=page;i++)
            {
                rezult.AddRange(this.ParsujStrone(i));
            }

            return rezult;
        }

        public IEnumerable<Demotywator> PobierzZeStrony(int page)
        {
            return this.ParsujStrone(page);
        }

        public IEnumerable<Demotywator> PobierzZGłownej()
        {
            return this.ParsujStrone(1);
        }
        
        private IEnumerable<Demotywator> ParsujStrone(int strona)
        {
            var rezult = new List<Demotywator>();

            var html = ApiTools.ŁadujStronę(ApiTools.AdresWWW + "page/" + strona);

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                var demotywator = new DemotywatorParser(demotywatorBuldier, ApiTools.AdresWWW).Parsuj(htmlNode);

                if (demotywator == null) continue;

                rezult.Add(demotywator);
            }
         
            return rezult;
        }
    }
}
