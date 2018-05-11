using HtmlAgilityPack;
using MojeDemotywatoryApi.Models;
using System.Collections.Generic;

namespace MojeDemotywatoryApi.Parsers
{
    public interface IParser<out T>
    {
        T Parse(HtmlNode htmllNode);

        IEnumerable<T> ParseMany(HtmlNode htmllNode);
    }
}