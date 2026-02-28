using System;
using VelocityExcel.Api;

namespace ExcelMergeCellRead
{
	class ExcelMergeCellRead
	{
		static void Main(string[] args)
		{

      // note:before reading first create the "merge_cell_demo.xlsx" excel file using ExcelMergeCellWrite code 
      // which is provided in Write Excel Sections.

      Console.WriteLine("Basic Demo of How to Read Merge Cell Content from Excel using VelocityExcel");
			Console.WriteLine("==========================================");

			// Open the Excel file
			using var reader = new ExcelReader("merge_cell_demo.xlsx");

			using var sheet = reader.OpenWorksheet("Products");

			Console.WriteLine($"Worksheet: {sheet.Name}");
			Console.WriteLine(new string('-', 60));

			// Stream rows forward-only
			int rowNum = 1;
			foreach (var row in sheet.ReadRows())
			{
				// Print row as-is: join values with " | "
				Console.WriteLine($"Row {rowNum,2}: {string.Join(" | ", row)}");
				rowNum++;
			}

			if (sheet.MergeRanges.Count > 0)
			{
				Console.WriteLine(new string('-', 60));
				Console.WriteLine("Merged cell ranges:");
				foreach (var mergeRef in sheet.MergeRanges)
				{
					Console.WriteLine($"  • {mergeRef}");
				}
			}

			Console.WriteLine("\nDone.");
		}
	}
}