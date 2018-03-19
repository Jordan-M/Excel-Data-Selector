using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.IO;

namespace DataExtractor
{
    class LINQDatabaseHandler
    {
        MutableDataTable csv;

        public LINQDatabaseHandler(MutableDataTable csv)
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

        public void SelectData(string column, string data)
        {
            IEnumerable<Row> selection = csv.Rows.Where(i => i.Values[csv.GetColumnIndex(column)] == data);

            using (StreamWriter csvStream = new StreamWriter("C:\\Users\\Jordan\\Desktop\\test.csv"))
            {
                foreach (Row r in selection)
                {
                    CsvWriter.RawWriteLine(r.Values, csvStream);
                }
            }

        }
    }
}
