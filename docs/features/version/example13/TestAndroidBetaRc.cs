using System;
using System.Collections.Generic;

namespace IntelliDataSort
{
    class TestAndroidBetaRc
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Android versions - beta / rc ordering ===\n");

            var sorter = new HumanSort();
            var data = new[]
            {
                "v14.0.0", "v14.0.0-beta.1", "v14.0.0-beta.2", "v14.0.0-rc.1",
                "v13.0.0", "v13.0.0-beta.5", "v13.0.0-rc.2", "v12.1.0"
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