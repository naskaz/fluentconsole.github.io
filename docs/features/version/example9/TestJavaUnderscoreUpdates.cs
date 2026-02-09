using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestJavaUnderscoreUpdates
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Java versions - underscore update numbers ===\n");

            var sorter = new HumanSort();
            var data = new[]
            {
                "1.8.0_45", "1.8.0_202", "1.8.0_301", "1.8.0_11",
                "1.8.0_361", "11.0.2", "11.0.16", "17.0.1", "17.0.8"
            };

            Console.WriteLine("Input:");
            DisplayList(data);

            Console.WriteLine("\nAscending:");
            var asc = sorter.Sort(data, HumanSort.ColumnType.Version, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);

            Console.WriteLine("\nDescending:");
            var desc = sorter.Sort(data, HumanSort.ColumnType.Version, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}