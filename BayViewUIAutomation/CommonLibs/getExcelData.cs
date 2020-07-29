using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace BayViewUIAutomation.CommonLibs
{

    public class GetExcelData
    {
        private static string FilePath = "D:\\QA\\VSBayViewUIAutomation\\BayViewUIAutomation\\DataResources\\TestProjectId.xlsx";

        private static string UploadFilePath = ConfigurationManager.AppSettings["UploadFilePath"];
        public static StringBuilder CsvFile = new StringBuilder();
        public static StringBuilder cellValue = new StringBuilder();
        public static string CsvFilePath = "D:\\QA\\VSBayViewUIAutomation\\BayViewUIAutomation\\DataResources\\TestProjectIdResult.csv";

        //Get Excel sheet all cell values
        //public void GetExcelValues(int rowNumber, string sheetName)
        //{
        //    var xApplication = new Excel.Application();
        //    xApplication.DisplayAlerts = false;
        //    var xWorkbook = xApplication.Workbooks.Open(FilePath, Notify: false);
        //    Excel.Worksheet xWorksheet = xWorkbook.Sheets[sheetName];
        //    var xRange = xWorksheet.UsedRange;
        //    var cellValue = "";
        //    int columnNumber;
        //    var colCount = xRange.Columns.Count;
        //    for (columnNumber = 1; columnNumber <= colCount; columnNumber++)
        //        if (xRange.Cells[rowNumber, columnNumber] != null && xRange.Cells[rowNumber, columnNumber].Value2 != null)
        //        {
        //            cellValue = xRange.Cells[rowNumber, columnNumber].Value2.ToString();
        //           // GetVariableNameAndSetValues(rowNumber, columnNumber, cellValue, sheetName);
        //            Console.WriteLine(cellValue);
        //            Console.ReadLine();
        //        }

        //    //cleanup
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();

        //    //release com objects to fully kill excel process from running in the background
        //    Marshal.ReleaseComObject(xRange);
        //    Marshal.ReleaseComObject(xWorksheet);

        //    //close and release
        //    xWorkbook.Close();
        //    Marshal.ReleaseComObject(xWorkbook);

        //    //quit and release
        //    xApplication.Quit();
        //    Marshal.ReleaseComObject(xApplication);
        //}


        public StringBuilder GetProjectIdList(int columnNumber, string sheetName)
        {
            var xApplication = new Excel.Application();
            xApplication.DisplayAlerts = false;
            var xWorkbook = xApplication.Workbooks.Open(FilePath, Notify: false);
            Excel.Worksheet xWorksheet = xWorkbook.Sheets[sheetName];
            var xRange = xWorksheet.UsedRange;
            var cellValue1 = "";
            StringBuilder cellValue = new StringBuilder(cellValue1);
            int rowNumber;
            var rowCountCount = xRange.Rows.Count;
            for (rowNumber = 2; rowNumber <= rowCountCount; rowNumber++)
                if (xRange.Cells[rowNumber, columnNumber] != null && xRange.Cells[rowNumber, columnNumber].Value2 != null)
                {
                    cellValue1 = xRange.Cells[rowNumber, columnNumber].Value2.ToString();
                    
                    // GetVariableNameAndSetValues(rowNumber, columnNumber, cellValue, sheetName);
                    //Console.WriteLine(cellValue);
                    //Console.ReadLine();
                    cellValue.Append(cellValue1).Append(',');
                }
            //Console.WriteLine("Done");
           // Console.ReadLine();
            
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xRange);
            Marshal.ReleaseComObject(xWorksheet);

            //close and release
            xWorkbook.Close();
            Marshal.ReleaseComObject(xWorkbook);

            //quit and release
            xApplication.Quit();
            Marshal.ReleaseComObject(xApplication);
            return cellValue;
        }


        public void ResultOfProjectId(int rowId, string result, string projectId)
        {

            if (File.Exists(CsvFilePath))
            {
                List<string> lines = File.ReadAllLines(CsvFilePath).ToList();

                //string result = "Pass";
                if (result.Equals("Pass"))
                {
                    //CsvFile.Append();
                    CsvFile.Append($"{projectId},{"Passed"},{Environment.NewLine}");
                    File.WriteAllText(CsvFilePath, CsvFile.ToString());
                }
                else if (result.Equals("Fail"))
                {
                    CsvFile.Append($"{projectId},{"Failed"}");
                    File.WriteAllText(CsvFilePath, CsvFile.ToString());
                }
            }
        }
    }
}
