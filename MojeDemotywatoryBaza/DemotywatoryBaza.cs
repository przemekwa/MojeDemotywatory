using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryBaza
{
    public class DemotywatoryBaza
    {
        private DemotywatoryContext demotywatoryContex;

        public DemotywatoryBaza()
        {
            this.demotywatoryContex = new DemotywatoryContext("MyDbCS");
        }

        public void Testy()
        {
            var result = this.demotywatoryContex.Uzytkownicy.FirstOrDefault();
        }
    }
}
