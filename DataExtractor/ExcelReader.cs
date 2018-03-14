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
using DataAccess;

namespace DataExtractor
{
    static class ExcelReader
    {
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
            workBook.Close(true);
            Marshal.ReleaseComObject(workBook);

            //quit and release
            excel.Quit();
            Marshal.ReleaseComObject(excel);
        }

        public static MutableDataTable Read(string fileLocation)
        {
            Application excel = new Application();
            Workbook workBook = excel.Workbooks.Open(fileLocation);
            Worksheet sheet = workBook.Sheets[1];
            Range range = sheet.UsedRange;

            workBook.SaveAs(fileLocation + ".csv", XlFileFormat.xlCSV);

            CleanResources(excel, workBook, sheet, range);

            return DataAccess.DataTable.New.Read(fileLocation + ".csv");
           
        }
    }
}
