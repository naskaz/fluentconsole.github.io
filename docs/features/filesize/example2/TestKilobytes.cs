using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestKilobytes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 2: KILOBYTES");
            Console.WriteLine("==================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "100 KB", "50 KB", "1 KB", "0.5 KB", "1023 KB", "500 KB", "10.5 KB", "999 KB"
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