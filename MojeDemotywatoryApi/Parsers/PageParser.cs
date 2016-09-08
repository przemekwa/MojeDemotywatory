using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Parsers
{
    public class PageParser : IPageParser
    {
        private readonly IParser<Demotivator> demotivatorParser;

        private readonly IParser<DemotivatorSlide> slideDemotivatorParser;

        private readonly string domainUrl;

        public PageParser(IParser<Demotivator> demotivatorParser, IParser<DemotivatorSlide> slideDemotivatorParser, string domainUrl)
        {
            this.demotivatorParser = demotivatorParser;
            this.slideDemotivatorParser = slideDemotivatorParser;
            this.domainUrl = domainUrl;
        }

        public Page Parse(int pageNumber)
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

                    rezult.DemotivatorSlideCollection.AddRange(this.GetDemovivatorSlides(url));
                }
                else
                {
                    var demotivator = this.demotivatorParser.Parse(htmlNode);

                    if (demotivator == null)
                    {
                        continue;
                    }

                    rezult.DemotivatorCollection.Add(demotivator);
                }
            }

            return rezult;
        }

        public IEnumerable<DemotivatorSlide> GetDemovivatorSlides(string url)
        {
            return ApiTools.LoadHtml(url).DocumentNode.SelectNodes("//div[@class=\"rsSlideContent\"]")
                .Select(htmlNode => this.slideDemotivatorParser.Parse(htmlNode))
                .Where(demotivatorSlide => demotivatorSlide != null)
                .ToList();
        }
    }
}
