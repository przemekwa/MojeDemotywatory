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
        private readonly string domainUrl;
       
        private readonly IParser<Demotivator> demotivatorParser;

        private readonly IParser<DemotivatorSlide> slideDemotivatorParser;

        public DemotivatorApi(string domainUrl)
        {
            if (string.IsNullOrEmpty(domainUrl))
            {
                throw new ArgumentNullException(nameof(domainUrl), "Adres strony demotywatorów nie może być pusty");
            }

            this.demotivatorParser = new DemotivatorParser(new DemotivatorBuilder(), domainUrl);

            this.slideDemotivatorParser = new DemotivatorSlideParser(new DemotivatorSlideBuilder());

            this.domainUrl = domainUrl;
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

            var html = ApiTools.LoadHtml(domainUrl + "page/" + pageNumber);

            foreach (var htmlNode in html.DocumentNode.SelectNodes("//div[@class=\"demotivator pic \"]"))
            {
                 var isSlideType = htmlNode.SelectSingleNode("h2/span[@class=\"gallery_pics_count\"]") != null;

                if (isSlideType)
                {
                    var link = htmlNode.SelectSingleNode("div[1]/a[@class=\"picwrapper\"]");

                    var url = domainUrl + link.Attributes["href"].Value;

                    rezult.DemotivatorSlideCollection.AddRange(this.GetDemovivatorSlides(url).ToList());
                }
                else
                {
                   var demotivator =  this.demotivatorParser.Parse(htmlNode);

                    if (demotivator == null)
                    {
                        continue;
                    }

                    rezult.DemotivatorCollection.Add(demotivator);
                }
            }
         
            return rezult;
        }


        private IEnumerable<DemotivatorSlide> GetDemovivatorSlides(string url)
        {
            return ApiTools.LoadHtml(url).DocumentNode.SelectNodes("//div[@class=\"rsSlideContent\"]")
                .Select(htmlNode => this.slideDemotivatorParser.Parse(htmlNode))
                .Where(demotivatorSlide => demotivatorSlide != null)
                .ToList();
        }
    }
}
