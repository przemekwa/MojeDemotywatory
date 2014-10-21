using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{

    public abstract class Mem
    {
        public string ObrazekUrl { get; set; }
        public string AdresUrl { get; set; }
        public bool czySlajdy { get; set; }
    }


    public class Demotywator : Mem
    {
      
    }

    public class DemotywatorSlajd :Mem
    {
        public string Opis { get; set; }
    }
}
