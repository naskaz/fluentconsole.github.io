
namespace IntelliDataSort
{
	class TestRealWorldExamples
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Test 8: Real-World Examples");
			Console.WriteLine("============================\n");

			var sorter = new HumanSort();

			// File names
			var files = new List<string>
						{
								"report_final.docx", "report_draft_v2.docx", "report_draft_v10.docx",
								"report_draft_v1.docx", "data_2024-01.csv", "data_2024-02.csv",
								"data_2023-12.csv", "backup_old.tar.gz", "backup_new.tar.gz",
								"readme.txt", "README.txt", "ReadMe.txt"
						};

			Console.WriteLine("File names - Sorted as PlainString:");
			var sortedFiles = sorter.Sort(files, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(sortedFiles);

			// Product codes
			var products = new List<string>
						{
								"PROD-001", "PROD-010", "PROD-100", "PROD-002", "prod-001",
								"PROD-011", "PROD-101", "ITEM-A", "ITEM-B", "ITEM-AA", "ITEM-AB", "ITEM-BA"
						};

			Console.WriteLine("\nProduct codes - Sorted as PlainString:");
			var sortedProducts = sorter.Sort(products, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(sortedProducts);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayList(IReadOnlyList<string> list)
		{
			foreach (var item in list) Console.WriteLine($"  {item}");
		}
	}
}