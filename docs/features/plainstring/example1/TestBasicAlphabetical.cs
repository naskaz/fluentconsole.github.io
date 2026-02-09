using System;
using System.Collections.Generic;


namespace IntelliDataSort
{
	class TestBasicAlphabetical
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Test 1: Basic Alphabetical Sorting");
			Console.WriteLine("==================================\n");

			var sorter = new HumanSort();
			var data = new List<string>
						{
								"Zebra", "apple", "Banana", "cherry", "Date", "Fig", "grape"
						};

			Console.WriteLine("Original order:");
			DisplayList(data);

			Console.WriteLine("\nAscending order:");
			var asc = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(asc);

			Console.WriteLine("\nDescending order:");
			var desc = sorter.Sort(data, HumanSort.ColumnType.PlainString, false, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(desc);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayList(IReadOnlyList<string> list)
		{
			foreach (var item in list) Console.WriteLine($"  {item}");
		}
	}
}

