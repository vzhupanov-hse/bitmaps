namespace ZhupanovVyacheslav__195__3
{
    public class DimPromotion : DimLine
    {
        public int PromotionKey { get; set; }
        public int PromotionAlternateKey { get; set; }
        public string EnglishPromotionName { get; set; }
        public string EnglishPromotionType { get; set; }
        public string EnglishPromotionCategory { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int MinQty { get; set; }

        public override string GetName => "DimPromotion";

        public override int GetKey => PromotionKey;

        public DimPromotion(int promotionKey, int promotionAlternateKey, string englishPromotionName, string englishPromotionType,
            string englishPromotionCategory, string startDate, string endDate, int minQty)
        {
            PromotionKey = promotionKey;
            PromotionAlternateKey = promotionAlternateKey;
            EnglishPromotionCategory = englishPromotionCategory;
            EnglishPromotionName = englishPromotionName;
            EnglishPromotionType = englishPromotionType;
            StartDate = startDate;
            EndDate = endDate;
            MinQty = minQty;
        }
    }
}
