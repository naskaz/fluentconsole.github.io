
using System;
using VelocityExcel.Api;

namespace ExcelMergeCellWriteComplex
{
  internal class ExcelMergeCellWriteComplex
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Complex Demo of How to Create Excel with Merged Cells using VelocityExcel");
      Console.WriteLine("==========================================");


      // Create a complex Excel file with merged cells
      using var writer = new ExcelWriter("ComplexReport.xlsx", new ExcelOptions
      {
        CompressionPreset = "Fastest",
        UseSharedStrings = false,
        PrettyPrintXml = false
      });

      // ============================================
      // WORKSHEET 1: Sales Report with Merged Headers
      // ============================================
      using (var sheet1 = writer.CreateWorksheet("Sales Report"))
      {
        // Merge header row (A1:E1)
        sheet1.MergeCells(1, 1, 1, 5);

        // Write merged header
        sheet1.WriteRow(new object[] { "Q4 2024 Sales Summary" });

        // Write column headers
        sheet1.WriteRow(new object[] { "Region", "Product", "Units", "Price", "Total" });

        // Write data rows
        var salesData = new[]
        {
                    new object[] { "North", "Widget A", 150, 29.99, 4498.50 },
                    new object[] { "North", "Widget B", 200, 49.99, 9998.00 },
                    new object[] { "South", "Widget A", 175, 29.99, 5248.25 },
                    new object[] { "South", "Widget B", 225, 49.99, 11247.75 },
                    new object[] { "East", "Widget A", 130, 29.99, 3898.70 },
                    new object[] { "East", "Widget B", 180, 49.99, 8998.20 },
                    new object[] { "West", "Widget A", 160, 29.99, 4798.40 },
                    new object[] { "West", "Widget B", 210, 49.99, 10497.90 },
                };

        sheet1.WriteRows(salesData);

        // Merge totals row label (A11:C11)
        sheet1.MergeCells(11, 1, 11, 3);
        sheet1.WriteRow(new object[] { "Grand Total", null, null, null, 59185.70 });
      }

      // ============================================
      // WORKSHEET 2: Schedule with Time Blocks
      // ============================================
      using (var sheet2 = writer.CreateWorksheet("Schedule"))
      {
        // Merge title (A1:D1)
        sheet2.MergeCells(1, 1, 1, 4);
        sheet2.WriteRow(new object[] { "Project Timeline" });

        // Headers
        sheet2.WriteRow(new object[] { "Phase", "Start Date", "End Date", "Status" });

        // Data with dates
        sheet2.WriteRow(new object[] { "Planning", new DateTime(2024, 1, 1), new DateTime(2024, 1, 15), "Complete" });
        sheet2.WriteRow(new object[] { "Development", new DateTime(2024, 1, 16), new DateTime(2024, 3, 30), "In Progress" });

        // Merge cells for multi-row status (A5:A7)
        sheet2.MergeCells(5, 1, 7, 1);
        sheet2.WriteRow(new object[] { "Testing Phase" });
        sheet2.WriteRow(new object[] { null, new DateTime(2024, 4, 1), new DateTime(2024, 4, 15), "Pending" });
        sheet2.WriteRow(new object[] { null, new DateTime(2024, 4, 16), new DateTime(2024, 4, 30), "Pending" });

        // Merge footer (A9:D9)
        sheet2.MergeCells(9, 1, 9, 4);
        sheet2.WriteRow(new object[] { "Note: All dates are subject to change" });
      }

      // ============================================
      // WORKSHEET 3: Complex Layout with Multiple Merges
      // ============================================
      using (var sheet3 = writer.CreateWorksheet("Dashboard"))
      {
        // Main title (A1:F1)
        sheet3.MergeCells(1, 1, 1, 6);
        sheet3.WriteRow(new object[] { "Executive Dashboard" });

        // Subtitle (A2:F2)
        sheet3.MergeCells(2, 1, 2, 6);
        sheet3.WriteRow(new object[] { "Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm") });

        // Empty row
        sheet3.WriteRow(new object[] { });

        // Section 1 Header (A4:C4)
        sheet3.MergeCells(4, 1, 4, 3);
        sheet3.WriteRow(new object[] { "Key Metrics" });

        // Metrics data
        sheet3.WriteRow(new object[] { "Revenue", "$1,250,000", "Growth", "+15.3%" });
        sheet3.WriteRow(new object[] { "Customers", "8,450", "Retention", "94.2%" });
        sheet3.WriteRow(new object[] { "Orders", "12,380", "Avg Value", "$101.05" });

        // Empty row
        sheet3.WriteRow(new object[] { });

        // Section 2 Header (A9:C9)
        sheet3.MergeCells(9, 1, 9, 3);
        sheet3.WriteRow(new object[] { "Regional Performance" });

        // Regional data with merged region names
        sheet3.MergeCells(10, 1, 12, 1); // North America (3 rows)
        sheet3.WriteRow(new object[] { "North America" });
        sheet3.WriteRow(new object[] { null, "USA", "$850,000" });
        sheet3.WriteRow(new object[] { null, "Canada", "$125,000" });

        sheet3.MergeCells(13, 1, 14, 1); // Europe (2 rows)
        sheet3.WriteRow(new object[] { "Europe" });
        sheet3.WriteRow(new object[] { null, "UK", "$180,000" });

        // Footer (A16:F16)
        sheet3.MergeCells(16, 1, 16, 6);
        sheet3.WriteRow(new object[] { "Confidential - Internal Use Only" });
      }

      writer.Close();

      Console.WriteLine("Excel file created successfully!");
    }
  }
}

