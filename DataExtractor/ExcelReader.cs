using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace DataExtractor
{
    static class ExcelReader
    {
        public static List<String> Read(string filePath)
        {
            Application excel = new Application();
            Workbook workBook = excel.Workbooks.Open(filePath);
            Worksheet sheet = workBook.Sheets[1];
            Range range = sheet.UsedRange;

            int rows = range.Rows.Count;
            int cols = range.Columns.Count;

            List<string> valueList = new List<string>();
            StringBuilder line = new StringBuilder();

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    var cellObject = range.Cells[i, j];
                    var cellValue = range.Cells[i, j].Value2;

                    if (cellObject != null)
                    {
                        string contentFormat = "\"{0}\"";
                        string content = (cellValue == null) ? "" : cellValue.ToString();
                        line.Append(String.Format(contentFormat, content));
                        line.Append(',');
                    }
                }
                line.Length--; // Remove the last comma
                valueList.Add(line.ToString());
                Console.WriteLine(line.ToString());
                line.Clear();
            }

            workBook.Close(true);
            excel.Quit();

           return valueList;
        }
    }
}
