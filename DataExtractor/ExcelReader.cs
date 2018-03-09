using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Runtime.InteropServices;

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
                        string content = (cellValue == null) ? "" : cellValue.ToString();
                        line.Append(CleanString(content));
                        line.Append(',');
                    }
                }
                line.Length--; // Remove the last comma
                valueList.Add(line.ToString());
                Console.WriteLine(line.ToString());
                line.Clear();
            }

            CleanResources(excel, workBook, sheet, range);

            return valueList;
        }

        private static void CleanResources(Application excel, Workbook workBook, Worksheet sheet, Range range)
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(range);
            Marshal.ReleaseComObject(sheet);

            //close and release
            workBook.Close();
            Marshal.ReleaseComObject(workBook);

            //quit and release
            excel.Quit();
            Marshal.ReleaseComObject(excel);
        }

        private static string CleanString(string dirtyString)
        {
            StringBuilder cleanString = new StringBuilder();

            cleanString.Append('"'); // All of our string should start with a "

            foreach (char c in dirtyString)
            {
                cleanString.Append(c);
                if (c == '"')
                {
                    cleanString.Append(c);
                }
            }

            cleanString.Append('"'); // All of our string should end with a "

            return cleanString.ToString();
        }
    }
}
