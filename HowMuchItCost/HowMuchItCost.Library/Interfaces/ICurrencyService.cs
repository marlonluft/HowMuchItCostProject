using HowMuchItCost.Library.Enumerador;

namespace HowMuchItCost.Library.Interfaces
{
    public interface ICurrencyService
    {
        decimal GetBRLPrice(ECurrency currency);
    }
}
