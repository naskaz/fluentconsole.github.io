using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestGigabytes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 4: GIGABYTES");
            Console.WriteLine("==================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "100 GB", "50 GB", "1 GB", "0.1 GB", "1023 GB", "500 GB", "10.25 GB", "999 GB"
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