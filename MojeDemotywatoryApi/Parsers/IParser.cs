using HtmlAgilityPack;
using MojeDemotywatoryApi.Models;

namespace MojeDemotywatoryApi.Parsers
{
    internal interface IParser<out T>
    {
        T Parse(HtmlNode htmllNode);
    }
}