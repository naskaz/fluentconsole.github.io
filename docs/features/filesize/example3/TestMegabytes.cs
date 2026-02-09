using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestMegabytes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 3: MEGABYTES");
            Console.WriteLine("==================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "100 MB", "50 MB", "1 MB", "0.25 MB", "1023 MB", "500 MB", "10.75 MB", "999 MB"
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