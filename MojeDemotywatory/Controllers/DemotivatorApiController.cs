using System;
using System.Collections.Generic;
using System.Linq;
using MojeDemotywatoryApi.Interface;

namespace MojeDemotywatory.Controllers
{
    using System.Web.Http;
    using MojeDemotywatoryApi;
    using MojeDemotywatoryApi.Models;

  
    public class DemotivatorApiController : ApiController
    {
        private readonly IDemotivatorApi demotivatorApi;

        public DemotivatorApiController()
        {
            this.demotivatorApi = new DemotivatorApi("http://demotywatory.pl/");
        }

        public Page Get()
        { 
            return this.demotivatorApi.GetMainPage();
        }

        public Page Get(int id)
        {
            return this.demotivatorApi.GetPage(id);
        }
     
        public IEnumerable<Page> Get(int first, int last)
        {
            return this.demotivatorApi.GetPages(first, last);
        }
    }
}
