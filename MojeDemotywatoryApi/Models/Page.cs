using System.Collections.Generic;

namespace MojeDemotywatoryApi.Models
{
    public class Page
    {
        public int PageNumber { get; set; }

        public List<Demotivator> DemotywatorList { get; set; }
        
        public List<DemotivatorSlide> DemotywatorSlajdList { get; set; }

        public Page(int pageNumber)
        {
            this.DemotywatorList = new List<Demotivator>();
            this.DemotywatorSlajdList = new List<DemotivatorSlide>();

            this.PageNumber = pageNumber;
        }
    }
}
