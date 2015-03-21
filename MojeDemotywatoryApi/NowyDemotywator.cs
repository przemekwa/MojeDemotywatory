using HtmlAgilityPack;
using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    internal class NowyDemotywator : DemotywatorBuldier
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

    internal class NowyDemotywatorSlajd : DemotywatorSlajdBuldier
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
