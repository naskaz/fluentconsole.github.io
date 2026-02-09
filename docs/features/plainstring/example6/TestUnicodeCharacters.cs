namespace IntelliDataSort
{
	class TestUnicodeCharacters
	{
		static void Mains(string[] args)
		{
			Console.WriteLine("Test 6: Unicode and International Characters");
			Console.WriteLine("============================================\n");

			var sorter = new HumanSort();
			var data = new List<string>
						{
								"café", "cafe", "naïve", "naive", "résumé", "resume",
								"Müller", "Mueller", "São Paulo", "Sao Paulo",
								"北京", "東京", "서울", "Δέλτα", "Alpha", "Бета", "Гамма",
								"🎵 Music", "📁 Folder", "🚀 Rocket"
						};

			Console.WriteLine("Original order:");
			DisplayList(data);

			Console.WriteLine("\nSorted order:");
			var sorted = sorter.Sort(data, HumanSort.ColumnType.PlainString, true, HumanSort.NullHandling.NullsFirst, out _);
			DisplayList(sorted);

			Console.WriteLine("\n=== TEST COMPLETED ===");
		}

		static void DisplayList(IReadOnlyList<string> list)
		{
			foreach (var item in list) Console.WriteLine($"  {item}");
		}
	}
}
