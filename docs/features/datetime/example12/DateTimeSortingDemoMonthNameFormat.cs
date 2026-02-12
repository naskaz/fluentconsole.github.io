namespace DateTimeSortingDemoFullMonthNameFormat
{
	class DateTimeSortingDemoFullMonthNameFormat
	{
		static void Main(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (Full Month Name Format: MMMM dd, yyyy)");
			Console.WriteLine("==========================================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US"); // Using US culture for month name parsing

			// Test data with full month name format (MMMM dd, yyyy)
			var data = new List<string>
						{
								"April 07, 2023",   // April 7, 2023
                "May 06, 2023",     // May 6, 2023
                "January 12, 2024", // January 12, 2024
                "July 08, 2022",    // July 8, 2022
                "February 03, 2025", // February 3, 2025
                "November 10, 2023", // November 10, 2023
            };

			Console.WriteLine($"Input Data ({data.Count} items, format: MMMM dd, yyyy):");
			Console.WriteLine("==========================================================================");
			Console.WriteLine("Note: en-US culture interprets as full month name day, year");
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
					culture,  // US culture for month name parsing
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
					culture,  // US culture for month name parsing
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
