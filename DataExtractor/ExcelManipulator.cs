using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.IO;

namespace DataExtractor
{
    class ExcelManipulator
    {
        MutableDataTable csv;

        public ExcelManipulator(MutableDataTable csv)
        {
            this.csv = csv;
        }

        public string[] RetrieveHeaders()
        {
            string[] headers = new string[csv.ColumnNames.Count()];

            for (int i = 0; i < headers.Length; i++)
            {
                headers[i] = csv.ColumnNames.ElementAt(i);
            }

            return headers;
        }

        public List<string> RetrieveDataFromHeader(string header)
        {
            string[] columnData = csv.GetColumn(header).Values;
            return columnData.Distinct().ToList();
        }

        public MemoryStream SelectData(string column, string data)
        {
            IEnumerable<Row> selection = csv.Rows.Where(i => i.Values[csv.GetColumnIndex(column)] == data);

            MemoryStream csvStream = new MemoryStream();

            StreamWriter sw = new StreamWriter(csvStream);
            
            foreach (Row r in selection)
            {
                CsvWriter.RawWriteLine(r.Values, sw);
            }
            

            return csvStream;
        }
    }
}
