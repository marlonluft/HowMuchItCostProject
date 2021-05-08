using HowMuchItCost.Library.Enumerador;
using HowMuchItCost.Library.Interfaces;
using HowMuchItCost.Library.Services.Extractor;
using System;

namespace HowMuchItCost.Library.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IServiceProvider _serviceProvider;

        public CurrencyService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public decimal GetBRLPrice(ECurrency currency)
        {
            IExtractorService extractor = currency switch
            {
                ECurrency.Dogecoin => (IExtractorService)_serviceProvider.GetService(typeof(DogeService)),
                _ => throw new InvalidOperationException(),
            };

            return extractor.ExtractPrice();
        }
    }
}
