using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestAllUnitsMixed
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 6: ALL UNITS MIXED");
            Console.WriteLine("========================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "100 B", "1 KB", "1 MB", "1 GB", "1 TB",
                "1024 B", "1024 KB", "1024 MB", "1024 GB",
                "0.5 MB", "500 KB", "0.1 GB", "10 MB", "0.01 TB"
            };

            Console.WriteLine("Input Data:");
            DisplayList(data);

            Console.WriteLine("\nAscending Sort:");
            var asc = sorter.Sort(data, HumanSort.ColumnType.FileSize, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);

            Console.WriteLine("\nDescending Sort:");
            var desc = sorter.Sort(data, HumanSort.ColumnType.FileSize, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}