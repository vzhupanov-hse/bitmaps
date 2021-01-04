namespace ZhupanovVyacheslav__195__3
{
    public class DimDate : DimLine
    {
        public int DateKey { get; set; }
        public string FullDateAlternateKey { get; set; }
        public byte DayNumberOfWeek { get; set; }
        public string EnglishDayNameOfWeek { get; set; }
        public byte DayNumberOfMonth { get; set; }
        public short DayNumberOfYear { get; set; }
        public byte WeekNumberOfYear { get; set; }
        public string EnglishMonthName { get; set; }
        public byte MonthNumberOfYear { get; set; }
        public byte CalendarQuarter { get; set; }
        public short CalendarYear { get; set; }
        public byte CalendarSemester { get; set; }
        public byte FiscalQuarter { get; set; }
        public short FiscalYear { get; set; }
        public byte FiscalSemester { get; set; }

        public override string GetName => "DimDate";

        public override int GetKey => DateKey;

        public DimDate(int dateKey, string fullDateAlternateKey, byte dayNumberOfWeek, string englishDayNameOfWeek, byte dayNumberOfMonth,
            short dayNumberOfYear, byte weekNumberOfYear, string englishMonthName, byte monthNumberOfYear, byte calendarQuarter, short calendarYear,
            byte calendarSemester, byte fiscalQuarter, short fiscalYear, byte fiscalSemester)
        {
            DateKey = dateKey;
            FullDateAlternateKey = fullDateAlternateKey;
            DayNumberOfWeek = dayNumberOfWeek;
            EnglishDayNameOfWeek = englishDayNameOfWeek;
            DayNumberOfMonth = dayNumberOfMonth;
            DayNumberOfYear = dayNumberOfYear;
            WeekNumberOfYear = weekNumberOfYear;
            EnglishMonthName = englishMonthName;
            MonthNumberOfYear = monthNumberOfYear;
            CalendarQuarter = calendarQuarter;
            CalendarYear = calendarYear;
            CalendarSemester = calendarSemester;
            FiscalQuarter = fiscalQuarter;
            FiscalYear = fiscalYear;
            FiscalSemester = fiscalSemester;
        }
    }
}
