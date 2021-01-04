using System;
using System.Collections.Generic;
using System.IO;

namespace ZhupanovVyacheslav__195__3
{
    class Program
    {
        static string OutputFormat { get; set; }
        static (string, string, string, string)[] comparisonСharacteristics;
        static List<FactResellerSales> resellerSales;
        static List<Table> tables;
        static Compare compare;
        static Bitmaps bitmaps;
        static string output_path;
        static string input_path;
        static string data_path;

        static void Main(string[] args)
        {
            if (args.Length == 3)
            {
                CreateInputPath(args[1]);
                CreateOutputPath(args[2]);
                CreateDataPath(args[0]);
                ParseFile(input_path);
                tables = new List<Table>();
                for (int i = 0; i < comparisonСharacteristics.Length; i++)
                {
                    if (comparisonСharacteristics[i].Item1[0] != 'F')
                        tables.Add(new Table(comparisonСharacteristics[i].Item1, data_path));
                    else
                    {
                        if (resellerSales == null)
                        {
                            resellerSales = new List<FactResellerSales>();
                            AddFactResellerSales(i, 0);
                        }
                        else
                            AddFactResellerSales(i, 1);
                    }
                }
                compare = new Compare();
                bitmaps = new Bitmaps();
                AddBitmaps();
                InvisibleJoin join = new InvisibleJoin();
                join.CreateNewBitmaps(bitmaps, data_path);
                join.AndBitmaps(bitmaps);
                Output output = new Output();
                output.CreateOutputString(OutputFormat, join.ResBitmap, data_path);
                output.WriteFile(output_path);
            }
            else
                Console.WriteLine("Что-то не так с аргументами!");
        }

        private static void CreateInputPath(string path)
        {
            if (path[1] != ':')
                input_path = "input\\" + path;
            else
                input_path = path;
        }

        private static void CreateDataPath(string path)
        {
            if (path[1] != ':')
                data_path = "data\\";
            else
                data_path = path + "\\";
        }

        private static void CreateOutputPath(string path)
        {
            if (path[1] != ':')
                output_path = "output\\" + path;
            else
                output_path = path;
        }

        private static void AddBitmaps()
        {
            for (int i = 0; i < comparisonСharacteristics.Length; i++)
            {
                if (comparisonСharacteristics[i].Item1[0] != 'F')
                    switch (comparisonСharacteristics[i].Item1)
                    {
                        case "DimSalesTerritory":
                            compare.CompareValue(comparisonСharacteristics[i], tables, bitmaps.DimSalesTerritoryBitmap);
                            break;
                        case "DimEmployee":
                            compare.CompareValue(comparisonСharacteristics[i], tables, bitmaps.DimEmployeeBitmap);
                            break;
                        case "DimDate":
                            compare.CompareValue(comparisonСharacteristics[i], tables, bitmaps.DimDateBitmap);
                            break;
                        case "DimProduct":
                            compare.CompareValue(comparisonСharacteristics[i], tables, bitmaps.DimProductBitmap);
                            break;
                        case "DimReseller":
                            compare.CompareValue(comparisonСharacteristics[i], tables, bitmaps.DimResellerBitmap);
                            break;
                        case "DimCurrency":
                            compare.CompareValue(comparisonСharacteristics[i], tables, bitmaps.DimCurrencyBitmap);
                            break;
                        case "DimPromotion":
                            compare.CompareValue(comparisonСharacteristics[i], tables, bitmaps.DimPromotionBitmap);
                            break;
                    }
                else
                    compare.CompareValuesFactResellerSales(comparisonСharacteristics[i], resellerSales, bitmaps.FactResellerSalesBitmap);
            }
        }

        private static void AddFactResellerSales(int i, int flag)
        {
            switch (comparisonСharacteristics[i].Item2)
            {
                case "CustomerPONumber":
                    CustomerPONumberAdd(i, flag);
                    break;
                case "CarrierTrackingNumber":
                    CarrierTrackingNumberAdd(i, flag);
                    break;
                case "OrderQuantity":
                    OrderQuantityAdd(i, flag);
                    break;
                case "SalesOrderLineNumber":
                    SalesOrderLineNumberAdd(i, flag);
                    break;
                case "SalesOrderNumber":
                    SalesOrderNumberAdd(i, flag);
                    break;
                case "SalesTerritoryKey":
                    SalesTerritoryKeyAdd(i, flag);
                    break;
                case "CurrencyKey":
                    CurrencyKeyAdd(i, flag);
                    break;
                case "PromotionKey":
                    PromotionKeyAdd(i, flag);
                    break;
                case "EmployeeKey":
                    EmployeeKeyAdd(i, flag);
                    break;
                case "ProductKey":
                    ProductKeyAdd(i, flag);
                    break;
                case "OrderDateKey":
                    OrderDateKeyAdd(i, flag);
                    break;
                case "ResellerKey":
                    ResellerKeyAdd(i, flag);
                    break;
            }
        }

        private static void OrderDateKeyAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                {
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.OrderDateKey = int.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].OrderDateKey = int.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void ResellerKeyAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.ResellerKey = int.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].ResellerKey = int.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void ProductKeyAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.ProductKey = int.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].ProductKey = int.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void EmployeeKeyAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.EmployeeKey = int.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].EmployeeKey = int.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void PromotionKeyAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.PromotionKey = int.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].PromotionKey = int.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void CurrencyKeyAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.CurrencyKey = int.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].CurrencyKey = int.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void SalesTerritoryKeyAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.SalesTerritoryKey = int.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].SalesTerritoryKey = int.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void SalesOrderNumberAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.SalesOrderNumber = input;
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].SalesOrderNumber = input;
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void SalesOrderLineNumberAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.SalesOrderLineNumber = byte.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].SalesOrderLineNumber = byte.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void OrderQuantityAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.OrderQuantity = short.Parse(input);
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].OrderQuantity = short.Parse(input);
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void CarrierTrackingNumberAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.CarrierTrackingNumber = input;
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].CarrierTrackingNumber = input;
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void CustomerPONumberAdd(int i, int flag)
        {
            using (StreamReader sr = new StreamReader(data_path + comparisonСharacteristics[i].Item1 + "." + comparisonСharacteristics[i].Item2 + ".csv"))
            {
                string input = sr.ReadLine();
                if (flag == 0)
                    while (input != null)
                    {
                        FactResellerSales item = new FactResellerSales();
                        item.CustomerPONumber = input;
                        resellerSales.Add(item);
                        input = sr.ReadLine();
                    }
                else
                {
                    for (int j = 0; j < resellerSales.Count; j++)
                    {
                        resellerSales[j].CustomerPONumber = input;
                        input = sr.ReadLine();
                    }
                }
            }
        }

        private static void ParseFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                OutputFormat = sr.ReadLine();
                int count = int.Parse(sr.ReadLine());
                comparisonСharacteristics = new (string, string, string, string)[count];
                for (int i = 0; i < count; i++)
                    comparisonСharacteristics[i] = SplitString(sr.ReadLine());
            }
        }

        private static (string, string, string, string) SplitString(string val)
        {
            string table = string.Empty;
            string column = string.Empty;
            string value = string.Empty;
            int i = 0;
            while (val[i] != '.')
            {
                table += val[i];
                i++;
            }
            i++;
            while (val[i] != ' ')
            {
                column += val[i];
                i++;
            }
            string sign = val[++i].ToString();
            i++;
            if (val[i] != ' ')
            {
                sign += val[i];
                i++;
            }
            while (i < val.Length)
            {
                value += val[i];
                i++;
            }
            return (table, column, sign, value);
        }
    }
}
