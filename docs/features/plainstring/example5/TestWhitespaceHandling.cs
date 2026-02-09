namespace IntelliDataSort
{

	class TestWhitespaceHandling
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("Test 5: Whitespace Handling");
			Console.WriteLine("============================\n");

			var sorter = new HumanSort();
			var data = new List<string>
						{
								"apple", " apple", "  apple", "apple ", "apple  ",
								"\tapple", "apple\t", "banana", " banana", "banana ",
								"", " ", "  ", "\t", "\t\t"
						};

			Console.WriteLine("Original order (with quotes):");
			DisplayWithQuotes(data);

			Console.WriteLine("\nSorted order (with quotes):");
			var sorted = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayWithQuotes(sorted);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayWithQuotes(IReadOnlyList<string> list)
		{
			foreach (var item in list)
			{
				string escaped = item?.Replace(" ", "␣").Replace("\t", "→") ?? "null";
				Console.WriteLine($"  '{escaped}'");
			}
		}
	}

}
