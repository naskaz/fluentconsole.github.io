using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestWindowsServerVersions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Windows Server versions ===\n");

            var sorter = new HumanSort();
            var data = new[]
            {
                "10.0.20348.2402",
                "10.0.17763.5329",
                "10.0.14393.6930",
                "10.0.17763.3887"
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