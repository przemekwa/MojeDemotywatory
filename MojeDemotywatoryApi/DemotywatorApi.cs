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
        public static string DemotywatorSiteUrl { get; set; }

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

            DemotywatorSiteUrl = Url;
        }

        public IEnumerable<Page> GetPages(int first, int last)
        {
            var rezult = new List<Page>();

            for (int i=first;i<=last;i++)
            {
                rezult.Add(this.ParsePage(i));
            }

            return rezult;
        }

        public Page GetPage(int page)
        {
            return this.ParsePage(page);
        }

        public Page GetMainPage()
        {
            return this.ParsePage(1);
        }
        
        private Page ParsePage(int pageNumber)
        {
            var rezult = new Page(pageNumber);

            var html = ApiTools.LoadHtml(DemotywatorSiteUrl + "page/" + pageNumber);

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                var demotywator = new DemotywatorParser(demotywatorBuldier, DemotywatorSiteUrl).Parse(htmlNode);

                if (demotywator == null) continue;

                rezult.DemotywatorList.Add(demotywator);
            }
        
            return rezult;
        }
    }
}
