using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestPercentWord
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 3: PERCENT WORD (MIXED DATA)");
            Console.WriteLine("==================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "10 percent", "25.5 percent", "50 percent", "0 percent", "100 percent", "(15 percent)", "-30 percent",
                "99.99 percent", "0.01 percent", "(5 percent)", "75 percent", "-1 percent", "33.33 percent", "66.66 percent"
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