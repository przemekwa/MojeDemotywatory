using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeDemotywatoryApi
{
    interface IDemotywatoryApi
    {
        IEnumerable<Page> GetPages(int first, int last);
        Page GetPage(int page);
        Page GetMainPage();
    }
}
