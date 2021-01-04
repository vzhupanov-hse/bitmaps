using System.IO;

namespace ZhupanovVyacheslav__195__3
{
    class InvisibleJoin
    {
        public Bitmap ResBitmap { get; set; }

        public void CreateNewBitmaps(Bitmaps bitmaps, string data_path)
        {
            if (!bitmaps.DimCurrencyBitmap.IsEmpty)
            {
                bitmaps.CurrencyKeys = ParseColumn(data_path + "FactResellerSales.CurrencyKey.csv", bitmaps.DimCurrencyBitmap);
                ResBitmap = bitmaps.CurrencyKeys;
            }
            if (!bitmaps.DimDateBitmap.IsEmpty)
            {
                bitmaps.DateKeys = ParseColumn(data_path + "FactResellerSales.OrderDateKey.csv", bitmaps.DimDateBitmap);
                ResBitmap = bitmaps.DateKeys;
            }
            if (!bitmaps.DimEmployeeBitmap.IsEmpty)
            {
                bitmaps.EmployeeKeys = ParseColumn(data_path + "FactResellerSales.EmployeeKey.csv", bitmaps.DimEmployeeBitmap);
                ResBitmap = bitmaps.EmployeeKeys;
            }
            if (!bitmaps.DimProductBitmap.IsEmpty)
            {
                bitmaps.ProductKeys = ParseColumn(data_path + "FactResellerSales.ProductKey.csv", bitmaps.DimProductBitmap);
                ResBitmap = bitmaps.ProductKeys;
            }
            if (!bitmaps.DimPromotionBitmap.IsEmpty)
            {
                bitmaps.PromotionKeys = ParseColumn(data_path + "FactResellerSales.PromotionKey.csv", bitmaps.DimPromotionBitmap);
                ResBitmap = bitmaps.PromotionKeys;
            }
            if (!bitmaps.DimResellerBitmap.IsEmpty)
            {
                bitmaps.ResellerKeys = ParseColumn(data_path + "FactResellerSales.ResellerKey.csv", bitmaps.DimResellerBitmap);
                ResBitmap = bitmaps.ResellerKeys;
            }
            if (!bitmaps.DimSalesTerritoryBitmap.IsEmpty)
            {
                bitmaps.SalesTerritoryKeys = ParseColumn(data_path + "FactResellerSales.SalesTerritoryKey.csv", bitmaps.DimSalesTerritoryBitmap);
                ResBitmap = bitmaps.SalesTerritoryKeys;
            }
        }

        public Bitmap ParseColumn(string path, Bitmap bitmap)
        {
            Bitmap new_bitmap = new RoaringBitmap();
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                int i = 1;
                while (input != null)
                {
                    if (bitmap.Get(int.Parse(input)))
                        new_bitmap.Set(i, true);
                    i++;
                    input = sr.ReadLine();
                }
            }
            return new_bitmap;
        }

        public void AndBitmaps(Bitmaps bitmaps)
        {
            if (bitmaps.SalesTerritoryKeys != null)
                ResBitmap.And(bitmaps.SalesTerritoryKeys);
            if (bitmaps.ResellerKeys != null)
                ResBitmap.And(bitmaps.ResellerKeys);
            if (bitmaps.PromotionKeys != null)
                ResBitmap.And(bitmaps.PromotionKeys);
            if (bitmaps.ProductKeys != null)
                ResBitmap.And(bitmaps.ProductKeys);
            if (!bitmaps.FactResellerSalesBitmap.IsEmpty)
                ResBitmap.And(bitmaps.FactResellerSalesBitmap);
            if (bitmaps.EmployeeKeys != null)
                ResBitmap.And(bitmaps.EmployeeKeys);
            if (bitmaps.DateKeys != null)
                ResBitmap.And(bitmaps.DateKeys);
            if (bitmaps.CurrencyKeys != null)
                ResBitmap.And(bitmaps.CurrencyKeys);
        }
    }
}
