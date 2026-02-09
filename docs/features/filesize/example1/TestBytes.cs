using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestBytes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 1: BYTES");
            Console.WriteLine("==============\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "100 B", "50 B", "1 B", "0 B", "1023 B", "500 B", "10 B", "999 B"
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