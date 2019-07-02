using System;
using System.Linq;
using HtmlAgilityPack;

namespace CurrencyParse.Extensions
{
    public static class HtmlNodeExtensions
    {
        public static string GetValue(this HtmlNode htmlNode, Func<string, bool> function)
        {
            return htmlNode.Elements("td").FirstOrDefault(td => function(td.InnerText)).CheckAndGetValue();
        }

        private static string CheckAndGetValue(this HtmlNode htmlNode)
        {
            return htmlNode != null 
                ? htmlNode.InnerText 
                : string.Empty;
        }
    }
}
