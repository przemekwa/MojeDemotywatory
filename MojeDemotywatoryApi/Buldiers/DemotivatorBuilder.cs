using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Buldiers
{
    internal sealed class DemotivatorBuilder : Builder<Demotivator>
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
