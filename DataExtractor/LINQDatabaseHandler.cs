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

            var compactCSV = DataAccess.DataTable.New.ReadFromString("");
            
            foreach (Row r in selection)
            {
                compactCSV.
            }

        }
    }
}
