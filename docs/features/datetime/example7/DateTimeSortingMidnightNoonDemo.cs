namespace DateTimeSortingMidnightNoonDemo
{
	class DateTimeSortingMidnightNoonDemo
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (Midnight & Noon Edge Cases)");
			Console.WriteLine("==============================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US"); // Month-first culture with AM/PM

			// Test data with midnight and noon edge cases
			var data = new List<string>
{
"07/04/2023 12:00:00 AM",  // Midnight start of July 4th
                "07/04/2023 12:00:30 AM",  // 30 seconds past midnight
                "07/04/2023 12:00:00 PM",  // Noon on July 4th
                "07/04/2023 12:00:30 PM",  // 30 seconds past noon
                "06/05/2023 11:59:59 PM",  // 1 second before midnight
                "06/05/2023 11:59:30 AM",  // 30 seconds before noon
                "12/01/2024 12:01:00 AM",  // 1 minute past midnight
                "12/01/2024 11:59:00 AM",  // 1 minute before noon
            };

			Console.WriteLine($"Input Data ({data.Count} items with midnight/noon edge cases):");
			Console.WriteLine("===============================================================");
			Console.WriteLine("Note: Testing AM/PM edge cases with 12:00");
			Console.WriteLine();

			foreach (var item in data)
			{
				Console.WriteLine($"  {item}");
			}

			Console.WriteLine("\n\n1. ASCENDING SORT (Earliest to Latest):");
			Console.WriteLine("========================================");
			var ascending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			true,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,  // Culture with AM/PM format
			out var parsedAsc
			);

			DisplaySortedResults(ascending, parsedAsc);

			Console.WriteLine("\n\n2. DESCENDING SORT (Latest to Earliest):");
			Console.WriteLine("==========================================");
			var descending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			false,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,  // Culture with AM/PM format
			out var parsedDesc
			);

			DisplaySortedResults(descending, parsedDesc);

			Console.WriteLine("\n\nDATE TIME SORTING DEMO COMPLETE ✓");
		}

		static void DisplaySortedResults(IReadOnlyList<string> sorted, List<(string original, object parsed)> parsedValues)
		{
			foreach (var item in sorted)
			{
				Console.WriteLine($"  {item}");
			}
		}
	}

}
