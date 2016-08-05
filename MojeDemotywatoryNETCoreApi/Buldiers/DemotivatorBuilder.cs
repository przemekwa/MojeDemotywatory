using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryNETCoreApi.Models;

namespace MojeDemotywatoryNETCoreApi.Buldiers
{
    internal sealed class DemotivatorBuilder : Builder
    {
        public override Demotivator Build()
        {
            var rezult = new Demotivator
            {
                Url = this.Url,
                ImgUrl = this.ImgUrl,
            };

            return rezult;
        }
    }
}
