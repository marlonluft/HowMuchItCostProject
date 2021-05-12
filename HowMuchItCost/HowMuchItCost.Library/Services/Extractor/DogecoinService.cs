namespace HowMuchItCost.Library.Services.Extractor
{
    public class DogecoinService : ExtractorBase
    {
        public override string CurrencyUrl => "https://br.investing.com/crypto/dogecoin/doge-brl";

        public override string CurrencyXPath => @"//*[@id=""last_last""]";
    }
}
