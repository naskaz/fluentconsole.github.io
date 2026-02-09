using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestIOSVersions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== iOS versions ===\n");

            var sorter = new HumanSort();
            var data = new[] { "17.2.1", "16.7.4", "17.1", "15.8", "17.0.3", "16.6" };

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