using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadExcelData
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<Sales> excelData = new List<Sales>();
            string file = @"..\..\..\Resources\SalesData.xlsx";

            if (File.Exists(file))
            {
                using (var package = new ExcelPackage(new FileInfo(file)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                    {
                        excelData.Add(new Sales(
                            worksheet.Cells[i, 1].Value.ToString(),
                            worksheet.Cells[i, 2].Value.ToString(),
                            (int)(double)worksheet.Cells[i, 3].Value,
                            (double)worksheet.Cells[i, 4].Value
                            ));
                    }
                }
            }
            else
            {
                throw new FileNotFoundException("There is no such file in the given directory");
            }

            Console.WriteLine($"You have {excelData.Count} sales. Total Sales is {excelData.Sum(s => s.UnitCost)}\n.");
            excelData.Where(s => s.Unit >= 10).OrderBy(s => s.UnitCost).OrderBy(s => s.Rep).ToList().ForEach(s => Console.WriteLine(s));
        }
    }
}
