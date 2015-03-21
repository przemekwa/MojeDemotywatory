using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MojeDemotywatoryApi.Buldiers;

namespace MojeDemotywatoryApi
{
    public class DemotywatorApi : IDemotywatoryApi
    {
        public static string DomainUrl { get; set; }

        private Builder demotywatorBuldier;

        public DemotywatorApi(string Url, Builder demotywatorBuldier = null)
        {
            if (demotywatorBuldier == null)
            {
                this.demotywatorBuldier = new DemotywatorBuilder();
            } 
            else
            {
                this.demotywatorBuldier = demotywatorBuldier;
            }

            if (string.IsNullOrEmpty(Url))
            {
                throw new ArgumentNullException("Url", "Adres strony demotywatorów nie może być pusty");
            }

            DomainUrl = Url;
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

            var html = ApiTools.LoadHtml(DomainUrl + "page/" + pageNumber);

            foreach (HtmlNode htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                 var isSlideType = htmlNode.SelectSingleNode("h2/span[@class=\"gallery_pics_count\"]") != null;

                if (isSlideType)
                {
                    var link = htmlNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

                    var url = DemotywatorApi.DomainUrl + link.Attributes["href"].Value;

                    rezult.DemotywatorSlajdList.AddRange(ApiTools.PobierzDemotywatoryZeSlajdow(url).ToList());
                }
                else
                {
                    var demotywator = new DemotywatorParser(demotywatorBuldier, DomainUrl).Parse(htmlNode);

                    if (demotywator == null) continue;

                    rezult.DemotywatorList.Add(demotywator);
                }
            }
         
            return rezult;
        }
    }
}
