namespace ZhupanovVyacheslav__195__3
{
    public class DimCurrency : DimLine
    {
        public int CurrencyKey { get; set; }
        public string CurrencyAlternateKey { get; set; }
        public string CurrencyName { get; set; }

        public override string GetName => "DimCurrency";

        public override int GetKey => CurrencyKey;

        public DimCurrency(int currencyKey, string currencyAlternateKey, string currencyName)
        {
            CurrencyAlternateKey = currencyAlternateKey;
            CurrencyKey = currencyKey;
            CurrencyName = currencyName;
        }
    }
}
