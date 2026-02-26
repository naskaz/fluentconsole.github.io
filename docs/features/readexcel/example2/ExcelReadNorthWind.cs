using System;
using System.Globalization;  // ← Add for NumberStyles
using VelocityExcel.Api;

namespace ExcelReadNorthWind
{
	class ExcelReadNorthWind
	{
		private const string InputFile = "Northwind_Orders_Export.xlsx";

		static void Main(string[] args)  
		{
			Console.WriteLine("🚀 VelocityExcel NorthWind SQL Import Demo");
			Console.WriteLine("==========================================");

			try
			{
				ImportOrdersFromExcelStreaming(InputFile); 
				Console.WriteLine($"✅ Import complete: {InputFile}");
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"❌ Import failed: {ex.Message}");
				Console.Error.WriteLine($"📍 Stack: {ex.StackTrace}");
				Environment.Exit(1);
			}
		}

		public static void ImportOrdersFromExcelStreaming(string inputPath)
		{
			using var reader = new ExcelReader(inputPath);

			Console.WriteLine($"📄 Worksheets found: {string.Join(", ", reader.WorksheetNames)}");

			if (!reader.TryOpenWorksheet("Orders", out var worksheet))
				throw new KeyNotFoundException("Worksheet 'Orders' not found.");

			using (worksheet)
			{
				Console.WriteLine($"📥 Reading worksheet: {worksheet.Name}");
				Console.WriteLine();

				int rowCount = 0;

				foreach (var row in worksheet.ReadRows())
				{
					rowCount++;

					// HEADER
					if (rowCount == 1)
					{
						Console.WriteLine("📋 Headers:");
						for (int i = 0; i < row.Length; i++)
							Console.Write($"[{i}] {row[i]}  ");

						Console.WriteLine("\n" + new string('-', 120) + "\n");
						continue;
					}

					var orderId = GetInt(row, 0);
					var employeeId = GetInt(row, 1);
					var orderDate = GetDate(row, 2);
					var requiredDate = GetDate(row, 3);
					var shippedDate = GetDate(row, 4);
					var shipVia = GetInt(row, 5);
					var freight = GetDecimal(row, 6);
					var shipName = GetString(row, 7);
					var shipAddress = GetString(row, 8);
					var shipCity = GetString(row, 9);
					var shipRegion = GetString(row, 10);
					var shipPostalCode = GetString(row, 11);
					var shipCountry = GetString(row, 12);

					// DISPLAY FIRST 5 ROWS
					if (rowCount <= 6)
					{
						Console.WriteLine($"Row {rowCount - 1}:");
						Console.WriteLine($"  [0]  OrderID:        {orderId}");
						Console.WriteLine($"  [1]  EmployeeID:     {employeeId}");
						Console.WriteLine($"  [2]  OrderDate:      {FormatDate(orderDate)}");
						Console.WriteLine($"  [3]  RequiredDate:   {FormatDate(requiredDate)}");
						Console.WriteLine($"  [4]  ShippedDate:    {FormatDate(shippedDate)}");
						Console.WriteLine($"  [5]  ShipVia:        {shipVia}");
						Console.WriteLine($"  [6]  Freight:        {FormatMoney(freight)}");
						Console.WriteLine($"  [7]  ShipName:       {shipName}");
						Console.WriteLine($"  [8]  ShipAddress:    {shipAddress}");
						Console.WriteLine($"  [9]  ShipCity:       {shipCity}");
						Console.WriteLine($"  [10] ShipRegion:     {shipRegion}");
						Console.WriteLine($"  [11] ShipPostalCode: {shipPostalCode}");
						Console.WriteLine($"  [12] ShipCountry:    {shipCountry}");
						Console.WriteLine();
					}

					if (rowCount % 10_000 == 0 && rowCount > 1)
						Console.WriteLine($"📊 Processed {rowCount - 1:N0} data rows...");
				}

				Console.WriteLine($"✅ Read {rowCount - 1:N0} data rows from '{worksheet.Name}'");
			}
		}

		// ================================
		// TYPE HELPERS
		// ================================

		static int? GetInt(object?[] row, int index)
		{
			if (index >= row?.Length) return null;
			var value = row[index];
			if (value == null) return null;

			return value switch
			{
				int i => i,
				long l => (int)l,
				double d => (int)d,
				decimal m => (int)m,
				string s when int.TryParse(s, out int result) => result,
				_ => null
			};
		}

		static decimal? GetDecimal(object?[] row, int index)
		{
			if (index >= row?.Length) return null;
			var value = row[index];
			if (value == null) return null;

			return value switch
			{
				decimal d => d,
				double dbl => (decimal)dbl,
				float f => (decimal)f,
				int i => i,
				long l => l,
				string s when decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal result) => result,
				_ => null
			};
		}

		static DateTime? GetDate(object?[] row, int index)
		{
			if (index >= row?.Length) return null;
			return row[index] is DateTime dt ? dt : null;
		}

		static string? GetString(object?[] row, int index)
		{
			if (index >= row?.Length) return null;
			return row[index]?.ToString();
		}

		// ================================
		// FORMAT HELPERS
		// ================================

		static string FormatDate(DateTime? date)
				=> date.HasValue ? date.Value.ToString("yyyy-MM-dd") : "";

		static string FormatMoney(decimal? value)
				=> value.HasValue ? value.Value.ToString("0.00") : "";
	}
}