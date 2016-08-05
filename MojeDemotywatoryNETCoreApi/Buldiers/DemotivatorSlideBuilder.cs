using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryNETCoreApi.Models;

namespace MojeDemotywatoryNETCoreApi.Buldiers
{
    internal sealed class DemotivatorSlideBuilder : SlideBuilder
    {
        public override DemotivatorSlide Build()
        {
            var rezult = new DemotivatorSlide
            {
                ImgUrl = this.ImgUrl,
                Description= this.Description
            };

            return rezult;
        }
    }
}
