using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Parsers
{
    public interface IPageParser
    {
        Page Parse(int pageNumber);
    }
}