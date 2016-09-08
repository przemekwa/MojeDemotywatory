using HtmlAgilityPack;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Parsers
{
    public interface IParser<out T>
    {
        T Parse(HtmlNode htmllNode);
    }
}