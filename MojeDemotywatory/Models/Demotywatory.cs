using MojeDemotywatoryApi;
using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MojeDemotywatory.Models
{
    public class Demotywatory
    {
        public List<Demotywator> ListaDemotow { get; set; }
        public List<DemotywatorSlajd> ListaSjaldowDemotow { get; set; }
        public int AktualnaStrona { get; set; }
        public int Fajne { get; set; }
    }
}