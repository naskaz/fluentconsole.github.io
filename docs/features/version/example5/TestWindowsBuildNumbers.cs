using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestWindowsBuildNumbers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Windows versions - build number ordering ===\n");

            var sorter = new HumanSort();
            var data = new[]
            {
                "10.0.19045.4046",
                "10.0.19045.3031",
                "10.0.22621.2506",
                "10.0.22621.1702",
                "6.3.9600.20470",
                "6.3.9600.16384",
                "6.1.7601.24545",
                "6.1.7601.17514"
            };

            Console.WriteLine("Input:");
            DisplayList(data);

            Console.WriteLine("\nAscending:");
            var asc = sorter.Sort(data, HumanSort.ColumnType.Version, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);

            Console.WriteLine("\nDescending:");
            var desc = sorter.Sort(data, HumanSort.ColumnType.Version, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}