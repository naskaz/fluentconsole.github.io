using System;
using VelocityExcel.Api;

namespace ExcelDateTimeRoundingRead
{
  class ExcelDateTimeRoundingRead
  {
    static void Main(string[] args)
    {
      //Note: first create the excel file "date_time_demo.xlsx" using the code "ExcelDateTimeWrite.cs" 
      // which is located in "Write Excel" sidebar menu of the documentation.
      Console.WriteLine("Basic Demo of How to Read Excel DateTime with DateTime Rounding using VelocityExcel");
      Console.WriteLine("==========================================");

      // Create ExcelOptions with RoundDateTime set to true
      var options = new ExcelOptions
      {
        RoundDateTime = true
      };

      using var reader = new ExcelReader("date_time_demo.xlsx", options);
      using var sheet = reader.OpenWorksheet("Products");

      Console.WriteLine($"Worksheet: {sheet.Name}");
      Console.WriteLine(new string('-', 60));

      int rowNum = 1;
      foreach (var row in sheet.ReadRows())
      {
        Console.Write($"Row {rowNum,2}: ");

        for (int i = 0; i < row.Length; i++)
        {
          if (i > 0)
            Console.Write(" | ");

          if (row[i] is DateTime dt)
            Console.Write(dt.ToString("yyyy-MM-dd HH:mm:ss"));
          else
            Console.Write(row[i]?.ToString() ?? "NULL");
        }

        Console.WriteLine();
        rowNum++;
      }

      Console.WriteLine("\nDone.");
    }
  }
}