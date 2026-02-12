

namespace DateTimeSortingDemoMixedFormats
{
	class DateTimeSortingDemoMixedFormats
	{
		static void Main(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (MIXED DATE FORMATS)");
			Console.WriteLine("=======================================================\n");

			var sorter = new HumanSort();
			var usCulture = new CultureInfo("en-US"); // Month-first
			var ukCulture = new CultureInfo("en-GB"); // Day-first

			// Test data with completely mixed date formats
			var data = new List<string>
						{
                // MMM dd, yyyy (US format with comma)
                "Apr 07, 2023",
								"May 06, 2023",
								"Jan 12, 2024",
                
                // MMMM dd, yyyy (US format with comma, full month)
                "April 07, 2023",
								"July 08, 2022",
								"February 03, 2025",
                
                // dd MMM yyyy (UK format, abbreviated month)
                "07 Apr 2023",
								"06 May 2023",
								"12 Jan 2024",
                
                // dd MMMM yyyy (UK format, full month)
                "08 July 2022",
								"03 February 2025",
								"10 November 2023",
                
                // MMM dd yyyy (US format without comma)
                "Nov 10 2023",
								"Dec 25 2023",
								"Mar 15 2024",
                
                // MMMM dd yyyy (US format without comma, full month)
                "August 30 2022",
								"October 01 2023",
								"June 19 2024",
                
                // dd MMM yyyy HH:mm (UK format with time)
                "05 Sep 2022 10:25",
								"19 Jun 2024 13:40",
								"01 Oct 2023 20:15",
                
                // dd MMMM yyyy HH:mm (UK format with time, full month)
                "05 September 2022 10:25",
								"19 June 2024 13:40",
								"01 October 2023 20:15",
						};

			Console.WriteLine($"Input Data ({data.Count} items - MIXED FORMATS):");
			Console.WriteLine("=======================================================");
			Console.WriteLine("Including: US formats (month-first) and UK formats (day-first)");
			Console.WriteLine("With and without commas, with abbreviations, full months, and time components");
			Console.WriteLine("\nRAW INPUT (UNSORTED):");
			Console.WriteLine("----------------------");

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
					usCulture,
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
					usCulture,
					out var parsedDesc
			);

			DisplaySortedResults(descending, parsedDesc);

			Console.WriteLine("\n\nDATE TIME SORTING DEMO COMPLETE ✓");
			Console.WriteLine("=================================");
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


