using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{

    public class Demotywator
    {
        public string ObrazekUrl { get; set; }
        public string AdresUrl { get; set; }
        public bool czySlajdy { get; set; }
        public IEnumerable<DemotywatorSlajd> slajdy { get; set; }
    }
    
    public class DemotywatorSlajd : Demotywator
    {
        public string Opis { get; set; }

    }
}
