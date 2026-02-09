namespace DateTimeSortingInvalidInputsDemo
{
	class DateTimeSortingInvalidInputsDemo
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING - INVALID BUT PLAUSIBLE INPUTS TEST");
			Console.WriteLine("========================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US");


			//			var data = new List<string>
			//{
			//    // Invalid dates/times (from your original test)
			//    "2023-02-30",
			//		"2023-04-31",
			//		"2023-06-31",
			//		"2023-09-31",
			//		"2023-11-31",
			//		"2023-13-15",
			//		"2023-00-15",
			//		"2023-05-00",
			//		"2023-05-32",
			//		"2023-02-29",
			//		"2024-02-30",
			//		"2023-06-31 14:30:00",
			//		"99:99:99",
			//		"25:00:00",
			//		"14:61:00",
			//		"14:30:61",
			//		"14:30:00 99",
			//		"2:30:99 PM",           

			//    // Valid dates/times (added)
			//    "2023-01-15",           // valid date
			//    "2023-03-10",           // valid date
			//    "2024-02-29",           // leap year valid date
			//    "2023-06-30 14:30:00",  // valid datetime
			//    "12:45:30",             // valid time
			//    "2:30:00 PM",            // valid 12-hour time
			//};


			var data = new List<string>
{
    // Invalid dates/times (from your original test)
    "2023-02-30",
		"2023-04-31",
		"2023-06-31",
		"2023-09-31",
		"2023-11-31",
		"2023-13-15",
		"2023-00-15",
		"2023-05-00",
		"2023-05-32",
		"2023-02-29",
		"2024-02-30",
		"2023-06-31 14:30:00",
		"99:99:99",
		"25:00:00",
		"14:61:00",
		"14:30:61",
		"14:30:00 99",
		"2:30:99 PM",           

    // Valid dates/times
    "2023-01-15",           // valid date
    "2023-03-10",           // valid date
    "2024-02-29",           // leap year valid date
    "2023-06-30 14:30:00",  // valid datetime
    "12:45:30",             // valid time
    "2:30:00 PM",           // valid 12-hour time

    // Valid with time zones
    "2023-06-30T14:30:00+05:30", // ISO 8601 with IST offset
    "2023-06-30T14:30:00Z",      // UTC
    "2023-06-30T14:30:00-04:00", // EDT offset

    // Invalid with time zones
    "2023-06-30T25:00:00+02:00", // invalid hour
    "2023-06-31T14:30:00+05:30", // invalid date
    "2023-06-30T14:30:00+99:99", // invalid offset

		"2023-06-30T14:30:00.123Z",


		"2023-06-30T14:30:00.1Z",
"2023-06-30T14:30:00.12Z",
"2023-06-30T14:30:00.123Z",
"2023-06-30T14:30:00.123456Z",
"2023-06-30T14:30:00.1234567Z",
"2023-06-30T14:30:00.12345678Z"



};




			Console.WriteLine($"Input Data ({data.Count} items with invalid but plausible date/time):");
			Console.WriteLine("======================================================================");
			Console.WriteLine("Note: These look like dates/times but are invalid");
			Console.WriteLine();

			for (int i = 0; i < data.Count; i++)
			{
				Console.WriteLine($"  [{i}] {data[i]}");
			}

			Console.WriteLine("\n\n1. ASCENDING SORT (Invalid dates should fall to end):");
			Console.WriteLine("==========================================================");
			var ascending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			true,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,
			out var parsedAsc
			);

			DisplaySortedResultsWithValidity(ascending, parsedAsc, data);

			Console.WriteLine("\n\n2. DESCENDING SORT (Invalid dates should fall to beginning):");
			Console.WriteLine("==============================================================");
			var descending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			false,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,
			out var parsedDesc
			);

			DisplaySortedResultsWithValidity(descending, parsedDesc, data);

			Console.WriteLine("\n\nINVALID INPUTS TEST COMPLETE ✓");
		}

		static void DisplaySortedResultsWithValidity(IReadOnlyList<string> sorted, List<(string original, object parsed)> parsedValues, List<string> original)
		{
			Console.WriteLine("Sorted results with parsing status:");
			Console.WriteLine("(Invalid dates should be sorted as strings at the end/bottom)");
			Console.WriteLine("----------------------------------------------------------------");

			var itemOccurrences = new Dictionary<string, Queue<int>>();

			// Build occurrence queues
			for (int i = 0; i < original.Count; i++)
			{
				string item = original[i];
				if (!itemOccurrences.ContainsKey(item))
					itemOccurrences[item] = new Queue<int>();
				itemOccurrences[item].Enqueue(i);
			}

			// Display with original indices and parse status
			for (int i = 0; i < sorted.Count; i++)
			{
				string currentItem = sorted[i];
				int originalIndex = itemOccurrences[currentItem].Dequeue();

				// Check if this item was parsed successfully
				var parsedItem = parsedValues.FirstOrDefault(p => p.original == currentItem);
				bool isValid = parsedItem.parsed != null;

				Console.WriteLine($"  [{i}] {currentItem} " +
				$"(was at index {originalIndex} in input) " +
				$"{(isValid ? "✓ VALID" : "✗ INVALID")}");
			}
		}
	}

}