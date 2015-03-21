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
        public List<Demotywator> DemotywatorList { get; set; }
        public List<DemotywatorSlajd> DemotywatorSlajdList { get; set; }
        public int AktualnaStrona { get; set; }
        public int Fajne { get; set; }
    }
}