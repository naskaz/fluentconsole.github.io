using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestYearMonthPatterns
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Year-Month Patterns ===\n");

            var sorter = new HumanSort();
            var data = new List<string> { "2023-09", "2023-01", "2024-01", "2023-12" };

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