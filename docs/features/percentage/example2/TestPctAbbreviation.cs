using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestPctAbbreviation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 2: PCT ABBREVIATION (MIXED DATA)");
            Console.WriteLine("======================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "10 pct", "25.5 pct", "50 pct", "0 pct", "100 pct", "(15 pct)", "-30 pct",
                "99.99 pct", "0.01 pct", "(5 pct)", "75 pct", "-1 pct", "33.33 pct", "66.66 pct"
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