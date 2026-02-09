namespace IntelliDataSort
{
	class TestCaseSensitivity
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("Test 2: Case Sensitivity");
			Console.WriteLine("========================\n");

			var sorter = new HumanSort();
			var data = new List<string>
						{
								"apple", "Apple", "APPLE", "banana", "Banana", "BANANA", "cherry", "Cherry"
						};

			Console.WriteLine("Original order:");
			DisplayList(data);

			Console.WriteLine("\nSorted (OrdinalIgnoreCase):");
			var sorted = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(sorted);

			Console.WriteLine("\nCase-insensitive groups:");
			var grouped = sorted
					.GroupBy(s => s.ToUpperInvariant())
					.Select(g => $"{g.Key}: {string.Join(", ", g)}");
			foreach (var group in grouped) Console.WriteLine($"  {group}");

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayList(IReadOnlyList<string> list)
		{
			foreach (var item in list) Console.WriteLine($"  {item}");
		}
	}
}
