using HowMuchItCost.Library.Enumerador;
using HowMuchItCost.Library.Interfaces;
using HowMuchItCost.Library.Services.Extractor;
using Microsoft.Extensions.Caching.Distributed;
using System;

namespace HowMuchItCost.Library.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDistributedCache _distributedCache;

        public CurrencyService(IServiceProvider serviceProvider, IDistributedCache distributedCache)
        {
            _serviceProvider = serviceProvider;
            _distributedCache = distributedCache;
        }

        public decimal GetBRLPrice(ECurrency currency)
        {
            var key = currency.ToString();

            if (!decimal.TryParse(_distributedCache.GetString(key), out decimal price))
            {
                IExtractorService extractor = currency switch
                {
                    ECurrency.Dogecoin => (IExtractorService)_serviceProvider.GetService(typeof(DogecoinService)),
                    ECurrency.Bitcoin => (IExtractorService)_serviceProvider.GetService(typeof(BitcoinService)),
                    _ => throw new InvalidOperationException(),
                };

                price = extractor.ExtractPrice();
                _distributedCache.SetString(key, price.ToString());
            }

            return price;
        }
    }
}
