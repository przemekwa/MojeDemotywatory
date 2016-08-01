

namespace MojeDemotywatory.Models
{
    using System.Collections.Generic;

    using MojeDemotywatoryApi.Models;

    public class PageModel
    {
        public List<Demotivator> DemotivatorList { get; set; }

        public List<DemotivatorSlide> DemotivatorSlideList { get; set; }

        public int CurrentPage { get; set; }

        public int FavoriteCount { get; set; }
    }
}