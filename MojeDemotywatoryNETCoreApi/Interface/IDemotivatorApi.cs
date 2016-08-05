using System.Collections.Generic;
using MojeDemotywatoryNETCoreApi.Models;

namespace MojeDemotywatoryNETCoreApi.Interface
{
    internal interface IDemotivatorApi
    {
        IEnumerable<Page> GetPages(int first, int last);
        Page GetPage(int page);
        Page GetMainPage();
    }
}
