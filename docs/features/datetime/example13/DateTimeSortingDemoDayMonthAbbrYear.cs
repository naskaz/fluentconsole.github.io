
namespace DateTimeSortingDemoDayMonthAbbrYear
{

	class DateTimeSortingDemoDayMonthAbbrYear
	{
		static void Main(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (Day Month Abbr Year Format: dd MMM yyyy)");
			Console.WriteLine("================================================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-GB"); // Using GB culture for day-first parsing

			// Test data with day month abbreviation year format (dd MMM yyyy)
			var data = new List<string>
						{
								"07 Apr 2023",  // 7 April 2023
                "06 May 2023",  // 6 May 2023
                "12 Jan 2024",  // 12 January 2024
                "08 Jul 2022",  // 8 July 2022
                "03 Feb 2025",  // 3 February 2025
                "10 Nov 2023",  // 10 November 2023
                "25 Dec 2023",  // 25 December 2023
                "15 Mar 2024",  // 15 March 2024
                "30 Aug 2022",  // 30 August 2022
                "01 Oct 2023",  // 1 October 2023
                "19 Jun 2024",  // 19 June 2024
                "05 Sep 2022",  // 5 September 2022
            };

			Console.WriteLine($"Input Data ({data.Count} items, format: dd MMM yyyy):");
			Console.WriteLine("================================================================================");
			Console.WriteLine("Note: en-GB culture interprets as day month abbreviation year (dd MMM yyyy)");
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
					culture,
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
					culture,
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
