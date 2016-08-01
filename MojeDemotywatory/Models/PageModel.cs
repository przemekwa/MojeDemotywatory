using MojeDemotywatoryApi;
using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MojeDemotywatory.Models
{
    public class PageModel
    {
        public List<Demotivator> DemotivatorList { get; set; }
        public List<DemotivatorSlide> DemotivatorSlajdList { get; set; }
        public int CurrentPage { get; set; }
        public int Fajne { get; set; }
    }
}