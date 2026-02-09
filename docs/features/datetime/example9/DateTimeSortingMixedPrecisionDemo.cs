namespace DateTimeSortingMixedPrecisionDemo
{
	class DateTimeSortingMixedPrecisionDemo
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING MIXED PRECISION TEST");
			Console.WriteLine("========================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US");

			// Test data with mixed precision (with/without seconds)
			var data = new List<string>
{
"07/04/2023 2:30 PM",      // No seconds
                "07/04/2023 2:30:45 PM",   // With seconds
                "07/04/2023 2:30:15 PM",   // With seconds, different value
                "07/04/2023 2:30 PM",      // No seconds (again)
                "07/04/2023 12:00 PM",     // Noon, no seconds
                "07/04/2023 12:00:30 PM",  // Noon, with seconds
                "07/04/2023 12:00:00 PM",  // Noon, zero seconds
                "06/05/2023 2:30 PM",      // Different day, no seconds
                "06/05/2023 2:30:01 PM",   // Different day, with seconds
            };

			Console.WriteLine($"Input Data ({data.Count} items with mixed precision):");
			Console.WriteLine("======================================================");
			Console.WriteLine("Note: Some have seconds, some don't");
			Console.WriteLine();

			for (int i = 0; i < data.Count; i++)
			{
				Console.WriteLine($"  [{i}] {data[i]}");
			}

			Console.WriteLine("\n\n1. ASCENDING SORT (Should treat missing seconds as 00):");
			Console.WriteLine("========================================================");
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

			Console.WriteLine("\n\nMIXED PRECISION TEST COMPLETE ✓");
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
