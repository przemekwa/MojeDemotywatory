namespace MojeDemotywatoryApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HtmlAgilityPack;
    using Buldiers;
    using Interface;
    using Models;
    using Parsers;

    public class DemotivatorApi : IDemotivatorApi
    {
        private readonly string url;

        public static string DomainUrl { get; set; }

        private readonly Builder buldier;

        public DemotivatorApi(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url), "Adres strony demotywatorów nie może być pusty");
            }

            this.url = url;

            this.buldier = new DemotivatorBuilder();

            DomainUrl = url;
        }

        public IEnumerable<Page> GetPages(int first, int last)
        {
            var rezult = new List<Page>();

            for (var i=first;i<=last;i++)
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

            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                 var isSlideType = htmlNode.SelectSingleNode("h2/span[@class=\"gallery_pics_count\"]") != null;

                if (isSlideType)
                {
                    var link = htmlNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

                    var url = DomainUrl + link.Attributes["href"].Value;

                    rezult.DemotivatorSlajdList.AddRange(ApiTools.GetDemovivatorSlides(url).ToList());
                }
                else
                {
                    var demotywator = new DemotywatorParser(buldier, DomainUrl).Parse(htmlNode);

                    if (demotywator == null)
                    {
                        continue;
                    }

                    rezult.DemotivatorList.Add(demotywator);
                }
            }
         
            return rezult;
        }
    }
}
