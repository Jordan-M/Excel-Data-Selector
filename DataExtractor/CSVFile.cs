using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExtractor
{
    class CSVFile
    {
        List<string> file;
        public int Rows { get; private set; } = 0;
        public int Cols { get; private set; } = 0;

        public CSVFile(string filePath)
        {
            file = new List<string>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                file.Add(reader.ReadLine());
            }

            SetRowsAndCols();
        }

        public CSVFile(List<string> csvData)
        {
            file = csvData;
            SetRowsAndCols();
        } 

        public string[] GetRowAsArray(int row)
        {
            return file[row].Split(',');
        }

        public string GetRow(int row)
        {
            return file[row];
        }

        private void SetRowsAndCols()
        {
            if (file == null)
                return;

            Rows = file.Count - 1;
            Cols = GetRowAsArray(0).Length;
        }

    }
}
