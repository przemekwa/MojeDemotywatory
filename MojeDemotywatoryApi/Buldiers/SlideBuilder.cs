using MojeDemotywatoryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    public abstract class SlideBuilder
    {
        public string AdresObrazka { get; set; }

        public string AdresStrony { get; set; }

        public string Opis { get; set; }

        abstract public DemotywatorSlajd Build();
    }
}
