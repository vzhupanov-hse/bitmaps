using System.Collections.Generic;
using System.IO;

namespace ZhupanovVyacheslav__195__3
{
    class Output
    {
        string outputString;
        public void CreateOutputString(string outputFotmat, Bitmap resBitmap, string data_path)
        {
            string[] arOutputFotmat = outputFotmat.Split(',');
            List<List<string>> allvalues = new List<List<string>>();
            for (int i = 0; i < arOutputFotmat.Length; i++)
            {
                List<string> value = new List<string>();
                using (StreamReader sr = new StreamReader(data_path + arOutputFotmat[i] + ".csv"))
                {
                    string input = sr.ReadLine();
                    int j = 1;
                    while (input != null)
                    {
                        if (resBitmap.Get(j))
                            value.Add(input);
                        j++;
                        input = sr.ReadLine();
                    }
                }
                allvalues.Add(value);
            }
            List<string> outputRes = allvalues[0];
            for (int i = 1; i < allvalues.Count; i++)
                for (int j = 0; j < allvalues[i].Count; j++)
                    outputRes[j] += "|" + allvalues[i][j];
            for (int i = 0; i < outputRes.Count; i++)
                outputString += outputRes[i] + "\n";
        }

        public void WriteFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(outputString);
            }
        }
    }
}
