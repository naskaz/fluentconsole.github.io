namespace IntelliDataSort
{
	class TestSpecialCharacters
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("Test 3: Special Characters and Symbols");
			Console.WriteLine("=======================================\n");

			var sorter = new HumanSort();
			var data = new List<string>
						{
								"File_v1.2",
								"File#1",
								"File@Home",
								"File-2024",
								"File+Plus",
								"File(Backup)",
								"File[Temp]",
								"File{Test}",
								"File|Pipe",
								"File\\Backslash",
								"File/Slash",
								"File*Star",
								"File?Question",
								"File!Exclamation",
								"File~Tilde",
								"File`Backtick",
								"File%Percent",
								"File^Caret",
								"File&Ampersand",
								"File=Equal"
						};

			Console.WriteLine("Original order:");
			DisplayList(data);

			Console.WriteLine("\nAscending order:");
			var ascending = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(ascending);

			Console.WriteLine("\nDescending order:");
			var descending = sorter.Sort(data, HumanSort.ColumnType.PlainString, false, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(descending);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayList(IReadOnlyList<string> list)
		{
			foreach (var item in list) Console.WriteLine($"  {item}");
		}
	}
}
