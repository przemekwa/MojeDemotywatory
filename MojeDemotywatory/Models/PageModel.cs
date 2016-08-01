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
        public List<Demotivator> DemotywatorList { get; set; }
        public List<DemotivatorSlide> DemotywatorSlajdList { get; set; }
        public int AktualnaStrona { get; set; }
        public int Fajne { get; set; }
    }
}