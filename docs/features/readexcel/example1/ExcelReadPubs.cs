using System;
using VelocityExcel.Api;

namespace ExcelReadPubs
{
	class ExcelReadPubs
	{
		static void Main(string[] args)
		{
			try
			{
				using var reader = new ExcelReader("Pubs_Employee_Export.xlsx");

				if (!reader.TryOpenWorksheet("Employees", out var sheet))
				{
					Console.Error.WriteLine("❌ Worksheet 'Employees' not found!");
					Console.Error.WriteLine($"Available sheets: {string.Join(", ", reader.WorksheetNames)}");
					return;
				}

				using (sheet)
				{
					Console.WriteLine("Reading Pubs Employee Data from Excel");
					Console.WriteLine("========================================");

					int rowCount = 0;
					bool isHeader = true;

					foreach (var row in sheet.ReadRows())
					{
						// Skip header row
						if (isHeader)
						{
							isHeader = false;
							rowCount++;
							continue;
						}

						var empId = GetString(row, 0);
						var firstName = GetString(row, 1);
						var middleInitial = GetString(row, 2);
						var lastName = GetString(row, 3);
						var jobId = GetShort(row, 4);
						var jobLevel = GetShort(row, 5);
						var pubId = GetString(row, 6);
						var hireDate = GetDateTime(row, 7);

						// Display first 10 employees as sample
						if (rowCount < 10)
						{
							Console.WriteLine($"{empId}: {firstName} {middleInitial} {lastName} - Job: {jobId}, Level: {jobLevel}, " +
								$"pubId: {pubId}, Hired: {hireDate?.ToString("yyyy-MM-dd") ?? "N/A"}");
						}
						else if (rowCount == 10)
						{
							Console.WriteLine("... (more employees)");
						}

						rowCount++;
					}

					Console.WriteLine($"\n✅ Total employees read: {rowCount:N0}");
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"❌ Error: {ex.Message}");
				Console.Error.WriteLine($"📍 Stack: {ex.StackTrace}");
			}
		}

		// ================================
		// TYPE HELPERS
		// ================================

		static string? GetString(object?[] row, int index)
		{
			if (index >= row?.Length) return null;
			return row[index] as string;
		}

		static short? GetShort(object?[] row, int index)
		{
			if (index >= row?.Length) return null;
			var value = row[index];
			if (value == null) return null;

			return value switch
			{
				short s => s,
				int i => (short)i,
				byte b => (short)b,
				string str when short.TryParse(str, out short result) => result,
				_ => null
			};
		}

		static DateTime? GetDateTime(object?[] row, int index)
		{
			if (index >= row?.Length) return null;
			return row[index] as DateTime?;
		}
	}
}