using System.Collections.Generic;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Interface
{
    internal interface IDemotivatorApi
    {
        IEnumerable<Page> GetPages(int first, int last);
        Page GetPage(int page);
        Page GetMainPage();
    }
}
