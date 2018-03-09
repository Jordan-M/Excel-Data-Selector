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
            workBook.SaveAs(filePath + ".csv", XlFileFormat.xlCSVWindows);
            workBook.Close(true);
            excel.Quit();

            List<string> valueList = null;
            using (StreamReader sr = new StreamReader(filePath + ".csv"))
            {
                string content = sr.ReadToEnd();
                valueList = new List<string>(content.Split(new string[] { "\r\n" }, StringSplitOptions.None));
            }

            new FileInfo(filePath + ".csv").Delete();

           return valueList;
        }
    }
}
