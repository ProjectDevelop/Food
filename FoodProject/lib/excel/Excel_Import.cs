using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using FoodProject.DAL.Repositories;
using FoodProject.DAL;

namespace FoodProject.lib.excel
{
   public class Excel_Import
    {
        BarcodeRepository barcodeRepository;
        Barcode barcode;
        public Excel_Import()
        {
             barcodeRepository = new BarcodeRepository();
            barcode = new Barcode();
        }

        public void ReadExcel(string filepath)
        {
           /*Application xlApp = new Application();
           Workbook xlWorkbook = xlApp.Workbooks.Open(filepath);
           _Worksheet xlWorksheet = xlWorkbook.Sheets[1];
           Range xlRange = xlWorksheet.UsedRange;
        

           int rowCount = xlRange.Rows.Count;
           int colCount = xlRange.Columns.Count;

            for (int i = 1; i <= rowCount; i++)
            {
                if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                {
                    barcode.Barcode1 = xlRange.Cells[i, 1].Value2.ToString();
                }
                if (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null)
                {
                    barcode.ProductName = xlRange.Cells[i, 2].Value2.ToString();
                }
                barcodeRepository.Add(barcode);

                
            }
            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:  
            //  never use two dots, all COM objects must be referenced and released individually  
            //  ex: [somthing].[something].[something] is bad  

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            */
        }

    }
}
