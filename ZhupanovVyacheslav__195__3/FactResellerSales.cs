﻿namespace ZhupanovVyacheslav__195__3
{
    public class FactResellerSales : DimLine
    {
        public int ProductKey { get; set; }
        public int OrderDateKey { get; set; }
        public int ResellerKey { get; set; }
        public int EmployeeKey { get; set; }
        public int PromotionKey { get; set; }
        public int CurrencyKey { get; set; }
        public int SalesTerritoryKey { get; set; }
        public string SalesOrderNumber { get; set; }
        public byte SalesOrderLineNumber { get; set; }
        public short OrderQuantity { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public string CustomerPONumber { get; set; }

        public override string GetName => "FactResellerSales";

        public override int GetKey => 0;
    }
}
