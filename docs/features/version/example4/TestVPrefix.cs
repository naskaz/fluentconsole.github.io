using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestVPrefix
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== v-Prefix Handling ===\n");

            var sorter = new HumanSort();
            var data = new List<string> { "v2.0.0", "v1.2.0", "v1.10.0", "v1.1.0" };

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