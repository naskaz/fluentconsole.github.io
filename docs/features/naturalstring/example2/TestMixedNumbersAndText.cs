using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestMixedNumbersAndText
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Mixed Numbers and Text ===\n");

            var sorter = new HumanSort();
            var data = new List<string> { "text10", "text2", "text1", "text20" };

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