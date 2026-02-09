using System;
using System.Collections.Generic;

namespace IntelliDataSort.Test
{
    class TestKoreanWon
    {
        static void Main(string[] args)
        {
            Console.WriteLine("7. KOREAN WON (₩ at START) - Integers Only");
            Console.WriteLine("==========================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "(₩100)", "(₩1,000)", "(₩10,000)",
                "₩0", "₩1", "₩10", "₩50", "₩100", "₩250", "₩500",
                "₩1,000", "₩10,000", "₩100,000", "₩1,000,000"
            };

            Console.WriteLine("Input Data:");
            DisplayList(data);

            Console.WriteLine("\nAscending Sort:");
            var asc = sorter.Sort(data, HumanSort.ColumnType.Currency, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);

            Console.WriteLine("\nDescending Sort:");
            var desc = sorter.Sort(data, HumanSort.ColumnType.Currency, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}