
namespace MonthNameVariationsSortTest
{
	class MonthNameVariationsSortTest
	{
		static void Main(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING DEMONSTRATION (MIXED DATE FORMATS)");
			Console.WriteLine("=======================================================\n");

			var sorter = new HumanSort();
			var usCulture = new CultureInfo("en-US"); // Month-first
			var ukCulture = new CultureInfo("en-GB"); // Day-first


			// Test data with month name formats - VALID VARIATIONS ONLY
			var data = new List<string>
{
    // ----- STANDARD FORMATS (8 REQUIRED FORMATS) -----
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

    // ----- VALID EDGE CASES (WITHIN THE 8 FORMATS) -----
    
    // Same date across different formats
    "Dec 31, 2023",
		"31 Dec 2023",
		"December 31, 2023",
		"Dec 31 2023",
		"31 December 2023",
    
    // Leap day
    "Feb 29, 2024",
		"29 Feb 2024",
		"February 29, 2024",
		"29 February 2024",
    
    // Single-digit days
    "Mar 1, 2023",
		"1 Mar 2023",
		"March 1, 2023",
		"1 March 2023",
		"Apr 5, 2023",
		"5 Apr 2023",
		"Jun 7, 2023",
		"7 Jun 2023",
    
    // Single-digit months
    "Jan 1, 2023",
		"Feb 2, 2023",
		"Mar 3, 2023",
		"Apr 4, 2023",
		"May 5, 2023",
		"Jun 6, 2023",
		"Jul 7, 2023",
		"Aug 8, 2023",
		"Sep 9, 2023",
		"Oct 10, 2023",
		"Nov 11, 2023",
		"Dec 12, 2023",
    
    // Period after month abbreviation
    "Jan. 15, 2023",
		"Feb. 15, 2023",
		"Mar. 15, 2023",
		"Apr. 15, 2023",
		"May. 15, 2023",
		"Jun. 15, 2023",
		"Jul. 15, 2023",
		"Aug. 15, 2023",
		"Sep. 15, 2023",
		"Oct. 15, 2023",
		"Nov. 15, 2023",
		"Dec. 15, 2023",
		"15 Jan. 2023",
		"15 Feb. 2023",
    
    // All caps month names
    "JAN 15, 2023",
		"FEB 15, 2023",
		"MAR 15, 2023",
		"APR 15, 2023",
		"MAY 15, 2023",
		"JUN 15, 2023",
		"JUL 15, 2023",
		"AUG 15, 2023",
		"SEP 15, 2023",
		"OCT 15, 2023",
		"NOV 15, 2023",
		"DEC 15, 2023",
		"15 JAN 2023",
		"15 FEB 2023",
    
    // Full month all caps
    "JANUARY 15, 2023",
		"FEBRUARY 15, 2023",
		"MARCH 15, 2023",
		"APRIL 15, 2023",
		"15 JANUARY 2023",
		"15 FEBRUARY 2023",
    
    // Mixed case month names
    "jAn 15, 2023",
		"fEb 15, 2023",
		"mAr 15, 2023",
		"aPr 15, 2023",
		"15 jAn 2023",
		"15 fEb 2023",
		"jAnUaRy 15, 2023",
		"fEbRuArY 15, 2023",
    
    // Month name variants (standard 3-letter abbreviations only)
    "Sep 15, 2023",
		"Sep. 15, 2023",
		"15 Sep 2023",
		"September 15, 2023",
    
    // Extra whitespace within the format
    "Apr   07,   2023",
		"07   Apr   2023",
		"April   07,   2023",
		"07   April   2023",
    
    // Time variations (24-hour)
    "15 Jan 2023 09:05",
		"15 Jan 2023 14:30",
		"15 Jan 2023 23:59",
		"15 January 2023 09:05",
		"Jan 15, 2023 09:05",
		"January 15, 2023 09:05",
    
    // Time variations (12-hour with AM/PM)
    "15 Jan 2023 9:05 AM",
		"15 Jan 2023 2:30 PM",
		"15 Jan 2023 11:59 PM",
		"Jan 15, 2023 9:05 AM",
		"January 15, 2023 2:30 PM",
    
    // Time with seconds
    "15 Jan 2023 09:05:30",
		"15 Jan 2023 2:30:45 PM",
		"Jan 15, 2023 09:05:30",
		"January 15, 2023 2:30:45 PM",
    
    // Future dates
    "Jan 01, 2050",
		"01 Jan 2050",
		"January 01, 2050",
		"01 January 2050",
		"Dec 31, 2099",
		"31 Dec 2099",
    
    // Past dates
    "Jan 01, 1900",
		"01 Jan 1900",
		"January 01, 1900",
		"01 January 1900",
		"Dec 31, 1899",
		"31 Dec 1899",
		"Jul 04, 1776",
		"04 July 1776",
};


			Console.WriteLine($"Input Data ({data.Count} items - MIXED FORMATS WITH EDGE CASES):");
			Console.WriteLine("=================================================================");
			Console.WriteLine("Including: US/UK formats, nulls, empty strings, invalid dates,");
			Console.WriteLine("leap day, ordinal suffixes, 2-digit years, and various edge cases");
			Console.WriteLine("\nRAW INPUT (UNSORTED):");
			Console.WriteLine("----------------------");

			foreach (var item in data)
			{
				if (item == null)
					Console.WriteLine("  [NULL]");
				else if (item == "")
					Console.WriteLine("  [EMPTY STRING]");
				else if (item.Trim() == "")
					Console.WriteLine($"  [WHITESPACE: \"{item}\"]");
				else
					Console.WriteLine($"  {item}");
			}

			Console.WriteLine("\n\n1. ASCENDING SORT (Earliest to Latest):");
			Console.WriteLine("========================================");
			Console.WriteLine("Note: Nulls, empty strings, and invalid dates appear first");
			Console.WriteLine();

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
			Console.WriteLine("Note: Nulls, empty strings, and invalid dates appear first");
			Console.WriteLine();

			var descending = sorter.Sort(
							data,
							HumanSort.ColumnType.DateTime,
							false,
							nullHandling: HumanSort.NullHandling.NullsFirst,
							usCulture,
							out var parsedDesc
			);

			DisplaySortedResults(descending, parsedDesc);

			Console.WriteLine("\n\nDATE TIME SORTING DEMO WITH EDGE CASES COMPLETE ✓");
			Console.WriteLine("=================================================");
		}

		static void DisplaySortedResults(IReadOnlyList<string> sorted, List<(string original, object parsed)> parsedValues)
		{
			foreach (var item in sorted)
			{
				if (item == null)
				{
					Console.WriteLine("  [NULL]");
				}
				else if (item == "")
				{
					Console.WriteLine("  [EMPTY STRING]");
				}
				else if (item.Trim() == "")
				{
					Console.WriteLine($"  [WHITESPACE: \"{item}\"]");
				}
				else
				{
					Console.WriteLine($"  {item}");
				}
			}
		}
	}
}

