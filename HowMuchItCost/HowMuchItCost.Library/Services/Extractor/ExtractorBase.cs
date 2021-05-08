using HowMuchItCost.Library.Interfaces;

namespace HowMuchItCost.Library.Services.Extractor
{
    public abstract class ExtractorBase : IExtractorService
    {
        public abstract string CurrencyUrl { get; }

        public decimal ExtractPrice()
        {
            return 0;
        }
    }
}
