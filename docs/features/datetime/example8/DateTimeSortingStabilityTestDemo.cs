namespace DateTimeSortingStabilityTestDemo
{
	class DateTimeSortingStabilityTestDemo
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("DATE TIME SORTING STABILITY TEST (Identical Timestamps)");
			Console.WriteLine("=========================================================\n");

			var sorter = new HumanSort();
			var culture = new CultureInfo("en-US");

			// Test data with identical timestamps
			var data = new List<string>
{
"07/04/2023 2:30:45 PM",   // First occurrence
                "07/04/2023 9:15:30 AM",   //
                "07/04/2023 2:30:45 PM",   // Identical to first - same text
                "07/04/2023 2:30:45 PM",   // Third identical - same text
                "06/05/2023 2:30:45 PM",   // Different date
                "07/04/2023 2:30:45 PM",   // Fourth identical - same text
                "06/05/2023 2:30:45 PM",   // Identical to other date
            };

			Console.WriteLine($"Input Data ({data.Count} items with identical timestamps):");
			Console.WriteLine("==========================================================");
			Console.WriteLine("Note: Testing stable sort with identical values");
			Console.WriteLine();

			for (int i = 0; i < data.Count; i++)
			{
				Console.WriteLine($"  [{i}] {data[i]}");
			}

			Console.WriteLine("\n\n1. ASCENDING SORT (Check stability - input order preserved):");
			Console.WriteLine("=============================================================");
			var ascending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			true,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,
			out var parsedAsc
			);

			DisplaySortedResultsWithIndex(ascending, parsedAsc, data);

			Console.WriteLine("\n\n2. DESCENDING SORT (Check stability - input order preserved):");
			Console.WriteLine("===============================================================");
			var descending = sorter.Sort(
			data,
			HumanSort.ColumnType.DateTime,
			false,
			nullHandling: HumanSort.NullHandling.NullsFirst,
			culture,
			out var parsedDesc
			);

			DisplaySortedResultsWithIndex(descending, parsedDesc, data);

			Console.WriteLine("\n\nSTABILITY TEST COMPLETE ✓");
		}

		static void DisplaySortedResultsWithIndex(IReadOnlyList<string> sorted, List<(string original, object parsed)> parsedValues, List<string> original)
		{
			Console.WriteLine("Sorted results (stable sort should preserve original order of identical items):");
			Console.WriteLine("------------------------------------------------------------------------------");

			// Since we can't get original indices from sorted list directly,
			// and parsedValues is in input order, not sorted order,
			// we'll use the occurrence tracking method

			var itemOccurrences = new Dictionary<string, Queue<int>>();

			// Build occurrence queues
			for (int i = 0; i < original.Count; i++)
			{
				string item = original[i];
				if (!itemOccurrences.ContainsKey(item))
					itemOccurrences[item] = new Queue<int>();
				itemOccurrences[item].Enqueue(i);
			}

			// Now display with correct original indices
			for (int i = 0; i < sorted.Count; i++)
			{
				string currentItem = sorted[i];
				int originalIndex = itemOccurrences[currentItem].Dequeue();
				Console.WriteLine($"  [{i}] {currentItem} (was at index {originalIndex} in input)");
			}
		}
	}

}