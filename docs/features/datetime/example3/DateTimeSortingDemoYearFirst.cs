namespace DateTimeSortingDemoYearFirst
{

	class DateTimeSortingDemoYearFirst
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (Year-First Culture: ja-JP)");
			Console.WriteLine("=============================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("ja-JP"); // Year-first culture

			// Test data with ambiguous dates (all parts ≤ 12)
			var data = new List<string>
	{
	"2023/04/07",  // Year-first: 2023 April 7th
                  "2023/05/06",  // Year-first: 2023 May 6th
                  "2024/01/12",  // Year-first: 2024 January 12th
                  "2022/07/08",  // Year-first: 2022 July 8th
                  "2025/02/03",  // Year-first: 2025 February 3rd
                  "2023/11/10",  // Year-first: 2023 November 10th
              };

			Console.WriteLine($"Input Data ({data.Count} items, year-first yyyy/MM/dd format):");
			Console.WriteLine("================================================================");
			Console.WriteLine("Note: ja-JP culture interprets as year-first (yyyy/MM/dd)");
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
			culture,  // Year-first culture
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
			culture,  // Year-first culture
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
