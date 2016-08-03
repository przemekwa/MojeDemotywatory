using System;
using System.Collections.Generic;
using System.Linq;

namespace MojeDemotywatory.Controllers
{
    using System.Web.Http;
    using MojeDemotywatoryApi;
    using MojeDemotywatoryApi.Models;

  
    public class DemotivatorApiController : ApiController
    {
        public DemotivatorApi DemotivatorApi { get; set; } = new DemotivatorApi("http://demotywatory.pl/");

        public Page Get()
        {
            return this.DemotivatorApi.GetMainPage();
        }

        public Page Get(int id)
        {
            return this.DemotivatorApi.GetPage(id);
        }
     
        public IEnumerable<Page> Get(int first, int last)
        {
            return this.DemotivatorApi.GetPages(first,last).ToList();
        }
    }
}
