namespace DateTimeSortingDemoMonthFirst
{
	class DateTimeSortingDemoMonthFirst
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (Month-First Culture: en-US)");
			Console.WriteLine("=============================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US"); // Month-first culture

			// Test data with ambiguous dates (both parts ≤ 12)
			var data = new List<string>
	{
	"04/07/2023",  // Month-first: July 4th, 2023
                  "05/06/2023",  // Month-first: June 5th, 2023
                  "01/12/2024",  // Month-first: December 1st, 2024
                  "07/08/2022",  // Month-first: August 7th, 2022
                  "02/03/2025",  // Month-first: March 2nd, 2025
                  "11/10/2023",  // Month-first: October 11th, 2023
              };

			Console.WriteLine($"Input Data ({data.Count} items, ambiguous MM/dd dates):");
			Console.WriteLine("==========================================================");
			Console.WriteLine("Note: en-US culture interprets as month-first (MM/dd/yyyy)");
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
			culture,  // Month-first culture
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
			culture,  // Month-first culture
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