using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    interface IDemotywatoryApi
    {
        IEnumerable<Demotywator> GetDemotywatorFromPages(int first, int last);
        IEnumerable<Demotywator> GetDemotywatorFromPage(int page);
        IEnumerable<Demotywator> GetDemotywatorFromMainPage();
    }
}
