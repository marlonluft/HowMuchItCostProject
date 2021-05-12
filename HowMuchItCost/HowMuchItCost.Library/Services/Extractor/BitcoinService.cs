namespace HowMuchItCost.Library.Services.Extractor
{
    public class BitcoinService : ExtractorBase
    {
        public override string CurrencyUrl => "https://br.investing.com/crypto/bitcoin/btc-brl";

        public override string CurrencyXPath => @"//*[@id=""last_last""]";
    }
}
