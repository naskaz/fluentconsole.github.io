using System;
using System.Collections.Generic;

namespace IntelliDataSort.Test
{
    class TestPolishZloty
    {
        static void Main(string[] args)
        {
            Console.WriteLine("10. POLISH ZŁOTY (zł at START) - With Decimals");
            Console.WriteLine("==============================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "(zł100.00)", "(zł1,000.00)", "(zł10,000.00)",
                "zł0.00", "zł1.00", "zł10.00", "zł50.00",
                "zł100.00", "zł250.00", "zł500.00",
                "zł1,000.00", "zł5,000.00",
                "zł10,000.00", "zł100,000.00", "zł1,000,000.00"
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