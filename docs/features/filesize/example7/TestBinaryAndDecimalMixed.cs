using System;
using System.Collections.Generic;

namespace IntelliDataSort.Test
{
    class TestBinaryAndDecimalMixed
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TEST 7: BINARY AND DECIMAL UNITS MIXED");
            Console.WriteLine("======================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                // Bytes
                "1023 B",
                "1024 B",      // = 1 KiB

                // Decimal (SI) units
                "1 KB",         // 1,000 B
                "1.024 KB",     // 1,024 B
                "1 MB",         // 1,000,000 B
                "0.5 MB",       // 500,000 B

                // Binary (IEC) units
                "1 KiB",        // 1,024 B
                "2 KiB",        // 2,048 B
                "1 MiB",        // 1,048,576 B
                "0.5 MiB",      // 524,288 B

                // Mixed edge cases
                "1024 KB",      // 1,024,000 B
                "1000 KiB",     // 1,024,000 B → same as above but different meaning!
                "1 GiB",        // 1,073,741,824 B
                "0.1 GiB",      // ~107 MB
                "100 MB",       // 100,000,000 B
                "95.37 MiB",    // ≈100,000,000 B (close to 100 MB)
            };

            Console.WriteLine("Input Data:");
            DisplayList(data);

            Console.WriteLine("\nAscending Sort (smallest to largest):");
            var asc = sorter.Sort(data, HumanSort.ColumnType.FileSize, true, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(asc);

            Console.WriteLine("\nDescending Sort (largest to smallest):");
            var desc = sorter.Sort(data, HumanSort.ColumnType.FileSize, false, HumanSort.NullHandling.NullsFirst, out _);
            DisplayList(desc);

            Console.WriteLine("\n=== TEST COMPLETED ===");
            Console.WriteLine("\n💡 Note: A correct parser should distinguish:");
            Console.WriteLine("   - 1 KB (1,000 B) vs 1 KiB (1,024 B)");
            Console.WriteLine("   - 100 MB (100,000,000 B) vs ~95.37 MiB (same in bytes)");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}