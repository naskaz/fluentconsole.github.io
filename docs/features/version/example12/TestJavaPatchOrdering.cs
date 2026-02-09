using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestJavaPatchOrdering
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Java patch ordering ===\n");

            var sorter = new HumanSort();
            var data = new[] { "17.0.8", "17.0.10", "17.0.9" };

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