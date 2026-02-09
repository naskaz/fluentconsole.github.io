using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestMacOSVersions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== macOS versions ===\n");

            var sorter = new HumanSort();
            var data = new[] { "13.6.3", "14.2", "12.7.2", "14.1", "13.0", "14.2.1" };

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