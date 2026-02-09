using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestLeadingZeros
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Leading Zeros ===\n");

            var sorter = new HumanSort();
            var data = new List<string> { "file001", "file010", "file100", "file2" };

            Console.WriteLine("Original:");
            DisplayList(data);

            Console.WriteLine("\nAscending:");
            var asc = sorter.Sort(data, HumanSort.ColumnType.NaturalString, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);

            Console.WriteLine("\nDescending:");
            var desc = sorter.Sort(data, HumanSort.ColumnType.NaturalString, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}