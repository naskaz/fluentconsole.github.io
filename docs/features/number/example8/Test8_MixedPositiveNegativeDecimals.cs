using System;
using System.Collections.Generic;
using System.Linq;

namespace Test8_MixedPositiveNegativeDecimals
{
    class Test8_MixedPositiveNegativeDecimals
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 8: MIXED POSITIVE/NEGATIVE DECIMALS");
            Console.WriteLine("==========================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "100.5", "-25.25", "50.75", "0.0", "-1.123", "999.99", "-42.42", "7.777", "-1000.001", "500.555"
            };

            Console.WriteLine("Input Data:");
            DisplayList(data);

            Console.WriteLine("\nAscending Sort:");
            var asc = sorter.Sort(data, HumanSort.ColumnType.Number, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);
            ValidateOrder(asc, true, "Mixed decimals ascending");

            Console.WriteLine("\nDescending Sort:");
            var desc = sorter.Sort(data, HumanSort.ColumnType.Number, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);
            ValidateOrder(desc, false, "Mixed decimals descending");

            Console.WriteLine("\n=== TEST COMPLETED ===");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list)
                Console.WriteLine($"  {item}");
        }

        static void ValidateOrder(IReadOnlyList<string> sorted, bool ascending, string testName)
        {
            try
            {
                var values = sorted.Select(double.Parse).ToList();
                bool valid = true;
                for (int i = 0; i < values.Count - 1; i++)
                {
                    if (ascending && values[i] > values[i + 1])
                    { valid = false; break; }
                    if (!ascending && values[i] < values[i + 1])
                    { valid = false; break; }
                }
                Console.WriteLine($"\n{(valid ? "✓" : "✗")} {testName}: {(valid ? "PASSED" : "FAILED")}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ {testName}: ERROR - {ex.Message}");
            }
        }
    }
}