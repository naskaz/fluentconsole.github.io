using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using VelocityExcel.Api;

namespace ExcelWriteNorthWind
{
	class ExcelWriteNorthWind
	{
		// 🔧 Configure your connection string
		private const string ConnectionString =
				"Server=localhost;Database=Northwind;Trusted_Connection=True;TrustServerCertificate=True;";

		private const string OutputFile = "Northwind_Orders_Export.xlsx";

		static async Task Main(string[] args)
		{
			Console.WriteLine("🚀 VelocityExcel NorthWind SQL Export Demo");
			Console.WriteLine("================================");

			try
			{
				// Export with streaming (memory-efficient for large datasets)
				await ExportOrdersToExcelStreamingAsync(ConnectionString, OutputFile);

				Console.WriteLine($"✅ Export complete: {OutputFile}");
				Console.WriteLine($"📁 File size: {new System.IO.FileInfo(OutputFile).Length / 1024:N0} KB");
			}
			catch (SqlException ex)
			{
				Console.Error.WriteLine($"❌ Database error: {ex.Message}");
				Environment.Exit(1);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"❌ Export failed: {ex.Message}");
				Environment.Exit(1);
			}
		}

	
		public static async Task ExportOrdersToExcelStreamingAsync(string connectionString, string outputPath)
		{
			var options = new ExcelOptions
			{
				CompressionPreset = "Fastest",
				UseSharedStrings = false,      
				PrettyPrintXml = false,
				WriteCellReferences = false
			};

			using var writer = new ExcelWriter(outputPath, options);
			using var worksheet = writer.CreateWorksheet("Orders");

			// Write header row
			worksheet.WriteRow(
					"OrderID",
					"EmployeeID",
					"OrderDate",
					"RequiredDate",
					"ShippedDate",
					"ShipVia",
					"Freight",
					"ShipName",
					"ShipAddress",
					"ShipCity",
					"ShipRegion",
					"ShipPostalCode",
					"ShipCountry"
			);

			// Stream rows directly from SQL Server (no intermediate DataTable in memory)
			using var connection = new SqlConnection(connectionString);
			await connection.OpenAsync();

			using var command = new SqlCommand(
					@"SELECT [OrderID]
                        ,[EmployeeID]
                        ,[OrderDate]
                        ,[RequiredDate]
                        ,[ShippedDate]
                        ,[ShipVia]
                        ,[Freight]
                        ,[ShipName]
                        ,[ShipAddress]
                        ,[ShipCity]
                        ,[ShipRegion]
                        ,[ShipPostalCode]
                        ,[ShipCountry]
                  FROM [Northwind].[dbo].[Orders]
                  ORDER BY [OrderDate] DESC",
					connection);

			using var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess);

			int rowCount = 0;
			while (await reader.ReadAsync())
			{
				// Build row array - VelocityExcel handles nulls, dates, decimals automatically
				var row = new object?[]
				{
										reader.IsDBNull(0) ? null : reader.GetInt32(0),    
                    reader.IsDBNull(1) ? null : reader.GetInt32(1),    
                    reader.IsDBNull(2) ? null : reader.GetDateTime(2), 
                    reader.IsDBNull(3) ? null : reader.GetDateTime(3), 
                    reader.IsDBNull(4) ? null : reader.GetDateTime(4), 
                    reader.IsDBNull(5) ? null : reader.GetInt32(5),    
                    reader.IsDBNull(6) ? null : reader.GetDecimal(6),  
                    reader.IsDBNull(7) ? null : reader.GetString(7),  
                    reader.IsDBNull(8) ? null : reader.GetString(8),   
                    reader.IsDBNull(9) ? null : reader.GetString(9),   
                    reader.IsDBNull(10) ? null : reader.GetString(10), 
                    reader.IsDBNull(11) ? null : reader.GetString(11), 
                    reader.IsDBNull(12) ? null : reader.GetString(12)  
				};

				worksheet.WriteRow(row);
				rowCount++;

				// Optional: Progress reporting for large exports
				if (rowCount % 10_000 == 0)
				{
					Console.WriteLine($"📊 Processed {rowCount:N0} rows...");
				}
			}

			Console.WriteLine($"📥 Read {rowCount:N0} rows from database");
			// Worksheet auto-completes on Dispose
		}

	}

}

