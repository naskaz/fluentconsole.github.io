
namespace IntelliDataSort
{
	class TestEmptyAndNullHandling
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("Test 7: Empty and Null Handling");
			Console.WriteLine("================================\n");

			var sorter = new HumanSort();
			var data = new List<string>
						{
								"valid", null, "", " ", "another", null, "\t", "last"
						};

			Console.WriteLine("Original order:");
			DisplayWithNulls(data);

			Console.WriteLine("\nWith NullHandling.NullsFirst (default):");
			var sorted1 = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayWithNulls(sorted1);

			Console.WriteLine("\nWith NullHandling.NullsAsEmpty:");
			var sorted2 = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsAsEmpty, out _);
			DisplayWithNulls(sorted2);

			Console.WriteLine("\nWith NullHandling.NullsLast:");
			var sorted3 = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsLast, out _);
			DisplayWithNulls(sorted3);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayWithNulls(IReadOnlyList<string> list)
		{
			foreach (var item in list)
			{
				string display = item == null ? "null" : $"'{Escape(item)}'";
				Console.WriteLine($"  {display}");
			}
		}

		static string Escape(string s)
		{
			if (s == null) return "null";
			return s.Replace(" ", "␣").Replace("\t", "→");
		}
	}
}

