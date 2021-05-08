using HowMuchItCost.Library.CustomException;
using HowMuchItCost.Library.Interfaces;
using HtmlAgilityPack;
using System;

namespace HowMuchItCost.Library.Services.Extractor
{
    public abstract class ExtractorBase : IExtractorService
    {
        public abstract string CurrencyUrl { get; }
        public abstract string CurrencyXPath { get; }

        public decimal ExtractPrice()
        {
            var value = ExtractValue();

            if (!decimal.TryParse(value, out decimal result))
            {
                throw new ExtractException("Failed to extract value");
            }

            return result;
        }

        private string ExtractValue()
        {
            var web = new HtmlWeb();
            var document = web.Load(CurrencyUrl);

            // treat if page has redirected
            if (web.ResponseUri.OriginalString.StartsWith(CurrencyUrl))
            {
                var value = GetNodeValue(document, CurrencyXPath);
                return value;
            }

            throw new ExtractException("Currency page has been redirected");
        }

        private static string GetNodeValue(HtmlDocument Document, string xpath)
        {
            var node = GetNodeXPath(Document, xpath);
            return node?.InnerText;
        }

        private static HtmlNode GetNodeXPath(HtmlDocument Document, string xpath)
        {
            var node = Document.DocumentNode.SelectSingleNode(xpath);
            return node;
        }
    }
}
