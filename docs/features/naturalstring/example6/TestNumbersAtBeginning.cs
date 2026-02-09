using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestNumbersAtBeginning
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Numbers at beginning ===\n");

            var sorter = new HumanSort();
            var data = new List<string> { "10item", "2item", "1item", "20item" };

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