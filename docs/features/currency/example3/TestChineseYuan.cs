using System;
using System.Collections.Generic;

namespace IntelliDataSort.Test
{
    class TestChineseYuan
    {
        static void Main(string[] args)
        {
            Console.WriteLine("3. CHINESE YUAN (¥ at START) - With Decimals");
            Console.WriteLine("============================================\n");

            var sorter = new HumanSort();
            var data = new List<string>
            {
                "(¥100.00)", "(¥1,000.00)", "(¥10,000.00)",
                "¥0.00", "¥1.00", "¥10.00", "¥50.00",
                "¥100.00", "¥250.00", "¥500.00",
                "¥1,000.00", "¥5,000.00",
                "¥10,000.00", "¥100,000.00", "¥1,000,000.00"
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
            Console.WriteLine("\n💡 Note: Chinese Yuan (CNY) uses ¥ symbol and supports decimals.");
            Console.WriteLine("   Distinct from Japanese Yen (JPY), which typically has no decimals.");
        }

        static void DisplayList(IReadOnlyList<string> list)
        {
            foreach (var item in list) Console.WriteLine($"  {item}");
        }
    }
}