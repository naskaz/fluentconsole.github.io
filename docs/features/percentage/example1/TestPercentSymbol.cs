using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestPercentSymbol
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 1: % SYMBOL (MIXED DATA)");
            Console.WriteLine("==============================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "10%", "25.5%", "50%", "0%", "100%", "(15%)", "-30%",
                "99.99%", "0.01%", "(5%)", "75%", "-1%", "33.33%", "66.66%"
            };

            Console.WriteLine($"Input Data ({data.Count} items):");
            DisplayList(data);

            Console.WriteLine("\n1. ASCENDING SORT (Smallest to Largest):");
            Console.WriteLine("==========================================");
            var asc = sorter.Sort(data, HumanSort.ColumnType.Percentage, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);

            Console.WriteLine("\n2. DESCENDING SORT (Largest to Smallest):");
            Console.WriteLine("===========================================");
            var desc = sorter.Sort(data, HumanSort.ColumnType.Percentage, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}