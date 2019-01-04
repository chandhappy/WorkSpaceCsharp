using System;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace AzureDataCopy
{
    class Program
    {
        
       static void Main(string[] args)
        {
            string strCmdText;
            string SourceKey = "nA1XwHsi31dn7nFDnCmiWAdtbADr1DYD5OUn9R3vsZbo3FP2wibVVnlzJ4Q6/ZI01v8YdjLvZ8cycSbJweFISQ==";
            string DestKey = "u3np+WCtOJYSwawiVpb4hpvmzNfiwPDE92vf97smZWT73WsdtldjrFZpldQa2O4eI9eaSvqZyEGsjCjSV6Lf9A==";

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\INCBASHA\Desktop\Singapore Data Migration\AzureDataURLS.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                //write the value to the console
                if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 2] != null && xlRange.Cells[i, 1].Value2 != null && xlRange.Cells[i, 2].Value2 != null) { 
  
                    strCmdText = null;
                    strCmdText = "/k cd C:/Program Files (x86)/Microsoft SDKs/Azure/AzCopy" + "& AzCopy /Source:\"" + xlRange.Cells[i, 1].Value2.ToString() + "\" /Dest:\"" + xlRange.Cells[i, 2].Value2.ToString() + "\" /SourceKey:" + SourceKey + " /DestKey:" + DestKey + "  /Y /V:C:/Desktop/testServer/azcopy_" + System.DateTime.Now.ToShortDateString() + ".log";
                    Console.WriteLine(strCmdText);
                    //System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                    System.Threading.Thread.Sleep(8000);
                    Array.ForEach(Process.GetProcessesByName("cmd"), x => x.Kill());
                    strCmdText = null;
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
           
            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            Console.ReadKey();

            
        }


    }
}
