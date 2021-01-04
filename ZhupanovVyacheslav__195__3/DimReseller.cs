namespace ZhupanovVyacheslav__195__3
{
    public class DimReseller : DimLine
    {
        public int ResellerKey { get; set; }
        public string ResellerAlternateKey { get; set; }
        public string Phone { get; set; }
        public string BusinessType { get; set; }
        public string ResellerName { get; set; }
        public int NumberEmployees { get; set; }
        public string OrderFrequency { get; set; }
        public string ProductLine { get; set; }
        public string AddressLine1 { get; set; }
        public string BankName { get; set; }
        public int YearOpened { get; set; }

        public override string GetName => "DimReseller";

        public override int GetKey => ResellerKey;

        public DimReseller(int resellerKey, string resellerAlternateKey, string phone, string businessType, string resellerName,
            int numberEmployees, string orderFrequency, string productLine, string addressLine1, string bankName, int yearOpened)
        {
            ResellerAlternateKey = resellerAlternateKey;
            ResellerKey = resellerKey;
            Phone = phone;
            BusinessType = businessType;
            ResellerName = resellerName;
            NumberEmployees = numberEmployees;
            OrderFrequency = orderFrequency;
            ProductLine = productLine;
            AddressLine1 = addressLine1;
            BankName = bankName;
            YearOpened = yearOpened;
        }
    }
}
