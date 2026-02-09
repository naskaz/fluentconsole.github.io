using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestLinuxKernelVersions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Linux kernel versions ===\n");

            var sorter = new HumanSort();
            var data = new[] { "6.6.8", "6.1.55", "5.15.148", "6.6.1", "5.10.201", "6.6.0" };

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