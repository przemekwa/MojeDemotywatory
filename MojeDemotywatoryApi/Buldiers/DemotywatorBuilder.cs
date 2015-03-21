using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi.Buldiers
{
    internal sealed class DemotywatorBuilder : Builder
    {
        public override Demotywator Build()
        {
            var rezult = new Demotywator
            {
                Url = this.Url,
                ImgUrl = this.ImgUrl,
            };

            return rezult;
        }
    }
}
