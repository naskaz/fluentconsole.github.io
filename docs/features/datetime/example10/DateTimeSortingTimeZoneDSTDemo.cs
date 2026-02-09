namespace DateTimeSortingTimeZoneDSTDemo
{
	class DateTimeSortingTimeZoneDSTDemo
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING TIMEZONE/DST TEST");
			Console.WriteLine("=====================================\n");


			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US");



			var data = new List<string>
{
"2023-03-11T23:30:00-05:00",  // 2023-03-12 04:30Z
    "2023-03-12T01:30:00-05:00",  // 2023-03-12 06:30Z
    "2023-03-12T01:59:59-05:00",  // 2023-03-12 06:59:59Z
    "2023-03-12T03:00:00-04:00",  // 2023-03-12 07:00Z
    "2023-03-12T03:30:00-04:00",  // 2023-03-12 07:30Z
    "2023-03-12T03:00:00-05:00",  // 2023-03-12 08:00Z
    "2023-03-13T01:30:00-04:00",  // 2023-03-13 05:30Z
};

			Console.WriteLine($"Input Data ({data.Count} items with timezone offsets):");
			Console.WriteLine("======================================================");
			Console.WriteLine("Note: ISO format with timezone offsets (-05:00 = EST, -04:00 = EDT)");
			Console.WriteLine("March 12, 2023: DST transition in US (2 AM → 3 AM)");
			Console.WriteLine();

			for (int i = 0; i < data.Count; i++)
			{
				Console.WriteLine($"  [{i}] {data[i]}");
			}

			Console.WriteLine("\n\n1. ASCENDING SORT (Should sort by UTC time):");
			Console.WriteLine("==============================================");
			var ascending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			true,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,
			out var parsedAsc
			);

			DisplaySortedResultsWithIndex(ascending, parsedAsc, data);

			Console.WriteLine("\n\n2. DESCENDING SORT:");
			Console.WriteLine("===================");
			var descending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			false,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,
			out var parsedDesc
			);

			DisplaySortedResultsWithIndex(descending, parsedDesc, data);

			Console.WriteLine("\n\nTIMEZONE/DST TEST COMPLETE ✓");
		}

		static void DisplaySortedResultsWithIndex(IReadOnlyList<string> sorted, List<(string original, object parsed)> parsedValues, List<string> original)
		{
			Console.WriteLine("Sorted results (stable sort should preserve original order of identical items):");
			Console.WriteLine("------------------------------------------------------------------------------");

			var itemOccurrences = new Dictionary<string, Queue<int>>();

			// Build occurrence queues
			for (int i = 0; i < original.Count; i++)
			{
				string item = original[i];
				if (!itemOccurrences.ContainsKey(item))
					itemOccurrences[item] = new Queue<int>();
				itemOccurrences[item].Enqueue(i);
			}

			// Display with original indices
			for (int i = 0; i < sorted.Count; i++)
			{
				string currentItem = sorted[i];
				int originalIndex = itemOccurrences[currentItem].Dequeue();
				Console.WriteLine($"  [{i}] {currentItem} (was at index {originalIndex} in input)");
			}
		}
	}

}
