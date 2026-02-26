using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using VelocityExcel.Api;

namespace ExcelWritePubs
{
	class ExcelWritePubs
	{
		private const string ConnectionString =
				"Server=localhost;Database=pubs;Trusted_Connection=True;TrustServerCertificate=True;";

		private const string OutputFile = "Pubs_Employee_Export.xlsx";

		static async Task Mains(string[] args)
		{
			Console.WriteLine("VelocityExcel Pubs Employee Export Demo");
			Console.WriteLine("==========================================");

			try
			{
				await ExportEmployeesToExcelStreamingAsync(ConnectionString, OutputFile);

				Console.WriteLine($"Export complete: {OutputFile}");
				Console.WriteLine(
						$"File size: {new System.IO.FileInfo(OutputFile).Length / 1024:N0} KB"
				);
			}
			catch (SqlException ex)
			{
				Console.Error.WriteLine($"Database error: {ex.Message}");
				Environment.Exit(1);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"Export failed: {ex.Message}");
				Environment.Exit(1);
			}
		}

		public static async Task ExportEmployeesToExcelStreamingAsync(
				string connectionString,
				string outputPath
		)
		{
			var options = new ExcelOptions
			{
				CompressionPreset = "Fastest",
				UseSharedStrings = false,
				PrettyPrintXml = false,
			};

			using var writer = new ExcelWriter(outputPath, options);
			using var worksheet = writer.CreateWorksheet("Employees");

			worksheet.WriteRow(
					"emp_id",
					"fname",
					"minit",
					"lname",
					"job_id",
					"job_lvl",
					"pub_id",
					"hire_date"
			);

			using var connection = new SqlConnection(connectionString);
			await connection.OpenAsync();

			using var command = new SqlCommand(
					@"SELECT [emp_id]
                        ,[fname]
                        ,[minit]
                        ,[lname]
                        ,[job_id]
                        ,[job_lvl]
                        ,[pub_id]
                        ,[hire_date]
                  FROM [pubs].[dbo].[employee]
                  ORDER BY [lname], [fname]",
					connection
			);

			using var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess);

			int rowCount = 0;
			while (await reader.ReadAsync())
			{
				var row = new object?[]
				{
										reader.IsDBNull(0) ? null : reader.GetString(0),
										reader.IsDBNull(1) ? null : reader.GetString(1),
										reader.IsDBNull(2) ? null : reader.GetString(2),
										reader.IsDBNull(3) ? null : reader.GetString(3),

										reader.IsDBNull(4)
												? null
												: GetIntValue(reader, 4),

										reader.IsDBNull(5)
												? null
												: GetIntValue(reader, 5),
										reader.IsDBNull(6) ? null : reader.GetString(6),
										reader.IsDBNull(7) ? null : reader.GetDateTime(7),
				};

				worksheet.WriteRow(row);
				rowCount++;

				if (rowCount % 10_000 == 0)
				{
					Console.WriteLine($"Processed {rowCount:N0} rows...");
				}
			}

			Console.WriteLine($"Read {rowCount:N0} rows from pubs.dbo.employee");
		}

		private static object? GetIntValue(SqlDataReader reader, int ordinal)
		{
			var value = reader.GetValue(ordinal);
			return value switch
			{
				byte b => (short)b, 
				short s => s, 
				int i => (short)i, 
				null => null,
				_ => Convert.ToInt16(value), 
			};
		}
	}
}
