using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    public class Demotywator
    {
        public string AdresObrazka { get; set; }

        public string AdresStrony { get; set; }

        public bool CzySaSlajdy { get; set; }

        public string AsdresStronyZeSlajdami { get; set; }

        public IEnumerable<DemotywatorSlajd> ListaSlajdow { get; set; }
       
    }

    public class DemotywatorSlajd : Demotywator
    {
        public string Opis { get; set; }
    }
}
