using System;
using System.Linq;
using VelocityExcel.Api;

namespace ExcelMergeCellReadComplex
{
	class ExcelMergeCellReadComplex
	{
		static void Main(string[] args)
		{

      // note:before reading first create the "ComplexReport.xlsx" excel file using ExcelMergeCellWriteComplex code 
      // which is provided in Write Excel Sections.

      Console.WriteLine("Complex Demo of How to Read Merge Cell Content from Excel using VelocityExcel");
			Console.WriteLine("==========================================");

			const string filePath = "ComplexReport.xlsx";

			try
			{
				// Open the Excel file for reading
				using var reader = new ExcelReader(filePath);

				Console.WriteLine($"📊 File: {filePath}");
				Console.WriteLine($"📑 Worksheets: {reader.WorksheetCount}");
				Console.WriteLine();

				// List all worksheet names
				Console.WriteLine("📋 Available Worksheets:");
				foreach (var name in reader.WorksheetNames)
				{
					Console.WriteLine($"  ✓ {name}");
				}
				Console.WriteLine();

				// Read each worksheet
				foreach (var sheetName in reader.WorksheetNames)
				{
					ReadWorksheet(reader, sheetName);
					Console.WriteLine(new string('─', 60));
					Console.WriteLine();
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"❌ Error: {ex.Message}");
				if (ex is System.IO.FileNotFoundException)
				{
					Console.Error.WriteLine($"💡 Hint: Make sure '{filePath}' exists in the current directory.");
				}
			}
		}


		static void ReadWorksheet(ExcelReader reader, string sheetName)
		{
			Console.WriteLine($"🔍 Reading: [{sheetName}]");
			Console.WriteLine();

			using var sheet = reader.OpenWorksheet(sheetName);
			int rowNum = 0;

			foreach (var row in sheet.ReadRows())
			{
				rowNum++;

				// Skip completely empty rows for cleaner output
				if (row.All(c => c == null || string.IsNullOrWhiteSpace(c?.ToString())))
					continue;

				// Format and display the row
				var formatted = row
						.Select((cell, idx) =>
						{
							var value = cell?.ToString() ?? "";
							// Truncate long strings for display
							return value.Length > 50 ? value.Substring(0, 47) + "..." : value;
						})
						.ToArray();

				Console.WriteLine($"[{rowNum,4}] {string.Join(" | ", formatted)}");
			}


			var merges = sheet.MergeRanges;
			if (merges?.Count > 0)
			{
				Console.WriteLine();
				Console.WriteLine($"🔗 Merge Ranges ({merges.Count}):");
				foreach (var range in merges)
				{
					Console.WriteLine($"   • {range}");
				}
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("🔗 No merged cells in this worksheet");
			}
		}
	}
}