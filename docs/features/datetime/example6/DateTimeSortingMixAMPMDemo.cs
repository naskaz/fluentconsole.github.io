namespace DateTimeSortingMixAMPMDemo
{
	class DateTimeSortingMixAMPMDemo
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (AM/PM with Seconds)");
			Console.WriteLine("=====================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US"); // Month-first culture with AM/PM

			// Test data with dates, AM/PM time, and seconds
			var data = new List<string>
{
"07/04/2023 2:30:45 PM",   // 2:30:45 PM on July 4th 2023
                "07/04/2023 9:15:30 AM",   // 9:15:30 AM on July 4th 2023
                "07/04/2023 2:30:15 PM",   // 2:30:15 PM on July 4th 2023 (earlier seconds)
                "06/05/2023 11:45:59 PM",  // 11:45:59 PM on June 5th 2023
                "06/05/2023 8:00:01 AM",   // 8:00:01 AM on June 5th 2023
                "12/01/2024 12:01:30 AM",  // 12:01:30 AM on Dec 1st 2024
                "12/01/2024 3:30:00 PM",   // 3:30:00 PM on Dec 1st 2024
            };

			Console.WriteLine($"Input Data ({data.Count} items with AM/PM and seconds):");
			Console.WriteLine("=======================================================");
			Console.WriteLine("Note: en-US culture with AM/PM format including seconds");
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