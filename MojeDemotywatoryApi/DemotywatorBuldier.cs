using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    public abstract class DemotywatorBuldier
    {
        public string AdresObrazka { get; set; }

        public string AdresStrony { get; set; }

        public bool CzySaSlajdy { get; set; }

        public string AsdresStronyZeSlajdami { get; set; }

        public IEnumerable<DemotywatorSlajd> ListaSlajdów { get; set; }

        public string Opis { get; set; }

        abstract public Demotywator Build();
    }

    public abstract class DemotywatorSlajdBuldier
    {
        public string AdresObrazka { get; set; }

        public string AdresStrony { get; set; }

        public bool CzySaSlajdy { get; set; }

        public string AsdresStronyZeSlajdami { get; set; }

        public string Opis { get; set; }

        abstract public DemotywatorSlajd Build();
    }

}
