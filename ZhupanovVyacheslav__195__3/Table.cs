using System.Collections.Generic;
using System.IO;

namespace ZhupanovVyacheslav__195__3
{
    public class Table
    {
        List<DimLine> lines;

        public Table(string tablePath, string data_path)
        {
            lines = new List<DimLine>();
            ParseTable(tablePath + ".csv", data_path);
        }

        public string GetName { get; private set; }

        public List<DimLine> GetTable => lines;

        private void DimSalesTerritoryAdd(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] characteristics = input.Split('|');
                    lines.Add(new DimSalesTerritory(int.Parse(characteristics[0]), int.Parse(characteristics[1]), characteristics[2], characteristics[3], characteristics[4]));
                    input = sr.ReadLine();
                }
            }
        }

        private void DimEmployeeAdd(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] characteristics = input.Split('|');
                    lines.Add(new DimEmployee(int.Parse(characteristics[0]), characteristics[1], characteristics[2], characteristics[3],
                        characteristics[4], characteristics[5], characteristics[6], characteristics[7], characteristics[8], characteristics[9],
                        byte.Parse(characteristics[10]), short.Parse(characteristics[11]), short.Parse(characteristics[12]), characteristics[13],
                        characteristics[14]));
                    input = sr.ReadLine();
                }
            }
        }

        private void DimDateAdd(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] characteristics = input.Split('|');
                    lines.Add(new DimDate(int.Parse(characteristics[0]), characteristics[1], byte.Parse(characteristics[2]), characteristics[3],
                        byte.Parse(characteristics[4]), short.Parse(characteristics[5]), byte.Parse(characteristics[6]), characteristics[7],
                        byte.Parse(characteristics[8]), byte.Parse(characteristics[9]), short.Parse(characteristics[10]), byte.Parse(characteristics[11]),
                        byte.Parse(characteristics[12]), short.Parse(characteristics[13]), byte.Parse(characteristics[14])));
                    input = sr.ReadLine();
                }
            }
        }

        private void DimProductAdd(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] characteristics = input.Split('|');
                    lines.Add(new DimProduct(int.Parse(characteristics[0]), characteristics[1], characteristics[2], characteristics[3],
                        short.Parse(characteristics[4]), short.Parse(characteristics[5]), characteristics[6], int.Parse(characteristics[7]), characteristics[8]));
                    input = sr.ReadLine();
                }
            }
        }

        private void DimResellerAdd(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] characteristics = input.Split('|');
                    lines.Add(new DimReseller(int.Parse(characteristics[0]), characteristics[1], characteristics[2], characteristics[3],
                        characteristics[4], int.Parse(characteristics[5]), characteristics[6], characteristics[7], characteristics[8],
                        characteristics[9], int.Parse(characteristics[10])));
                    input = sr.ReadLine();
                }
            }
        }

        private void DimCurrencyAdd(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] characteristics = input.Split('|');
                    lines.Add(new DimCurrency(int.Parse(characteristics[0]), characteristics[1], characteristics[2]));
                    input = sr.ReadLine();
                }
            }
        }

        private void DimPromotionAdd(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string input = sr.ReadLine();
                while (input != null)
                {
                    string[] characteristics = input.Split('|');
                    lines.Add(new DimPromotion(int.Parse(characteristics[0]), int.Parse(characteristics[1]), characteristics[2], characteristics[3],
                        characteristics[4], characteristics[5], characteristics[6], int.Parse(characteristics[7])));
                    input = sr.ReadLine();
                }
            }
        }

        private void ParseTable(string tablePath, string data_path)
        {
            switch (tablePath)
            {
                case "DimSalesTerritory.csv":
                    DimSalesTerritoryAdd(data_path + tablePath);
                    GetName = "DimSalesTerritory";
                    break;
                case "DimEmployee.csv":
                    DimEmployeeAdd(data_path + tablePath);
                    GetName = "DimEmployee";
                    break;
                case "DimDate.csv":
                    DimDateAdd(data_path + tablePath);
                    GetName = "DimDate";
                    break;
                case "DimProduct.csv":
                    DimProductAdd(data_path + tablePath);
                    GetName = "DimProduct";
                    break;
                case "DimReseller.csv":
                    DimResellerAdd(data_path + tablePath);
                    GetName = "DimReseller";
                    break;
                case "DimCurrency.csv":
                    DimCurrencyAdd(data_path + tablePath);
                    GetName = "DimCurrency";
                    break;
                case "DimPromotion.csv":
                    DimPromotionAdd(data_path + tablePath);
                    GetName = "DimPromotion";
                    break;
            }
        }
    }
}
