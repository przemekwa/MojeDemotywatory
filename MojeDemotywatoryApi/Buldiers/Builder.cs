using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    public abstract class Builder
    {
        public string ImgUrl { get; set; }

        public string Url { get; set; }

        public string Opis { get; set; }

        public abstract Demotywator Build();
    }
}
