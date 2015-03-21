using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi.Buldiers
{
    internal sealed class DemotywatorSlideBuilder : SlideBuilder
    {
        public override DemotywatorSlajd Build()
        {
            var rezult = new DemotywatorSlajd
            {
                ImgUrl = this.AdresObrazka,
                Opis = this.Opis
            };

            return rezult;
        }
    }
}
