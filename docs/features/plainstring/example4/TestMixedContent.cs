namespace IntelliDataSort
{
	class TestMixedContent
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("Test 4: Mixed Content (Numbers as Strings) and PlainString vs NaturalString");
			Console.WriteLine("===========================================\n");

			var sorter = new HumanSort();
			var data = new List<string>
						{
								"123", "45", "999", "1", "1000", "001", "01", "10", "2", "20",
								"ABC123", "123ABC", "A1", "1A", "Version2", "Version10", "Version1"
						};

			Console.WriteLine("Original order:");
			DisplayList(data);

			// PlainString: Ascending & Descending
			Console.WriteLine("\nSorted as PlainString (Ascending):");
			var plainAsc = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(plainAsc);

			Console.WriteLine("\nSorted as PlainString (Descending):");
			var plainDesc = sorter.Sort(data, HumanSort.ColumnType.PlainString, false, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(plainDesc);

			// NaturalString: Ascending & Descending (for full comparison)
			Console.WriteLine("\nSorted as NaturalString (Ascending):");
			var naturalAsc = sorter.Sort(data, HumanSort.ColumnType.NaturalString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(naturalAsc);

			Console.WriteLine("\nSorted as NaturalString (Descending):");
			var naturalDesc = sorter.Sort(data, HumanSort.ColumnType.NaturalString, false, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(naturalDesc);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayList(IReadOnlyList<string> list)
		{
			foreach (var item in list) Console.WriteLine($"  {item}");
		}
	}
}
