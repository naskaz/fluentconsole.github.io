using System;
using System.Collections.Generic;
using System.Linq;

namespace Test11_ScientificNotation
{
    class Test11_ScientificNotation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 11: SCIENTIFIC NOTATION NUMBERS");
            Console.WriteLine("====================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "1e2", "2.5e1", "3e0", "1.5e-1", "2e-2", "1.23e3", "4.56e-3", "7.89e2", "9.99e-1", "1e-3"
            };

            Console.WriteLine("Input Data:");
            DisplayList(data);

            Console.WriteLine("\nAscending Sort:");
            var asc = sorter.Sort(data, HumanSort.ColumnType.Number, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);
            ValidateOrder(asc, true, "Scientific notation ascending");

            Console.WriteLine("\nDescending Sort:");
            var desc = sorter.Sort(data, HumanSort.ColumnType.Number, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);
            ValidateOrder(desc, false, "Scientific notation descending");

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