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
        /// <summary>
        /// Reads in an excel file and creates a List of strings in CSV format for each row
        /// </summary>
        /// <param name="filePath">Path to an excel file</param>
        /// <returns>A list of csv style strings</returns>
        public static List<String> Read(string filePath) 
        {
            Application excel = new Application();
            Workbook workBook;

            try
            {
                workBook = excel.Workbooks.Open(filePath);
            }
            catch (COMException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            Worksheet sheet = workBook.Sheets[1];
            Range range = sheet.UsedRange;

            int rows = range.Rows.Count;
            int cols = range.Columns.Count;

            List<string> valueList = new List<string>();
            StringBuilder line = new StringBuilder();

            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    var cellObject = range.Cells[i, j];
                    var cellValue = range.Cells[i, j].Value2;

                    if (cellObject != null)
                    {
                        DateTime time;
                        string content;
                        if (cellValue == null)
                        {
                            content = CleanString("");
                        }
                        else if (DateTime.TryParse(cellObject.Value.ToString(), out time))
                        {
                            content = CleanString(cellObject.Value.ToShortDateString());
                        }
                        else
                        {
                            content = CleanString(cellValue.ToString());
                        }
                        line.Append(content);
                        line.Append(',');
                    }
                }
                line.Length--; // Remove the last comma
                valueList.Add(line.ToString());
                line.Clear();
            }

            CleanResources(excel, workBook, sheet, range);

            return valueList;
        }

        /// <summary>
        /// Cleans up the enviornment and frees all resources
        /// </summary>
        /// <param name="excel">Application to release</param>
        /// <param name="workBook">Workbook to release</param>
        /// <param name="sheet">Sheet to release</param>
        /// <param name="range">Range to release</param>
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

        /// <summary>
        /// Cleans a string to make it CSV friendly.
        /// Things that make a string csv friendly are:
        ///     1.) Surrounded by quotes. This forces all commas in the string to be escaped
        ///     2.) Any quoutes inside the string should be followed by another quote to escape it
        /// </summary>
        /// <param name="dirtyString">A string to make csv friendly</param>
        /// <returns>The clean string</returns>
        private static string CleanString(string dirtyString)
        {
            //DEBUG
            //double d = double.Parse(dirtyString);
            //DateTime conv = DateTime.FromOADate(d);
            //return conv.ToShortDateString();

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
