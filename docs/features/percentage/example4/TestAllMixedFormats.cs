using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestAllMixedFormats
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 4: ALL FORMATS MIXED TOGETHER");
            Console.WriteLine("===================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "10%", "25.5 pct", "50 percent", "(15%)", "-30 pct", "(5 percent)",
                "0%", "100 percent", "75 pct", "-5%", "99.99%", "0.01 pct",
                "33.33 percent", "(25 pct)", "-10 percent", "66.66%"
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