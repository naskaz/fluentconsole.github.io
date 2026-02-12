
namespace DateTimeSortingDemoDayMonthAbbrYearTime
{
	class DateTimeSortingDemoDayMonthAbbrYearTime
	{
		static void Main(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (Day Month Abbr Year Time Format: dd MMM yyyy HH:mm)");
			Console.WriteLine("============================================================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-GB"); // Using GB culture for day-first parsing

			// Test data with day month abbreviation year and time format (dd MMM yyyy HH:mm)
			var data = new List<string>
						{
								"07 Apr 2023 14:30",  // 7 April 2023, 2:30 PM
                "06 May 2023 09:15",  // 6 May 2023, 9:15 AM
                "12 Jan 2024 18:45",  // 12 January 2024, 6:45 PM
                "08 Jul 2022 11:20",  // 8 July 2022, 11:20 AM
                "03 Feb 2025 22:10",  // 3 February 2025, 10:10 PM
                "10 Nov 2023 07:30",  // 10 November 2023, 7:30 AM
                "25 Dec 2023 12:00",  // 25 December 2023, 12:00 PM
                "15 Mar 2024 16:55",  // 15 March 2024, 4:55 PM
                "30 Aug 2022 08:05",  // 30 August 2022, 8:05 AM
                "01 Oct 2023 20:15",  // 1 October 2023, 8:15 PM
                "19 Jun 2024 13:40",  // 19 June 2024, 1:40 PM
                "05 Sep 2022 10:25",  // 5 September 2022, 10:25 AM
            };

			Console.WriteLine($"Input Data ({data.Count} items, format: dd MMM yyyy HH:mm):");
			Console.WriteLine("============================================================================================");
			Console.WriteLine("Note: en-GB culture interprets as day month abbreviation year with 24-hour time");
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
