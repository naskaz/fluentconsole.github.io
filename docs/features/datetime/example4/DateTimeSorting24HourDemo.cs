namespace DateTimeSorting24HourDemo
{
	class DateTimeSorting24HourDemo
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (24-Hour Time Format)");
			Console.WriteLine("========================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-GB"); // Day-first culture with 24-hour format

			// Test data with dates and 24-hour time
			var data = new List<string>
{
"04/07/2023 14:30",  // 2:30 PM on 4th July 2023
                "04/07/2023 09:15",  // 9:15 AM on 4th July 2023
                "05/06/2023 23:45",  // 11:45 PM on 5th June 2023
                "05/06/2023 08:00",  // 8:00 AM on 5th June 2023
                "01/12/2024 00:01",  // 12:01 AM on 1st Dec 2024
                "01/12/2024 15:30",  // 3:30 PM on 1st Dec 2024
            };

			Console.WriteLine($"Input Data ({data.Count} items with 24-hour time):");
			Console.WriteLine("====================================================");
			Console.WriteLine("Note: en-GB culture with 24-hour time format");
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
			culture,  // Culture with 24-hour format
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
			culture,  // Culture with 24-hour format
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
