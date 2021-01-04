namespace ZhupanovVyacheslav__195__3
{
    public class Bitmaps
    {
        public Bitmap DimProductBitmap { get; set; }
        public Bitmap DimResellerBitmap { get; set; }
        public Bitmap DimCurrencyBitmap { get; set; }
        public Bitmap DimPromotionBitmap { get; set; }
        public Bitmap DimSalesTerritoryBitmap { get; set; }
        public Bitmap DimEmployeeBitmap { get; set; }
        public Bitmap DimDateBitmap { get; set; }
        public Bitmap FactResellerSalesBitmap { get; set; }
        public Bitmap CurrencyKeys { get; set; }
        public Bitmap ProductKeys { get; set; }
        public Bitmap ResellerKeys { get; set; }
        public Bitmap PromotionKeys { get; set; }
        public Bitmap SalesTerritoryKeys { get; set; }
        public Bitmap EmployeeKeys { get; set; }
        public Bitmap DateKeys { get; set; }

        public Bitmaps()
        {
            DimCurrencyBitmap = new RoaringBitmap();
            DimDateBitmap = new RoaringBitmap();
            DimEmployeeBitmap = new RoaringBitmap();
            DimProductBitmap = new RoaringBitmap();
            DimPromotionBitmap = new RoaringBitmap();
            DimResellerBitmap = new RoaringBitmap();
            DimSalesTerritoryBitmap = new RoaringBitmap();
            FactResellerSalesBitmap = new RoaringBitmap();
        }
    }
}
