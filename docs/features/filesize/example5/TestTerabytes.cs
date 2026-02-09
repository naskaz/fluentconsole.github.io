using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestTerabytes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 5: TERABYTES");
            Console.WriteLine("==================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "100 TB", "50 TB", "1 TB", "0.01 TB", "1023 TB", "500 TB", "10.5 TB", "999 TB"
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