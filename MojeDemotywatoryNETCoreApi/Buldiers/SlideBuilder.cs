using MojeDemotywatoryNETCoreApi.Models;

namespace MojeDemotywatoryNETCoreApi.Buldiers
{
    internal abstract class SlideBuilder
    {
        public string ImgUrl { get; set; }

        public string AdresStrony { get; set; }

        public string Description { get; set; }

        public abstract DemotivatorSlide Build();
    }
}
