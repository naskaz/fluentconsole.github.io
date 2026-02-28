using System;
using VelocityExcel.Api;

namespace ComplexExcelReader
{
  internal class ComplexExcelReader
  {
    static void Main(string[] args)
    {

      Console.WriteLine("ComplexExcelReader Program Demonstrating How to Read any Excel file using VelocityExcel");
      Console.WriteLine("==========================================");

      string filePath = @"yourExcelFile.xlsx";

      try
      {
        using var reader = new ExcelReader(filePath);

        Console.WriteLine("========================================");
        Console.WriteLine("Excel File Loaded Successfully");
        Console.WriteLine($"Worksheet Count: {reader.WorksheetCount}");
        Console.WriteLine("========================================");

        foreach (var sheetName in reader.WorksheetNames)
        {
          Console.WriteLine($"\nReading Worksheet: {sheetName}");
          Console.WriteLine("----------------------------------------");

          using var worksheet = reader.OpenWorksheet(sheetName);

          long rowNumber = 0;

          foreach (var row in worksheet.ReadRows())
          {
            rowNumber++;

            Console.WriteLine($"\nRow {rowNumber}:");

            for (int i = 0; i < row.Length; i++)
            {
              object? cell = row[i];

              if (cell == null)
              {
                Console.WriteLine($"  Col {i + 1}: NULL");
                continue;
              }

              PrintCellValue(i + 1, cell);
            }
          }

          if (worksheet.MergeRanges.Count > 0)
          {
            Console.WriteLine("\nMerged Ranges:");
            foreach (var merge in worksheet.MergeRanges)
            {
              Console.WriteLine($"  {merge}");
            }
          }

          Console.WriteLine($"\nFinished Sheet: {sheetName}");
        }

        Console.WriteLine("\nAll worksheets processed successfully.");
      }
      catch (Exception ex)
      {
        Console.WriteLine("========================================");
        Console.WriteLine("ERROR OCCURRED");
        Console.WriteLine(ex.Message);
        Console.WriteLine("========================================");
      }
    }

    static void PrintCellValue(int columnIndex, object value)
    {
      switch (value)
      {
        case double number:
          Console.WriteLine($"  Col {columnIndex}: Number = {number}");
          break;

        case string text:
          Console.WriteLine($"  Col {columnIndex}: Text = {text}");
          break;

        case bool boolean:
          Console.WriteLine($"  Col {columnIndex}: Boolean = {boolean}");
          break;

        case DateTime dateTime:
          Console.WriteLine($"  Col {columnIndex}: DateTime = {dateTime:yyyy-MM-dd HH:mm:ss}");
          break;

        case TimeSpan timeSpan:
          Console.WriteLine($"  Col {columnIndex}: TimeSpan = {timeSpan}");
          break;

        default:
          Console.WriteLine($"  Col {columnIndex}: Unknown Type = {value}");
          break;
      }
    }
  }
}