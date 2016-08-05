using System;
using System.Collections.Generic;

namespace MojeDemotywatoryNETCoreApi.Models
{
    public class Page
    {
        public int PageNumber { get; set; }

        public List<Demotivator> DemotivatorList { get; set; }
        
        public List<DemotivatorSlide> DemotivatorSlajdList { get; set; }

        public Page(int pageNumber)
        {
            this.DemotivatorList = new List<Demotivator>();
            this.DemotivatorSlajdList = new List<DemotivatorSlide>();

            this.PageNumber = pageNumber;
        }
    }
}
