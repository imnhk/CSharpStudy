using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace COMInterop
{
    class Program
    {
        public static void OldWay(string[,] data, string savePath)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)excelApp.ActiveSheet;

            for(int i=0; i<data.GetLength(0); i++)
            {
                ((Excel.Range)worksheet.Cells[i + 1, 1]).Value2 = data[i, 0];
                ((Excel.Range)worksheet.Cells[i + 1, 2]).Value2 = data[i, 1];
            }

            worksheet.SaveAs(savePath + "\\ shpark-book-old.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            excelApp.Quit();
        }

        public static void NewWay(string[,] data, string savePath)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            Excel._Worksheet worksheet = excelApp.ActiveSheet;

            for(int i=0; i<data.GetLength(0); i++)
            {
                worksheet.Cells[i + 1, 1] = data[i, 0];
                worksheet.Cells[i + 1, 2] = data[i, 1];
            }

            worksheet.SaveAs(savePath + "\\ shpark-book-dynamic.xlsx");
            excelApp.Quit();
        }

        static void Main(string[] args)
        {
            string savePath = System.IO.Directory.GetCurrentDirectory();
            string[,] array = new string[,]
            {
                {"뇌알고리즘", "2009" },
                {"C# 4.0", "2011" },
                {"C# 5.0", "2013" }
            };

            Console.WriteLine("Creating Excel document in old way...");
            OldWay(array, savePath);


            Console.WriteLine("Creating Excel document in new way...");
            NewWay(array, savePath);
        }
    }
}
