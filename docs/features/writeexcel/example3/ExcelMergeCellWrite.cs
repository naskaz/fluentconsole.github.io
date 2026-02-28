using System;
using VelocityExcel.Api;

namespace ExcelMergeCellWrite
{
  class ExcelMergeCellWrite
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Basic Demo of How to Create Excel with Merged Cells using VelocityExcel");
      Console.WriteLine("==========================================");

      var options = new ExcelOptions
      {
        CompressionPreset = "Fastest",
        PrettyPrintXml = false,
        UseSharedStrings = false,
      };

      using (var writer = new ExcelWriter("merge_cell_demo.xlsx", options))
      {
        using (var sheet = writer.CreateWorksheet("Products"))
        {
          // === DECLARE ALL MERGES FIRST ===
          sheet.MergeCells(1, 1, 1, 5);   // A1:E1
          sheet.MergeCells(2, 1, 2, 2);   // A2:B2
          sheet.MergeCells(2, 3, 2, 5);   // C2:E2
          sheet.MergeCells(24, 1, 24, 2); // A24:B24
          sheet.MergeCells(24, 3, 24, 5); // C24:E24
          sheet.MergeCells(26, 1, 27, 1); // A26:A27
          sheet.MergeCells(26, 2, 27, 5); // B26:E27

          // === WRITE ROWS (ALL 5 columns, null for merged cells) ===

          // Row 1: A1:E1 merged → value in A1 only
          sheet.WriteRow("PRODUCT CATALOG - ALL ITEMS", null, null, null, null);

          // Row 2: A2:B2 merged (value in A2), C2:E2 merged (value in C2)
          sheet.WriteRow("Product Information", null, "Pricing & Status", null, null);

          // Row 3: No merges - all 5 columns
          sheet.WriteRow("Product ID", "Name", "Price", "In Stock", "Last Updated");

          // Rows 4-23: Data rows
          for (int i = 1; i <= 20; i++)
          {
            sheet.WriteRow(
                i,
                $"Product {i}",
                19.99 + (i * 0.01),
                i % 3 == 0,
                DateTime.Now.AddDays(-i)
            );
          }

          // Row 24: A24:B24 merged (value in A24), C24:E24 merged (value in C24)
          double totalValue = 0;
          for (int i = 1; i <= 20; i++)
          {
            totalValue += 19.99 + (i * 0.01);
          }
          sheet.WriteRow("Total Inventory Value:", null, $"${totalValue:F2}", null, null);

          // Row 25: Empty spacer
          sheet.WriteRow(null, null, null, null, null);

          // Row 26: A26:A27 merged (value in A26), B26:E27 merged (value in B26)
          sheet.WriteRow(
              "Note:",
              "This is a merged cell spanning multiple rows and columns showing important information about the product catalog.",
              null, null, null
          );

          // Row 27: All part of merges → all null
          sheet.WriteRow(null, null, null, null, null);
        }
      }

      Console.WriteLine("Excel file with merged cells created successfully!");
    }
  }
}