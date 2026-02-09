using IntelliDataSort;
using System.Globalization;

namespace DateTimeSortingDemoDayFirst
{
	class DateTimeSortingDemoDayFirst
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (Day-First Culture: en-GB)");
			Console.WriteLine("=============================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-GB"); // Day-first culture

			// Test data with ambiguous dates (both parts ≤ 12)
			var data = new List<string>
	{
	"04/07/2023",  // Day-first: 4th July 2023
                  "05/06/2023",  // Day-first: 5th June 2023
                  "01/12/2024",  // Day-first: 1st December 2024
                  "07/08/2022",  // Day-first: 7th August 2022
                  "02/03/2025",  // Day-first: 2nd March 2025
                  "11/10/2023",  // Day-first: 11th October 2023
              };

			Console.WriteLine($"Input Data ({data.Count} items, ambiguous dd/MM dates):");
			Console.WriteLine("==========================================================");
			Console.WriteLine("Note: en-GB culture interprets as day-first (dd/MM/yyyy)");
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
			culture,  // Day-first culture
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
			culture,  // Day-first culture
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