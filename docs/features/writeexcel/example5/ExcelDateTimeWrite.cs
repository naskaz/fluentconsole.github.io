using System;
using VelocityExcel.Api;

namespace ExcelDateTimeWrite
{
  class ExcelDateTimeWrite
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Basic Demo of How to Create Excel with DateTime Values using VelocityExcel" + 
      " and to Understand Datetime Rounding while reading Excel Files");
      Console.WriteLine("==========================================");

      var options = new ExcelOptions
      {
        CompressionPreset = "Fastest",
        PrettyPrintXml = false,
        UseSharedStrings = false,
      };

      using (var writer = new ExcelWriter("date_time_demo.xlsx", options))
      {
        using (var sheet = writer.CreateWorksheet("Products"))
        {
          // Header row
          sheet.WriteRow("Product", "Quantity", "Unit Price", "Total", "Date");

          // Sample rows with DateTime values
          sheet.WriteRow("Phone", 8, 676.82, 5414.56, new DateTime(2025, 5, 4, 18, 26, 23, 892));
          sheet.WriteRow("Keyboard", 12, 125.50, 1506.00, new DateTime(2025, 5, 5, 9, 15, 42, 120));
          sheet.WriteRow("Mouse", 15, 49.99, 749.85, new DateTime(2025, 5, 6, 14, 5, 59, 650));
          sheet.WriteRow("Monitor", 5, 899.95, 4499.75, new DateTime(2025, 5, 7, 21, 45, 10, 499));
          sheet.WriteRow("Laptop", 3, 1500.00, 4500.00, new DateTime(2025, 5, 8, 11, 30, 0, 5));
        }
      }

      Console.WriteLine("Excel file with DateTime values created successfully!");
    }
  }
}