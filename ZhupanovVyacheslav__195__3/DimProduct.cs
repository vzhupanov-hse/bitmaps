namespace ZhupanovVyacheslav__195__3
{
    public class DimProduct : DimLine
    {
        public int ProductKey { get; set; }
        public string ProductAlternateKey { get; set; }
        public string EnglishProductName { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public string SizeRange { get; set; }
        public int DaysToManufacture { get; set; }
        public string StartDate { get; set; }

        public override string GetName => "DimProduct";

        public override int GetKey => ProductKey;

        public DimProduct(int productKey, string productAlternateKey, string englishProductName, string color, short safetyStockLevel,
            short reorderPoint, string sizeRange, int daysToManufacture, string startDate)
        {
            ProductKey = productKey;
            ProductAlternateKey = productAlternateKey;
            EnglishProductName = englishProductName;
            Color = color;
            SafetyStockLevel = safetyStockLevel;
            ReorderPoint = reorderPoint;
            SizeRange = sizeRange;
            DaysToManufacture = daysToManufacture;
            StartDate = startDate;
        }
    }
}
