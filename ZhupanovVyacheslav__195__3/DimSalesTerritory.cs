namespace ZhupanovVyacheslav__195__3
{
    public class DimSalesTerritory : DimLine
    {
        public int SalesTerritoryKey { get; set; }
        public int SalesTerritoryAlternateKey { get; set; }
        public string SalesTerritoryRegion { get; set; }
        public string SalesTerritoryCountry { get; set; }
        public string SalesTerritoryGroup { get; set; }

        public override string GetName => "DimSalesTerritory";

        public override int GetKey => SalesTerritoryKey;

        public DimSalesTerritory(int salesTerritoryKey, int salesTerritoryAlternateKey, string salesTerritoryRegion, string salesTerritoryCountry,
            string salesTerritoryGroup)
        {
            SalesTerritoryAlternateKey = salesTerritoryAlternateKey;
            SalesTerritoryCountry = salesTerritoryCountry;
            SalesTerritoryGroup = salesTerritoryGroup;
            SalesTerritoryKey = salesTerritoryKey;
            SalesTerritoryRegion = salesTerritoryRegion;
        }

        public override string ToString() => $"{SalesTerritoryKey} {SalesTerritoryAlternateKey} {SalesTerritoryRegion} {SalesTerritoryCountry} {SalesTerritoryGroup}";
    }
}
