using System.Collections.Generic;

namespace ZhupanovVyacheslav__195__3
{
    public class Compare
    {
        public void CompareValue((string, string, string, string) comparisonСharacteristics, List<Table> tables, Bitmap bitmap)
        {
            string value = string.Empty;
            if (!int.TryParse(comparisonСharacteristics.Item4, out int x))
            {
                for (int i = 2; i < comparisonСharacteristics.Item4.Length - 1; i++)
                {
                    value += comparisonСharacteristics.Item4[i];
                }
                comparisonСharacteristics.Item4 = value;
            }
            for (int i = 0; i < tables.Count; i++)
            {
                if (comparisonСharacteristics.Item1 == tables[i].GetName)
                {
                    switch (comparisonСharacteristics.Item3)
                    {
                        case "<":
                            foreach (var item in tables[i].GetTable)
                                if (int.Parse(item[comparisonСharacteristics.Item2]) < int.Parse(comparisonСharacteristics.Item4))
                                    bitmap.Set(item.GetKey, true);
                            break;
                        case ">":
                            foreach (var item in tables[i].GetTable)
                                if (int.Parse(item[comparisonСharacteristics.Item2]) > int.Parse(comparisonСharacteristics.Item4))
                                    bitmap.Set(item.GetKey, true);
                            break;
                        case "<=":
                            foreach (var item in tables[i].GetTable)
                                if (int.Parse(item[comparisonСharacteristics.Item2]) <= int.Parse(comparisonСharacteristics.Item4))
                                    bitmap.Set(item.GetKey, true);
                            break;
                        case ">=":
                            foreach (var item in tables[i].GetTable)
                                if (int.Parse(item[comparisonСharacteristics.Item2]) >= int.Parse(comparisonСharacteristics.Item4))
                                    bitmap.Set(item.GetKey, true);
                            break;
                        case "=":
                            {
                                foreach (var item in tables[i].GetTable)
                                    if (item[comparisonСharacteristics.Item2] == comparisonСharacteristics.Item4)
                                        bitmap.Set(item.GetKey, true);
                            }
                            break;
                        case "<>":
                            {
                                foreach (var item in tables[i].GetTable)
                                    if (item[comparisonСharacteristics.Item2] != comparisonСharacteristics.Item4)
                                        bitmap.Set(item.GetKey, true);
                            }
                            break;
                    }
                }
            }
        }

        public void CompareValuesFactResellerSales((string, string, string, string) comparisonСharacteristics, List<FactResellerSales> table, Bitmap bitmap)
        {
            string value = string.Empty;
            if (!int.TryParse(comparisonСharacteristics.Item4, out int x))
            {
                for (int i = 1; i < comparisonСharacteristics.Item4.Length - 1; i++)
                {
                    value += comparisonСharacteristics.Item4[i];
                }
                comparisonСharacteristics.Item4 = value;
            }
            switch (comparisonСharacteristics.Item3)
            {
                case "<":
                    for (int i = 1; i < table.Count; i++)
                        if (int.Parse(table[i][comparisonСharacteristics.Item2]) < int.Parse(comparisonСharacteristics.Item4))
                            bitmap.Set(i, true);
                    break;
                case ">":
                    for (int i = 0; i < table.Count; i++)
                        if (int.Parse(table[i][comparisonСharacteristics.Item2]) > int.Parse(comparisonСharacteristics.Item4))
                            bitmap.Set(i, true);
                    break;
                case "<=":
                    for (int i = 0; i < table.Count; i++)
                        if (int.Parse(table[i][comparisonСharacteristics.Item2]) <= int.Parse(comparisonСharacteristics.Item4))
                            bitmap.Set(i, true);
                    break;
                case ">=":
                    for (int i = 0; i < table.Count; i++)
                        if (int.Parse(table[i][comparisonСharacteristics.Item2]) >= int.Parse(comparisonСharacteristics.Item4))
                            bitmap.Set(i, true);
                    break;
                case "=":
                    for (int i = 0; i < table.Count; i++)
                        if (table[i][comparisonСharacteristics.Item2] == comparisonСharacteristics.Item4)
                            bitmap.Set(i, true);
                    break;
                case "<>":
                    for (int i = 0; i < table.Count; i++)
                        if (table[i][comparisonСharacteristics.Item2] != comparisonСharacteristics.Item4)
                            bitmap.Set(i, true);
                    break;
            }
        }
    }
}
